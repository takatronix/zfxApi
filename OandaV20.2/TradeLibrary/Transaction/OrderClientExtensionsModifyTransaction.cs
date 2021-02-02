namespace OkonkwoOandaV20.TradeLibrary.Transaction
{
   public class OrderClientExtensionsModifyTransaction : Transaction
   {
      public long orderID { get; set; }
      public string clientOrderID { get; set; }
      public ClientExtensions clientExtensionsModify { get; set; }
      public ClientExtensions tradeClientExtensionsModify { get; set; }
   }
}
