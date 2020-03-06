using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class MSException : Exception
    {
        public List<Error> Errors { get; private set; }

        public MSException(List<Error> errors) 
        {
            this.Errors = errors;
        }

        public MSException(string message) : base(message) { }
        public MSException(string message, Exception inner) : base(message, inner) { }
        protected MSException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
