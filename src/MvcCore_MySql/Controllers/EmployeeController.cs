using Microsoft.AspNetCore.Mvc;
using MvcCore_MySql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore_MySql.Controllers
{
    public class EmployeeController : Controller
    {
        public async Task<IActionResult> Create() 
        {
            Employee body = new Employee();
            body.Name = "Mithun";
            body.Address = "aaaaa";
            body.PhoneNo = "0123423423";
            using (var db = new AppDb())
            {
                await db.Connection.OpenAsync();
                body.Db = db;
                await body.InsertAsync();
                return new OkObjectResult(body);
            }
        }
    }
}
