using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Manage.Logger
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<LoggingMiddleware> logger;

        public LoggingMiddleware(RequestDelegate requestDelegate, ILogger<LoggingMiddleware> injectLogger)
        {
            this.next = requestDelegate;
            this.logger = injectLogger;
        }

        public async Task Invoke(HttpContext context)
        {
            string logFilePath = @"C:\Users\nvpch\OneDrive\Máy tính\Logger\loggerTest" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
            FileInfo logFileInfo = new FileInfo(logFilePath);
            DirectoryInfo logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();

            try
            {
                DateTime startTime = DateTime.Now;//Japan Standard Time
                //string crid = context.Request.Headers.ensureRequestCrid();

                NetSegmentHelper data = new NetSegmentHelper
                {
                    segmentLogConfig = NetSegmentLogConfig.fullProfile(),
                    requestMethod = context.Request.Method,
                    requestUrl = context.getRawRequestUrl(),
                    requestHeaders = context.Request.Headers.toDictionary()
                };

                // Catch payload from request body
                byte[] payloadBuffer = await context.Request.getPayloadBuffer();

                // Convert byte[] to payload string
                data.requestPayload = payloadBuffer.convertToUtf8String();

                // Copy the content to use for the next pipeline
                context.Request.Body = new MemoryStream(payloadBuffer);

                // https://stackoverflow.com/questions/37395227/add-response-headers-to-asp-net-core-middleware
                // Reattach the crid to the header-response
                // Code set header is always placed before next(context)
                context.Response.OnStarting(state =>
                {
                    HttpContext httpContext = (HttpContext)state;
                    return Task.CompletedTask;
                },
                context);

                using (Stream originalBody = context.Response.Body)
                {

                    try
                    {
                        // https://stackoverflow.com/questions/43403941/how-to-read-asp-net-core-response-body
                        using (MemoryStream memStream = new MemoryStream())
                        {
                            context.Response.Body = memStream;

                            using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append))
                            {
                                using (StreamWriter log = new StreamWriter(fileStream))
                                {
                                    log.WriteLine(data);
                                }
                            }
                            //Continue the pipeline to enter the controller
                            await next(context);

                            // Reset position to read out response payload
                            memStream.Position = 0;
                            data.responseBody = new StreamReader(memStream).ReadToEnd();

                            // Reset location to copy back to stream
                            memStream.Position = 0;
                            await memStream.CopyToAsync(originalBody);
                            context.Response.Body = originalBody;
                        }
                    }
                    catch (Exception streamEx)
                    {
                        using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append))
                        {
                            using (StreamWriter log = new StreamWriter(fileStream))
                            {
                                log.WriteLine(streamEx.ToString());
                            }
                        }
                        Console.WriteLine(streamEx.ToString());
                    }
                }

                // bind response data
                data.responseCode = context.Response.StatusCode;
                data.responseReaders = context.Response.Headers.toDictionary();
                data.executeTime = DateTime.Now.Subtract(startTime).Milliseconds;  //Japan Standard Time

                // Implement dump log
                /////System.DateTime.Today.ToString("MM-dd-yyyy") +
                logger.LogInformation(data.ToString());

                using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append))
                {
                    using (StreamWriter log = new StreamWriter(fileStream))
                    {
                        log.WriteLine(data);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //UtilityLog.WriteExceptionLog(ex, "Invoke");
            }
        }
    }
}
