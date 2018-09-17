using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WordData;

namespace WordData.Models
{
  public class Country
  {
    private string _id;
    private string _name;

    public Country(string Name, string Id)
    {
      _id = Id;
      _name = Name;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetId()
    {
      return _id;
    }

    public static List<Country> GetAll()
    {
      List<Country> allCountries = new List<Country> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string countryId = rdr.GetString(0);
        string countryName = rdr.GetString(1);
        Country newCountry = new Country(countryName, countryId);
        allCountries.Add(newCountry);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCountries;
    }
  }
}
