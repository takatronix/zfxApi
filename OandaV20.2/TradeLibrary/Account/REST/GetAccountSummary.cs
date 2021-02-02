using OkonkwoOandaV20.TradeLibrary.Account;
using System.Threading.Tasks;

namespace OkonkwoOandaV20.TradeLibrary.REST
{
   public partial class Rest20
   {
      /// <summary>
      /// Get a summary for a single Account that a client has access to.
      /// http://developer.oanda.com/rest-live-v20/account-ep/#_collapse_endpoint_4
      /// </summary>
      /// <param name="accountID">summary will be retrieved for this account id</param>
      /// <returns>an AccountSummary object containing the account details</returns>
      public static async Task<AccountSummary> GetAccountSummaryAsync(string accountID)
      {
         string uri = ServerUri(EServer.Account) + "accounts/" + accountID + "/summary";

         var response = await MakeRequestAsync<AccountSummaryResponse, AccountSummaryErrorResponse>(uri);
         return response.account;
      }
   }

   /// <summary>
   /// The GET success response received from the accounts/accountID/summary
   /// </summary>
   public class AccountSummaryResponse : Response
   {
      /// <summary>
      /// The summary of the requested Account.
      /// </summary>
      public AccountSummary account { get; set; }
   }

   /// <summary>
   /// The GET error response received from the accounts/accountID/summary
   /// </summary>
   public class AccountSummaryErrorResponse : ErrorResponse
   {
   }
}