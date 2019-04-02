using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Fit4You.Core.Utilities
{
    public class FileHelper : IFileHelper
    {
        public void SaveMailLocalCopy(string to, string body)
        {
            var dir = @"C:/temp/smtp-spool";
            var guid = Guid.NewGuid().ToString();
            var email = to.ToString();
            var mailOwner = email.Substring(0, email.IndexOf('@'));

            var filename = $"email_{guid}_{mailOwner}.htm";

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            File.WriteAllText($@"{dir}/{filename}", body, Encoding.UTF8);
        }
    }
}
