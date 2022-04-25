using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodApp.Entities.Interfaces
{
    public interface ICarVersion3 : ICarVersion2
    {
        bool MitKofferraum { get; set; }
    }
}
