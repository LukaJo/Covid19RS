using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19RS.Models
{
    public class Covid19
    {
        public int Id { get; set; }
        public int UkupanBrRegSlucajeva { get; set; }
        public int BrojSmrtnihSlucajeva { get; set; }
        public decimal ProcenatSmrtnosti { get; set; }
        public int BrojTestiranihOsoba { get; set; }
        public int BrojTestiranihOsoba24h { get; set; }
        public int BrojPotvrdjenihSlucajeva24h { get; set; }
        public int BrojPreminulihosoba24h { get; set; }
        public int BrojAktivnihSlucajeva { get; set; }
        public int BrojOsobaNaRespiratorima { get; set; }
    }



    public class Rootobject
    {
        public Global Global { get; set; }
        public Country[] Countries { get; set; }
        public DateTime Date { get; set; }
    }

    public class Global
    {
        public int NewConfirmed { get; set; }
        public int TotalConfirmed { get; set; }
        public int NewDeaths { get; set; }
        public int TotalDeaths { get; set; }
        public int NewRecovered { get; set; }
        public int TotalRecovered { get; set; }
    }

    public class Country
    {
        [JsonProperty("Country")]
        public string Zemlja { get; set; }
        [JsonProperty("CountryCode")]
        public string ZemljaKod { get; set; }
        [JsonProperty("NewConfirmed")]
        public int Novozarazenih { get; set; }
        [JsonProperty("TotalConfirmed")]
        public int UkupnoRegistrovanih { get; set; }
        [JsonProperty("NewDeaths")]
        public int Novopreminulih { get; set; }
        [JsonProperty("TotalDeaths")]
        public int UkupnoPreminulih { get; set; }
        [JsonProperty("NewRecovered")]
        public int NovoOporavljenih { get; set; }
        [JsonProperty("TotalRecovered")]
        public int UkupnoOporavljenih { get; set; }
    }






}
