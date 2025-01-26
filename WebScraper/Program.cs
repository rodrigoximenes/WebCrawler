using HtmlAgilityPack;

internal class Program
{
    private static void Main(string[] args)
    {
        String url = "https://weather.com/weather/today/l/624f0cccc10bececfa4c083056cef743837a76588790f476c9ebea44be35e51f";
        var httpClient = new HttpClient();
        var html = httpClient.GetStringAsync(url).Result;
        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(html);

        // Get the temperature
        var temperatureElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='CurrentConditions--tempValue--zUBSz']");
        var temperature = temperatureElement.InnerText.Trim();
        Console.WriteLine("Temperature: " + temperature);

        // Get the conditions
        var conditionElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='CurrentConditions--phraseValue---VS-k']");
        var conditions = conditionElement.InnerText.Trim();
        Console.WriteLine("Conditions: " + conditions);

        // Get the location
        var cityElement = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class='CurrentConditions--location--yub4l']");
        var city = cityElement.InnerText.Trim();
        Console.WriteLine("City: " + city);
    }
}