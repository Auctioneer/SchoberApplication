using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
//Add MySql Library
using MySql.Data.MySqlClient;
using SchoberApplication;
using System.Security.Cryptography;

namespace ConnectCsharpToMysql
{
    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "silva.computing.dundee.ac.uk";
            database = "15ac3d06";
            uid = "15ac3u06";
            password = "cba123";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }


        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    default:
                        //         Console.WriteLine(ex.);
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
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

        public MySqlConnection getConnection()
        {
            return connection;
        }


        //For hashing passwords. source: http://blogs.msdn.com/b/csharpfaq/archive/2006/10/09/how-do-i-calculate-a-md5-hash-from-a-string_3f00_.aspx
        public static string calcMD5(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        //Check if username is in the database - for log in. Method by KP
        public bool unameExists(String usernameToCompare)
        {
            string query = "SELECT username FROM systemlogin";

            if (OpenConnection() == true)
            {
                MySqlDataReader data;
                MySqlCommand cmd = new MySqlCommand(query, connection);
                data = cmd.ExecuteReader();
                while (data.Read())
                {
                    String username = data.GetString("username");
                    if (username.CompareTo(usernameToCompare) == 0)
                    {
                        CloseConnection();
                        return true;
                    }
                }
                CloseConnection();
                return false;
            }
            else
            {
                CloseConnection();
                return false;
            }
        }

        //Check if given username matches with password- for log in. Method by KP
        public bool matchPassword(String usernameToCompare, String passToCompare)
        {
            try
            {
                string query = "SELECT password FROM systemlogin WHERE username=\"" + usernameToCompare + "\"";

                if (OpenConnection() == true)
                {
                    MySqlDataReader data;
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    data = cmd.ExecuteReader();
                    String password = null;
                    while (data.Read())
                    {
                        password = data.GetString("password");
                    }
                    if (password != null)
                    {
                        passToCompare = calcMD5(passToCompare);
                        if (password.CompareTo(passToCompare) == 0)
                        {
                            CloseConnection();
                            return true;
                        }

                    }
                    CloseConnection();
                    return false;
                }
                else
                {
                    CloseConnection();
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
    }
}


 
