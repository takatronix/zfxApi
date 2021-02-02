using System.Threading.Tasks;

namespace OkonkwoOandaV20.TradeLibrary.REST
{
   public partial class Rest20
   {
      /// <summary>
      /// Get the full details for a single Account that a client has access to. Full pending Order, open Trade 
      /// and open Position representations are provided.
      /// http://developer.oanda.com/rest-live-v20/account-ep/#_collapse_endpoint_3
      /// </summary>
      /// <param name="accountID">details will be retrieved for this account id</param>
      /// <returns>an Account object containing the account details</returns>
      public static async Task<Account.Account> GetAccountAsync(string accountID)
      {
         string uri = ServerUri(EServer.Account) + "accounts/" + accountID;

         var response = await MakeRequestAsync<AccountResponse, AccountErrorResponse>(uri);
         return response.account;
      }
   }

   /// <summary>
   /// The GET success response received from the accounts/accountID
   /// </summary>
   public class AccountResponse : Response
   {
      /// <summary>
      /// The full details of the requested Account.
      /// </summary>
      public Account.Account account { get; set; }
   }

   /// <summary>
   /// The GET error response received from the accounts/accountID
   /// </summary>
   public class AccountErrorResponse : ErrorResponse
   {
   }
}