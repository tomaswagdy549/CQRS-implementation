using Catalog.Core.Entities;
using Catalog.Core.Interfaces.IFileManager;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace Catalog.Infrastructure.FileManager
{
    public class FileManager : IFileManager
    {
        private readonly IConfiguration _IConfiguration;
        public FileManager(IConfiguration configuration)
        {
            _IConfiguration = configuration;
        }

        public async Task<GenericResponse<byte[]?>> DownLoadFile(string fileLink)
        {
            byte[] fileBytes;
            try
            {
                using (var client = new HttpClient())
                {
                    using (var result = await client.GetAsync(fileLink))
                    {
                        if (result.IsSuccessStatusCode)
                        {
                            return new GenericResponse<byte[]?>()
                            {
                                Data = await result.Content.ReadAsByteArrayAsync(),
                                Message = "File Downloaded Successfully",
                                HttpStatusCode = System.Net.HttpStatusCode.OK
                            };
                        }
                        return new GenericResponse<byte[]?>()
                        {
                            Data = null,
                            Message = "Failed to download the file",
                            HttpStatusCode = System.Net.HttpStatusCode.InternalServerError
                        };
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                return new GenericResponse<byte[]?>()
                {
                    Data = null,
                    Message = "Failed to download the file",
                    HttpStatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        public async Task<GenericResponse<string>> UploadFileAsync(IFormFile file)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            var root = configurationBuilder.Build();
            string FileManagerAPIUrl = root.GetSection("FileManagerAPIUrl").Value;
            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    var client = new RestClient(FileManagerAPIUrl + "UploadFile?tagName=" + file.Name + "&userId=" + new Guid());
                    var request = new RestRequest("", Method.Post);
                    var filePath = Path.GetTempFileName();
                    request.AddFile("File", fileBytes, file.FileName);
                    RestResponse response = await client.ExecuteAsync(request);
                    if (response.IsSuccessful)
                    {
                        var fileModel = JsonConvert.DeserializeObject<FileModel>(response.Content);
                        return new GenericResponse<string>()
                        {
                            Data = fileModel.Url,
                            Message = "File Upload Succesfully , file remote link attached",
                            HttpStatusCode = System.Net.HttpStatusCode.OK
                        };
                    }
                }
            }
            return new GenericResponse<string>()
            {
                Data = null,
                Message = "Failed to upload the picture",
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }

        public async Task<GenericResponse<List<string>>> UploadMultipleFiles(List<IFormFile> files)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            var root = configurationBuilder.Build();
            string FileManagerAPIUrl = root.GetSection("FileManagerAPIUrl").Value;
            var client = new RestClient(FileManagerAPIUrl + "UploadMultipleFile?tagName=" + new Guid());
            var request = new RestRequest("", Method.Post);
            foreach (IFormFile currentFile in files)
            {
                if (currentFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        currentFile.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        var filePath = Path.GetTempFileName();
                        request.AddFile("lstFiles", fileBytes, currentFile.FileName);

                    }
                }
            }
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var Urls = JsonConvert.DeserializeObject<List<FileModel>>(response.Content)!;
                return new GenericResponse<List<string>>()
                {
                    Data = Urls.Select(u => u.Url).ToList(),
                    Message = "files uploaded succesfully",
                    HttpStatusCode = System.Net.HttpStatusCode.OK
                };
            }
            return null;
        }
        public class FileModel
        {
            public string Url { get; set; }
            public string? FileName { get; set; }
        }
    }
}
