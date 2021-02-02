namespace OkonkwoOandaV20.TradeLibrary.Transaction
{
   public abstract class EntryOrderRejectTransaction : EntryOrderTransaction
   {
      public string rejectReason { get; set; }
   }
}
