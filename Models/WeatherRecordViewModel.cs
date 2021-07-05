using System;

namespace SampleMVCWeatherApp.Models
{
    public class WeatherRecordViewModel
    {
        public int _id { get; set; }
        public string Opad_Typ { get; set; }
        public string Lokalizacja_Opis { get; set; } 
        public double Wilgotnosc { get; set; }
        public double T_Grunt { get; set; }
        public double Wiatr { get; set; }
        public DateTime Czas_Rejestracji { get; set; }
        public double T_Powietrza { get; set; }
        public double Wiatr_Kierunek { get; set; }
    }
}
