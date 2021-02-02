namespace OkonkwoOandaV20.TradeLibrary.Transaction
{
   public class StopOrderRejectTransaction : PriceEntryOrderRejectTransaction
   {
      public decimal? priceBound { get; set; }
   }
}
 