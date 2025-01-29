using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_core_pi3bplus.Services;
public class Car : ICar
{
    public void Drive()
    {
        Console.WriteLine("Car is driving");
    }
}
