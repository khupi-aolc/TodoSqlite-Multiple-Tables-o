using BellApp.Helpers.Validators;
using BellApp.Models.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BellApp.Services
{
    public class APIServices
    {
        //Registration Service
        public async Task<bool> RegisterAsync(ValidatableObject<string> company, ValidatableObject<string> companyno, ValidatableObject<string> jobposition, ValidatableObject<string> name, ValidatableObject<string> email, ValidatablePair<string> password)
        {
            var client = new HttpClient();
            var model = new UsersDto
            {
                Company = company.ToString(),
                CompanyNo = companyno.ToString(),
                JobPosition = jobposition.ToString(),
                Name = name.ToString(),
                Email = email.ToString(),
                Password = password.ToString()

            };

            var json = JsonConvert.SerializeObject(model);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("http://10.31.0.238:45464/api/UserInfo", httpContent);

            return response.IsSuccessStatusCode;
        }
    }
}
