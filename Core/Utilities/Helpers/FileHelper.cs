using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            string root = Environment.CurrentDirectory + "\\wwwroot\\images\\";

            if (file != null)
            {

                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                    
                string extension = Path.GetExtension(file.FileName);

                string guid = Guid.NewGuid().ToString();

                string path = extension + guid;

                using (FileStream fileStream = File.Create(root + path))
                {
                    file.CopyTo(fileStream);
                    return path;
                }

            }

            return null;


        }
    }
}
