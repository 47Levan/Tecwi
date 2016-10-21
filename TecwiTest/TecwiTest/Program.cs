using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecwiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Hello World -> olleH dlroW
            //string s = "Hello World";
            //int length = s.Length;
            //var temp = s.Split(' ');
            //for (int i=0;i<temp.Length;i++)
            //{
            //    temp[i]=String.Join("",temp[i].Reverse());
            //}
            //string result = String.Join(" ",temp);
            //Console.WriteLine(result);
            //Console.Read();
            //            Киев:
            //            -Париж
            //            - Лондон

            //             Париж:
            //            -Лондон
            //            - Киев

            //            Лондон:
            //            -Киев
            //            - Париж
            //            - Нью Йорк

            //            Нью Йорк:
            //            -Лондон
            Airport Kiev = new Airport() { City = "Kiev", AirportsToFly = new List<Airport>() };
            Airport London = new Airport() { City = "London", AirportsToFly = new List<Airport>() };
            Airport Paris = new Airport() { City = "Paris", AirportsToFly = new List<Airport>() };
            Airport New_York = new Airport() { City = "New York", AirportsToFly = new List<Airport>() };
            Kiev.AirportsToFly.Add(London);
            Kiev.AirportsToFly.Add(Paris);
            Paris.AirportsToFly.Add(London);
            Paris.AirportsToFly.Add(Kiev);
            London.AirportsToFly.Add(Kiev);
            London.AirportsToFly.Add(Paris);
            London.AirportsToFly.Add(New_York);
            New_York.AirportsToFly.Add(London);
            string route= Kiev.Route(Kiev, New_York);
            Console.WriteLine(route);
            Console.Read();

        }
    }

    class Airport
    {
        public string Route(Airport dep, Airport dest,string route="")
        {
            route +=this.City+" ";
            if (this.City == dest.City)
            {
                return route;
            }
            else
            {
                foreach (Airport airport in this.AirportsToFly)
                {
                    Airport newAirport = airport.Clone();
                    newAirport.AirportsToFly.Remove(dep);
                    newAirport.AirportsToFly.RemoveAll(x=>x.City==this.City);
                    string result=newAirport.Route(dep, dest,route);
                    if (result.Contains(dest.City))
                    {
                        return result;
                    }
                }
            }
            return "There no possible routes";
        }
        public string City { get; set; }
        public List<Airport> AirportsToFly { get; set; }
        public Airport Clone()
        {
            Airport newAirport = new Airport()
            {
                City = this.City,
                AirportsToFly = new List<Airport>()
            };
            foreach (Airport airport in this.AirportsToFly)
            {
                newAirport.AirportsToFly.Add(airport);
            }
            return newAirport;
        }
    }
}
