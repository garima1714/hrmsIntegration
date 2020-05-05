using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Custom_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApplication1.Models;

namespace backend.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class SubmitTimeSheetController : ControllerBase
    {
        HrmsIntegrationContext db = new HrmsIntegrationContext();
        [Route("save/sheet")]
        [HttpPost]
        public IActionResult save([FromBody] AddTimeSheet items)
        {
            try
            {
                TimeSheet timeSheet = new TimeSheet();
                

                var existingEmployeee = db.TimeSheet.FirstOrDefault(item => items.Empid==item.Empid);
                if (existingEmployeee == null)
                {
                    timeSheet.Empid = items.Empid;
                    timeSheet.Empname = items.Empname;
                    db.Add(timeSheet);
                    db.SaveChanges();
                }
                foreach(TimeSheetData value in items.data)
                {
                    TimeSheetItem timeSheetItem = new TimeSheetItem();
                    TimeSheetEntry timeSheetEntry = new TimeSheetEntry();
                    timeSheetItem.Hours = value.Hours;
                    timeSheetItem.Empid = items.Empid;
                    timeSheetItem.Status = "Drafted";
                    timeSheetItem.Submittedto = value.Submittedto;
                    timeSheetItem.To = items.To;
                    timeSheetItem.From = items.From;
                    timeSheetItem.Date = value.Date;
                    db.Add(timeSheetItem);
                    db.SaveChanges();
                    int index = timeSheetItem.Timestampid;

                    timeSheetEntry.Customer = value.Customer;
                    timeSheetEntry.Company = value.Company;
                    timeSheetEntry.Task = value.Task;
                    timeSheetEntry.Project = value.Project;
                    timeSheetEntry.Timestampid = index;

                    db.Add(timeSheetEntry);
                    db.SaveChanges();
                }
                
               

            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return Ok();
        }

        //[Route("submit/sheets")]
        //[HttpPost]
        //public IActionResult submit([FromHeader] Entry cred, [FromBody] AddTimeSheet value)
        //{
        //    try
        //    {
        //        Timesheetv2 timeSheet = new Timesheetv2();
        //        Timesheetitemv2 timeSheetItem = new Timesheetitemv2();
        //        Timesheetentryv2 timeSheetEntry = new Timesheetentryv2();

        //        var existingEmployeee = db.Timesheetv2.FirstOrDefault(item => cred.EmpId == item.EmpId);
        //        if (existingEmployeee == null)
        //        {
        //            timeSheet.EmpId = cred.EmpId;
        //            timeSheet.EmpName = cred.EmpName;
        //            db.Add(timeSheet);
        //            db.SaveChanges();
        //        }

        //        timeSheetItem.Hours = value.Hours;
        //        timeSheetItem.EmpId = cred.EmpId;
        //        timeSheetItem.Status = "Submitted";
        //        timeSheetItem.Submittedto = value.Submittedto;
        //        timeSheetItem.ToDate = cred.ToDate;
        //        timeSheetItem.FromDate = cred.FromDate;
        //        timeSheetItem.Date = value.Date;
        //        db.Add(timeSheetItem);
        //        db.SaveChanges();
        //        int index = timeSheetItem.TimestampId;

        //        timeSheetEntry.Customer = value.Customer;
        //        timeSheetEntry.Company = value.Company;
        //        timeSheetEntry.Task = value.Task;
        //        timeSheetEntry.Project = value.Project;
        //        timeSheetEntry.Timestampid = index;

        //        db.Add(timeSheetEntry);
        //        db.SaveChanges();


        //    }
        //    catch (Exception e)
        //    {
        //        Console.Write(e);
        //    }
        //    return Ok();
        //}
    }
}