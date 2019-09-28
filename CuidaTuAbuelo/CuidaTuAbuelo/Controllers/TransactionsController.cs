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
            var transactionList =
                await _context.
                Transactions.
                Join(_context.Services, t => t.serviceId, sc => sc.serviceId, (t, s) => new { t, s }).
                Join(_context.Users, t => t.t.userId, u => u.id, (t, u) => new { t, u }).
                Join(_context.Products, t => t.t.t.productId, p => p.productId, (t, p) => new { t, p }).
                Select(s => new
                {
                    productDescription = s.p.description,
                    productName = s.p.name,
                    nourseName = s.t.u.name,
                    serviceDescription = s.t.t.s.description,
                    s.t.t.t.initialDate,
                    s.t.t.t.finalDate,
                    s.t.t.t.notes,
                    s.t.t.t.transactionScore,
                    s.t.t.t.transactionId,
                    transactionValue = string.Format("{0:N0}", s.t.t.t.transactionValue),
                    s.t.t.t.createdDate,
                    s.t.u.imageUrl
                }).OrderByDescending(o => o.createdDate).ToListAsync();

            return Json(new CommandResult<object>(true, "", transactionList));
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
            try
            {

                var transaction = await _context.Transactions.Where(w => w.transactionId == transactions.transactionId).FirstOrDefaultAsync();
                transaction.transactionScore = transactions.transactionScore;
                _context.Transactions.Update(transaction);
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

                transactions.createdDate = DateTime.Now;
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
