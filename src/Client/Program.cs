using Application.Catalog.Weather.GetByCityName;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Mapster;
using Domain.Entities;
using iTextSharp.text.pdf;

namespace Client
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            InitializeMapster();
            var serviceProvider = new ServiceCollection()
            .AddTransient<IWeatherService, WeatherService>()
            .AddTransient<GetWeatherByCityNameHandler>()
            .BuildServiceProvider();
            while (true)
            {
                Console.WriteLine("Please enter city name:");
                var cityName = Console.ReadLine();

                if (cityName == null)
                {
                    Console.WriteLine("Invalid city name");
                }
                try
                {
                    Console.WriteLine($"Downloading {cityName} weather info ...");
                    var weatherHandler = serviceProvider.GetService<GetWeatherByCityNameHandler>();
                    var response = await weatherHandler!.Handle(new GetWeatherByCityNameRequest(cityName!));
                    
                    Console.WriteLine($"Generating Report ...");
                    GeneratePdf(cityName, response);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error:{ex.Message}");
                    Console.WriteLine($"Press Any key to continue..");
                    Console.ReadKey();
                }
            }
        }
        static void InitializeMapster()
        {
            TypeAdapterConfig<Weather, GetWeatherByCityNameResponse>
                .NewConfig().Map(dest => dest, src => src.Current);
        }


        public static void GeneratePdf(string? cityName, GetWeatherByCityNameResponse pdfData)
        {
            iTextSharp.text.Document doc = new();
            string filePath = $"Weather Report.pdf";
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

            doc.Open();
            PdfPTable table = new PdfPTable(6);

            table.AddCell("City Name");
            table.AddCell("Observation Time");
            table.AddCell("Temperature");
            table.AddCell("Weather Code");
            table.AddCell("Pressure");
            table.AddCell("Humidity");


            table.AddCell(cityName);
            table.AddCell(pdfData.ObservationTime);
            table.AddCell(pdfData.Temperature.ToString());
            table.AddCell(pdfData.WeatherCode.ToString());
            table.AddCell(pdfData.Pressure.ToString());
            table.AddCell(pdfData.Humidity.ToString());

            doc.Add(table);

            doc.Close();
            writer.Close();

            Console.WriteLine("PDF created successfully at " + filePath);

        }
    }
}