using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public List<Dictionary<string,string>> GetDataList()
        {
            int totalPages = 6;
            List<Dictionary<string, string>> dataList = new List<Dictionary<string, string>>();
            for (int CurrentPage=1; CurrentPage <= totalPages; CurrentPage++)
            {
                var request = WebRequest.Create("https://reqres.in/api/example?per_page=2&page=" + CurrentPage + "");
                request.Method = "GET";
                request.ContentType = "application/json";
                var response = request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {                
                    Dictionary<string, object> result = JsonConvert.DeserializeObject<Dictionary<string, object>>(reader.ReadToEnd());
                    JArray data = JArray.Parse(result["data"].ToString());
                    CreateList(dataList, data);
                    response.Close();
                }
            
            }
            return dataList;
           
        }

        private void CreateList(List<Dictionary<string,string>> dataList, JArray data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                Dictionary<string, string> dataColor = new Dictionary<string, string>();
                dataColor["id"] = data[i]["id"].ToString();
                dataColor["name"] = data[i]["name"].ToString();
                dataColor["year"] = data[i]["year"].ToString();
                dataColor["pantone_value"] = data[i]["pantone_value"].ToString();
                dataList.Add(dataColor);
            }
        }
    }
}