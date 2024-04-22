﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Uppgift12_Garage20.Data;
using Uppgift12_Garage20.Models;
using Uppgift12_Garage20.ViewModels;

namespace Uppgift12_Garage20.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        public decimal PricePerHour { get; set; } = 30.00m;

        private readonly GarageContext _context;

        public ParkedVehiclesController(GarageContext context)
        {
            _context = context;
        }

        // Validates wether the provided registration number is unique in the ParkedVehicle table
        private async Task<bool> IsRegistrationNumberUnique(string registrationNumber)
        {
            var parkedVehicle = await _context.ParkedVehicle
               .FirstOrDefaultAsync(v => v.RegistrationNumber.ToLower() == registrationNumber.ToLower());

            return parkedVehicle == null;
        }

        // GET: ParkedVehicles
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParkedVehicle
                .Select(vehicle => new VehicleSummaryViewModel(vehicle))
                .ToListAsync());
        }

        // GET: ParkedVehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.ParkedVehicleId == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }

        /// <summary>
        /// Displays the view for parking a new vehicle.
        /// </summary>
        /// <returns>The view for parking a vehicle.</returns>
        public IActionResult Park()
        {
            return View();
        }

        /// <summary>
        /// Adds a new parked vehicle
        /// </summary>s
        /// <param name="parkedVehicle">The vehicle to park</param>
        /// <returns>The action result.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Park([Bind("ParkedVehicleId,VehicleType,RegistrationNumber,Color,Make,Model,NumberOfWheels")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                bool isUnique = await IsRegistrationNumberUnique(parkedVehicle.RegistrationNumber);
                if (isUnique)
                {
                    _context.Add(parkedVehicle);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("ParkingError", "A vehicle with that registration number is already in the garage");
                }
            }
            
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParkedVehicleId,VehicleType,RegistrationNumber,Color,Make,Model,NumberOfWheels,ArrivalTime")] ParkedVehicle parkedVehicle)
        {
            if (id != parkedVehicle.ParkedVehicleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkedVehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkedVehicleExists(parkedVehicle.ParkedVehicleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                // For a successful edit, redirect to details page with success message
                TempData["success"] = $"Successfully edited vehicle <b>{parkedVehicle.RegistrationNumber}</b>";
                //return RedirectToAction(nameof(Index));
                return RedirectToAction(nameof(Details), new { id = parkedVehicle.ParkedVehicleId });
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/EndParking/5
        public async Task<IActionResult> EndParking(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.ParkedVehicleId == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/EndParking/5
        [HttpPost, ActionName("EndParking")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnEndParkingConfirmed(int id)
        {
            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            if (parkedVehicle != null)
            {
                _context.ParkedVehicle.Remove(parkedVehicle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: ParkedVehicles/Receipt/5
        public async Task<IActionResult> Receipt(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.ParkedVehicleId == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            var receiptModel = new Receipt(parkedVehicle.ParkedVehicleId,
                    parkedVehicle.RegistrationNumber,
                    parkedVehicle.ArrivalTime,
                    PricePerHour);

            return View(receiptModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private bool ParkedVehicleExists(int id)
        {
            return _context.ParkedVehicle.Any(e => e.ParkedVehicleId == id);
        }
    }
}
