using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace covid19
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }

        private static async Task ProcessRepositories()
        {
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync("https://raw.githubusercontent.com/pcm-dpc/COVID-19/master/dati-json/dpc-covid19-ita-andamento-nazionale.json");

            var serializeOptions = new JsonSerializerOptions();
            serializeOptions.WriteIndented = true;
            var jdatinazione = await JsonSerializer.DeserializeAsync<List<datinazione>>(await streamTask, serializeOptions);

            using(var context = new LibraryContext())
            {
                context.Database.EnsureCreated();
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE dati_nazione;");
                int a = 0;
                foreach (var record in jdatinazione)
               {
                  context.dati_nazione.Add(record);
                  a += 1;               
               }

               context.SaveChanges();
               Console.WriteLine(a);
            }

            streamTask = client.GetStreamAsync("https://raw.githubusercontent.com/pcm-dpc/COVID-19/master/dati-json/dpc-covid19-ita-regioni.json");

            serializeOptions = new JsonSerializerOptions();
            serializeOptions.WriteIndented = true;
            var jdatiregioni = await JsonSerializer.DeserializeAsync<List<datiregioni>>(await streamTask, serializeOptions);

            using(var context = new LibraryContext())
            {
                context.Database.EnsureCreated();
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE dati_regione;");
                int a = 0;
                foreach (var record in jdatiregioni)
               {
                  context.dati_regione.Add(record);
                  a += 1;               
               }

               context.SaveChanges();
               Console.WriteLine(a);
            }


            streamTask = client.GetStreamAsync("https://raw.githubusercontent.com/pcm-dpc/COVID-19/master/dati-json/dpc-covid19-ita-province.json");

            serializeOptions = new JsonSerializerOptions();
            serializeOptions.WriteIndented = true;
            var jdatiprovince = await JsonSerializer.DeserializeAsync<List<datiprovince>>(await streamTask, serializeOptions);

            // Ordino i record con LINQ
            //List<datiprovince> SortedList = json.OrderByDescending(o=>o.data).ToList();
            
            using(var context = new LibraryContext())
            {
                context.Database.EnsureCreated();
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE dati_provincia;");
                int a = 0;
                foreach (var record in jdatiprovince)
               {
                  context.dati_provincia.Add(record);
                  a += 1;               
               }

               context.SaveChanges();
               Console.WriteLine(a);
            }

        }
    }
}
