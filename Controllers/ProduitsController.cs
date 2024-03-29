﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcommerceReact.Data;
using EcommerceReact.Models;
namespace EcommerceReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProduitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Produits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produit>>> GetProduits()
        {
            var produits = await _context.Produits.ToListAsync();

            if (produits == null || !produits.Any())
            {
                return NotFound();
            }

            return produits;
        }

        // GET: api/Produits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produit>> GetProduit(int id)
        {
            var produit = await _context.Produits.FindAsync(id);

            if (produit == null)
            {
                return NotFound();
            }

            return produit;
        }

        // PUT: api/Produits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduit(int id, Produit produit)
        {
            if (id != produit.ProduitId)
            {
                return BadRequest();
            }

            _context.Entry(produit).State = EntityState.Modified;
            produit.ImageUrl = "ClientApp/public/images/CarpetHomeBej.jpeg";

            _context.Entry(produit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduitExists(id))
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

        // POST: api/Produits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Produit>> PostProduit(Produit produit)
        {
            produit.ImageUrl = "ClientApp/public/images/CarpetHomeBej.jpeg";

            _context.Produits.Add(produit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduit", new { id = produit.ProduitId }, produit);
            _context.Produits.Add(produit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduit", new { id = produit.ProduitId }, produit);
        }

        // DELETE: api/Produits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduit(int id)
        {
            var produit = await _context.Produits.FindAsync(id);
            if (produit == null)
            {
                return NotFound();
            }

            _context.Produits.Remove(produit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProduitExists(int id)
        {
            return _context.Produits.Any(e => e.ProduitId == id);
        }
    }
}

