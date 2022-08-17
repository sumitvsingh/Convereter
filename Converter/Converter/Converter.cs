namespace Converter
{
    public interface IConverter
    {
        public double centimetersToInches(double inputParameter, double conversionRate);
        public double inchesToCentimeteres(double inputParameter, double conversionRate);
        public double gramsToOunces(double inputParameter, double conversionRate);
        public double ouncesToGrams(double inputParameter, double conversionRate);
        //public double celsiusToFahrenheit(double inputParameter);
        //public double fahrenheitToCelsius(double inputParameter);
        public double rupeeToDollar(double inputParameter, double conversionRate);
        public double dollarToRupee(double inputParameter, double conversionRate);

    }
    public class Converter: IConverter
    {
        public double centimetersToInches(double inputParameter , double conversionRate)  
        {
            
            return inputParameter / conversionRate; 
        }

        public double inchesToCentimeteres(double inputParameter, double conversionRate) 
        {
            return inputParameter * conversionRate; 
        }

        public double gramsToOunces(double inputParameter, double conversionRate) 
        {
            return inputParameter / conversionRate; 
        }

        public double ouncesToGrams(double inputParameter, double conversionRate) 
        {
            return inputParameter * conversionRate; 
        }

        //public double celsiusToFahrenheit(double inputParameter)
        //{
        //    return (inputParameter * 9) / 5 + 32;
        //}

        //public double fahrenheitToCelsius(double inputParameter)
        //{
        //    return (inputParameter - 32) / 5 * 9;
        //}

        public double rupeeToDollar(double inputParameter, double conversionRate)
        {
            return (inputParameter / conversionRate);
        }

        public double dollarToRupee(double inputParameter, double conversionRate)
        {
            return (inputParameter * conversionRate);
        }
    }
}
