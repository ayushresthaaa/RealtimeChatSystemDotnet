using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace  StudentRecordSystem.Data.Entities
{

    public class User : IdentityUser
    {
        [Required, StringLength(50, ErrorMessage ="Please enter your First Name")]
        public string? FirstName {get; set; } = string.Empty; 
        [Required, StringLength(50, ErrorMessage = "Please Enter a Last name")]
        public string? LastName {get;set;} = string.Empty; 

    }
}