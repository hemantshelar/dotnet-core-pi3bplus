using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_core_pi3bplus.Services;
public class ToyotaCar(ICar car) : IToyotaCar
{
    public void Drive()
    {
        car.Drive();
        Console.WriteLine("Toyota Car is driving");
    }
}
