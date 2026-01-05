using Filminurk.Core.Domain;
using Filminurk.Core.Dto;
using Filminurk.Core.ServiceInterface;
using Filminurk.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.ApplicationServices.Services
{
    public class FileServices : IFilesServices
    {
        private readonly IHostEnvironment _webhost;
        private readonly FilminurkTARpe24Context _context;

        public FileServices(IHostEnvironment webhost, FilminurkTARpe24Context context)
        {
            _webhost = webhost;
            _context = context;
        }



        public void FilesToApi(MoviesDTO dto, Movie domain)
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
                        _context.FilesToApi.AddAsync(path);
                    }
                }
            }
        }

        public async Task<FileToApi> RemoveImageFromApi(FileToApiDTO dto)
        {
            var imageID = await _context.FilesToApi.FirstOrDefaultAsync(x => x.ImageID == dto.ImageID);

            var filePath = _webhost.ContentRootPath + "\\wwwroot\\multipleFileUpload" + imageID.ExistingFilepath;
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            _context.FilesToApi.Remove(imageID);
            await _context.SaveChangesAsync();

            return null;
        }
        public async Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDTO[] dtos)
        {
            foreach (var dto in dtos)
            {
                RemoveImageFromApi(dto);
            }
            return null;
        }
    }
}


