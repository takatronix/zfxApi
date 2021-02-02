namespace OkonkwoOandaV20.TradeLibrary.Account
{
   /// <summary>
   /// http://developer.oanda.com/rest-live-v20/account-df/#AccountSummary
   /// </summary>
   public class AccountSummary : CalculatedAccountState
   {
      public string id { get; set; }
      public string alias { get; set; }
      public string currency { get; set; }
      public decimal balance { get; set; }
      public int createdByUserID { get; set; }
      public string createdTime { get; set; }

      /// <summary>
      /// The current guaranteed Stop Loss Order mode of the Account.
      /// </summary>
      public string guaranteedStopLossOrderMode { get; set; }

      public decimal pl { get; set; }
      public decimal resettablePL { get; set; }
      public string resettablePLTime { get; set; }

      /// <summary>
      /// The total amount of financing paid/collected over the lifetime of the Account.
      /// </summary>
      public decimal financing { get; set; }

      /// <summary>
      /// The total amount of commission paid over the lifetime of the Account.
      /// </summary>
      public decimal commission { get; set; }

      /// <summary>
      /// The total amount of fees charged over the lifetime of the Account for the execution of guaranteed Stop Loss Orders.
      /// </summary>
      public decimal guaranteedExecutionFees { get; set; }

      public decimal? marginRate { get; set; }
      public string marginCallEnterTime { get; set; }
      public int marginCallExtensionCount { get; set; }
      public string lastMarginCallExtensionTime { get; set; }
      public int openTradeCount { get; set; }
      public int openPositionCount { get; set; }
      public int pendingOrderCount { get; set; }
      public bool hedgingEnabled { get; set; }

      public long lastTransactionID { get; set; }
   }
}
