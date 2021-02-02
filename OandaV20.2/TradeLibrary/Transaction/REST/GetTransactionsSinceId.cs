using OkonkwoOandaV20.TradeLibrary.Transaction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OkonkwoOandaV20.TradeLibrary.REST
{
   public partial class Rest20
   {
      /// <summary>
      /// Get a range of Transactions for an Account starting at (but not including) a provided Transaction ID.
      /// http://developer.oanda.com/rest-live-v20/transaction-ep/#_collapse_endpoint_5
      /// </summary>
      /// <param name="accountID">the id of the account to which the transaction belongs</param>
      /// <param name="transactionID">the id of the first transaction to retrieve</param>
      /// <returns>A list of transaction objects</returns>
      public static async Task<List<ITransaction>> GetTransactionsSinceIdAsync(string accountID, long transactionID)
      {
         string uri = ServerUri(EServer.Account) + "accounts/" + accountID + "/transactions/sinceid";
         uri += "?id=" + transactionID;

         var response = await MakeRequestAsync<TransactionsSinceIdRangeResponse, TransactionsSinceIdRangeErrorResponse>(uri);

         return response.transactions;
      }
   }

   /// <summary>
   /// The GET success response received from accounts/accountID/transactions/sinceid
   /// </summary>
   public class TransactionsSinceIdRangeResponse : TransactionsResponse
   {
   }

   /// <summary>
   /// The GET error response received from accounts/accountID/transactions/sinceid
   /// </summary>
   public class TransactionsSinceIdRangeErrorResponse : TransactionsErrorResponse
   {
   }
}
