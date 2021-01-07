using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;
using PL_452490_P2;

namespace PL_452490_P2.Test
{
    public partial class GlobalTestingClass
    {
        private readonly HttpClient _client;

        public GlobalTestingClass()
        {
            var server = new TestServer(
                new WebHostBuilder()
                    .UseEnvironment("Development")
                    .UseStartup<PL_452490_P2.Startup>()
            );
            _client = server.CreateClient();
        }

        [Theory]
        [InlineData("GET", 4)]
        [InlineData("GET", 2)]
        public async Task Person_ReturnsOkStatusForVarietyOfGetIds(
            string method,
            int? id = null
        )
        {
            var request = new HttpRequestMessage(
                new HttpMethod(method),
                $"/api/person/{id}"
            );
            var response = await _client.SendAsync(request);
            
            if (method == "GET")
            {
                var content = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine(content);
                Assert.NotEmpty(content);
            }

            response.EnsureSuccessStatusCode();
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        
        [Theory]
        [InlineData(2)]
        public async Task Person_CheckGetPostAndDeleteNonDestructivelyOnSingleId(int id)
        {
            var getRequest = new HttpRequestMessage(
                new HttpMethod("GET"),
                $"/api/Person/{id}"
            );
            var getResponse = await _client.SendAsync(getRequest);
        
            var getContent = await getResponse.Content.ReadAsStringAsync();

            getResponse.EnsureSuccessStatusCode();

            var deleteRequest = new HttpRequestMessage(
                new HttpMethod("DELETE"),
                $"/api/Person/{id}"
            );

            var deleteResponse = await _client.SendAsync(deleteRequest);

            deleteResponse.EnsureSuccessStatusCode();

            var postRequest = new HttpRequestMessage(
                new HttpMethod("POST"),
                $"/api/Person"
            );

            postRequest.Content = new StringContent(getContent, Encoding.UTF8, "application/json");

            var postResponse = await _client.SendAsync(postRequest);

            postResponse.EnsureSuccessStatusCode();

            var getRequestAfterPost = new HttpRequestMessage(
                new HttpMethod("GET"),
                $"/api/Person/{id}"
            );

            var getResponseAfterPost = await _client.SendAsync(getRequestAfterPost);

            var getContentAfterPost = await getResponseAfterPost.Content.ReadAsStringAsync();
            
            Assert.Equal(getContent, getContentAfterPost);
        }
    }
}