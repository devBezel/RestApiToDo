using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestApi.Models;
using MySql.Data.MySqlClient;
using System.Collections;

namespace RestApi
{
    public class ListPersistence
    {

        private MySqlConnection conn;
        public ListPersistence()
        {
            string connString;
            connString = "server=localhost;user=root;database=crud;SslMode=none;";
            try
            {
                conn = new MySqlConnection(connString);
                conn.Open();
            }
            catch (MySqlException ex)
            {

                throw;
            }
        }
        public ListTo getList(long id)
        {
            ListTo listN = new ListTo();
            MySqlDataReader reader = null;
            String sqlInquiry = "SELECT * FROM todo WHERE id=" + id.ToString();
            MySqlCommand comm = new MySqlCommand(sqlInquiry, conn);

            reader = comm.ExecuteReader();
            if(reader.Read())
            {
                listN.id = reader.GetInt32(0);
                listN.title = reader.GetString(1);
                listN.text = reader.GetString(2);
                listN.priority = reader.GetString(3);
                return listN;
            }
            else
            {
                return null;
            }

        }
        public ArrayList getLists()
        {
            ArrayList listArray = new ArrayList();
            MySqlDataReader reader = null;
            String sqlInquiry = "SELECT * FROM todo";
            MySqlCommand comm = new MySqlCommand(sqlInquiry, conn);

            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                ListTo listN = new ListTo();
                listN.id = reader.GetInt32(0);
                listN.title = reader.GetString(1);
                listN.text = reader.GetString(2);
                listN.priority = reader.GetString(3);
                listArray.Add(listN);
            }
            return listArray;

        }
        public long saveList(ListTo listToSave)
        {
            String sqlInquiry = "INSERT INTO todo (title,text,priority) VALUES ('" + listToSave.title + "','" + listToSave.text + "','" + listToSave.priority + "')";
            MySqlCommand comm = new MySqlCommand(sqlInquiry, conn);
            comm.ExecuteNonQuery();
            long id = comm.LastInsertedId;
            return id;
        }
    }
}