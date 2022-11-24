using System;
using EasyAccess.Datatypes;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;

namespace HotelBuchen
{
    partial class EasyAccess
    {
        private readonly OleDbConnection _con;
        private readonly OleDbCommand _command;
        private OleDbDataReader reader;
        // Parameter:
        //   databasePath:
        //     The Full Path of the database on your PC or server.
        public EasyAccess(string databasePath)
        {
            _command = new OleDbCommand();

            if (!Directory.Exists(databasePath))
            {
                Console.WriteLine("Path does not Exist");
            }
            else
            {
                _con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + databasePath);
                _command.Connection = _con;
                _con.Open();
            }
        }

        public dataset getColumnNames(string table)
        {
            dataset data = new dataset();
            _command.CommandText = "Select * from " + table + ";";
            reader = _command.ExecuteReader();


            for (int i = 0; i < reader.FieldCount; i++)
            {
                List<string> templist = new List<string>();

                templist.Add(reader.GetName(i));
                templist.Add(reader.GetFieldType(i).ToString());
                data.add(templist);
            }
            reader.Close();
            return data;
        }

        public dataset getItem(string SQLQuery)
        {
            dataset data = new dataset();

            _command.CommandText = SQLQuery;
            reader = _command.ExecuteReader();
            int j = 0;
            while (reader.Read())
            {
                List<string> templist = new List<string>();
                templist.Add(reader.GetName(j));
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    templist.Add(reader.GetValue(i).ToString());
                }
                data.add(templist);
                j++;
            }

            reader.Close();
            return data;
        }

        public void executequerey(string sql)
        {
            _command.CommandText = sql;
            _command.ExecuteNonQuery();
        }


        public void CloseDatabase()
        {
            _command.Connection.Close();
            _con.Close();
        }
    }
}

