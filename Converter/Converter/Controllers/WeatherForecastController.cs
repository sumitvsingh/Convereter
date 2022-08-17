using Microsoft.AspNetCore.Mvc;

namespace Converter.Controllers
{
     
    //Input Parameters for choice, belpw are the choices

    //centimetersToInches
    //inchesToCentimeteres
    //gramsToOunces
    //ouncesToGrams
    //celsiusToFahrenheit
    //fahrenheitToCelsius
    //rupeeToDollar
    //dollarToRupee


    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IGetConversionRate _getConversionRate;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IGetConversionRate getConversionRate)
        {
            _logger = logger;
            _getConversionRate = getConversionRate;
        }




        [HttpPost(Name = "Converter")]
        public ConverterResponse Converter([FromBody] ConverterRequest converterRequest)
        {
            ConverterResponse response = new ConverterResponse();
            Response res = new Response();
            IConverter converter = new Converter();
            switch (converterRequest.Choice) //switch statement for choices
            {
                case "centimetersToInches":
                    res = _getConversionRate.getConversionRate("centimetersToInches");
                    response.OutputNumber = converter.centimetersToInches(converterRequest.InputNumber, res.ConversionRate);
                    response.Unit = "Inches";
                    break;
                case "inchesToCentimeteres":
                    res = _getConversionRate.getConversionRate("inchesToCentimeteres");
                    response.OutputNumber = converter.inchesToCentimeteres(converterRequest.InputNumber, res.ConversionRate);
                    response.Unit = "Centimeteres";
                    break;
                case "gramsToOunces":
                    res = _getConversionRate.getConversionRate("gramsToOunces");
                    response.OutputNumber = converter.gramsToOunces(converterRequest.InputNumber, res.ConversionRate);
                    response.Unit = "Ounces";
                    break;
                case "ouncesToGrams":
                    res = _getConversionRate.getConversionRate("ouncesToGrams");
                    response.OutputNumber = converter.ouncesToGrams(converterRequest.InputNumber, res.ConversionRate);
                    response.Unit = "Grams";
                    break;
                case "celsiusToFahrenheit":
                    res = _getConversionRate.getTemperatureConversion("celsiusToFahrenheit", converterRequest.InputNumber);
                    //response.OutputNumber = converter.celsiusToFahrenheit(converterRequest.InputNumber);
                    response.OutputNumber = res.ConversionRate;
                    response.Unit = "Fahrenheit";
                    break;
                case "fahrenheitToCelsius":
                    res = _getConversionRate.getTemperatureConversion("fahrenheitToCelsius", converterRequest.InputNumber);
                    response.OutputNumber = res.ConversionRate;
                    //response.OutputNumber = converter.fahrenheitToCelsius(converterRequest.InputNumber);
                    response.Unit = "Celsius";
                    break;
                case "rupeeToDollar":
                    res = _getConversionRate.getConversionRate("rupeeToDollar");
                    response.OutputNumber = converter.rupeeToDollar(converterRequest.InputNumber, res.ConversionRate);
                    response.Unit = "Dollars";
                    break;
                case "dollarToRupee":
                    res = _getConversionRate.getConversionRate("dollarToRupee");
                    response.OutputNumber = converter.dollarToRupee(converterRequest.InputNumber, res.ConversionRate);
                    response.Unit = "Rupees";
                    break;


            }
            return response;
        }

    }
}