using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApplicationManagement.DbModel;

namespace ApplicationManagement.Controllers
{
    public class JobCircularsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobCircularsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: JobCirculars
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobCirculars.ToListAsync());
        }

        // GET: JobCirculars/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobCircular = await _context.JobCirculars
                .SingleOrDefaultAsync(m => m.Id == id);
            if (jobCircular == null)
            {
                return NotFound();
            }

            return View(jobCircular);
        }

        // GET: JobCirculars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobCirculars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostName,ApplicationFormat,Description,NoOfTotalAvailablePosts,NoticeImageFileUrl,EndDate,StartDate,Id,CreatedTime,CreatorUserId,LastModifiedTime,LastModifireUserId")] JobCircular jobCircular)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobCircular);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(jobCircular);
        }

        // GET: JobCirculars/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobCircular = await _context.JobCirculars.SingleOrDefaultAsync(m => m.Id == id);
            if (jobCircular == null)
            {
                return NotFound();
            }
            return View(jobCircular);
        }

        // POST: JobCirculars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("PostName,ApplicationFormat,Description,NoOfTotalAvailablePosts,NoticeImageFileUrl,EndDate,StartDate,Id,CreatedTime,CreatorUserId,LastModifiedTime,LastModifireUserId")] JobCircular jobCircular)
        {
            if (id != jobCircular.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobCircular);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobCircularExists(jobCircular.Id))
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
            return View(jobCircular);
        }

        // GET: JobCirculars/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobCircular = await _context.JobCirculars
                .SingleOrDefaultAsync(m => m.Id == id);
            if (jobCircular == null)
            {
                return NotFound();
            }

            return View(jobCircular);
        }

        // POST: JobCirculars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var jobCircular = await _context.JobCirculars.SingleOrDefaultAsync(m => m.Id == id);
            _context.JobCirculars.Remove(jobCircular);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool JobCircularExists(long id)
        {
            return _context.JobCirculars.Any(e => e.Id == id);
        }
    }
}
