using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Error
    {
        public string Message { get; set; }
        public string FieldName { get; set; }

        public Error()
        {

        }

        public Error(string message, string fieldName)
        {
            this.Message = message;
            this.FieldName = fieldName;
        }
    }
}
