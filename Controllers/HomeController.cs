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


    }
}
