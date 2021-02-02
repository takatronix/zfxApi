namespace OkonkwoOandaV20.TradeLibrary.Transaction
{
   public class MarketIfTouchedOrderRejectTransaction : PriceEntryOrderRejectTransaction
   {
      public decimal? priceBound { get; set; }
   }
}
 