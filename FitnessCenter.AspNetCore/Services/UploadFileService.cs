using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace FitnessCenter.AspNetCore.Services
{
    public class UploadFileService
    {
        private readonly IWebHostEnvironment _appEnvironment;

        public UploadFileService(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public async Task<bool> UploadFileAsync(IFormFile uploadedFile, string savePath)
        {
            if (uploadedFile != null)
            {
                if (!string.IsNullOrEmpty(uploadedFile.FileName))
                {
                    if (!Directory.Exists($"{_appEnvironment.WebRootPath}/{savePath}"))
                    {
                        Directory.CreateDirectory($"{_appEnvironment.WebRootPath}/{savePath}");
                    }

                    savePath += "/" + uploadedFile.FileName;

                    if (!File.Exists(_appEnvironment.WebRootPath + "/" + savePath))
                    {
                        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + "/" + savePath, FileMode.Create))
                        {
                            await uploadedFile.CopyToAsync(fileStream);

                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public async Task<bool> UploadFilesAsync(List<IFormFile> uploadedFiles, string savePath)
        {
            if(uploadedFiles != null)
            {
                foreach(var file in uploadedFiles)
                {
                    if (!string.IsNullOrEmpty(file.FileName))
                    {
                        var path = savePath + "/" + file.FileName;

                        if (!Directory.Exists($"{_appEnvironment.WebRootPath}/{savePath}"))
                        {
                            Directory.CreateDirectory($"{_appEnvironment.WebRootPath}/{savePath}");
                        }

                        if (!File.Exists(_appEnvironment.WebRootPath + "/" + path))
                        {
                            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + "/" + path, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }
                        }
                    }
                }

                return true;
            }

            return false;
        }
    }
}