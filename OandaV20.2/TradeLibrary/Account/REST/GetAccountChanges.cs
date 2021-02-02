using OkonkwoOandaV20.TradeLibrary.Account;
using System.Threading.Tasks;

namespace OkonkwoOandaV20.TradeLibrary.REST
{
   public partial class Rest20
   {
      /// <summary>
      /// Endpoint used to poll an Account for its current state and changes since a specified TransactionID.
      /// http://developer.oanda.com/rest-live-v20/account-ep/#_collapse_endpoint_7
      /// </summary>
      /// <param name="accountID">details will be retrieved for this account id</param>
      /// <param name="parameters">the parameters for the request</param>
      /// <returns>an AccountChangesResponse object</returns>
      public static async Task<AccountChangesResponse> GetAccountChangesAsync(string accountID, AccountChangesParameters parameters)
      {
         string uri = ServerUri(EServer.Account) + "accounts/" + accountID + "/changes";

         uri += "?sinceTransactionID=" + parameters.sinceTransactionID;

         var response = await MakeRequestAsync<AccountChangesResponse, AccountChangesErrorResponse>(uri);

         return response;
      }

      public class AccountChangesParameters
      {
         /// <summary>
         /// ID of the Transaction to get Account changes since.
         /// </summary>
         public long sinceTransactionID { get; set; }
      }
   }

   /// <summary>
   /// The GET success response received from the accounts/accountID/changes
   /// </summary>
   public class AccountChangesResponse : Response
   {
      /// <summary>
      /// The changes to the Account’s Orders, Trades and Positions since the
      /// specified Transaction ID. Only provided if the sinceTransactionID is
      /// supplied to the poll request.
      /// </summary>
      public AccountChanges changes { get; set; }

      /// <summary>
      /// The Account’s current price-dependent state.
      /// </summary>
      public AccountChangesState state { get; set; }
   }

   /// <summary>
   /// The GET error response received from the accounts/accountID/changes
   /// </summary>
   public class AccountChangesErrorResponse : ErrorResponse
   {
   }
}
