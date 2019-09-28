using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CuidaTuAbuelo.DataAccess;
using CuidaTuAbuelo.Models;
using CuidaTuAbuelo.Logic;

namespace CuidaTuAbuelo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : Controller
    {
        private readonly CuidaTuAbueloContext _context;

        public TransactionsController(CuidaTuAbueloContext context)
        {
            _context = context;
        }
        // GET: api/Transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transactions>>> GetTransactions()
        {
            var transactionList = await _context.Transactions.ToListAsync();
            return Json(new CommandResult<List<Transactions>>(true, "", transactionList));
        }
        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transactions>> GetTransactions(int id)
        {
            var transactions = await _context.Transactions.FindAsync(id);

            if (transactions == null)
            {
                return NotFound();
            }

            return Json(new CommandResult<Transactions>(true, "", transactions));
        }
        // PUT: api/Transactions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactions(int id, Transactions transactions)
        {
            if (id != transactions.transactionId)
            {
                return BadRequest();
            }
            _context.Entry(transactions).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return Json(new CommandResult<Transactions>(true, "Transacción actualizada correctamente.", transactions));
            }
            catch (Exception ex)
            {
                return Json(new CommandResult<Transactions>(false, "Error editando la trasacción. " + ex.Message, transactions));
            }
        }
        // POST: api/Transactions
        [HttpPost]
        public async Task<ActionResult<Transactions>> PostTransactions(Transactions transactions)
        {
            try
            {

                _context.Transactions.Add(transactions);
                await _context.SaveChangesAsync();
                return Json(new CommandResult<Transactions>(true, "Transacción creada correctamente.", transactions));
            }
            catch (Exception ex)
            {
                return Json(new CommandResult<Transactions>(false, "Error al crear la transacción." + ex.Message, transactions));
            }
        }
        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Transactions>> DeleteTransactions(int id)
        {
            var transactions = await _context.Transactions.FindAsync(id);
            if (transactions == null)
            {
                return NotFound();
            }
            try
            {
                _context.Transactions.Remove(transactions);
                await _context.SaveChangesAsync();
                return Json(new CommandResult<Transactions>(true, "Transacción eliminada correctamente.", transactions));
            }
            catch (Exception ex)
            {
                return Json(new CommandResult<Transactions>(true, "Error eliminando la transacción.", transactions));
            }
        }
    }
}
