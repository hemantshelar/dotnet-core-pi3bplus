using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_core_pi3bplus.Services;
public class Customer(IPalisadeCar palisadeCar)
{
    private readonly string CustID = Guid.NewGuid().ToString();
    public void IsDriving()
    {
        Console.Write($"{CustID} - ");
        palisadeCar.Drive();
    }
}
