using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common.Extensions
{
    public static class EmailValidatorStringExtenstion
    {
       public static bool IsValidEmail(this string email)
       {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch (Exception)
            {
               throw new Exception("Email inválido.");
            }
       }
    }
}
