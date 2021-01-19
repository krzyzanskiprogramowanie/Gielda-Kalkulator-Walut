using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;


namespace DataAccessLibrary
{
    public static class Class1
    {
        public static void InitializeDatabase()
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename=sqliteSample4.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS THB (Primary_Key NVARCHAR(2048) PRIMARY KEY, " +
                    "Text_Entry NVARCHAR(2048) NULL)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }
        public static void AddData(string inputText, string key)
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename=sqliteSample4.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

           

                try
                {
                    insertCommand.CommandText = "INSERT INTO THB VALUES (@PrimaryEntry, @Entry);";
                    insertCommand.Parameters.AddWithValue("@Entry", inputText);
                    insertCommand.Parameters.AddWithValue("@PrimaryEntry", key);

                    insertCommand.ExecuteReader();
                }
                catch (Exception )
                {
                  
                    insertCommand.CommandText = $"UPDATE THB SET Text_Entry='{inputText}' WHERE Primary_Key='{key}' ;";

                    insertCommand.ExecuteReader();
                }

                db.Close();
            }

        }

        public static string entries2, entries3;
        public static string GetData2(string klucz)
        {


            using (SqliteConnection db =
                new SqliteConnection("Filename=sqliteSample4.db"))
            {
                string sql = $"SELECT Text_Entry from THB WHERE Primary_Key='{klucz}'";
                db.Open();
                // polecenie = "SELECT " + nazwaMiasta + ", " + idMiasta + " FROM " + nazwaTabeli + ";";
                SqliteCommand selectCommand = new SqliteCommand
                    (sql, db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {

                    entries2 = (query.GetString(0));
                    //  entries3 = (query.GetString(1));

                }

                entries2 = entries2 + " " + entries3;

                db.Close();
            }

            return entries2;
        }



        public static void InitializeDatabase2()
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename=sqliteSample7.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS MyTable (Primary_Key NVARCHAR(2048) PRIMARY KEY, " +
                    "Text_Entry NVARCHAR(2048) NULL)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }
        public static void AddData10(string inputText, string key)
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename=sqliteSample7.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                 try
                {
                    insertCommand.CommandText = "INSERT INTO MyTable VALUES (@PrimaryEntry, @Entry);";
                    insertCommand.Parameters.AddWithValue("@Entry", inputText);
                    insertCommand.Parameters.AddWithValue("@PrimaryEntry", key);

                    insertCommand.ExecuteReader();
                }
                catch (Exception )
                {
                    
                    insertCommand.CommandText = $"UPDATE MyTable SET Text_Entry='{inputText}' WHERE Primary_Key='{key}' ;";

                    insertCommand.ExecuteReader();
                }
            

          

                db.Close();
            }

        }
        public static List<String> GetData()
        {
            List<String> entries = new List<string>();

            using (SqliteConnection db =
                new SqliteConnection("Filename=sqliteSample7.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from MyTable", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }

                db.Close();
            }

            return entries;
        }

        public static void Clear()
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename=sqliteSample7.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;



                try
                {
                    insertCommand.CommandText = "DELETE FROM MyTable";
               

                    insertCommand.ExecuteReader();
                }
                catch (Exception )
                {

                  //  insertCommand.CommandText = $"UPDATE THB SET Text_Entry='{inputText}' WHERE Primary_Key='{key}' ;";

                   // insertCommand.ExecuteReader();
                }

                db.Close();
            }

        }

    }
}

