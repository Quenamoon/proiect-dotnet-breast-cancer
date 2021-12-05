using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("users")]
    public class User : BaseEntity
    {
        [Column("email")]
        public string Email { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("usertype")]
        public string UserTypeString
        {
            get { return UserType.ToString(); }
            set { UserType = value.ParseEnum<UserType>(); }
        }

        [NotMapped]
        public UserType UserType { get; set; }
    }
}