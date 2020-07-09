using DaemonPieShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaemonPieShop.Data.Interface
{
    public interface IPieRepository
    {
        Pie GetPieById(long? PieId);
        IEnumerable<Pie> AllPies { get;  }
        IEnumerable<Pie> PiesOfTheWeek { get; }
        
    }
}
    