using System.Text.Json.Serialization;
using System.Text.Json;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

string fileContent = await File.ReadAllTextAsync("data.json");
var cars = JsonSerializer.Deserialize<List<CarData>>(fileContent);


// How Many Makes build CAr With HP between
// (0 TO 100) , (101 TO 200), (201 TO 300), (301 TO 400) and (401, 500)
cars.GroupBy(x => x.HP
    switch
{
    <= 100 => "0 TO 100",
    <= 200 => "101 TO 200",
    <= 300 => "201 TO 300",
    <= 400 => "301 TO 400",
    _ => "401 TO 500"
}).Select(x => new
{
    HP_Category = x.Key,
    NumberOfMake = cars.Select(y => y.Make).Distinct().Count()
})
.ToList()
.ForEach(z => Console.WriteLine($"{z.HP_Category}  : {z.NumberOfMake}") );










    

class CarData
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("car_make")]
    public string Make { get; set; }

    [JsonPropertyName("car_models")]
    public string Model { get; set; }

    [JsonPropertyName("car_year")]
    public int Year { get; set; }

    [JsonPropertyName("number_of_doors")]
    public int NumberOfDoors { get; set; }

    [JsonPropertyName("hp")]
    public int HP { get; set; }
}




//var carWithFourDoors = cars.Where(x => x.NumberOfDoors == 4).Take(10);
//var topTenCarsWithMostHorsePower = cars.OrderByDescending(x => x.HP).Where(x => x.NumberOfDoors == 2).Take(10);

//foreach (var item in topTenCarsWithMostHorsePower)
//{
//    Console.WriteLine($@" {item.Make}  {item.NumberOfDoors}  {item.HP}");
//}


//print make + model for all makes that start with 'M'

//var query = cars.Where(x => x.Make.StartsWith('M'))
//    .Take(10)
//    .Select(y => $"{y.Make} {y.Model}")
//    .ToList();


//foreach (var item in query)
//{
//    Console.WriteLine($@"{item}");
//}


//cars.Where(x => x.Make.StartsWith('M'))
//   .Take(10)
//   .Select(y => $"{y.Make} {y.Model}")
//   .ToList()
//   .ForEach(z => Console.WriteLine(z));



// display the number of models per make that appeared after 1995
//cars.Where(x => x.Year >= 2000).
//    GroupBy(x => x.Make)
//    .Select(y => new { y.Key, NumberOfModels = y.Count() })
//    .ToList()
//    .ForEach(x => Console.WriteLine($@"{x.Key} : {x.NumberOfModels}"));


// show all makes , and display the number of models per make that appeared after 2000
//cars.GroupBy(x => x.Make)
//    .Select(y => new { y.Key, NumberOfModels = y.Where(x => x.Year >= 2000).Count() })
// //  .Select(y => new { y.Key, NumberOfModels = y.Count(x => x.Year >= 2000) })  // alter native 
//    .ToList()
//    .ForEach(x => Console.WriteLine($@"{x.Key} : {x.NumberOfModels}"));




// display a list of car make that have at least 2 models with >= 400 Horse Power
//cars.Where(x => x.HP >= 400)
//    .GroupBy(y => y.Make)
//    .Select(z => new { make = z.Key, NumberOfHorsePowerCars = z.Count() })
//    .Where(make => make.NumberOfHorsePowerCars >= 2)  // behave like having clause 
//    .ToList()
//    .ForEach(m => Console.WriteLine($@"{m.make} : {m.NumberOfHorsePowerCars}"));




// display a list of car make that have at least 2 models with >= 400 Horse Power
//cars.Where(x => x.HP >= 400)
//    .GroupBy(y => y.Make)
//    .Select(z => new { make = z.Key, NumberOfHorsePowerCars = z.Count() })
//    .Where(make => make.NumberOfHorsePowerCars >= 2)  // behave like having clause 
//    .ToList()
//    .ForEach(m => Console.WriteLine($"{m.make} : {m.NumberOfHorsePowerCars}"));




// Display the Average  Horse Power Per Car-Make
//cars.GroupBy(x => x.Make)
//    .Select(y => new { Make = y.Key, HorsePowerAverage = y.Average(x => x.HP) })
//    .ToList()
//    .ForEach(x => Console.WriteLine($"{x.Make}  : {x.HorsePowerAverage}"));






// How Many Makes build CAr With HP between
// (0 TO 100) , (101 TO 200), (201 TO 300), (301 TO 400) and (401, 500)
//cars.GroupBy(x => x.HP
//    switch
//{
//    <= 100 => "0 TO 100",
//    <= 200 => "101 TO 200",
//    <= 300 => "201 TO 300",
//    <= 400 => "301 TO 400",
//    _ => "401 TO 500"
//}).Select(x => new
//{
//    HP_Category = x.Key,
//    NumberOfMake = cars.Select(y => y.Make).Distinct().Count()
//})
//.ToList()
//.ForEach(z => Console.WriteLine($"{z.HP_Category}  : {z.NumberOfMake}"));


