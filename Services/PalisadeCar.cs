using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_core_pi3bplus.Services;
public class PalisadeCar(ICar car) : IPalisadeCar
{
    public void Drive()
    {
        car.Drive();
        Console.WriteLine("Palisade Car is driving");
    }

}
