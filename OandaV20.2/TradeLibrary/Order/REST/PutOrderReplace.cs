using Newtonsoft.Json;
using OkonkwoOandaV20.Framework.JsonConverters;
using OkonkwoOandaV20.TradeLibrary.REST.OrderRequest;
using OkonkwoOandaV20.TradeLibrary.Transaction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OkonkwoOandaV20.TradeLibrary.REST
{
   /// <summary>
   /// http://developer.oanda.com/rest-live-v20/account-ep/
   /// </summary>
   public partial class Rest20
   {
      /// <summary>
      /// Replace an order by simultaneously cancelling it and replacing it with the given order request
      /// </summary>
      /// <param name="accountID">the identifier of the account to post on</param>
      /// <param name="orderSpecifier">the orderSpecifier of the order to cancel</param>
      /// <param name="parameters">the parameters for the request</param>
      /// <returns>PostOrderResponse with details of the results (throws if if fails)</returns>
      public static async Task<OrderReplaceResponse> PutOrderReplaceAsync(string accountID, long orderSpecifier, IOrderRequest request)
      {
         string uri = ServerUri(EServer.Account) + "accounts/" + accountID + "/orders/" + orderSpecifier;

         var order = new Dictionary<string, IOrderRequest> { { "order", request } };
         var body = ConvertToJSON(order);

         var response = await MakeRequestWithJSONBody<OrderReplaceResponse, OrderReplaceErrorResponse>("PUT", body, uri);

         return response;
      }
   }

   /// <summary>
   /// The PUT success response received from accounts/accountID/orders/orderSpecifier
   /// </summary>
   public class OrderReplaceResponse : Response
   {
      /// <summary>
      /// The Transaction that cancelled the Order to be replaced.
      /// </summary>
      public OrderCancelTransaction orderCancelTransaction { get; set; }

      /// <summary>
      /// The Transaction that created the replacing Order as requested.
      /// </summary>
      [JsonConverter(typeof(TransactionConverter))]
      public ITransaction orderCreateTransaction { get; set; }

      /// <summary>
      /// The Transaction that filled the replacing Order. This is only provided
      /// when the replacing Order was immediately filled.
      /// </summary>
      public OrderFillTransaction orderFillTransaction { get; set; }

      /// <summary>
      /// The Transaction that reissues the replacing Order. Only provided when the
      /// replacing Order was partially filled immediately and is configured to be
      /// reissued for its remaining units.
      /// </summary>
      [JsonConverter(typeof(TransactionConverter))]
      public ITransaction orderReissueTransaction { get; set; }

      /// <summary>
      /// The Transaction that rejects the reissue of the Order. Only provided when
      /// the replacing Order was paritially filled immediately and was configured
      /// to be reissued, however the reissue was rejected.
      /// </summary>
      [JsonConverter(typeof(TransactionConverter))]
      public ITransaction orderReissueRejectTransaction { get; set; }

      /// <summary>
      /// The Transaction that cancelled the replacing Order. Only provided when
      /// the replacing Order was immediately cancelled.
      /// </summary>
      public OrderCancelTransaction replacingOrderCancelTransaction { get; set; }
   }

   /// <summary>
   /// The PUT error response received from accounts/accountID/orders/orderSpecifier
   /// </summary>
   public class OrderReplaceErrorResponse : OrderCancelErrorResponse
   {
      /// <summary>
      /// The Transaction that rejected the creation of the replacing Order
      /// </summary>
      [JsonConverter(typeof(TransactionConverter))]
      public ITransaction orderRejectTransaction { get; set; }
   }
}