using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
namespace SarmatServer.Database

{
    
    public class Db
    {
        
        private void DbConnect()
        {

        }
        private void DbGetData()
        {

        }
        private void DbSetData()
        {

        }
        
    }
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string ImgSource { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Online { get; set; }

    }

}
