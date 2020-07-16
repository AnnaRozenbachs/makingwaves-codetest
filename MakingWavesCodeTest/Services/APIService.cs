using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace MakingWavesCodeTest.Services
{
    public class APIService
    {
        public void CreateRequest()
        {
            var request = WebRequest.Create("https://reqres.in/api/example?per_page=2&page=1");
            request.Method = "GET";
            request.ContentType = "application/json";
            var response = request.GetResponse();

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                string result = reader.ReadToEnd();
            }
        }
    }
}