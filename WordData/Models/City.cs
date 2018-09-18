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
    private int _population;

    public City(string Name, int Population, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _population = Population;
    }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }

    public int GetPopulation()
    {
      return _population;
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
        int cityPopulation = rdr.GetInt32(4);
        City newCity = new City(cityName, cityPopulation, cityId);
        allCities.Add(newCity);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }

    public static List<City> GetByPopulation(string Population)
    {
      List<City> allByPopulation = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city WHERE population <= " + Population + ";";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string cityName = rdr.GetString(1);
        int cityPopulation = rdr.GetInt32(4);
        City newCity = new City(cityName, cityPopulation, cityId);
        allByPopulation.Add(newCity);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allByPopulation;
    }


  }
}
