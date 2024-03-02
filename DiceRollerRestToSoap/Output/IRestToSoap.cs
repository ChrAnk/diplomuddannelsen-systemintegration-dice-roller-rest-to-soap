using DiceRollerRESTToSoap.Input;
using System.ServiceModel;
using System.Text.Json;

namespace DiceRollerRESTToSoap.Output
{
    [ServiceContract]
    public interface IRestToSoap
    {
        [OperationContract]
        public Task<SoapOutput> DiceResults(int dice, int sides);
    }

    public class DiceSoapService : IRestToSoap
    {
        public async Task<SoapOutput> DiceResults(int count, int sides)
        {
            HttpClient client = new();

            var stream = client.GetStreamAsync($"https://christianankerstjerne.com/privat/dice-api/?dice={count}&sides={sides}");

            var result = await JsonSerializer.DeserializeAsync<RestInput>(await stream);

            SoapOutput output = new();

            output.sum = result.values.Sum();
            output.count = result.values.Count();
            output.average = result.values.Average();

            return output;
        }
    }
}