

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NITrade;
using NTrade;

public class Program
{

    public static void Main(string[] args)
    {

        //calling program as an example

        List<Trade> tradeList = new List<Trade>();

        Trade t = new Trade(2000000, "Private"); tradeList.Add(t);
        t = new Trade(400000, "Public"); tradeList.Add(t);
        t = new Trade(500000, "Public"); tradeList.Add(t);
        t = new Trade(3000000, "Public"); tradeList.Add(t);

        Trade trade = new Trade();

        List<string> tradeCategories = trade.RiskAnalysis(tradeList);

    }
}


