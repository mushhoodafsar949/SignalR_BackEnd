using CRUDinCore.Classes;
using CRUDinCore.Data;
using CRUDinCore.Hubs;
using CRUDinCore.Interfaces;
using CRUDinCore.Models;
using CRUDinCore.Models.DataModels;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace CRUDinCore.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentsfromCodefirstController : Controller
    {
        private readonly MyDbContext dbContext;
        private IHubContext<NotifyHub, ITypedHubClient> hubContext;
        public StudentsfromCodefirstController(MyDbContext myDbContext, IHubContext<NotifyHub, ITypedHubClient> context )
        {
            this.dbContext = myDbContext;
            hubContext= context;
        }

        [HttpGet]
        public async Task<IActionResult> getStudents()
        {
            return Ok( await dbContext.Students.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> addStudents(StudentAdd studentAdd)
        {
            var addstudent = new Student()
            {
                Id = studentAdd.Id,
                Name = studentAdd.Name,
                RollNumber = studentAdd.RollNumber,
                TeacherId = studentAdd.TeacherId,
                section = studentAdd.section
            };
            await dbContext.Students.AddAsync(addstudent);
            await dbContext.SaveChangesAsync();
            return Ok(addstudent);

        }

        [HttpGet]
        public string get()
        {
            string status = string.Empty;
            var message = new Message() { Type = "Warning", Information = "test it" };
            hubContext.Clients.All.BroadcastMessage(message);
            status = "success";

            return status;

        }

    }
}
