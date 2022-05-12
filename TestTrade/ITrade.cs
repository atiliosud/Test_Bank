using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NITrade
{
    public interface ITrade
    {
        double Value { get; set; }
        string ClientSector { get; set; }

    }
}
