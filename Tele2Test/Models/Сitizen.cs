using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace Tele2Test.Models
{
    public class Citizen
    { 
        public string id { get; set; }
        //{
        //    get { return this.id; }
        //    set
        //    {
        //        this.id = value;
        //        using (WebClient wc = new WebClient())
        //        {
        //            string urlID = "http://testlodtask20172.azurewebsites.net/task/" + value;
        //            JsonDocument doc = JsonDocument.Parse(urlID);
        //            JsonElement root = doc.RootElement;
        //            var citizenTmp = root[0];
        //            this.age = int.Parse(citizenTmp.GetProperty("age").ToString());
        //        }
        //    }
        //}
        public string name { get; set; }
        public string sex { get; set; }

        public int age { get; set; }
        public override string ToString() => JsonSerializer.Serialize<Citizen>(this);
    }


    //public class CitizenWithAge : Citizen
    //{
    //    public CitizenWithAge() { }
    //    public CitizenWithAge(Citizen citizen)
    //    {
    //        this.id = citizen.id;
    //        this.name = citizen.name;
    //        this.sex = citizen.sex;
    //    }
    //    public int age { get; set; }
    //}


}
