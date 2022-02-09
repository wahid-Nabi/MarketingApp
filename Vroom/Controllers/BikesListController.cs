using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vroom.Models;

namespace Vroom.Controllers
{
    public class BikesListController : Controller
    {
        private readonly VroomDbContext _dbContex;
        public BikesListController(VroomDbContext context)
        {
            this._dbContex = context;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddBikes()
        {

            var ModelNames = new SelectList(_dbContex.BikeModels.Select(x => x.ModelName).ToList());
            
            ViewBag.ListOfModel = ModelNames; 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddBikes(BikeModel model)
        {
            //if(string.IsNullOrEmpty(model.ModelName))
            //{
            //    ViewBag.Message = "Select Model name";
            //    return View();
            //}
            if (string.IsNullOrEmpty(model.ToString()))
            {
                return RedirectToAction("Bikes", "Home");
            }
            if (ModelState.IsValid)
            {
                await _dbContex.BikeModels.AddAsync(model);
                await _dbContex.SaveChangesAsync();

                return RedirectToAction("Bikes", "Home");
            }
            else
            {
                
                return View();
            }
           
        }
       
        [HttpGet]
       public async  Task<ActionResult> Delete(long Id)
        {
            if (!string.IsNullOrEmpty(Id.ToString()))
            {  
            var Bike = _dbContex.BikeModels.Find(Id);

            if (!string.IsNullOrEmpty(Bike.BikeModelId.ToString()))
            {
                _dbContex.BikeModels.Remove(Bike);
                await _dbContex.SaveChangesAsync();
                return RedirectToAction("Bikes", "Home");
            }
                else
                {
                    return View(Bike);
                }
       }
            return View();
        }
        [HttpGet]
        public ActionResult Add_Update(long? Id)
        {
            if (Id != 0 || Id != null)
            {
                var bikeExists = _dbContex.BikeModels.Find(Id);
                if(bikeExists != null)
                {
                    return View(bikeExists);
                }
                else
                {

                    //send add page
                    return RedirectToAction("AddBikes");

                }
            }
            return View();
        }
        [HttpPost]        
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add_Update(BikeModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                 var GetBike =  _dbContex.BikeModels.FirstOrDefault(x => x.BikeModelId == model.BikeModelId);
                    if (GetBike != null)
                    {
                        GetBike.Name = model.Name;
                        GetBike.ModelName = model.ModelName;
                        GetBike.Description = model.Description;
                        await _dbContex.SaveChangesAsync();
                        TempData["Message"] = "Success Updated";
                        return RedirectToAction("Bikes", "Home");
                    }

                    else
                    {
                        TempData["Message"] = "Not Found";
                        return RedirectToAction("Bikes","Home");
                    }
                   
                }
                else
                {
                    TempData["Message"] = "Invalid";
                    return View();
                }
            }
            return View();
        }
    }
}
