using OkonkwoOandaV20.TradeLibrary.Transaction;
using System.Threading.Tasks;

namespace OkonkwoOandaV20.TradeLibrary.REST
{
   public partial class Rest20
   {
      /// <summary>
      /// Modify the Client Extensions for the order in the given account.
      /// http://developer.oanda.com/rest-live-v20/order-ep/
      /// </summary>
      /// <param name="accountId">the identifier of the account to post on</param>
      /// <param name="orderSpecifier">the orderSpecifier to update extensions for</param>
      /// <param name="parameters">the parameters for the request</param>
      /// <returns>an OrderClientExtensionsModifyResponse (throws an OrderClientExtensionsModifyErrorResponse if the request fails.)</returns>
      public static async Task<OrderClientExtensionsResponse> PutOrderClientExtensionsAsync(string accountID, long orderSpecifier, OrderClientExtensionsParameters parameters)
      {
         string uri = ServerUri(EServer.Account) + "accounts/" + accountID + "/orders/" + orderSpecifier + "/clientExtensions";

         //var extensions = new Dictionary<string, ClientExtensions>();
         //extensions.Add("clientExtensions", parameters.orderExtensions);

         //if (parameters.tradeExtensions != null)
         //extensions.Add("tradeClientExtensions", parameters.tradeExtensions);

         //var response = await MakeRequestWithJSONBody<OrderClientExtensionsModifyResponse, OrderClientExtensionsModifyErrorResponse, Dictionary<string, ClientExtensions>>("PUT", extensions, uri);

         var response = await MakeRequestWithJSONBody<OrderClientExtensionsResponse, OrderClientExtensionsErrorResponse, OrderClientExtensionsParameters>("PUT", parameters, uri);

         return response;
      }

      public class OrderClientExtensionsParameters
      {
         /// <summary>
         /// The Client Extensions to update for the Order. Do not set, modify, or
         /// delete clientExtensions if your account is associated with MT4.
         /// </summary>
         public ClientExtensions clientExtensions { get; set; }

         /// <summary>
         /// The Client Extensions to update for the Trade created when the Order is
         /// filled. Do not set, modify, or delete clientExtensions if your account is
         /// associated with MT4.
         /// </summary>
         public ClientExtensions tradeClientExtensions { get; set; }
      }
   }

   /// <summary>
   /// The PUT success response received from accounts/accountID/orders/orderSpecifier/clientExtensions
   /// </summary>
   public class OrderClientExtensionsResponse : Response
   {
      /// <summary>
      /// The Transaction that modified the Client Extensions for the Order
      /// </summary>
      public OrderClientExtensionsModifyTransaction orderClientExtensionsModifyTransaction { get; set; }
   }

   /// <summary>
   /// The PUT error response received from accounts/accountID/orders/orderSpecifier/clientExtensions
   /// </summary>
   public class OrderClientExtensionsErrorResponse : ErrorResponse
   {
      /// <summary>
      /// The Transaction that rejected the modification of the Client Extensions 
      /// for the Order. Only present if the Account exists.
      /// </summary>
      public OrderClientExtensionsModifyRejectTransaction orderClientExtensionsModifyRejectTransaction { get; set; }
   }
}