using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
//using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateBoundedController : ControllerBase
    {
        HrmsIntegrationContext db = new HrmsIntegrationContext();
        // GET: api/DateBounded
        [HttpGet]
        public IActionResult Get(string empid, DateTime fromDate, DateTime toDate)
        {

            try
            {
                var q = (from pd in db.TimeSheet
                         join od in db.TimeSheetItem on pd.Empid equals od.Empid
                         join ct in db.TimeSheetEntry
                         on new { a = od.Timestampid } equals new { a = ct.Timestampid }
                         where empid==od.Empid
                         where fromDate >= od.From &&
                          toDate <= od.To
                         select new
                         {
                             pd.Empid,
                             pd.Empname,
                             ct.Customer,
                             ct.Task,
                             od.Day,
                             od.Hours,
                             od.Status,
                             od.To,
                             od.From,
                             ct.Project,
                             ct.Company,
                         }).OrderBy(x => x.Day).ToList();

                return Ok(new
                {
                    statusCode = 200,
                    message = "done",
                    data = q
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

        // GET: api/DateBounded/5
        [HttpGet("{id}", Name = "Get")]
        //public ActionResult<IEnumerable<string>> Get(int id, string to, string from, string day)
        //{
        //    try
        //    {
        //        var itm = db.TimeSheet.Where(e => e.EmpId == id && e.TimeSheetItem.To == to && e.TimeSheetItem.From == from && e.TimeSheetItem.Day == day)
        //        .Select(a => new
        //        {
        //            a.EmpId,
        //            a.EmployeeName,
        //            a.TimeSheetItem.To,
        //            a.TimeSheetItem.From,
        //            a.TimeSheetItem.Day,
        //            a.TimeSheetItem.Hours,
        //            a.TimeSheetEntry.Customer,
        //            a.TimeSheetEntry.Company,
        //            a.TimeSheetEntry.Project,
        //            a.TimeSheetEntry.Task,
        //            a.Status,
        //        }).ToList();
        //        Console.WriteLine(itm);
        //        return Ok(itm);
        //    }
        //    catch (Exception e)
        //    {
        //        return Ok(BadRequest(new { error = e }));
        //        //Console.WriteLine(BadRequest(new { error = e }));
        //    }
        //}

        // POST: api/DateBounded
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/DateBounded/5
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
