using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_core_pi3bplus.Services;
public interface IToyotaCar : ICar
{
    new void Drive();
}
