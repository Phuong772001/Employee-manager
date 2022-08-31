namespace Manage.Logger
{
    public class NetSegmentLogConfig
    {
        public bool logRequestUrl { get; set; }
        public bool logRequestMethod { get; set; }
        public bool logRequestHeader { get; set; }
        public bool logRequestPayload { get; set; }
        public bool logResponseBody { get; set; }
        public bool logResponseErrorMessage { get; set; }
        public bool logResponseHeader { get; set; }

        public static NetSegmentLogConfig standardProfile()
        {
            return new NetSegmentLogConfig()
                    .enableLogRequestUrl(true)
                    .enableLogRequestMethod(true)
                    .enableLogRequestHeader(false)
                    .enableLogRequestPayload(true)
                    .enableResponseBody(true)
                    .enableResponseErrorMessage(false)
                    .enableResponseHeader(false);
        }

        public static NetSegmentLogConfig fullProfile()
        {
            return new NetSegmentLogConfig()
                    .enableLogRequestUrl(true)
                    .enableLogRequestMethod(true)
                    .enableLogRequestHeader(true)
                    .enableLogRequestPayload(true)
                    .enableResponseBody(true)
                    .enableResponseErrorMessage(true)
                    .enableResponseHeader(true);
        }

        public NetSegmentLogConfig enableLogRequestUrl(bool b)
        {
            this.logRequestUrl = b;
            return this;
        }

        public NetSegmentLogConfig enableLogRequestMethod(bool b)
        {
            this.logRequestMethod = b;
            return this;
        }

        public NetSegmentLogConfig enableLogRequestHeader(bool b)
        {
            this.logRequestHeader = b;
            return this;
        }

        public NetSegmentLogConfig enableLogRequestPayload(bool b)
        {
            this.logRequestPayload = b;
            return this;
        }

        public NetSegmentLogConfig enableResponseBody(bool b)
        {
            this.logResponseBody = b;
            return this;
        }

        public NetSegmentLogConfig enableResponseErrorMessage(bool b)
        {
            this.logResponseErrorMessage = b;
            return this;
        }

        public NetSegmentLogConfig enableResponseHeader(bool b)
        {
            this.logResponseHeader = b;
            return this;
        }
    }
}
