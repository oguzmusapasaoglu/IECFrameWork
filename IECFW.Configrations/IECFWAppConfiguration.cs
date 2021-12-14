namespace IFW.Configrations
{
    public class IECFWAppConfiguration
    {
        public string RedisServer { get; set; }
        public string PostgreConnString { get; set; }
        public string EncryptionKey { get; set; }
        public ApplicationSecurity ApplicationSecurity { get; set; }
    }

    public class ApplicationSecurity
    {
        public string JWTTokenSecretKey { get; set; }
        public int ExpiresInHours { get; set; }
    }
}
