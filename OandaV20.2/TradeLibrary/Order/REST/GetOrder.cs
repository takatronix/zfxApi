using Newtonsoft.Json;
using OkonkwoOandaV20.Framework.JsonConverters;
using OkonkwoOandaV20.TradeLibrary.Order;
using System.Threading.Tasks;

namespace OkonkwoOandaV20.TradeLibrary.REST
{
   /// <summary>
   /// http://developer.oanda.com/rest-live-v20/account-ep/
   /// </summary>
   public partial class Rest20
   {
      /// <summary>
      /// Retrieves an order belonging to the account
      /// </summary>
      /// <param name="accountID">the identifier of the account to retrieve the list for</param>
      /// <param name="orderSpecifier">The Order Specifier (orderId) [required]</param>
      /// <returns>a List of Order objects (or empty list, if no orders)</returns>
      public static async Task<IOrder> GetOrderAsync(string accountID, long orderSpecifier)
      {
         string uri = ServerUri(EServer.Account) + "accounts/" + accountID + "/orders/" + orderSpecifier;

         var response = await MakeRequestAsync<OrderResponse, OrderErrorResponse>(uri);

         return response.order;
      }
   }

   /// <summary>
   /// The GET success response received from accounts/accountID/orders/orderSpecifier
   /// </summary>
   public class OrderResponse : Response
   {
      [JsonConverter(typeof(OrderConverter))]
      public IOrder order { get; set; }
   }

   /// <summary>
   /// The GET error response received accounts/accountID/orders/orderSpecifier
   /// </summary>
   public class OrderErrorResponse : ErrorResponse
   {
   }
}
