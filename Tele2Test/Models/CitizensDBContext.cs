using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Tele2Test.Services;

namespace Tele2Test.Models
{
    public class CitizensDBContext : DbContext
    {
        public DbSet<Citizen> Citizens { get; set; }

        public CitizensDBContext(DbContextOptions options, JsonFileCitizenService citizenService)
            : base(options)
        {
            if (Citizens.ToList().Count == 0)
                foreach (Citizen citizen in citizenService.GetCitizens())
                {
                    Citizen tmpCit;
                    string urlId = "http://testlodtask20172.azurewebsites.net/task/" + citizen.id;
                    using (WebClient wc = new WebClient())
                    {
                        tmpCit = JsonSerializer.Deserialize<Citizen>(wc.DownloadString(urlId));
                        tmpCit.id = citizen.id;
                    }
                    Citizens.Add(tmpCit);
                }
            this.SaveChanges();
            //throw new Exception(citizenService.GetCitizens().Count().ToString());
        }

       
    }
}
