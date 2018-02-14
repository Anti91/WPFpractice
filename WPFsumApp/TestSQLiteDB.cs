using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

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

        public void InsertNewOp(TestSQLiteDB databaseObject, Operation operation)
        {
            string query = "INSERT INTO Operations('ID', 'FIRSTNUMBER', 'OP', 'SECONDNUMBER', 'RESULT', 'TIMESTAMP') VALUES(@ID, @FIRSTNUMBER, @OP, @SECONDNUMBER, @RESULT, @TIMESTAMP)";
            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnection);
            databaseObject.OpenConnection();
            myCommand.Parameters.AddWithValue("ID", operation.Id);
            myCommand.Parameters.AddWithValue("FIRSTNUMBER", operation.Firstnumber);
            myCommand.Parameters.AddWithValue("OP", operation.Op);
            myCommand.Parameters.AddWithValue("SECONDNUMBER", operation.Secondnumber);
            myCommand.Parameters.AddWithValue("RESULT", operation.Result);
            myCommand.Parameters.AddWithValue("TIMESTAMP", operation.Timestamp);
            
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
