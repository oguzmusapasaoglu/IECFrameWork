namespace IECFW.ExceptionHandling
{
    public class ExceptionModel
    {
        public string MethotName { get; set; }
        public string ExceptionTypeStr { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string RequestData { get; set; }
        public string ResponseData { get; set; }
        public int ProcessTime { get; set; }
    }
}
