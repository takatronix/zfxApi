using Newtonsoft.Json;
using OkonkwoOandaV20.Framework.JsonConverters;
using OkonkwoOandaV20.TradeLibrary.Transaction;
using System.Threading.Tasks;

namespace OkonkwoOandaV20.TradeLibrary.REST
{
   public partial class Rest20
   {
      /// <summary>
      /// Get the details of a single Account Transaction
      /// http://developer.oanda.com/rest-live-v20/transaction-ep/#_collapse_endpoint_3
      /// </summary>
      /// <param name="accountID">the id of the account to which the transaction belongs</param>
      /// <param name="transactionID">the id of the transaction to retrieve</param>
      /// <returns>A Transaction object with the details of the transaction</returns>
      public static async Task<ITransaction> GetTransactionAsync(string accountID, long transactionID)
      {
         string uri = ServerUri(EServer.Account) + "accounts/" + accountID + "/transactions/" + transactionID;

         var response = await MakeRequestAsync<TransactionResponse, TransactionErrorResponse>(uri);

         return response.transaction;
      }
   }

   /// <summary>
   /// The GET success response received from accounts/accountID/transactions/transactionID
   /// </summary>
   public class TransactionResponse : Response
   {
      /// <summary>
      /// The details of the Transaction requested
      /// </summary>
      [JsonConverter(typeof(TransactionConverter))]
      public ITransaction transaction { get; set; }
   }

   /// <summary>
   /// The GET error response received from accounts/accountID/transactions/transactionID
   /// </summary>
   public class TransactionErrorResponse : ErrorResponse
   {
   }
}

