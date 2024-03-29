﻿using System.ComponentModel.DataAnnotations; // for [Required]
using System.ComponentModel.DataAnnotations.Schema; // for [NotMapped]
using ContactMVC.Enums;

namespace ContactMVC.Models
{
    public class Contact
    {
        // Primary Key in Contacts Database
        public int Id { get; set; }

        // Foreign Key
        [Required]
        public string? AppUserId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and max {1} characters long.", MinimumLength = 2)]
        public string? FirstName { get; set; } // ? allows for null

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and max {1} characters long.", MinimumLength = 2)]
        public string? LastName { get; set; }

        [NotMapped]
        public string? FullName { get { return $"{FirstName} {LastName}"; } }

        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [Required]
        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        [Required]
        public string? City { get; set; }

        [Required]
        public States State { get; set; } // Enums.States  is optional

        [Required]
        [Display(Name = "Zip Code")]
        [DataType(DataType.PostalCode)]
        public int ZipCode { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        public byte[]? ImageData { get; set; }

        public string? ImageType { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        // Virtual/Navigation Properties
        public virtual AppUser? AppUser { get; set; }

        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();

    }
}
