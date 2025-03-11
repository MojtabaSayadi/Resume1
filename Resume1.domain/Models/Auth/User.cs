using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume1.domain.Models.Auth
{
    public class User
     {
        [Key]
        public int Id { get; set; }
       // [Required(ErrorMessage =" Please FullName ")]
        [MaxLength(10,ErrorMessage =" FullName is too long ")]
        public string FullName { get; set; }
       // [Required(ErrorMessage ="Please Password ")]
        [MaxLength(10,ErrorMessage ="Password is too long ")]
        public string Password { get; set; }
    }
}
