namespace UszyjMaseczke.WebApi.Configuration
{
    public class CorsConfigurationSection
    {
        public string[] Origins { get; set; }
        public string[] Methods { get; set; }
    }
}