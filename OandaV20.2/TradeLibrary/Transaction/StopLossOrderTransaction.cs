namespace OkonkwoOandaV20.TradeLibrary.Transaction
{
   public class StopLossOrderTransaction : ExitOrderTransaction
   {
      public decimal price { get; set; }
      public decimal distance { get; set; }

      /// <summary>
      /// Flag indicating that the Stop Loss Order is guaranteed. The default value
      /// depends on the GuaranteedStopLossOrderMode of the account, if it is
      /// REQUIRED, the default will be true, for DISABLED or ENABLED the default
      /// is false.
      /// </summary>
      public bool guaranteed { get; set; }

      /// <summary>
      /// The fee that will be charged if the Stop Loss Order is guaranteed and the
      /// Order is filled at the guaranteed price. The value is determined at Order
      /// creation time. It is in price units and is charged for each unit of the
      /// Trade.
      /// </summary>
      public decimal guaranteedExecutionPremium { get; set; }
   }
}
