using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using LargeBlobUpload.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace LargeBlobUpload.Controllers
{
    public class ResumableController : ApiController
    {
        static readonly CloudStorageAccount StorageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
        public HttpResponseMessage Post([ModelBinder] ResumableRequest request)
        {
            try
            {
                UploadBlobChunk(GetBlobContainer("files"), request);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            
        }

        private static void UploadBlobChunk(CloudBlobContainer blobContainer, ResumableRequest request)
        {

            var blockBlob = blobContainer.GetBlockBlobReference(request.ResumableFilename);

            blockBlob.Properties.ContentType = request.ResumableType;

            blockBlob.PutBlock(GetChunkId(request.ResumableChunkNumber - 1), request.FileStream, null);
            if (request.ResumableChunkNumber != request.ResumableTotalChunks)
                return;

            var ids = new string[request.ResumableTotalChunks];
            for (var i = 0; i < request.ResumableTotalChunks; i++)
            {
                ids[i] = GetChunkId(i);
            }
            blockBlob.PutBlockList(ids);
        }

        private static CloudBlobContainer GetBlobContainer(string containerName)
        {
            var container = StorageAccount.CreateCloudBlobClient().GetContainerReference(containerName);
            if (container.CreateIfNotExists())
                container.SetPermissions(new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });
            return container;
        }

        private static string GetChunkId(int chunkIndex)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(chunkIndex.ToString("D10")));
        }
    }

    
}
