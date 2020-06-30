using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerMastersController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public CustomerMastersController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerMaster>>> GetCustomerMaster()
        {
            return await _context.CustomerMaster.ToListAsync();
        }

        // GET: api/CustomerMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerMaster>> GetCustomerMaster(string id)
        {
            var customerMaster = await _context.CustomerMaster.FindAsync(id);

            if (customerMaster == null)
            {
                return NotFound();
            }

            return customerMaster;
        }

        // PUT: api/CustomerMasters/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerMaster(string id, CustomerMaster customerMaster)
        {
            if (id != customerMaster.CustCd)
            {
                return BadRequest();
            }

            _context.Entry(customerMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerMasterExists(id))
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

        // POST: api/CustomerMasters
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CustomerMaster>> PostCustomerMaster(CustomerMaster customerMaster)
        {
            _context.CustomerMaster.Add(customerMaster);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerMasterExists(customerMaster.CustCd))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomerMaster", new { id = customerMaster.CustCd }, customerMaster);
        }

        // DELETE: api/CustomerMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerMaster>> DeleteCustomerMaster(string id)
        {
            var customerMaster = await _context.CustomerMaster.FindAsync(id);
            if (customerMaster == null)
            {
                return NotFound();
            }

            _context.CustomerMaster.Remove(customerMaster);
            await _context.SaveChangesAsync();

            return customerMaster;
        }

        private bool CustomerMasterExists(string id)
        {
            return _context.CustomerMaster.Any(e => e.CustCd == id);
        }
    }
}
