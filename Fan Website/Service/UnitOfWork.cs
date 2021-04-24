using Fan_Website.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Service
{
    public class UnitOfWork : IUnitOfWork
    {

        private IHostingEnvironment hostingEnvironment; 

        public UnitOfWork(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment; 
        }
        public async void UploadImage(IFormFile file)
        {
            if (file != null)
            {
                long totalBytes = file.Length;
                string fileName = file.FileName.Trim('"');
                fileName = EnsureFileName(fileName);

                byte[] buffer = new byte[16 * 1024];
                using (FileStream output = File.Create(GetPathAndFileName(fileName)))
                {
                    using (Stream input = file.OpenReadStream())
                    {
                        int readBytes;
                        while ((readBytes = input.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            await output.WriteAsync(buffer, 0, readBytes);
                            totalBytes += readBytes;
                        }
                    }
                }
            }
            
            
        }

        private string GetPathAndFileName(object filename)
        {
            string path = hostingEnvironment.WebRootPath + "\\images\\"; 
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path + filename;
        }

        private string EnsureFileName(string fileName)
        {
            if (fileName.Contains("\\"))
            {
                fileName = fileName.Substring(fileName.LastIndexOf("\\") + 1); 

            }
            return fileName; 
        } 
    }
}
