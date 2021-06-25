
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MaxLengthAttribute = System.ComponentModel.DataAnnotations.MaxLengthAttribute;

namespace BellApp.Models.Dtos
{
    public class UsersDto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
       [Required]
        public string Company { get; set; }
        [Required]
        public string CompanyNo { get; set; }
        [Required]
        public string JobPosition { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, MaxLength(20), EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
