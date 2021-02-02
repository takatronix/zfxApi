using Newtonsoft.Json;
using OkonkwoOandaV20.TradeLibrary.REST;

namespace OkonkwoOandaV20.Framework.Factories
{
   public class ErrorResponseFactory
   {
      public static IErrorResponse Create(string message)
      {
         var dynamicError = JsonConvert.DeserializeObject<dynamic>(message);

         // the 'type' property is injected by the Rest20.GetWebResponse catch block

         switch (dynamicError.type.ToString())
         {
            case "AccountChangesErrorResponse":
               return JsonConvert.DeserializeObject<AccountChangesErrorResponse>(message);
            case "AccountConfigurationErrorResponse":
               return JsonConvert.DeserializeObject<AccountConfigurationErrorResponse>(message);
            case "AccountErrorResponse":
               return JsonConvert.DeserializeObject<AccountErrorResponse>(message);
            case "AccountsErrorResponse":
               return JsonConvert.DeserializeObject<AccountsErrorResponse>(message);
            case "AccountInstrumentsErrorResponse":
               return JsonConvert.DeserializeObject<AccountInstrumentsErrorResponse>(message);
            case "AccountSummaryErrorResponse":
               return JsonConvert.DeserializeObject<AccountSummaryErrorResponse>(message);
            case "InstrumentCandlesErrorResponse":
               return JsonConvert.DeserializeObject<InstrumentCandlesErrorResponse>(message);
            case "InstrumentOrderBookErrorResponse":
               return JsonConvert.DeserializeObject<InstrumentOrderBookErrorResponse>(message);
            case "InstrumentPositionBookErrorResponse":
               return JsonConvert.DeserializeObject<InstrumentPositionBookErrorResponse>(message);
            case "OpenPositionsErrorResponse":
               return JsonConvert.DeserializeObject<OpenPositionsErrorResponse>(message);
            case "OpenTradesErrorResponse":
               return JsonConvert.DeserializeObject<OpenTradesErrorResponse>(message);
            case "OrderCancelErrorResponse":
               return JsonConvert.DeserializeObject<OrderCancelErrorResponse>(message);
            case "OrderReplaceErrorResponse":
               return JsonConvert.DeserializeObject<OrderReplaceErrorResponse>(message);
            case "OrderClientExtensionsErrorResponse":
               return JsonConvert.DeserializeObject<OrderClientExtensionsErrorResponse>(message);
            case "OrderErrorResponse":
               return JsonConvert.DeserializeObject<OrderErrorResponse>(message);
            case "OrdersErrorResponse":
               return JsonConvert.DeserializeObject<OrdersErrorResponse>(message);
            case "PendingOrdersErrorResponse":
               return JsonConvert.DeserializeObject<PendingOrdersErrorResponse>(message);
            case "PositionErrorResponse":
               return JsonConvert.DeserializeObject<PositionErrorResponse>(message);
            case "PositionsErrorResponse":
               return JsonConvert.DeserializeObject<PositionsErrorResponse>(message);
            case "PostOrderErrorResponse":
               return JsonConvert.DeserializeObject<PostOrderErrorResponse>(message);
            case "PositionCloseErrorResponse":
               return JsonConvert.DeserializeObject<PositionCloseErrorResponse>(message);
            case "PricingErrorResponse":
               return JsonConvert.DeserializeObject<PricingErrorResponse>(message);
            case "TradeErrorResponse":
               return JsonConvert.DeserializeObject<TradeErrorResponse>(message);
            case "TradesErrorResponse":
               return JsonConvert.DeserializeObject<TradesErrorResponse>(message);
            case "TradeClientExtensionsErrorResponse":
               return JsonConvert.DeserializeObject<TradeClientExtensionsErrorResponse>(message);
            case "TradeCloseErrorResponse":
               return JsonConvert.DeserializeObject<TradeCloseErrorResponse>(message);
            case "TradeOrdersErrorResponse":
               return JsonConvert.DeserializeObject<TradeOrdersErrorResponse>(message);
            case "TransactionErrorResponse":
               return JsonConvert.DeserializeObject<TransactionErrorResponse>(message);
            case "TransactionsByIdRangeErrorResponse":
               return JsonConvert.DeserializeObject<TransactionsByIdRangeErrorResponse>(message);
            case "TransactionPagesErrorResponse":
               return JsonConvert.DeserializeObject<TransactionPagesErrorResponse>(message);
            case "TransactionsSinceIdRangeErrorResponse":
               return JsonConvert.DeserializeObject<TransactionsSinceIdRangeErrorResponse>(message);

            default:
               return JsonConvert.DeserializeObject<ErrorResponse>(message);
         }
      }
   }
}
