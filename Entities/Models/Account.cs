using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Account")]
    public class Account
    {
        public Account()
        {
            CaseHistory = new HashSet<CaseHistory>();
        }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(100, ErrorMessage = "Username can't be longer than 100 characters")]
        [Key]
        public string Username { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(100, ErrorMessage = "First name can't be longer than 100 characters")]
        public string Fname { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(100, ErrorMessage = "Last name can't be longer than 100 characters")]
        public string Lname { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(255, ErrorMessage = "Email can't be longer than 255 characters")]
        [EmailAddress(ErrorMessage = "Not a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Password can't be longer than 255 characters")]
        public string PasswordHash { get; set; }
        public string Salt { get; set; }

        public virtual ICollection<CaseHistory> CaseHistory { get; set; }
    }
}

