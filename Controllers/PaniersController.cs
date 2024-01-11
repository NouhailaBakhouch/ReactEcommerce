using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceReact.Models; // Assurez-vous d'ajuster le namespace en fonction de votre modèle de données
using EcommerceReact.Data;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaniersController : ControllerBase
    {
        private readonly ApplicationDbContext _context; // Assurez-vous d'ajuster le nom du contexte en fonction de votre application

        public PaniersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Paniers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Panier>>> GetPaniers()
        {
            return await _context.Paniers.ToListAsync();
        }

        // GET: api/Paniers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Panier>> GetPanier(int id)
        {
            var panier = await _context.Paniers.FindAsync(id);

            if (panier == null)
            {
                return NotFound();
            }

            return panier;
        }

        // POST: api/Paniers
        [HttpPost]
        public async Task<ActionResult<Panier>> PostPanier(Panier panier)
        {
            _context.Paniers.Add(panier);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPanier), new { id = panier.PanierId }, panier);
        }

        // PUT: api/Paniers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPanier(int id, Panier panier)
        {
            if (id != panier.PanierId)
            {
                return BadRequest();
            }

            _context.Entry(panier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PanierExists(id))
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

        // DELETE: api/Paniers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePanier(int id)
        {
            var panier = await _context.Paniers.FindAsync(id);
            if (panier == null)
            {
                return NotFound();
            }

            _context.Paniers.Remove(panier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PanierExists(int id)
        {
            return _context.Paniers.Any(e => e.PanierId == id);
        }
    }
}
