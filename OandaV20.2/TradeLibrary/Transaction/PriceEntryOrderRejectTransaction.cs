namespace OkonkwoOandaV20.TradeLibrary.Transaction
{
   public abstract class PriceEntryOrderRejectTransaction : EntryOrderRejectTransaction
   {
      public decimal price { get; set; }
      public string gtdTime { get; set; }
      public string triggerCondition { get; set; }
      public long? intendedReplacesOrderID { get; set; }
   }
}
