using Common;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class BaseService
    {
        private List<Error> errors = new List<Error>();

        protected void AddError(string fieldname, string message) 
        {
            errors.Add(new Error() {FieldName = fieldname, Message = message});
        }

        protected void CheckErros() 
        {
            if (errors.Count > 0)
            {
                throw new MSException(errors);
            }
        }
    }
}
