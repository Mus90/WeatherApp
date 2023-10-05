﻿
namespace Domain.Entities
{

    public class Weather
    {
        public Request? Request { get; set; }
        public Location? Location { get; set; }
        public Current? Current { get; set; }
    }
    public class Request
    {
        public string Type { get; set; }
        public string Query { get; set; }
        public string Language { get; set; }
        public string Unit { get; set; }
    }

    public class Location
    {
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? Lat { get; set; }
        public string? Lon { get; set; }
        public string? TimezoneId { get; set; }
        public string? Localtime { get; set; }
        public long? LocaltimeEpoch { get; set; }
        public string? UtcOffset { get; set; }
    }

    public class Current
    {
        public string? ObservationTime { get; set; }
        public int? Temperature { get; set; }
        public int? WeatherCode { get; set; }
        public List<string>? WeatherIcons { get; set; }
        public List<string>? WeatherDescriptions { get; set; }
        public int? WindSpeed { get; set; }
        public int? WindDegree { get; set; }
        public string? WindDir { get; set; }
        public int? Pressure { get; set; }
        public int? Precip { get; set; }
        public int? Humidity { get; set; }
        public int? Cloudcover { get; set; }
        public int? Feelslike { get; set; }
        public int? UvIndex { get; set; }
        public int? Visibility { get; set; }
    }
}