using System;

namespace ODT.Data
{
    public class AppSettings
    {
        public string _ODTConnection { get; set; }
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
