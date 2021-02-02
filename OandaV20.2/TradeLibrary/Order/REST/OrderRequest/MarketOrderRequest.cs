using OkonkwoOandaV20.TradeLibrary.Order;

namespace OkonkwoOandaV20.TradeLibrary.REST.OrderRequest
{
   public class MarketOrderRequest : EntryOrderRequest
   {
      public MarketOrderRequest(Instrument.Instrument oandaInstrument)
         : base(oandaInstrument)
      {
         type = OrderType.Market;
         timeInForce = TimeInForce.FillOrKill;
      }
   }
}
