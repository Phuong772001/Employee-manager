using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Logger
{
    public static class HttpContextExtensions
    {
        public static string getRawRequestUrl(this HttpContext httpContext)
        {
            if (httpContext == null)
            {
                return null;
            }

            // https://stackoverflow.com/questions/38437005/how-to-get-current-url-in-view-in-asp-net-core-1-0
            return string.Format("{0}://{1}{2}{3}", httpContext.Request.Scheme, httpContext.Request.Host, httpContext.Request.Path, httpContext.Request.QueryString);
        }

        public static Dictionary<string, string> toDictionary(this IHeaderDictionary headerData)
        {
            if (headerData == null)
            {
                return null;
            }

            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (string key in headerData.Keys)
            {
                if (!dic.ContainsKey(key))
                {
                    dic.Add(key, headerData[key]);
                }
            }

            return dic;
        }












        // special handling for login

        public static async Task<byte[]> getPayloadBuffer(this HttpRequest request)
        {
            if (request == null)
            {
                return null;
            }

            // http://www.palador.com/2017/05/24/logging-the-body-of-http-request-and-response-in-asp-net-core/
            // enable buffering to read byte[] data
            request.EnableBuffering();

            byte[] payloadBuffer = new byte[Convert.ToInt32(request.ContentLength)];

            // read payload data from client sent up into byte[] array
            await request.Body.ReadAsync(payloadBuffer, 0, payloadBuffer.Length);

            return payloadBuffer;
        }

        public static string convertToUtf8String(this byte[] data)
        {
            if (data == null)
            {
                return null;
            }

            return Encoding.UTF8.GetString(data);
        }


        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
