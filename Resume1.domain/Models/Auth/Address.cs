using System.ComponentModel.DataAnnotations.Schema;

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
