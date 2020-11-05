using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrandApp.Services
{
    public static class StorageService
    {
        private static BlobContainerClient _containerClient { get; set; }
        private static BlobClient _blobClient { get; set; }


        public static async Task InitializeStorageAsync(string connectionString, string containerName, bool uniqueName = false)
        {
            if (uniqueName)
                containerName = $"{containerName}-{Guid.NewGuid()}";

            try
            {
                BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

                try
                {
                    _containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);
                }
                catch
                {
                    try
                    {
                        _containerClient = blobServiceClient.GetBlobContainerClient(containerName);
                    }
                    catch { }
                }
            }
            catch { }

        }
        public static async Task UploadFileAsync(string @filePath)
        {
            try
            {
                _blobClient = _containerClient.GetBlobClient(Path.GetFileName(filePath));

                using FileStream fileStream = File.OpenRead(filePath);
                await _blobClient.UploadAsync(fileStream, true);
                fileStream.Close();

                File.Delete(filePath);
            }
            catch { }
        }

    }
}
