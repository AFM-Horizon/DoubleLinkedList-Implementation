using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListClassRewrite
{
    /// <summary>
    /// An <see cref="EmptyListException"/> should be thrown where an empty list is accessed by an invalid method.  
    /// </summary>
    public class EmptyListException : Exception
    {
        /// <summary>
        /// Throws an <see cref="EmptyListException"/>.
        /// </summary>
        public EmptyListException() : base()
        {
        }

        /// <summary>
        /// Throws an <see cref="EmptyListException"/> with a user specified error <paramref name="message"/>.
        /// </summary>
        /// <param name="message"></param>
        public EmptyListException(string message) : base(message)
        {
        }

        /// <summary>
        /// Throws an <see cref="EmptyListException"/> with a user specified error <paramref name="message"/> and the <paramref name="innerException"/> that caused
        /// caused the exception.  
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public EmptyListException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
