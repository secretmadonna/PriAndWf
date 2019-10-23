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
        public string JsonpCallback { get; private set; }
        public JsonpMediaTypeFormatter(string jsonpcallback = null)
        {
            JsonpCallback = jsonpcallback;
        }

        public override MediaTypeFormatter GetPerRequestFormatterInstance(Type type, HttpRequestMessage request, MediaTypeHeaderValue mediaType)
        {
            if (request.Method == HttpMethod.Get)
            {
                var jsonpKey = ConfigurationManager.AppSettings["cors:jsonp"];
                if (!string.IsNullOrEmpty(jsonpKey))
                {
                    var kvs = request.GetQueryNameValuePairs().ToDictionary(pair => pair.Key, pair => pair.Value);
                    string jsonpValue;
                    if (kvs.TryGetValue(jsonpKey, out jsonpValue))
                    {
                        if (!string.IsNullOrEmpty(jsonpValue))
                        {
                            return new JsonpMediaTypeFormatter(jsonpValue);
                        }
                    }
                }
            }
            return this;
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            if (!string.IsNullOrEmpty(JsonpCallback))
            {
                return Task.Factory.StartNew(() =>
                {
                    var streamWriter = new StreamWriter(writeStream);

                    streamWriter.Write($"{JsonpCallback}(");//XX(
                    streamWriter.Flush();
                    base.WriteToStreamAsync(type, value, writeStream, content, transportContext).ContinueWith(t =>
                    {
                        streamWriter.Write($")");//)
                        streamWriter.Flush();
                        streamWriter.Close();
                        streamWriter.Dispose();
                    });
                });
            }
            return base.WriteToStreamAsync(type, value, writeStream, content, transportContext);
        }
    }
}