using System;
using System.Data;
using System.Text.RegularExpressions;
using Dapper;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HelloWorld
{
  
    internal class Program
    {
      static void Main(string[] args)
      {
        IConfiguration config = new ConfigurationBuilder()
        .AddJsonFile ("appSettings.json")
        .Build();

        DataContextDapper dapper = new DataContextDapper(config);

        DataContextEF entityFramework = new DataContextEF(config);
       
        DateTime rightnow = dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");

        // Console.WriteLine(rightnow.ToString());

        Computer myComputer = new Computer() 
        {
          Motherboard = "Z690",
          HasWifi = true,
          HasLTE = true,
          ReleaseDate = DateTime.Now, 
          Price = 943.87m,
          VideoCard = "RTX 4080"
        };

        entityFramework.Add(myComputer);
        entityFramework.SaveChanges();

        string sql = @"INSERT INTO TutorialAppSchema.Computer (
          Motherboard,
          HasWifi,
          HasLTE,
          ReleaseDate,
          Price,
          VideoCard
        ) VALUES ('" + myComputer.Motherboard
                     +"','" + myComputer.HasWifi
                     +"','" + myComputer.HasLTE
                     +"','" + myComputer.ReleaseDate
                     +"','" + myComputer.Price
                     +"','" + myComputer.VideoCard 
        +"')";
            // Console.WriteLine(sql);

            bool result = dapper.ExecuteSql(sql);
            
            // Console.WriteLine(result);
            
            string sqlSelect = @"SELECT 
            Computer.ComputerId,
            Computer.Motherboard,
            Computer.HasWifi,
            Computer.HasLTE,
            Computer.ReleaseDate,  
            Computer.Price,
            Computer.VideoCard
        FROM TutorialAppSchema.Computer";

            IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);

            Console.WriteLine("'ComputerId','Motherboard','HasWifi','HasLTE','ReleaseDate'"+ ",'Price','VideoCard'" );
            foreach(Computer singleComputer in computers) {
              Console.WriteLine("'" + singleComputer.ComputerId
                     +"','" + singleComputer.Motherboard
                     +"','" + singleComputer.HasWifi
                     +"','" + singleComputer.HasLTE
                     +"','" + singleComputer.ReleaseDate
                     +"','" + singleComputer.Price
                     +"','" + singleComputer.VideoCard  +"'");
   
                     
            }

            IEnumerable<Computer>? computersEf = entityFramework.Computer?.ToList<Computer>();

            if (computersEf!=null)
          {
            Console.WriteLine("'ComputerId','Motherboard','HasWifi','HasLTE','ReleaseDate'"+ ",'Price','VideoCard'" );
            foreach(Computer singleComputer in computersEf) {
              Console.WriteLine("'" + singleComputer.ComputerId
                     +"','" + singleComputer.Motherboard
                     +"','" + singleComputer.HasWifi
                     +"','" + singleComputer.HasLTE
                     +"','" + singleComputer.ReleaseDate
                     +"','" + singleComputer.Price
                     +"','" + singleComputer.VideoCard  +"'");
   
                     
            }

          }

     Console.WriteLine("Up and Running =)");
    Console.WriteLine("Testing");
    DENEME
    dENEME 2
    

        // Console.WriteLine(myComputer.Motherboard);
        // Console.WriteLine(myComputer.HasWifi);
        // Console .WriteLine(myComputer.ReleaseDate);
        // Console.WriteLine(myComputer.VideoCard);
  }
  }
  }
  