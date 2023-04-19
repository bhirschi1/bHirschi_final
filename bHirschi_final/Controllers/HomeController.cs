using bHirschi_final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace bHirschi_final.Controllers
{
    public class HomeController : Controller
    {
        private IEntertainersRepository _repo { get; set; }
        //constructor
        public HomeController(IEntertainersRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Entertainers()
        {
            var ents = _repo.Entertainers
                .ToList();

            return View(ents); 
        }
        [HttpPost]
        public IActionResult Details(int entId)
        {
            var ent = _repo.Entertainers
                .FirstOrDefault(x => x.EntertainerID == entId);

            return View(ent);
        }

        [HttpPost]
        public IActionResult Edit(int entId)
        {
            var ent = _repo.Entertainers
                .FirstOrDefault(x => x.EntertainerID == entId);

            return View(ent);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        // rather than change the database to autogenerate the id like it should, I did a workaround that would
        // be changed before production in real life
        [HttpPost]
        public IActionResult Add(Entertainer newEnt)
        {
            int ssnAsInt;
            if (int.TryParse(newEnt.EntSSN, out ssnAsInt))
            {
                newEnt.EntertainerID = ssnAsInt - 10;
            }
            
            _repo.Add(newEnt);
            return RedirectToAction("Entertainers");
        }

        [HttpPost]
        public IActionResult Delete(int entId)
        {
            var entertainer = _repo.Entertainers.FirstOrDefault(e => e.EntertainerID == entId);
            if (entertainer == null)
            {
                return NotFound();
            }

            _repo.Delete(entertainer);
            return RedirectToAction("Entertainers");
        }

        // this is what's called when a record is edited
        [HttpPost]
        public IActionResult Save(Entertainer model)
        {
            if (ModelState.IsValid)
            {
                var existingEntertainer = _repo.Entertainers
                    .FirstOrDefault(x => x.EntertainerID == model.EntertainerID);

                if (existingEntertainer != null)
                {
                  
                    existingEntertainer.EntStageName = model.EntStageName;
                    existingEntertainer.EntPhoneNumber = model.EntPhoneNumber;
                    existingEntertainer.EntEMailAddress = model.EntEMailAddress;
                    existingEntertainer.EntStreetAddress = model.EntStreetAddress;
                    existingEntertainer.EntCity = model.EntCity;
                    existingEntertainer.EntState = model.EntState;
                    existingEntertainer.EntZipCode = model.EntZipCode;
                    existingEntertainer.EntWebPage = model.EntWebPage;
                    existingEntertainer.EntSSN = model.EntSSN;
                    existingEntertainer.DateEntered = model.DateEntered;

                    _repo.UpdateEntertainer(existingEntertainer);// Update the entertainer using the repository method

                    return RedirectToAction("Entertainers"); // Redirect to the list of entertainers (or any other desired action)
                }
            }

            return View("Edit", model); // If the model state is not valid or entertainer not found, return to the Edit view with the current model
        }


    }
}
