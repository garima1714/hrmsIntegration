using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewTimeSheetController : ControllerBase
    {
        HrmsIntegrationContext db = new HrmsIntegrationContext();
        // GET: api/ViewTimeSheet
        [HttpGet]
        public IActionResult Get(string empid)
        {
            try
            {
                var draft = 0;
                var pending = 0;
                var approved = 0;
                var rejected = 0;
                var timeSheetData = (from timeSheet in db.TimeSheet
                            join timeSheetItem in db.TimeSheetItem on timeSheet.Empid equals timeSheetItem.Empid
                            join timeSheetEntry in db.TimeSheetEntry
                            on new { a = timeSheetItem.Timestampid } equals new { a = timeSheetEntry.Timestampid }
                            where empid == timeSheetItem.Empid
                            select new
                            {
                                timeSheet.Empid,
                                timeSheet.Empname,
                                timeSheetEntry.Customer,
                                timeSheetEntry.Task,
                                timeSheetItem.Day,
                                timeSheetItem.Hours,
                                timeSheetItem.Status,
                                timeSheetItem.To,
                                timeSheetItem.From,
                                timeSheetEntry.Project,
                                timeSheetEntry.Company,
                            }).OrderBy(x => x.Day).ToList();

                foreach (var i in timeSheetData)
                {
                    if (i.Status == "draft")
                    {
                        draft++;
                    }
                    else if (i.Status == "pending")
                    {
                        pending++;
                    }
                    else if (i.Status == "approved")
                    {
                        approved++;
                    }
                    else if (i.Status == "rejected")
                    {
                        rejected++;
                    }
                }
                IDictionary<string, int> count = new Dictionary<string, int>();
                count.Add("draft", draft);
                count.Add("submitted", rejected);
                count.Add("pending", pending);
                count.Add("approved", approved);
                return Ok(new
                {
                    statusCode = 200,
                    message = "done",
                    data= count,timeSheetData

                    
                });
            }

            catch (Exception e)
            {
                return Ok(new
                {
                    Status = 500,
                    Message = e
                });
            }
        }

        // GET: api/ViewTimeSheet/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
        // POST: api/ViewTimeSheet
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ViewTimeSheet/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
