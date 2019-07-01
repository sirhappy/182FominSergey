using System;
using System.Runtime.Serialization;

namespace CWLibrary
{
    [Serializable]
    public class SerializeException : Exception
    {
        public SerializeException() : base("Не удалось сериализовать словарь!")
        {
        }

        public SerializeException(string message) : base(message)
        {
        }

        public SerializeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SerializeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}