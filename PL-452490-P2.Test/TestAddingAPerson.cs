using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PL_452490_P2.Models;
using Xunit;

namespace PL_452490_P2.Test
{
    public partial class GlobalTestingClass
    {
        [Fact]
        public async Task TestAddingAPerson()
        {
            var person = new Person()
            {
                Name = "Jakub Koralewski",
                MidichlorianCount = 2000000,
                MasterId = 4
            };
            var json = JsonConvert.SerializeObject(
                person,
                Newtonsoft.Json.Formatting.None,
                new JsonSerializerSettings {
                    NullValueHandling = NullValueHandling.Ignore
                }
            );
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/Person", requestContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            System.Diagnostics.Debug.WriteLine(responseContent);
            Assert.NotEmpty(responseContent);
        }
    }
}