using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tele2Test.Services;
using Tele2Test.Models;
using System.Text.Json;
using System.Net;

namespace Tele2Test.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CitizensController : ControllerBase
    {
        public JsonFileCitizenService citizenService { get; }
        public CitizensDBContext citizenDB { get; }

        public CitizensController(JsonFileCitizenService citizenService, CitizensDBContext citizenDB)
        {
            this.citizenService = citizenService;
            this.citizenDB = citizenDB;
        }

        [HttpGet]
        public IEnumerable<Citizen> Get(
            [FromQuery] string sex = null,
            [FromQuery] int minAge = 0,
            [FromQuery] int maxAge = 200)
        {
                return from citizen in citizenDB.Citizens.ToList()
                       where (citizen.sex == sex || sex == null) && citizen.age >= minAge && citizen.age <= maxAge
                       select citizen;
            
        }

        [Route("{id}")]
        [HttpGet]
        public Citizen GetCitizenById([FromRoute] string id)
        {
            Citizen cit;
            string urlId = "http://testlodtask20172.azurewebsites.net/task/" + id;
            using (WebClient wc = new WebClient())
            {
                cit = JsonSerializer.Deserialize<Citizen>(wc.DownloadString(urlId));
                cit.id = id;
            }
            return cit;
        }
    }
}
