using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PL_452490_P2.Models;
using Xunit;

namespace PL_452490_P2.Test
{
    public partial class GlobalTestingClass
    {
        [Fact]
        public async Task PeoplePaginationTest()
        {
            var allPeopleResponse = await _client.GetAsync("/api/Person");
            var allPeopleContent = await allPeopleResponse.Content.ReadAsStringAsync();
            var allPeople = JsonConvert.DeserializeObject<List<Person>>(allPeopleContent);
            var peopleCount = allPeople.Count;
            var size = (int) Math.Ceiling((float) peopleCount / 3);
            var responses = new List<Task<HttpResponseMessage>>();
            int page = 1;
            while (page <= 3)
            {
                responses.Add(_client.GetAsync($"/api/person?page={page}&size={size}"));
                page++;
            }

            await Task.WhenAll(responses);
            var contents = new List<Task<string>>();

            foreach (var response in responses)
            {
                contents.Add(response.Result.Content.ReadAsStringAsync());
            }

            await Task.WhenAll(contents);

            var flattenedPeople = new List<Person>();
            foreach (var content in contents)
            {
                var people = JsonConvert.DeserializeObject<List<Person>>(
                    content.Result
                );
                flattenedPeople = (List<Person>) flattenedPeople.Concat(people);
            }

            Assert.Equal(flattenedPeople.Count, allPeople.Count);
            Assert.Equal(flattenedPeople, allPeople);
        }
    }
}