using System.ComponentModel.DataAnnotations;
using System;


namespace DojoCrudelicious.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
            // MySQL VARCHAR and TEXT types can be represeted by a string
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
            // The MySQL DATETIME type can be represented by a DateTime
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;


    }
}