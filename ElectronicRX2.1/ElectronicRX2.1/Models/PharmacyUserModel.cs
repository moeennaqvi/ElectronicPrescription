using ElectronicRX2._1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.Models
{
    public class PharmacyUserSearchViewModel
    {
        public string condition { get; set; }
        public string value { get; set; }
    }

    public class PharmacyUserModel
    {
        public string PharmacyUserID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Email ID")]
        public string EmailId { get; set; }

        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public string PharmacyName { get; set; }
        public string PharmacyID { get; set; }

        public ApplicationUser GetUser()
        {
            var user = new ApplicationUser()
            {
                UserName = this.EmailId,
                UserType = "PharmacyUser",
                Email = this.EmailId,
                Name = this.FirstName + " " + this.LastName,
                PhoneNum = this.PhoneNumber,
                FaxNumber = this.FaxNumber,
                StreetAddress = this.StreetAddress,
                City = this.City,
                State = this.State,
                ZipCode = this.ZipCode,
                Id = this.EmailId,
                PhoneNumber = this.PhoneNumber,
                UserDOB = this.DOB,
                UserFirstName = this.FirstName,
                UserGender = this.Gender,
                UserLastName = this.LastName,
                UserMobileNumber = this.MobileNumber
            };
            return user;
        }
    }
}