using System;
using System.Text.Json.Serialization;

namespace covid19
{
    public class datinazione
    {
        public int id { get; set; }
        public DateTime data { get; set; }
        public String stato { get; set; }
        public int ricoverati_con_sintomi { get; set; }
        [JsonConverter(typeof(IntNullConvert))]
        public int terapia_intensiva { get; set; }
        [JsonConverter(typeof(IntNullConvert))]
        public int totale_ospedalizzati { get; set; }
        [JsonConverter(typeof(IntNullConvert))]
        public int isolamento_domiciliare { get; set; }
        [JsonConverter(typeof(IntNullConvert))]
        public int totale_positivi { get; set; }
        [JsonConverter(typeof(IntNullConvert))]
        public int variazione_totale_positivi { get; set; }
        [JsonConverter(typeof(IntNullConvert))]
        public int nuovi_positivi { get; set; }
        [JsonConverter(typeof(IntNullConvert))]
        public int dimessi_guariti { get; set; }
        [JsonConverter(typeof(IntNullConvert))]
        public int deceduti { get; set; }
        [JsonConverter(typeof(IntNullConvert))]
        public int casi_da_sospetto_diagnostico { get; set; }
        [JsonConverter(typeof(IntNullConvert))]
        public int casi_da_screening { get; set; }
        [JsonConverter(typeof(IntNullConvert))]
        public int totale_casi { get; set; }
        [JsonConverter(typeof(IntNullConvert))]
        public int tamponi { get; set; }
        [JsonConverter(typeof(IntNullConvert))]
        public int casi_testati { get; set; }
        public String note { get; set; }
    }

}