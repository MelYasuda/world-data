using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WordData;

namespace WordData.Models
{
  public class City
  {
    private int _id;
    private string _name;

    public City(string Name, int Id = 0)
    {
      _id = Id;
      _name = Name;
    }

    public string GetName()
    {
      return _name;
    }

    public static List<City> GetAll()
    {
      List<City> allCities = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string cityName = rdr.GetString(1);
        City newCity = new City(cityName, cityId);
        allCities.Add(newCity);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }
  }
}
