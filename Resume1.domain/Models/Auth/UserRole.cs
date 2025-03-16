using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume1.domain.Models.Auth
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        #region Relation
        [ForeignKey("UserId")]
        public User user {  get; set; }
        [ForeignKey("RoleId")]
        public Role role { get; set; }
        #endregion
    }
}
