using DataAccess.Concrete.EntityFramework;
using Entities.Abstract;
using Entities.Concrete;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Drawing;

//House house = new();
//    house.Title = "Yeni Test";
//    house.Description = "krdşm lütfen ç";
//    house.Price = 1000;
//    house.Size = 1;
//    house.Floor = 1;
//    house.Room = 1;
//    house.UserId = 1;
//    house.CategoryId = 1;


//    house.AddressDetail = new() { CityName = "ankara1", DistrictName = "Test1" };
//house.CategoryDetail = new() {CategoryName= "Kiralık Ev" };


//    EfHouseDal efHouse = new EfHouseDal();
//efHouse.Add(house);
////string[] includes = { "AddressDetail", "CategoryDetail" };
//////Console.WriteLine(JsonConvert.SerializeObject(efHouse.Get(x=>x.Title== "Kel2",includes)));


////EfAddressDal EfAddressDal = new EfAddressDal();
////Console.WriteLine(JsonConvert.SerializeObject(efHouse.GetAll(null, includes)));