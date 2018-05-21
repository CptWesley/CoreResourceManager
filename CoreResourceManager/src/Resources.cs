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
            Stream result = assembly.GetManifestResourceStream(name);

            if (result == null)
            {
                throw new ResourceDoesNotExistException();
            }

            return result;
        }
    }
}
