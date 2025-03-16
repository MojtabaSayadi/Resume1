using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume1.domain.Models.Auth
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        #region Relation
        public List<UserRole> userRoles { get; set; }
        #endregion
    }
}
