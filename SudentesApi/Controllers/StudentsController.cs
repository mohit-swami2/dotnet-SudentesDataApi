using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SudentesApi.Data;

namespace SudentesApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    //public static List<Students> Students = new List<Students>
    //{
    //    new Students
    //    {
    //        Id = 1,
    //        First_Name = "Mohit",
    //        Last_Name = "Swami",
    //        Roll_no = "34",
    //        Marks = 50
    //    },
    //    new Students
    //    {
    //        Id = 2,
    //        First_Name = "Rohit",
    //        Last_Name = "Soni",
    //        Roll_no = "45",
    //        Marks = 50
    //    }
    //};

    private readonly DataAccessClass _context;

    public StudentsController(DataAccessClass context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Students>>> Ger()
    {
        return Ok(await _context.Student.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<Students>>> Get(int id)
    {
        var DbStudent = await _context.Student.FindAsync(id);
        if(DbStudent is null)
        {
            return BadRequest("Id is not define");
        }
        else
        {
            return Ok(DbStudent);
        }
    }

    [HttpPost]
    public async Task<ActionResult<List<Students>>> Post(Students Request)
    {
        await _context.Student.AddAsync(Request);
        _context.SaveChanges();
        return Ok(await _context.Student.ToListAsync());
    }

    [HttpPut]
    public async Task<ActionResult<List<Students>>> Put(Students Request)
    {
        var stu = await _context.Student.FindAsync(Request.Id);
        if(stu is null)
        {
            return BadRequest("UnRecognised");
        }
        else
        {
            stu.First_Name = Request.First_Name;
            stu.Marks = Request.Marks;
            stu.Last_Name= Request.Last_Name;
        }
        _context.SaveChanges();
        return Ok(stu);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Students>>> Delete(int id)
    {
        var stu = await _context.Student.FindAsync(id);
        if(stu is null)
        {
            return BadRequest("Please give correct id");
        }
        else
        {
            _context.Student.Remove(stu);
            _context.SaveChanges(); 
        }
        return Ok("done");
    }
}   