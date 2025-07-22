using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAppOneToOneRelationExample.Models;

namespace MVCAppOneToOneRelationExample.Controllers
{
    public class FamilyController : Controller
    {
        FamilyDbContext dc = new FamilyDbContext();
        public ActionResult Index()
        {
            Player p1 = new Player { PlayerId = 101, Name = "Sachin Tendulkar", Profession = "Cricket"};
            Player p2 = new Player { PlayerId = 102, Name = "MS Dhoni", Profession = "Cricket" };
            Player p3 = new Player { PlayerId = 103, Name = "Pele", Profession = "Football" };
            Player p4 = new Player { PlayerId = 104, Name = "Tiger Woods", Profession = "Golf" };

            Spouse s1 = new Spouse { PlayerId = 101, SpouseName = "Anjali", SpouseProfession = "Doctor" };
            Spouse s2 = new Spouse { PlayerId = 102, SpouseName = "Sakshi", SpouseProfession = "Hotel Maintainance" };
            Spouse s3 = new Spouse { PlayerId = 103, SpouseName = "Janette", SpouseProfession = "Real estate Agent" };
            Spouse s4 = new Spouse { PlayerId = 104, SpouseName = "Molly", SpouseProfession = "House Wife" };

            dc.Player.Add(p1); dc.Player.Add(p2); dc.Player.Add(p3); dc.Player.Add(p4);
            dc.Spouse.Add(s1); dc.Spouse.Add(s2); dc.Spouse.Add(s3); dc.Spouse.Add(s4);
            dc.SaveChanges();

            return View(dc.Player);
        }
    }
}