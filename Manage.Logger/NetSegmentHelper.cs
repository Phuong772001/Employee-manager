using System.Collections.Generic;
using System.Text;

namespace Manage.Logger
{
    public class NetSegmentHelper
    {
        public int responseCode { get; set; }

        public string responseBody { get; set; }

        public string responseErrorMessage { get; set; }

        public Dictionary<string, string> responseReaders { get; set; }

        public string requestMethod { get; set; }

        public string requestUrl { get; set; }

        public string requestPayload { get; set; }

        public Dictionary<string, string> requestHeaders { get; set; }

        public long executeTime { get; set; }

        public NetSegmentLogConfig segmentLogConfig { get; set; }

        public override string ToString()
        {
            if (segmentLogConfig == null)
            {
                return null;
            }

            StringBuilder outputString = new StringBuilder();

            // template:
            // --> [POST] https://gitlab.jmango360.com/v4/api
            //     "Accept": "application/json" 
            //     "Content-Type": "application/json"
            //     { "projectId": 5 }
            // <-- 20 ms [404] c3780f18-8a12-4c6a-8989-3240b5b40c29
            //     "Cache-Control": "no-cache" 
            //     "Cache-control": "no-cache=set-cookie"
            //     { "message":{ "base":["Reference not found"]}}

            // --> POST https://gitlab.jmango360.com/v4/api
            outputString.Append("--> ");
            if (segmentLogConfig.logRequestMethod)
            {
                outputString.Append(string.Format("[{0}] ", this.requestMethod));
            }

            if (segmentLogConfig.logRequestUrl)
            {
                outputString.Append(this.requestUrl);
            }

            outputString.Append("\n");


            if (segmentLogConfig.logRequestHeader && this.requestHeaders != null && !this.requestHeaders.isEmpty())
            {
                outputString.Append(string.Format("{0}\n", this.requestHeaders.dumpHeaderForPostman("    ")));
            }

            //    payload { "projectId": 5 }
            if (segmentLogConfig.logRequestPayload && !string.IsNullOrEmpty(this.requestPayload))
            {
                outputString.Append(string.Format("    {0}\n", this.requestPayload));
            }

            // <-- 20 ms [404] 
            outputString.Append(string.Format("<-- {0:n0} ms [{1}] \n", this.executeTime, this.responseCode));

            //     "Accept": "application/json" 
            //     "Content-Type": "application/json"
            if (segmentLogConfig.logResponseHeader && !this.responseReaders.isEmpty())
            {
                outputString.Append(string.Format("{0}\n", this.responseReaders.dumpHeaderForPostman("    ")));
            }

            // { "message":{ "base":["Reference not found"]}}
            if (segmentLogConfig.logResponseBody && !string.IsNullOrEmpty(this.responseBody))
            {
                outputString.Append(string.Format("    {0}\n", this.responseBody));
            }

            if (segmentLogConfig.logResponseErrorMessage && !string.IsNullOrEmpty(this.responseErrorMessage))
            {
                outputString.Append(string.Format("    {0}\n", this.responseErrorMessage));
            }

            return outputString.ToString();
        }
    }
}
