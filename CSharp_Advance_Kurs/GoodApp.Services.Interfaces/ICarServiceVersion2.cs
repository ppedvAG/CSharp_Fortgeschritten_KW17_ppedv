using GoodApp.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodApp.Services.Interfaces
{
    public interface ICarServiceVersion2 : ICarService
    {
        public void LackiereAutoUm(ICarVersion2 car);
    }
}
