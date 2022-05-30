using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiPart.Auth;
using ApiPart.Models;
using Microsoft.AspNetCore.Authorization;

namespace ApiPart.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]
    public class GigsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GigsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Gigs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gig>>> GetGigs()
        {
          if (_context.Gigs == null)
          {
              return NotFound();
          }
            return await _context.Gigs.ToListAsync();
        }

        // GET: api/Gigs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gig>> GetGig(int id)
        {
          if (_context.Gigs == null)
          {
              return NotFound();
          }
            var gig = await _context.Gigs.FindAsync(id);

            if (gig == null)
            {
                return NotFound();
            }

            return gig;
        }

        // PUT: api/Gigs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [Authorize(Roles = "Admin,Freelancer")]
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGig(int id, Gig gig)
        {
            if (id != gig.GigId)
            {
                return BadRequest();
            }

            _context.Entry(gig).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GigExists(id))
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

        // POST: api/Gigs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [Authorize(Roles = "Admin,Freelancer")]
        [HttpPost]
        public async Task<ActionResult<Gig>> PostGig(Gig gig)
        {
          if (_context.Gigs == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Gigs'  is null.");
          }
            _context.Gigs.Add(gig);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGig", new { id = gig.GigId }, gig);
        }

        // DELETE: api/Gigs/5
        [Authorize(Roles = "Admin,Freelancer")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGig(int id)
        {
            if (_context.Gigs == null)
            {
                return NotFound();
            }
            var gig = await _context.Gigs.FindAsync(id);
            if (gig == null)
            {
                return NotFound();
            }

            _context.Gigs.Remove(gig);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GigExists(int id)
        {
            return (_context.Gigs?.Any(e => e.GigId == id)).GetValueOrDefault();
        }
    }
}
