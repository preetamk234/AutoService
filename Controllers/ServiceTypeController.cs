using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoService.Data;
using AutoService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoService.Controllers
{
    public class ServiceTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ServiceTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.ServiceTypes.ToList());
        }
        //Get 
        public IActionResult Create()
        {
            return View();
        }
        //Post 
        [HttpPost]
        public async Task<IActionResult> Create(ServiceType serviceType)
        {
            if (ModelState.IsValid)
            {
                _db.Add(serviceType);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceType);
        }
        //Get 
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var data = await _db.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (data == null)
                return NotFound();
            return View(data);

        }
        //Post 
        [HttpPost]
        public async Task<IActionResult> Edit (int id,ServiceType serviceType)
        {
            if (id != serviceType.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                _db.Update(serviceType);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceType);
        }
        //Get 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var data = await _db.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (data == null)
                return NotFound();
            return View(data);

        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var data = await _db.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (data == null)
                return NotFound();
            return View(data);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _db.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            _db.ServiceTypes.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //return View("~/ServciceType/Index");
        }
    }
}