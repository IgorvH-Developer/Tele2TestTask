using System;
using Xunit;
using Tele2Test.Controllers;
using Tele2Test.Services;
using Tele2Test.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Tele2Test;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace TestTele2APIs
{
    public class UnitTest1
    {
        private DbContextOptions<CitizensDBContext> option = new DbContextOptionsBuilder<CitizensDBContext>()
            .UseInMemoryDatabase(databaseName: "CitiDataBase")
            .Options;
        private JsonFileCitizenService citizenService = new JsonFileCitizenService();
        private CitizensDBContext _context { get; }
        private CitizensController citizenController;
        public UnitTest1()
        {
            this._context = new CitizensDBContext(option, citizenService);
            this.citizenController = new CitizensController(citizenService, _context);
        }

        [Fact]
        public void TestGetAllCitizens()
        {
            List<Citizen> citizens = citizenService.GetCitizens().ToList();

            List<Citizen> citizensInmemory = _context.Citizens.ToList();

            bool equalLists = false;
            if (citizensInmemory.Count() == citizens.Count())
                equalLists = true;

            Assert.Equal(true, equalLists);
        }

        [Fact]
        public void TestGetCitizenById()
        {
            Citizen citizen1 = new Citizen()
            {
                id = "qyfgqiyhwfoq1",
                name = "Stan Smith",
                sex = "male",
                age = 30
            };

            Citizen responseCitizen = citizenController.GetCitizenById("qyfgqiyhwfoq1");
            Assert.Equal(citizen1.id, responseCitizen.id);

        }
    }
}
