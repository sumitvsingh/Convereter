namespace Converter
{
   
    public class ConverterRequest
    {
        public string Choice  { get; set; }
        public Double InputNumber { get; set; }
       
                                                        

    }
    public class ConverterResponse
    {
        public Double OutputNumber { get; set; }
        public string Unit { get; set; }

    }

    public class Response
    {
       
        public double ConversionRate { get; set; }  

    }
   
}
