using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodApp.Services.Interfaces
{
    public interface ICarServiceVersion3 : ICarServiceVersion2
    {
        public void PruefeKofferRaumNachErsteHilfeSet(ICarServiceVersion3 carServiceVersion3);
    }
}
