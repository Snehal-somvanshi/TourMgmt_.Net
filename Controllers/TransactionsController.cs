using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourMgmtApp.Models;

namespace TourMgmtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly TourdbContext _context;

        public TransactionsController(TourdbContext context)
        {
            _context = context;
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {
          if (_context.Transactions == null)
          {
              return NotFound();
          }
            return await _context.Transactions.ToListAsync();
        }

        [HttpGet,Route("ondate")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactionsonDate(DateTime startdate,DateTime enddate)
        {
            if (_context.Transactions == null)
            {
                return NotFound();
            }
            return await _context.Transactions.Where(t=>t.Paymentdate >= startdate && t.Paymentdate <enddate).ToListAsync();
        }

        [HttpGet, Route("onamount")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactionsonAmount(int amount)
        {
            if (_context.Transactions == null)
            {
                return NotFound();
            }
            return await _context.Transactions.Where(t => t.Amount> amount).ToListAsync();
        }


        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
          if (_context.Transactions == null)
          {
              return NotFound();
          }
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        
        private bool TransactionExists(int id)
        {
            return (_context.Transactions?.Any(e => e.TransactionId == id)).GetValueOrDefault();
        }
    }
}
