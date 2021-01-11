using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewSample.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace ViewSample.Controllers
{


    public class HomeController : Controller
    {
        private readonly Context context;

        public HomeController (Context _context)
        {
            context = _context;
        }
        #region 讀取全部

        public async Task<IActionResult> Index()
        {
            return View(await context.Employee.ToListAsync());
        }
        #endregion

        #region 新增
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(Employee employee)
        {
            if (ModelState.IsValid)
            {
                context.Employee.Add(employee);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }


        #endregion

        #region 編輯
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await context.Employee.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [Route("Edit/{id}"),HttpPost,ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit(int id,Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                context.Update(employee);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        #endregion

        #region 顯示
        public async Task<IActionResult> Show(int id)
        {
            var employee = await context.Employee.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        #endregion
    }
}
