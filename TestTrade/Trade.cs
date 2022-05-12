using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NITrade;
using NClientSectorKey;
using NTradeValueKey;
using NRiskKey;

namespace NTrade
{

    //main class
    //Itrade interface heritage
    public class Trade : ITrade
    {

        public double Value { get; set; }
        public string ClientSector { get; set; }

        //override constructor for method call
        public Trade()
        {


        }
        //constructor for value setting
        public Trade(double value, string clientSector)
        {
            Value = value;
            ClientSector = clientSector;
        }


        //bussiness method for identify the trade risk
        public List<string> RiskAnalysis(List<Trade> portfolio)
        {

            ClientSectorKey clientSectorKey = new ClientSectorKey();
            TradeValueKey tradeValueKey = new TradeValueKey();
            RiskKey riskKey = new RiskKey();


            List<string> tradeCategories = new List<string>();

            foreach (var trade in portfolio)
            {
                if (trade.ClientSector == clientSectorKey.ClientSectorPublic & trade.Value > tradeValueKey.Value)
                {

                    tradeCategories.Add(riskKey.MediumRisk);
                }
                else if (trade.ClientSector == clientSectorKey.ClientSectorPrivate & trade.Value > tradeValueKey.Value)
                {

                    tradeCategories.Add(riskKey.HighRisk);
                }
                else
                {
                    tradeCategories.Add(riskKey.LowRisk);

                }

            }

            return tradeCategories;

        }

    }
}

