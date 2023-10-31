namespace OurProjects.Api.Services.JWT
{
    public class JwtConf
    {
        public string SecurityKey { get; set; }
        public int TokenExpiration { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
