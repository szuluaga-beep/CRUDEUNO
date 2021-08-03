using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication1.Models.Entities;

namespace WebApplication1.Helpers
{
    public class ApiService
    {
        private static HttpClient httpclient1 = new HttpClient();

        public static async Task<List<Person>> GetPersons()
        {

            HttpResponseMessage message = await httpclient1.GetAsync("https://localhost:44333/api/people");
            List<Person> people=new List<Person>();
            if (message.IsSuccessStatusCode)
            {
                var json = await httpclient1.GetStringAsync("https://localhost:44333/api/people");
                 people = JsonConvert.DeserializeObject<List<Person>>(json);
            }
           

            return people;
        }
        public static async Task<Person> GetPerson(int? id)
        {
            var person = new Person();
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync($"https://localhost:44333/api/people/{id}");
            person = JsonConvert.DeserializeObject<Person>(json);
            return person;
        }
    }
}
