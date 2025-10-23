using Filminurk.Core.Domain;
using Filminurk.Core.Dto;
using Filminurk.Data;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly IHostEnvironment _webhost;
        private readonly FilminurkTarpe24Context _context;

        public FileServices(IHostEnvironment webhost, FilminurkTarpe24Context context)
        {
            _webhost = webhost;
            _context = context;
        }
        public void FileUpload(MoviesDTO dto, Movie domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                if (!Directory.Exists(_webhost.ContentRootPath + "\\wwwroot\\multipleFileUpload\\"))
                {
                    Directory.CreateDirectory(_webhost.ContentRootPath + "\\wwwroot\\multipleFileUpload\\");
                }

                foreach (var file in dto.Files)
                {
                    string uploadsFolder = Path.Combine(_webhost.ContentRootPath, "wwwroot", "multipleFileUpload");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                        FileToApi path = new FileToApi
                        {
                            ImageID = Guid.NewGuid(),
                            ExistingFilepath = uniqueFileName,
                            MovieID = domain.Id,
                           
                        };
                        _context.FileToApis.AddAsync(path);
                    }
                }
            }
        }
    }
}
