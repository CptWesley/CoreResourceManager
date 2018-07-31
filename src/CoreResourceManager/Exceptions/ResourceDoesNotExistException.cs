using System;

namespace CoreResourceManager.Exceptions
{
    /// <summary>
    /// Exception thrown when the stream does not represent an image.
    /// </summary>
    /// <seealso cref="Exception" />
    public class ResourceDoesNotExistException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceDoesNotExistException"/> class.
        /// </summary>
        public ResourceDoesNotExistException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceDoesNotExistException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public ResourceDoesNotExistException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceDoesNotExistException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ResourceDoesNotExistException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
