namespace Ginilytics.Api.Startup.Setup.Middlewares
{
    internal class ErrorDetails
    {
        public string ErrorDescription { get; set; }
        public string InnerException { get; set; }
        public string Source { get; set; }
        public int StatusCode { get; set; }
    }
}