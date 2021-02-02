﻿namespace OkonkwoOandaV20.TradeLibrary.Transaction
{
   public abstract class ExitOrderRejectTransaction : RejectTransaction
   {
      public long tradeID { get; set; }
      public string clientTradeID { get; set; }    
      public string timeInForce { get; set; }
      public string gtdTime { get; set; }
      public string triggerCondition { get; set; }
      public string reason { get; set; }
      public ClientExtensions clientExtensions { get; set; }
      public long? orderFillTransactionID { get; set; }
      public long? intendedReplacesOrderID { get; set; }     
   }
}
