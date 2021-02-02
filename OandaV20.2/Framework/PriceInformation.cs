using OkonkwoOandaV20.TradeLibrary.Instrument;
using System.Collections.Generic;

namespace OkonkwoOandaV20.Framework
{
   public interface IHasPrices
   {
      PriceInformation priceInformation { get; set; }
   }

   /// <summary>
   /// Provides metadata for PriceObject instances
   /// </summary>
   public class PriceInformation
   {
      /// <summary>
      /// The name of the Price Object instrument
      /// </summary>
      public Instrument instrument { get; set; }

      /// <summary>
      /// The PriceObject properties that indicate the threshold price for order execution
      /// </summary>
      public List<string> priceProperties { get; set; }
   }
}
