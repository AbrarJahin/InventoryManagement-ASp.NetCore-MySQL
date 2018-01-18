using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApplicationManagement.DbModel;

namespace ApplicationManagement.Controllers
{
    public class EntriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EntriesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Entries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entries.ToListAsync());
        }

        // GET: Entries/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entries
                .SingleOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // GET: Entries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntryDate,InitialCount,NameOfSupplier,AddressOfSupplier,DescriptionOfProduct,NumberOfSuppliedProduct,SuppliedProductUnitPrice,SuppliedProductTotalPrice,TotalNoOfProductAfterInserted,ReceiveDate,NameOfUser,AddressOfUser,DemandnoteNo,NumberOfReceivedProduct,TotalNoOfProductAfterdeduction,Id,CreatedTime,CreatorUserId,CreatorIPAddress,LastModifiedTime,LastModifireUserId,LastModifireIPAddress")] Entry entry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entry);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(entry);
        }

        // GET: Entries/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entries.SingleOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }
            return View(entry);
        }

        // POST: Entries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("EntryDate,InitialCount,NameOfSupplier,AddressOfSupplier,DescriptionOfProduct,NumberOfSuppliedProduct,SuppliedProductUnitPrice,SuppliedProductTotalPrice,TotalNoOfProductAfterInserted,ReceiveDate,NameOfUser,AddressOfUser,DemandnoteNo,NumberOfReceivedProduct,TotalNoOfProductAfterdeduction,Id,CreatedTime,CreatorUserId,CreatorIPAddress,LastModifiedTime,LastModifireUserId,LastModifireIPAddress")] Entry entry)
        {
            if (id != entry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntryExists(entry.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(entry);
        }

        // GET: Entries/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entries
                .SingleOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // POST: Entries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var entry = await _context.Entries.SingleOrDefaultAsync(m => m.Id == id);
            _context.Entries.Remove(entry);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EntryExists(long id)
        {
            return _context.Entries.Any(e => e.Id == id);
        }
    }
}
