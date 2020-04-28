namespace ITICapitalServer.Logging
{
    public interface ILogger
    {
        public void Write(params string[] messages);
        public void Error(string error);
    }
}