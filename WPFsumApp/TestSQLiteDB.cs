using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Globalization;

namespace WPFsumApp
{
    public class TestSQLiteDB
    {
        public SQLiteConnection myConnection;

        public TestSQLiteDB()
        {
            myConnection = new SQLiteConnection("Data Source=../../teszt_db.db");
            if (!File.Exists("../../teszt_db.db"))
            {
                SQLiteConnection.CreateFile("../../teszt_db.db");
            }
        }

        public void OpenConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();
            }
        }

        public void InsertNewOp(TestSQLiteDB databaseObject, int id, int firstnum, string op, int secondnum, int result, string timestamp)
        {
            string query = "INSERT INTO Operations('ID', 'FIRSTNUMBER', 'OP', 'SECONDNUMBER', 'RESULT', 'TIMESTAMP') VALUES(@ID, @FIRSTNUMBER, @OP, @SECONDNUMBER, @RESULT, @TIMESTAMP)";
            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnection);
            databaseObject.OpenConnection();
            myCommand.Parameters.AddWithValue("ID", id);
            myCommand.Parameters.AddWithValue("FIRSTNUMBER", firstnum);
            myCommand.Parameters.AddWithValue("OP", op);
            myCommand.Parameters.AddWithValue("SECONDNUMBER", secondnum);
            myCommand.Parameters.AddWithValue("RESULT", result);
            myCommand.Parameters.AddWithValue("TIMESTAMP", timestamp);
            
            myCommand.ExecuteNonQuery();
            databaseObject.CloseConnection();
        }

        public List<Operation> SelectOpList(TestSQLiteDB databaseObject)
        {
            List<Operation> opList = new List<Operation>();
            string query = "SELECT * FROM Operations";
            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnection);
            databaseObject.OpenConnection();
            
            using (SQLiteDataReader queryResult = myCommand.ExecuteReader())
            {
                if (queryResult.HasRows)
                {
                    while (queryResult.Read())
                    {
                        Operation opNew = new Operation
                        {
                            Id = int.Parse(queryResult["ID"].ToString()),
                            Firstnumber = int.Parse(queryResult["FIRSTNUMBER"].ToString()),
                            Op = queryResult["OP"].ToString(),
                            Secondnumber = Convert.ToInt32(queryResult["SECONDNUMBER"]),
                            Result = Convert.ToInt32(queryResult["RESULT"]),
                            Timestamp = queryResult["TIMESTAMP"].ToString()
                        };
                        opList.Add(opNew);
                    }
                }
            }
            databaseObject.CloseConnection();
            return opList;
        }

        public void DeleteAllOp(TestSQLiteDB databaseObject)
        {
            string query = "DELETE FROM Operations";
            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnection);
            databaseObject.OpenConnection();
           
            myCommand.ExecuteNonQuery();
            databaseObject.CloseConnection();
        }
    }
}
