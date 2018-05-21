using System.IO;
using System.Reflection;
using CoreResourceManager.Exceptions;

namespace CoreResourceManager
{
    /// <summary>
    /// Static class used to retrieve project resources.
    /// </summary>
    public static class Resources
    {
        /// <summary>
        /// Gets stream of the resource with a certain name.
        /// </summary>
        /// <param name="name">Name of the resource to retrieve.</param>
        /// <returns>The stream to the resource.</returns>
        /// <exception cref="ResourceDoesNotExistException">Thrown when a resource does not exist.</exception>
        public static Stream Get(string name)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            return GetStream(assembly, name);
        }

        /// <summary>
        /// Gets the names of all available resources.
        /// </summary>
        /// <returns>An array with the names of all found resources.</returns>
        public static string[] GetNames()
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            string assemblyName = assembly.GetName().Name;
            string[] names = assembly.GetManifestResourceNames();

            for (int i = 0; i < names.Length; ++i)
            {
                names[i] = names[i].Replace($"{assemblyName}.Resources.", string.Empty);
            }

            return names;
        }

        /// <summary>
        /// Gets stream of the resource with a certain name in an assembly.
        /// </summary>
        /// <param name="assembly">Name of the resource to retrieve.</param>
        /// <param name="name">Name of the resource to retrieve the stream for.</param>
        /// <returns>The stream to the resource.</returns>
        /// <exception cref="ResourceDoesNotExistException">Thrown when a resource does not exist.</exception>
        private static Stream GetStream(Assembly assembly, string name)
        {
            string assemblyName = assembly.GetName().Name;
            Stream result = assembly.GetManifestResourceStream($"{assemblyName}.Resources.{name}");
            if (result == null)
            {
                throw new ResourceDoesNotExistException();
            }

            return result;
        }
    }
}
