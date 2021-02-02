using System.Collections.Generic;

namespace OkonkwoOandaV20.TradeLibrary.Transaction
{
   public class DelayedTradeClosureTransaction : Transaction
   {
      public string reason { get; set; }
      public List<long> tradeIDs { get; set; }
   }
}
