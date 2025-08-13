using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Catalog.Core.Interfaces.IFileManager
{
    public interface IFileManager
    {
        Task<GenericResponse<string>> UploadFileAsync(IFormFile file);
        Task<GenericResponse<List<string>>> UploadMultipleFiles(List<IFormFile> files);
        Task<GenericResponse<byte[]?>> DownLoadFile(string fileLink);
    }
}
