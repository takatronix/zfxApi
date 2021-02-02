using OkonkwoOandaV20.TradeLibrary.Transaction;

namespace OkonkwoOandaV20.Framework.Factories
{
   public class PriceObjectFactory
   {
      public static IHasPrices Create(string type)
      {
         IHasPrices priceObject;

         switch (type)
         {
            case "OkonkwoOandaV20.TradeLibrary.Transaction.TakeProfitDetails":
               priceObject = new TakeProfitDetails(); break;
            case "OkonkwoOandaV20.TradeLibrary.Transaction.StopLossDetails":
               priceObject = new StopLossDetails(); break;
            case "OkonkwoOandaV20.TradeLibrary.Transaction.TrailingStopLossDetails":
               priceObject = new TrailingStopLossDetails(); break;
            default: priceObject = null; break;
         }

         return priceObject;
      }
   }
}
