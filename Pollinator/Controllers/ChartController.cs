using Pollinator.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



namespace Pollinator.Controllers
{
    public class ChartController : Controller
    {

        public ActionResult Chart()
        {
            List<DataPoint> dataPoints = new List<DataPoint>{
                new DataPoint(10, 20),
                new DataPoint(20, 70),
                // new DataPoint(30, 10),

            };

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }


    }
}