﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StageEs1.Data;

namespace StageEs1.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AziendaDbContext _context;

        public CustomerController(AziendaDbContext context)
        {
            _context = context;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _context.Customers
                                          .Select(c => new
                                          {
                                              c.CustomerId,
                                              c.RagioneSociale,
                                              c.PIVA,
                                              c.CodFisc,
                                              c.IndirizzoCompleto
                                          })
                                          .ToListAsync();
            return Ok(customers);
        }

        // GET: api/customers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers
                                         .Where(c => c.CustomerId == id)
                                         .Select(c => new
                                         {
                                             c.CustomerId,
                                             c.RagioneSociale,
                                             c.PIVA,
                                             c.CodFisc,
                                             c.IndirizzoCompleto
                                         })
                                         .FirstOrDefaultAsync();

            if (customer == null)
            {
                return NotFound(new { message = "Cliente non trovato" });
            }

            return Ok(customer);
        }

        // POST: api/customers
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] Customer customer)
        {
            if (await _context.Customers.AnyAsync(c => c.PIVA == customer.PIVA))
            {
                return Conflict(new { message = "Un cliente con questa Partita IVA esiste già" });
            }

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerId }, customer);
        }

        // PUT: api/customers/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer updatedCustomer)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound(new { message = "Cliente non trovato" });
            }

            customer.RagioneSociale = updatedCustomer.RagioneSociale;
            customer.CodFisc = updatedCustomer.CodFisc;
            customer.Citta = updatedCustomer.Citta;
            customer.Cap = updatedCustomer.Cap;
            customer.Provincia = updatedCustomer.Provincia;
            customer.Via = updatedCustomer.Via;

            await _context.SaveChangesAsync();

            return Ok("Cliente aggiornato con successo");
        }

        // DELETE: api/customers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound(new { message = "Cliente non trovato" });
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return Ok("Cliente eliminato con successo");
        }
    }
}
