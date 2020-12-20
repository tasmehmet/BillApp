using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BillApp.Data;
using BillApp.Entity;
using BillApp.Business.Abstract;
using BillApp.Dto;
using Microsoft.AspNetCore.Identity;
using BillApp.Caching;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace BillApp.Web.Controllers
{
    public class BillsController : Controller
    {
        private readonly IBillService _billsManager;
        private UserManager<IdentityUser> _userManager;
        private readonly Business.Abstract.IRedisService _redisService;

        public BillsController(IBillService billsManager, UserManager<IdentityUser> userManager, Business.Abstract.IRedisService redisService)
        {
            _billsManager = billsManager;
            _userManager = userManager;
            _redisService = redisService;
        }

        // GET: Bills
        public IActionResult Index()
        {
            if (_redisService.KeyExists("Bills"))
            {
                var billsDto = _redisService.Get();
                return View(billsDto);
            }
            return View(_billsManager.GetAll());
        }

        // GET: Bills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bills = await _billsManager.GetById(id);
            if (bills == null)
            {
                return NotFound();
            }

            return View(bills);
        }

        // GET: Bills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bills/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CompanyName,TotalAmount,KdvAmount,KdvRate,Currency,BillNo,BillDate,CreateDate,UserId")] BillsDto model)
        {
            if (ModelState.IsValid)
            {
                var id = _userManager.GetUserId(User);
                model.IdentityUserId = id;
                _billsManager.Insert(model);

                _redisService.Set(model);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Bills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bills = await _billsManager.GetById(id);
            if (bills == null)
            {
                return NotFound();
            }
            return View(bills);
        }

        // POST: Bills/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,CompanyName,TotalAmount,KdvAmount,KdvRate,Currency,BillNo,BillDate,CreateDate")] BillsDto model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _billsManager.Update(model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillsExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Bills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bills = await _billsManager.GetById(id);
            if (bills == null)
            {
                return NotFound();
            }

            return View(bills);
        }

        // POST: Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bills = await _billsManager.GetById(id);
            if (bills == null)
            {
                return NotFound();
            }

            _billsManager.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool BillsExists(int id)
        {
            return _billsManager.GetAll().Any(e => e.Id == id);
        }
    }
}
