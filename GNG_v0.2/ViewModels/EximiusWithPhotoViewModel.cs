using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GNG_v0._2.ViewModels
{
    public class EximiusWithPhotoViewModel
    {
        [Required]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "You must enter a valid email.")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must enter a valid phone number.")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "You must enter a valid team Name within 50 characters.")]
        [Display(Name = "Team name")]
        [StringLength(50)]
        public string TeamName { get; set; }

        [Required(ErrorMessage = "You must enter a valid name.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter your in game name.")]
        [Display(Name = "Online Handle(Ingame Name)")]
        public string IGN { get; set; }

        [Required(ErrorMessage = "You must enter a valid IC.")]
        [Display(Name = "I.C Number(Nombor Kad Pengenalan")]
        public string IC { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "You must enter an IC sample.")]
        [Display(Name = "Uploaded IC")]
        public IFormFile Photo { get; set; }

        [Required(ErrorMessage = "Please select an option")]
        [Display(Name = "Race")]
        public string Race { get; set; }


        [Required(ErrorMessage = "Please select an option")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "You must enter a valid name.")]
        [Display(Name = "Full Name")]
        public string Member1_Name { get; set; }

        [Required(ErrorMessage = "Please enter your in game name.")]
        [Display(Name = "Online Handle(Ingame Name)")]
        public string Member1_IGN { get; set; }

        [Required(ErrorMessage = "You must enter a valid IC.")]
        [Display(Name = "I.C Number(Nombor Kad Pengenalan)")]
        public string Member1_IC { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "You must enter an IC sample.")]
        [Display(Name = "Uploaded IC")]
        public IFormFile Photo1 { get; set; }

        [Required(ErrorMessage = "You must enter a valid phone number.")]
        [Display(Name = "Contact Number")]
        public string Member1_ContactNumber { get; set; }

        [Required(ErrorMessage = "Please select an option")]
        [Display(Name = "Race")]
        public string Member1_Race { get; set; }

        [Required(ErrorMessage = "Please select an option")]
        [Display(Name = "State")]
        public string Member1_State { get; set; }

        [Required(ErrorMessage = "You must enter a valid name.")]
        [Display(Name = "Full Name")]
        public string Member2_Name { get; set; }

        [Required(ErrorMessage = "Please enter your in game name.")]
        [Display(Name = "Online Handle(Ingame Name)")]
        public string Member2_IGN { get; set; }

        [Required(ErrorMessage = "You must enter a valid IC.")]
        [Display(Name = "I.C Number(Nombor Kad Pengenalan)")]
        public string Member2_IC { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "You must enter an IC sample.")]
        [Display(Name = "Uploaded IC")]
        public IFormFile Photo2 { get; set; }

        [Required(ErrorMessage = "You must enter a valid phone number.")]
        [Display(Name = "Contact Number")]
        public string Member2_ContactNumber { get; set; }

        [Required(ErrorMessage = "Please select an option")]
        [Display(Name = "Race")]
        public string Member2_Race { get; set; }

        [Required(ErrorMessage = "Please select an option")]
        [Display(Name = "State")]
        public string Member2_State { get; set; }

        [Required(ErrorMessage = "You must enter a valid name.")]
        [Display(Name = "Full Name")]
        public string Member3_Name { get; set; }

        [Required(ErrorMessage = "Please enter your in game name.")]
        [Display(Name = "Online Handle(Ingame Name)")]
        public string Member3_IGN { get; set; }

        [Required(ErrorMessage = "You must enter a valid IC.")]
        [Display(Name = "I.C Number(Nombor Kad Pengenalan)")]
        public string Member3_IC { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "You must enter an IC sample.")]
        [Display(Name = "Uploaded IC")]
        public IFormFile Photo3 { get; set; }

        [Required(ErrorMessage = "You must enter a valid phone number.")]
        [Display(Name = "Contact Number")]
        public string Member3_ContactNumber { get; set; }

        [Required(ErrorMessage = "Please select an option")]
        [Display(Name = "Race")]
        public string Member3_Race { get; set; }

        [Required(ErrorMessage = "Please select an option")]
        [Display(Name = "State")]
        public string Member3_State { get; set; }

        [Required(ErrorMessage = "You must enter a valid name.")]
        [Display(Name = "Full Name")]
        public string Member4_Name { get; set; }

        [Required(ErrorMessage = "Please enter your in game name.")]
        [Display(Name = "Online Handle(Ingame Name)")]
        public string Member4_IGN { get; set; }

        [Required(ErrorMessage = "You must enter a valid IC.")]
        [Display(Name = "I.C Number(Nombor Kad Pengenalan)")]
        public string Member4_IC { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "You must enter an IC sample.")]
        [Display(Name = "Uploaded IC")]
        public IFormFile Photo4 { get; set; }

        [Required(ErrorMessage = "You must enter a valid phone number.")]
        [Display(Name = "Contact Number")]
        public string Member4_ContactNumber { get; set; }

        [Required(ErrorMessage = "Please select an option")]
        [Display(Name = "Race")]
        public string Member4_Race { get; set; }

        [Required(ErrorMessage = "Please select an option")]
        [Display(Name = "State")]
        public string Member4_State { get; set; }

        [Required]
        [Display(Name = "I understand this is an Early Access Pre-Release game, and that the game code is only for use for myself only.")]
        public bool Understand { get; set; }
    }
}
