namespace OkonkwoOandaV20.TradeLibrary.Transaction
{
   /// <summary>
   /// 
   /// </summary>
   public class ClientConfigureTransaction : Transaction
   {
      public string alias { get; set; }
      public decimal marginRate { get; set; }
   }
}