namespace ComicBookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Configuration;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;

    public partial class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public bool Admin { get; set; }


        public bool IsUserExist(string username, string password)
        {
            bool flag = false;
            string CS = ConfigurationManager.ConnectionStrings["UserContext"].ConnectionString;
            SqlConnection connection = new SqlConnection(CS);
            
            connection.Open();
            SqlCommand command = new SqlCommand("Select count(*) from [Users] where [Username]= @username and [Password]= @password", connection);
            command.Parameters.Add(new SqlParameter("@username",username));
            command.Parameters.Add(new SqlParameter("@password", password));
            flag = Convert.ToBoolean(command.ExecuteScalar());
            return flag;


           
        }

        public bool IsAdmin(string username, string password)
        {
            bool flag = false;
            string CS = ConfigurationManager.ConnectionStrings["UserContext"].ConnectionString;
            SqlConnection connection = new SqlConnection(CS);

            connection.Open();
            SqlCommand command = new SqlCommand("Select count(*) from [Users] where [Username]= @username and [Password]= @password and [Admin] = @Admin", connection);
            command.Parameters.Add(new SqlParameter("@username", username));
            command.Parameters.Add(new SqlParameter("@password", password));
            command.Parameters.Add(new SqlParameter("@Admin", true));
            flag = Convert.ToBoolean(command.ExecuteScalar());
            return flag;



        }
    }
}
