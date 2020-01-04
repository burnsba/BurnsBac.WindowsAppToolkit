using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using BurnsBac.WindowsAppToolkit.Error;
using BurnsBac.WindowsAppToolkit.HotConfig.DataSource;

namespace BurnsBac.WindowsAppToolkit.HotConfig
{
    /// <summary>
    /// Core of this library. Instantiates correct hw/ui types from skin xml. Resolves
    /// data sources from skin config json.
    /// </summary>
    public static class TypeResolver
    {
        /// <summary>
        /// List of types of known config data providers.
        /// </summary>
        private static List<Type> _configDataProviderTypes = new List<Type>();

        /// <summary>
        /// Whether or not data providers have already been loaded.
        /// </summary>
        private static bool _configDataProvidersLoaded = false;

        /// <summary>
        /// Gets or sets directory to load assemblies containg data providers from.
        /// </summary>
        public static string ConfigDataProvidersDirectory { get; set; }

        /// <summary>
        /// Resolves type name and assembly name to a type from the list
        /// of known data provider types.
        /// </summary>
        /// <param name="shortTypeName">Type name without assembly or version.</param>
        /// <param name="assemblyName">Name of hosting assembly.</param>
        /// <returns>Type. First() is called, so this will throw an exception if not found.</returns>
        public static Type GetConfigDataProviderType(string shortTypeName, string assemblyName)
        {
            LoadConfigDataProviders();

            return _configDataProviderTypes
                .Where(x =>
                    x.Assembly.FullName.IndexOf(assemblyName, 0, StringComparison.OrdinalIgnoreCase) >= 0
                    && x.FullName.IndexOf(shortTypeName, 0, StringComparison.OrdinalIgnoreCase) >= 0)
                .First();
        }

        /// <summary>
        /// Creates instance of skin data providor source.
        /// </summary>
        /// <param name="shortTypeName">Type name without assembly or version.</param>
        /// <param name="assemblyName">Name of hosting assembly.</param>
        /// <returns>New instance of data providor.</returns>
        public static IConfigDataProvider CreateConfigDataProviderInstance(string shortTypeName, string assemblyName)
        {
            LoadConfigDataProviders();

            var type = GetConfigDataProviderType(shortTypeName, assemblyName);
            return (IConfigDataProvider)Activator.CreateInstance(type);
        }

        /// <summary>
        /// Loads assemblies from specified directory. Looks for items of type <see cref="IConfigDataProvider"/>.
        /// This can only be performed once.
        /// </summary>
        private static void LoadConfigDataProviders()
        {
            if (_configDataProvidersLoaded)
            {
                return;
            }

            // Need an absolute path to iterate over the sub directories
            var directory = Path.GetFullPath(ConfigDataProvidersDirectory);

            if (string.IsNullOrEmpty(directory))
            {
                throw new ArgumentNullException($"{nameof(ConfigDataProvidersDirectory)}");
            }

            if (!Directory.Exists(directory))
            {
                throw new InvalidOperationException($"Missing config data providers directory: {directory}");
            }

            var files = Directory.EnumerateFiles(directory);

            foreach (var file in files)
            {
                if (!file.EndsWith(".dll"))
                {
                    continue;
                }

                var dllPath = Path.Combine(directory, file);
                Assembly assembly = null;

                try
                {
                    assembly = Assembly.LoadFrom(dllPath);
                }
                catch (System.IO.FileLoadException)
                {
                    System.Diagnostics.Debug.WriteLine($"The assembly {dllPath} has already been loaded.");
                    continue;
                }
                catch (System.BadImageFormatException)
                {
                    System.Diagnostics.Debug.WriteLine($"The file {dllPath} is not an assembly.");
                    continue;
                }
                catch
                {
                    throw;
                }

                var types = assembly.GetTypes();

                foreach (var type in types)
                {
                    if (typeof(IConfigDataProvider).IsAssignableFrom(type))
                    {
                        _configDataProviderTypes.Add(type);
                    }
                }
            }

            _configDataProvidersLoaded = true;
        }
    }
}
