using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1API.Models;
using F1API.Wrappers;
using F1API.Filters;
using F1API.Helpers;

namespace F1API.Controllers
{
  [Route("f1api/[controller]")]
  [ApiController]
  public class DriversController : ControllerBase
  {
    private readonly F1Context _db;
    private readonly IUriService _uriService;

    public DriversController(F1Context db, IUriService uriService)
    {
      _db = db;
      _uriService = uriService;
    }

    // GET f1api/drivers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Driver>>> Get([FromQuery] PaginationFilter filter, string name, int age, string team)
    {
      var route = Request.Path.Value;
      var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
      var query = _db.Drivers.AsQueryable();

      if (name != null)
      {
        query = query.Where(e => e.Name.Contains(name));
      }

      if (age > 0)
      {
        query = query.Where(e => e.Age >= age);
      }

      if (team != null)
      {
        query = query.Where(e => e.Team.Contains(team));
      }

      var pagedData = await query
        .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
        .Take(validFilter.PageSize)
        .ToListAsync();
      var totalRecords = await _db.Drivers.CountAsync();
      var pagedResponse = PaginationHelper.CreatePagedReponse<Driver>(pagedData, validFilter, totalRecords, _uriService, route);
      return Ok(pagedResponse);
    }

    // POST f1api/drivers
    [HttpPost]
    public async Task<ActionResult<Driver>> Post(Driver driver)
    {
      _db.Drivers.Add(driver);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetDriver), new { id = driver.DriverId }, driver);
    }

    // GET: f1api/drivers/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Driver>> GetDriver(int id)
    {
        var driver = await _db.Drivers.FindAsync(id);

        if (driver == null)
        {
            return NotFound();
        }

        return Ok(new Response<Driver>(driver));
    }

    // PUT: f1api/drivers/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Driver driver)
    {
      if (id != driver.DriverId)
      {
        return BadRequest();
      }

      _db.Entry(driver).State = EntityState.Modified;
      
      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!DriverExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // DELETE: f1api/drivers/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDriver(int id)
    {
      var driver = await _db.Drivers.FindAsync(id);
      if (driver == null)
      {
        return NotFound();
      }

      _db.Drivers.Remove(driver);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    private bool DriverExists(int id)
    {
      return _db.Drivers.Any(e => e.DriverId == id);
    }
  }
}
