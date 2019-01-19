using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;

namespace PriAndWf.TestWebApi.Core
{
    public class JsonpMediaTypeFormatter : JsonMediaTypeFormatter
    {
        public JsonpMediaTypeFormatter() : base()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/javascript"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/javascript"));
            MediaTypeMappings.Add(new UriPathExtensionMapping("jsonp", DefaultMediaType));
        }

        //public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        //{
        //    if (string.IsNullOrEmpty(this.JsonpCallback))
        //    {
        //        return base.WriteToStreamAsync(type, value, writeStream, content, transportContext);
        //    }
        //    try
        //    {
        //        WriteToStream(type, value, writeStream, content);
        //        return Task.FromResult<AsyncVoid>(new AsyncVoid());
        //    }
        //    catch (Exception ex)
        //    {
        //        TaskCompletionSource<AsyncVoid> source = new TaskCompletionSource<AsyncVoid>();
        //        source.SetException(ex);
        //        return source.Task;
        //    }
        //}
        //private void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        //{
        //    JsonSerializer serializer = JsonSerializer.Create(this.SerializerSettings);
        //    using (StreamWriter streamWriter = new StreamWriter(writeStream, this.SupportedEncodings.First()))
        //    {
        //        using (JsonTextWriter jsonTextWriter = new JsonTextWriter(streamWriter) { CloseOutput = false })
        //        {
        //            jsonTextWriter.WriteRaw(  "callback(");
        //            serializer.Serialize(jsonTextWriter, value);
        //            jsonTextWriter.WriteRaw(")");
        //        }
        //    }
        //}
        //public override MediaTypeFormatter GetPerRequestFormatterInstance(Type type, HttpRequestMessage request, MediaTypeHeaderValue mediaType)
        //{
        //    if (request.Method != HttpMethod.Get)
        //    {
        //        return this;
        //    }
        //    var jsonpKey = ConfigurationManager.AppSettings["cors:jsonp"];
        //    if (string.IsNullOrEmpty(jsonpKey))
        //    {
        //        jsonpKey = "callback";
        //    }
        //    var kvs = request.GetQueryNameValuePairs().ToDictionary(pair => pair.Key, pair => pair.Value);
        //    //if (kvs.TryGetValue(jsonpKey, out string jsonpValue))
        //    //{
        //    //    return new JsonpMediaTypeFormatter(jsonpValue);
        //    //}
        //    return this;
        //}
    }
}