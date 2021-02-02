﻿/// <summary>
/// http://developer.oanda.com/rest-live-v20/account-df/
/// </summary>
namespace OkonkwoOandaV20.TradeLibrary.Account
{
   public class GuaranteedStopLossOrderMode
   {
      public const string Disabled = "DISABLED";
      public const string Allowed = "ALLOWED";
      public const string Required = "REQUIRED";
   }

   public class AccountFinancingMode
   {
      public const string Daily = "DAILY";
      public const string NoFinancing = "NO_FINANCING";
      public const string SecondBySecond = "SECOND_BY_SECOND";
   }

   public class PositionAggregationMode
   {
      public const string AbsoluteSum = "ABSOLUTE_SUM";
      public const string MaximalSide = "MAXIMAL_SIDE";
      public const string NetSum = "NET_SUM";
   }
}
