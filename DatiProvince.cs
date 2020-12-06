using System;
using System.Text.Json.Serialization;

namespace covid19
{
    public class datiprovince
    {
        public int id { get; set; }
        public DateTime data { get; set; }
        public string stato { get; set; }
        public int codice_regione { get; set; }
        public string denominazione_regione { get; set; }
        public int codice_provincia { get; set; }
        public string denominazione_provincia { get; set; }
        public string sigla_provincia { get; set; }
        [JsonConverter(typeof(DoubleNullConvert))]
        public double lat { get; set; }
        [JsonConverter(typeof(DoubleNullConvert))]
        public double @long { get; set; }
        public int totale_casi { get; set; }
        public string note { get; set; }
    }

}