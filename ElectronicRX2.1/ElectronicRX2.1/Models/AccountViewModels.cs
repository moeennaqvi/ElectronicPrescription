using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectronicRX2._1.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string UserType { get; set; }
        
        [Required]
        [Display(Name = "Clinic/Pharmacy ID")]
        public string ID { get; set; }

        [Required]
        [Display(Name = "Clinic/Pharmacy Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Clinic/Pharmacy Phone Number")]
        public string PhoneNumber { get; set; }

        public string FaxNumber { get; set; }

        [Required]
        [Display(Name = "Clinic/Pharmacy Address")]
        public string StreetAddress { get; set; }

        [Required]
        [Display(Name = "Clinic/Pharmacy City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Clinic/Pharmacy State")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Clinic/Pharmacy ZipCode")]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "User First Name")]
        public string UserFirstName { get; set; }

        [Required]
        [Display(Name = "User Last Name")]
        public string UserLastName { get; set; }

        public string UserGender { get; set; }

        [Required]
        [Display(Name = "User Date of Birth")]
        public DateTime UserDOB { get; set; }

        public string UserMobileNumber { get; set; }

        public ApplicationUser GetUser()
        {
            var user = new ApplicationUser()
            {
                UserName = this.Email,
                UserType = this.UserType,
                Email = this.Email,
                Name = this.Name,
                PhoneNum = this.PhoneNumber,
                FaxNumber = this.FaxNumber,
                StreetAddress = this.StreetAddress,
                City = this.City,
                State = this.State,
                ZipCode = this.ZipCode,
                Id = this.Email,
                UserDOB = this.UserDOB,
                UserFirstName = this.UserFirstName,
                UserGender = this.UserGender,
                UserLastName = this.UserLastName,
                UserMobileNumber = this.UserMobileNumber,
                PhoneNumber = this.PhoneNumber
            };
            return user;
        }

        public ClinicianModel GetClinician()
        {
            var clinician = new ClinicianModel()
            {
                City = this.City,
                ClinicianID = this.Email,
                ClinicID = this.ID,
                ConfirmPassword = this.ConfirmPassword,
                DOB = this.UserDOB,
                Email = this.Email,
                FaxNumber = this.FaxNumber,
                FirstName = this.UserFirstName,
                Gender = this.UserGender,
                LastName = this.UserLastName,
                MobileNumber = this.UserMobileNumber,
                Password = this.Password,
                PhoneNumber = this.PhoneNumber,
                State = this.State,
                StreetAddress = this.StreetAddress,
                ZipCode = this.ZipCode
            };
            return clinician;
        }

        public ClinicModel GetClinic()
        {
            var clinic = new ClinicModel()
            {
                City = this.City,
                ClinicianID = this.Email,
                ClinicID = this.ID,
                ClinicName = this.Name,
                FaxNumber = this.FaxNumber,
                PhoneNumber = this.PhoneNumber,
                State = this.State,
                StreetAddress = this.StreetAddress,
                ZipCode = this.ZipCode
            };
            return clinic;
        }

        public PharmacistModel GetPharmacist()
        {
            var pharmacist = new PharmacistModel()
            {
                City = this.City,
                ConfirmPassword = this.ConfirmPassword,
                DOB = this.UserDOB,
                Email = this.Email,
                FaxNumber = this.FaxNumber,
                FirstName = this.UserFirstName,
                Gender = this.UserGender,
                LastName = this.UserLastName,
                MobileNumber = this.UserMobileNumber,
                Password = this.Password,
                PharmacistID = this.Email,
                PharmacyID = this.ID,
                PharmacyName = this.Name,
                PhoneNumber = this.PhoneNumber,
                State = this.State,
                StreetAddress = this.StreetAddress,
                ZipCode = this.ZipCode
            };
            return pharmacist;
        }

        public PharmacyModel GetPharmacy()
        {
            var pharmacy = new PharmacyModel()
            {
                StreetAddress = this.StreetAddress,
                City = this.City,
                FaxNumber = this.FaxNumber,
                PharmacistID = this.Email,
                PharmacyID = this.ID,
                PharmacyName = this.Name,
                PhoneNumber = this.PhoneNumber,
                State = this.State,
                ZipCode = this.ZipCode,
            };
            return pharmacy;
        }
    }

    public class EditUserViewModel
    {
        public EditUserViewModel() { }

        // Allow Initialization with an instance of ApplicationUser:
        public EditUserViewModel(ApplicationUser user)
        {
            this.UserType = user.UserType;
            this.Name = user.Name;
            this.PhoneNumber = user.PhoneNum;
            this.FaxNumber = user.FaxNumber;
            this.Email = user.Email;
            this.StreetAddress = user.StreetAddress;
            this.City = user.City;
            this.State = user.State;
            this.ZipCode = user.ZipCode;
            this.ID = user.Id;
            this.UserDOB = user.UserDOB;
            this.UserFirstName = user.UserFirstName;
            this.UserGender = user.UserGender;
            this.UserLastName = user.UserLastName;
            this.UserMobileNumber = user.UserMobileNumber;
        }

        [Required]
        [Display(Name = "User Type")]
        public string UserType { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Fax Number")]
        public string FaxNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        public string ID { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserGender { get; set; }
        public DateTime UserDOB { get; set; }
        public string UserMobileNumber { get; set; }
    }


    public class SelectUserRolesViewModel
    {
        public SelectUserRolesViewModel()
        {
            this.Roles = new List<SelectRoleEditorViewModel>();
        }


        // Enable initialization with an instance of ApplicationUser:
        public SelectUserRolesViewModel(ApplicationUser user)
            : this()
        {
            this.UserType = user.UserType;
            this.Name = user.Name;
            this.PhoneNumber = user.PhoneNum;
            this.FaxNumber = user.FaxNumber;
            this.Email = user.Email;
            this.StreetAddress = user.StreetAddress;
            this.City = user.City;
            this.State = user.State;
            this.ZipCode = user.ZipCode;
            this.ID = user.Id;
            this.UserDOB = user.UserDOB;
            this.UserFirstName = user.UserFirstName;
            this.UserGender = user.UserGender;
            this.UserLastName = user.UserLastName;
            this.UserMobileNumber = user.UserMobileNumber;

            var Db = new ApplicationDbContext();

            // Add all available roles to the list of EditorViewModels:
            var allRoles = Db.Roles;
            foreach (var role in allRoles)
            {
                // An EditorViewModel will be used by Editor Template:

                var rvm = new SelectRoleEditorViewModel((IdentityRole)role);
                this.Roles.Add(rvm);
            }

            // Set the Selected property to true for those roles for 
            // which the current user is a member:
            foreach (var userRole in user.Roles)
            {
                var checkUserRole =
                    this.Roles.Find(r => r.RoleName == userRole.RoleId);
                checkUserRole.Selected = true;
            }
        }

        public string UserType { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string ID { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserGender { get; set; }
        public DateTime UserDOB { get; set; }
        public string UserMobileNumber { get; set; }
        public List<SelectRoleEditorViewModel> Roles { get; set; }
    }

    // Used to display a single role with a checkbox, within a list structure:
    public class SelectRoleEditorViewModel
    {
        public SelectRoleEditorViewModel() { }
        public SelectRoleEditorViewModel(IdentityRole role)
        {
            this.RoleName = role.Name;
        }

        public bool Selected { get; set; }

        [Required]
        public string RoleName { get; set; }
    }


    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
