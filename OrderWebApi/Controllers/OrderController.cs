using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderWebApi.Data;

namespace OrderWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private IApplicationDbContext _context;
        public OrderController(IApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Entities.Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChanges();
            return Ok(order.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _context.Orders.ToListAsync();
            if (customers == null) return NotFound();
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _context.Orders.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (customer == null) return NotFound();
            return Ok(customer);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _context.Orders.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (customer == null) return NotFound();
            _context.Orders.Remove(customer);
            await _context.SaveChanges();
            return Ok(customer.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Entities.Order orderData)
        {
            var order = _context.Orders.Where(a => a.Id == id).FirstOrDefault();

            if (order == null) return NotFound();
            else
            {
                order.OrderId = orderData.OrderId;
                order.OrderOn = orderData.OrderOn;
                order.OrderDetails = orderData.OrderDetails;
                await _context.SaveChanges();
                return Ok(order.Id);
            }
        }
    }
}
