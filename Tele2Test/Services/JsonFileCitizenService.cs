using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Tele2Test.Models;
using System.Net;

namespace Tele2Test.Services
{
    public class JsonFileCitizenService
    {
        private string JsonUrlName
        {
            get { return "http://testlodtask20172.azurewebsites.net/task"; }
        }

        public IEnumerable<Citizen> GetCitizens()
        {
            using (WebClient wc = new WebClient()) 
            {
                return JsonSerializer.Deserialize<Citizen[]>(wc.DownloadString(JsonUrlName),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }
}
