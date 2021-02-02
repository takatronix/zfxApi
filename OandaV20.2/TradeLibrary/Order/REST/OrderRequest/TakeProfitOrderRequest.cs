using OkonkwoOandaV20.TradeLibrary.Order;

namespace OkonkwoOandaV20.TradeLibrary.REST.OrderRequest
{
   public class TakeProfitOrderRequest : ExitOrderRequest
   {
      public TakeProfitOrderRequest(Instrument.Instrument oandaInstrument)
         : base(oandaInstrument)
      {
         type = OrderType.TakeProfit;
      }
   }
}
