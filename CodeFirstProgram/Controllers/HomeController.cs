using CodeFirstProgram.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using System.Diagnostics;
using System.Xaml.Permissions;

namespace CodeFirstProgram.Controllers
{
    public class HomeController : Controller
    {
        public readonly StudentDBContext studentDB;

        public HomeController(StudentDBContext studentDB)
        {
            this.studentDB  = studentDB;
        }

        public IActionResult Index()
        {
            var list = studentDB.Students.ToList();
            return View(list);
        }
        
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {

            if (ModelState.IsValid)
            {
                await studentDB.Students.AddAsync(student);
                await studentDB.SaveChangesAsync();
                TempData["insert_success"] = "Record inserted successfully.";
                return RedirectToAction("Index");

            }
            return View();

        }

        public async Task<IActionResult> Details(int id)
        {

            if (id == null || studentDB.Students == null)
            {
                return NotFound();
            }

            var detail = await studentDB.Students.FirstOrDefaultAsync(x => x.Id == id );
            
            if(detail == null)
            {
                return NotFound();
            }
            return View(detail);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var edt = await studentDB.Students.FirstOrDefaultAsync(x => x.Id == id);
            return View(edt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int? id,Student std)
        {
            if (id == null || std == null) { return NotFound(); }
            if (id != std.Id) { return NotFound(); }

            if (ModelState.IsValid)
            {
            studentDB.Students.Update(std);
            TempData["update_success"] = "Record updated successfully.";
                await studentDB.SaveChangesAsync();
            return RedirectToAction("Index");

            }

            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || studentDB.Students == null)
            {
                return NotFound();
            }

            var ids = studentDB.Students.Where(x=>x.Id == id).FirstOrDefault();
            return View(ids);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            if (id == null || studentDB.Students == null)
            {
                return NotFound();
            }

            var ids = studentDB.Students.Where(x => x.Id == id).FirstOrDefault();
            Console.WriteLine("this id is from delete" + ids);
            studentDB.Students.Remove(ids);
            studentDB.SaveChanges();
            TempData["delete_success"] = "Record deleted successfully.";

            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
