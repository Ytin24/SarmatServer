using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
namespace SarmatServer.Database

{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string ImgSource { get; set; }
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Online { get; set; }

    }
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }

}
