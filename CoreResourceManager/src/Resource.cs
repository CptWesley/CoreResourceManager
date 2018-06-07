using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using CoreResourceManager.Exceptions;

namespace CoreResourceManager
{
    /// <summary>
    /// Static class used to retrieve project resources.
    /// </summary>
    public static class Resource
    {
        /// <summary>
        /// Gets stream of the resource with a certain name.
        /// </summary>
        /// <param name="name">Name of the resource to retrieve.</param>
        /// <returns>The stream to the resource.</returns>
        /// <exception cref="ResourceDoesNotExistException">Thrown when a resource does not exist.</exception>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Stream Get(string name) => GetStream(Assembly.GetCallingAssembly(), FixPath(name));

        /// <summary>
        /// Gets the names of all available resources.
        /// </summary>
        /// <returns>An array with the names of all found resources.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string[] GetNames() => GetNames(Assembly.GetCallingAssembly(), string.Empty);

        /// <summary>
        /// Gets the names of all available resources in a subfolder.
        /// </summary>
        /// <param name="path">Path of the resource subfolder to check in.</param>
        /// <returns>An array with the names of all found resources.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string[] GetNames(string path) => GetNames(Assembly.GetCallingAssembly(), FixPath(path));

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

        /// <summary>
        /// Gets the names of all available resources at a certain path
        /// in a specified assembly.
        /// </summary>
        /// <param name="assembly">The assembly to look in.</param>
        /// <param name="path">The path to look in.</param>
        /// <returns>An array of paths to found resources.</returns>
        private static string[] GetNames(Assembly assembly, string path)
        {
            string[] names = assembly.GetManifestResourceNames();
            string head = $"{assembly.GetName().Name}.Resources.{path}";

            if (!string.IsNullOrEmpty(path))
            {
                head += '.';
            }

            IEnumerable<string> resources = names.Where(
                x => x.Length > head.Length &&
                x.Substring(0, head.Length) == head);
            return resources.Select(x => x.Replace(head, string.Empty)).ToArray();
        }

        /// <summary>
        /// Fixes a path to a resource or subfolder.
        /// </summary>
        /// <param name="path">The path to fix.</param>
        /// <returns>A version of the path with general directory characters replaced with '.'.</returns>
        private static string FixPath(string path) => path.Replace('/', '.').Replace('\\', '.').Trim('.');
    }
}
