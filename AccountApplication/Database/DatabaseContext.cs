using AccountApplication.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApplication.Database
{
    internal class DatabaseContext : DbContext
    {
         private readonly string _connectionData = "data source=localhost; initial catalog=AccountDB_; integrated security=True;MultipleActiveResultSets=True;";



        public ObservableCollection<Account> GetAccounts()
        {
            ObservableCollection<Account> accounts = new ObservableCollection<Account>();
            using (SqlConnection cn = new SqlConnection(_connectionData))
            {
                cn.Open();
                var query = "SELECT * FROM Account";
                SqlCommand sqlCommand = new SqlCommand(query, cn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while(reader.Read())
                {
                    var account = new Account()
                    {
                        Name = (string)reader["Name"],
                        Login = (string)reader["Login"],
                        Password = (string)reader["Password"]

                    };
                    var Id_ = Convert.ToInt32(reader["Id"]);
                    account.Id = Id_;
                    accounts.Add(account);
                }

                cn.Close();
            }
            return accounts;

        }

        public ObservableCollection<Account> DeleteAccount(Account account)
        {
            using (SqlConnection cn = new SqlConnection(_connectionData))
            {
                cn.Open();
                var query = "DELETE Account WHERE Id = @Id";

            
                SqlCommand sqlCommand = new SqlCommand(query, cn);
                sqlCommand.Parameters.AddWithValue("@Id", account.Id);
                sqlCommand.CommandType = CommandType.Text;
                try
                {
                    sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {

                }


                cn.Close();

            }
            return this.GetAccounts();
        }


        public ObservableCollection<Account> UpdateAccount(Account account)
        {

            using (SqlConnection cn = new SqlConnection(_connectionData))
            {
                cn.Open();
                var query = "UPDATE Account Set Name = @Name, Login = @Login, Password = @Password WHERE Id = @Id";


                SqlCommand sqlCommand = new SqlCommand(query, cn);
                sqlCommand.Parameters.AddWithValue("@Id", account.Id);
                sqlCommand.Parameters.AddWithValue("@Name", account.Name);
                sqlCommand.Parameters.AddWithValue("@Login", account.Login);
                sqlCommand.Parameters.AddWithValue("@Password", account.Password);

                sqlCommand.CommandType = CommandType.Text;

                try
                {
                    sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    
                }
                cn.Close();

            }
            return this.GetAccounts();
        }

        public ObservableCollection<Account> AddAccount(Account account)
        {

            using (SqlConnection cn = new SqlConnection(_connectionData))
            {
                cn.Open();
                var query = "INSERT INTO Account VALUES (@Name,@Login,@Password)";


                SqlCommand sqlCommand = new SqlCommand(query, cn);
                sqlCommand.Parameters.AddWithValue("@Name", account.Name);
                sqlCommand.Parameters.AddWithValue("@Login", account.Login);
                sqlCommand.Parameters.AddWithValue("@Password", account.Password);

                sqlCommand.CommandType = CommandType.Text;
                try
                {
                    sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {

                }
                cn.Close();
            }
            return this.GetAccounts();
        }


    }
}
