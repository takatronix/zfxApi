using OkonkwoOandaV20.TradeLibrary.Transaction;
using System.Collections.Generic;

namespace OkonkwoOandaV20.TradeLibrary.Trade
{
   public abstract class TradeBase : CalculatedTradeState
   {
      public string instrument { get; set; }
      public decimal price { get; set; }
      public string openTime { get; set; }
      public string state { get; set; }
      public long initialUnits { get; set; }
      public decimal initialMarginRequired { get; set; }
      public long currentUnits { get; set; }
      public decimal realizedPL { get; set; }
      public decimal averageClosePrice { get; set; }
      public List<long> closingTransactionIDs { get; set; }
      public decimal financing { get; set; }
      public string closeTime { get; set; }
      public ClientExtensions clientExtensions { get; set; }
   }
}
