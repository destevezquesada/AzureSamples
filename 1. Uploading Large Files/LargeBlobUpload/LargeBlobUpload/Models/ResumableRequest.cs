using System;
using System.IO;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace LargeBlobUpload.Models
{
    [ModelBinder(typeof(ResumableRequestModelBinder))]
    public class ResumableRequest
    {
        /// <summary>
        /// The index of the chunk in the current upload. First chunk is 1 (no base-0 counting here)
        /// </summary>
        public int ResumableChunkNumber { get; set; }
        /// <summary>
        /// The total number of chunks.
        /// </summary>
        public int ResumableTotalChunks { get; set; }
        /// <summary>
        /// The general chunk size. Using this value and <see cref="ResumableTotalSize"/> you can calculate the total number of chunks. Please note that the size of the data received in the HTTP might be lower than ResumableChunkSize of this for the last chunk for a file.
        /// </summary>
        public int ResumableChunkSize { get; set; }
        /// <summary>
        /// The current chunk size.
        /// </summary>
        public int ResumableCurrentChunkSize { get; set; }
        /// <summary>
        /// The total file size.
        /// </summary>
        public int ResumableTotalSize { get; set; }
        /// <summary>
        /// The MIME content type of the file.
        /// </summary>
        public string ResumableType { get; set; }
        /// <summary>
        /// A unique identifier for the file contained in the request.
        /// </summary>
        public string ResumableIdentifier { get; set; }
        /// <summary>
        /// The original file name (since a bug in Firefox results in the file name not being transmitted in chunk multipart posts).
        /// </summary>
        public string ResumableFilename { get; set; }
        /// <summary>
        /// The file's relative path when selecting a directory (defaults to file name in all browsers except Chrome).
        /// </summary>
        public string ResumableRelativePath { get; set; }
        /// <summary>
        /// The file stream.
        /// </summary>
        public Stream FileStream { get; set; }
    }

    public class ResumableRequestModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(ResumableRequest))
            {
                return false;
            }

            try
            {
                var request = new ResumableRequest();

                foreach (var queryParamater in actionContext.Request.GetQueryNameValuePairs())
                {//int resumableChunkNumber, int resumableChunkSize, int resumableCurrentChunkSize, int resumableTotalSize, 
                 //string resumableType, string resumableIdentifier, string resumableFilename, string resumableRelativePath, 
                 //int resumableTotalChunks
                    switch (queryParamater.Key)
                    {
                        case "resumableChunkNumber":
                            request.ResumableChunkNumber = int.Parse(queryParamater.Value);
                            break;
                        case "resumableChunkSize":
                            request.ResumableChunkSize = int.Parse(queryParamater.Value);
                            break;
                        case "resumableCurrentChunkSize":
                            request.ResumableCurrentChunkSize = int.Parse(queryParamater.Value);
                            break;
                        case "resumableTotalSize":
                            request.ResumableTotalSize = int.Parse(queryParamater.Value);
                            break;
                        case "resumableType":
                            request.ResumableType = queryParamater.Value;
                            break;
                        case "resumableIdentifier":
                            request.ResumableIdentifier = queryParamater.Value;
                            break;
                        case "resumableFilename":
                            request.ResumableFilename = queryParamater.Value;
                            break;
                        case "resumableRelativePath":
                            request.ResumableRelativePath = queryParamater.Value;
                            break;
                        case "resumableTotalChunks":
                            request.ResumableTotalChunks = int.Parse(queryParamater.Value);
                            break;
                        default:
                            break;
                    }
                }

                request.FileStream = actionContext.Request.Content.ReadAsStreamAsync().Result;

                bindingContext.Model = request;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }

}