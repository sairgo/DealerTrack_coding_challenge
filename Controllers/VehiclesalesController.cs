using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesalesController : ControllerBase
    {
        public VehiclesalesController() {

        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Waiting for Post");
        }


        [HttpPost]
        public ActionResult PostCSV([FromForm] IFormFile csvFile) {
            try
            {
                if (csvFile != null)
                {

                    using System.IO.Stream csvStream = csvFile.OpenReadStream();
                    List<VehicleSales> result = ProcessCsv.CsvResult(csvStream);
                    return Ok(result);
                }
                else {
                    return BadRequest("You must send a File");
                }
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }

        }

    }
}
