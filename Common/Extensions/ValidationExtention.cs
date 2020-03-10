using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Extensions
{
    public static class ValidationExtension
    {
        public static void ThrowExceptionIfFail(this ValidationResult result)
        {
            if (result.IsValid)
            {
                return;
            }
            else
            {
                List<Error> errors = new List<Error>();
                foreach (var erro in result.Errors)
                {
                    Error er = new Error(erro.ErrorMessage, erro.PropertyName);
                    errors.Add(er);
                }
                throw new MSException(errors);
            }
        }
    }
}
