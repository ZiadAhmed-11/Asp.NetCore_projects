using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CitiesManagerWebAPI.DataBaseContext;
using CitiesManagerWebAPI.Models;

namespace CitiesManagerWebAPI.Controllers.v2
{
    [ApiVersion("2.0")]

    
    public class CitiesController : CustomControllerBase
    {
        private readonly AppDbContext _context;

        public CitiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string?>>> GetCities()
        {
            if (_context.Cities == null)
            {
                return NotFound();
            }
            return await _context.Cities.Select(temp=>temp.CityName).ToListAsync();
        }


        private bool CityExists(Guid id)
        {
            return (_context.Cities?.Any(e => e.CityID == id)).GetValueOrDefault();
        }
    }
}
