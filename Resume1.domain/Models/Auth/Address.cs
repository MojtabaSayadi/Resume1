using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume1.domain.Models.Auth
{
    public class Address
    {
        public int Id { get; set; }
        public string AddressContent { get; set; }
        public int UserId{ get; set; }

        #region Relation
                
        [ForeignKey("UserId")]
        public User User { get; set; }
        #endregion
    }
}
