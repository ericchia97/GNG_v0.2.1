using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GNG_v0._2.Models;
using GNG_v0._2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace GNG_v0._2.Controllers
{
    public class EsportsController : Controller
    {
        private readonly EximiusParticipantRepository _eximiusParticipantRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EsportsController(EximiusParticipantRepository eximiusParticipantRepository,
                                    IWebHostEnvironment webHostEnvironment)
        {
            _eximiusParticipantRepository = eximiusParticipantRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize]
        [HttpGet]
        public ViewResult Eximius()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Eximius(EximiusWithPhotoViewModel eximiusWithPhotoViewModel)
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = null;
                string uniqueFileName1 = null;
                string uniqueFileName2 = null;
                string uniqueFileName3 = null;
                string uniqueFileName4 = null;
                if (eximiusWithPhotoViewModel.Photo!= null)
                {
                    if (string.IsNullOrWhiteSpace(_webHostEnvironment.WebRootPath))
                    {
                        _webHostEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                    }
                    string uploadedtoFolder = Path.Combine(_webHostEnvironment.WebRootPath, "StoredImages");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + eximiusWithPhotoViewModel.Photo.FileName;
                    string filepath = Path.Combine(uploadedtoFolder, uniqueFileName);
                    eximiusWithPhotoViewModel.Photo.CopyTo(new FileStream(filepath, FileMode.Create));
                }
                if (eximiusWithPhotoViewModel.Photo1 != null)
                {
                    if (string.IsNullOrWhiteSpace(_webHostEnvironment.WebRootPath))
                    {
                        _webHostEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                    }
                    string uploadedtoFolder1 = Path.Combine(_webHostEnvironment.WebRootPath, "StoredImages");
                    uniqueFileName1 = Guid.NewGuid().ToString() + "_" + eximiusWithPhotoViewModel.Photo1.FileName;
                    string filepath1 = Path.Combine(uploadedtoFolder1, uniqueFileName1);
                    eximiusWithPhotoViewModel.Photo1.CopyTo(new FileStream(filepath1, FileMode.Create));
                }
                if (eximiusWithPhotoViewModel.Photo2 != null)
                {
                    if (string.IsNullOrWhiteSpace(_webHostEnvironment.WebRootPath))
                    {
                        _webHostEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                    }
                    string uploadedtoFolder2 = Path.Combine(_webHostEnvironment.WebRootPath, "StoredImages");
                    uniqueFileName2 = Guid.NewGuid().ToString() + "_" + eximiusWithPhotoViewModel.Photo2.FileName;
                    string filepath2 = Path.Combine(uploadedtoFolder2, uniqueFileName2);
                    eximiusWithPhotoViewModel.Photo2.CopyTo(new FileStream(filepath2, FileMode.Create));
                }
                if (eximiusWithPhotoViewModel.Photo3 != null)
                {
                    if (string.IsNullOrWhiteSpace(_webHostEnvironment.WebRootPath))
                    {
                        _webHostEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                    }
                    string uploadedtoFolder3 = Path.Combine(_webHostEnvironment.WebRootPath, "StoredImages");
                    uniqueFileName3 = Guid.NewGuid().ToString() + "_" + eximiusWithPhotoViewModel.Photo3.FileName;
                    string filepath3 = Path.Combine(uploadedtoFolder3, uniqueFileName3);
                    eximiusWithPhotoViewModel.Photo3.CopyTo(new FileStream(filepath3, FileMode.Create));
                }
                if (eximiusWithPhotoViewModel.Photo4 != null)
                {
                    if (string.IsNullOrWhiteSpace(_webHostEnvironment.WebRootPath))
                    {
                        _webHostEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                    }
                    string uploadedtoFolder4 = Path.Combine(_webHostEnvironment.WebRootPath, "StoredImages");
                    uniqueFileName4 = Guid.NewGuid().ToString() + "_" + eximiusWithPhotoViewModel.Photo4.FileName;
                    string filepath4 = Path.Combine(uploadedtoFolder4, uniqueFileName4);
                    eximiusWithPhotoViewModel.Photo4.CopyTo(new FileStream(filepath4, FileMode.Create));
                }

                ExismiusViewModel newParticipant = new ExismiusViewModel
                {
                    Id = eximiusWithPhotoViewModel.Id,
                    Email = eximiusWithPhotoViewModel.Email,
                    ContactNumber = eximiusWithPhotoViewModel.ContactNumber,
                    TeamName = eximiusWithPhotoViewModel.TeamName,
                    FullName = eximiusWithPhotoViewModel.FullName,
                    IGN = eximiusWithPhotoViewModel.IGN,
                    IC = eximiusWithPhotoViewModel.IC,
                    PhotoPath = uniqueFileName,
                    Race = eximiusWithPhotoViewModel.Race,
                    State = eximiusWithPhotoViewModel.State,
                    Member1_Name = eximiusWithPhotoViewModel.Member1_Name,
                    Member1_IGN = eximiusWithPhotoViewModel.Member1_IGN,
                    Member1_IC = eximiusWithPhotoViewModel.Member1_IC,
                    PhotoPath1 = uniqueFileName1,
                    Member1_ContactNumber = eximiusWithPhotoViewModel.Member1_ContactNumber,
                    Member1_Race = eximiusWithPhotoViewModel.Member1_Race,
                    Member1_State = eximiusWithPhotoViewModel.Member1_State,
                    Member2_Name = eximiusWithPhotoViewModel.Member2_Name,
                    Member2_IGN = eximiusWithPhotoViewModel.Member2_IGN,
                    Member2_IC = eximiusWithPhotoViewModel.Member2_IC,
                    PhotoPath2 = uniqueFileName2,
                    Member2_ContactNumber = eximiusWithPhotoViewModel.Member2_ContactNumber,
                    Member2_Race = eximiusWithPhotoViewModel.Member2_Race,
                    Member2_State = eximiusWithPhotoViewModel.Member2_State,
                    Member3_Name = eximiusWithPhotoViewModel.Member3_Name,
                    Member3_IGN = eximiusWithPhotoViewModel.Member3_IGN,
                    Member3_IC = eximiusWithPhotoViewModel.Member3_IC,
                    PhotoPath3 = uniqueFileName3,
                    Member3_ContactNumber = eximiusWithPhotoViewModel.Member3_ContactNumber,
                    Member3_Race = eximiusWithPhotoViewModel.Member3_Race,
                    Member3_State = eximiusWithPhotoViewModel.Member3_State,
                    Member4_Name = eximiusWithPhotoViewModel.Member4_Name,
                    Member4_IGN = eximiusWithPhotoViewModel.Member4_IGN,
                    Member4_IC = eximiusWithPhotoViewModel.Member4_IC,
                    PhotoPath4 = uniqueFileName4,
                    Member4_ContactNumber = eximiusWithPhotoViewModel.Member4_ContactNumber,
                    Member4_Race = eximiusWithPhotoViewModel.Member4_Race,
                    Member4_State = eximiusWithPhotoViewModel.Member4_State
                };
                _eximiusParticipantRepository.Register(newParticipant);
                ViewBag.Title = "Thank you for your registration!";
                ViewBag.Message = "You wil now redirected to home page.";
                return RedirectToAction("EximiusParticipantConfirmation",  new { id = newParticipant.Id } );
            }

            return View();
        }

        //Unable to access eximius participant confirmation page as getparticipant returns to string instead of integer
        public ViewResult EximiusParticipantConfirmation(int? id)
        {
            EximiusConfirmationViewModel eximiusConfirmationViewModel = new EximiusConfirmationViewModel()
            {
                Info_details = _eximiusParticipantRepository.GetParticipant(id ?? 2004),
                PageTitle = "Employee Details"
            };
            return View(eximiusConfirmationViewModel);
        }
    }
}
