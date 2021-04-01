using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Library
{
    class Library
    {
        private static MySqlConnection connection;
        private static string server;
        private static string database;
        private static string uid;
        private static string password;

        private static string user_name;
        private static string[] user_roles;

        public Library()
        {
        }

        private static void Initialize()
        {
            server = "localhost";
            database = "library";
            uid = "root";
            password = "rigero28";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        private static bool OpenConnection()
        {
            try
            {
                if (connection == null)
                {
                    Initialize();
                }
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        private static bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        
        static public bool Auterization(string username, string password)
        {
            string query = "select * from library.users where user_name='"+username+"' and password='"+password+"'";
            bool inUserList = false;

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                inUserList = dataReader.HasRows;
                if (inUserList)
                {
                    user_name = username;
                }
                dataReader.Close();
                CloseConnection();
                user_roles = getRoles(user_name).Split(',');
                return inUserList;
            }
            else
            {
                MessageBox.Show("Lose connection");
                return inUserList;
            }
        }

        static public string getRoles(string nameUser) 
        {
            string query = "select * from library.user_with_roles where user_name='"+ nameUser + "'";

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                string roles = "";
                while (dataReader.Read())
                {
                    roles += dataReader["user_role"] + ",";
                }
                
                dataReader.Close();

                CloseConnection();
                return roles;
            }
            else
            {
                MessageBox.Show("Lose connection");
                return "";
            }
        }

        static public bool inRole(string role)
        {
            return user_roles.Contains(role);
        }

        static public void LogOut()
        {
            user_name = null;
            user_roles = null;
        }
        
        static public string getListUsers()
        {
            string query = "select user_name from users";
            
            string listOfUsers = "";

            //Open connection
            if (OpenConnection())
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    listOfUsers += dataReader["user_name"] + ",";
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return listOfUsers;
            }
            else
            {
                return listOfUsers;
            }
        }
    }
}
