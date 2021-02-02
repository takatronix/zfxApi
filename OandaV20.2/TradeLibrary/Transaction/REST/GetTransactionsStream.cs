using Newtonsoft.Json;
using OkonkwoOandaV20.Framework.JsonConverters;
using OkonkwoOandaV20.TradeLibrary.Transaction;
using OkonkwoOandaV20.TradeLibrary.REST.Streaming;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace OkonkwoOandaV20.TradeLibrary.REST
{
   public partial class Rest20
   {
      /// <summary>
      /// Get a stream of Transactions for an Account starting from when the request is made
      /// </summary>
      /// <param name="accountID">the account ID you want to stream on</param>
      /// <returns>the WebResponse object that can be used to retrieve the events as they stream</returns>
      public static async Task<WebResponse> GetTransactionsStream(string accountID)
      {
         string uri = ServerUri(EServer.TransactionsStream) + "accounts/" + accountID + "/transactions/stream";

         HttpWebRequest request = WebRequest.CreateHttp(uri);
         request.Method = "GET";
         request.Headers[HttpRequestHeader.Authorization] = "Bearer " + AccessToken;

         try
         {
            WebResponse response = await request.GetResponseAsync();
            return response;
         }
         catch (WebException ex)
         {
            var response = (HttpWebResponse)ex.Response;
            var stream = new StreamReader(response.GetResponseStream());
            var result = stream.ReadToEnd();
            throw new Exception(result);
         }
      }
   }

   /// <summary>
   /// Events are authorized transactions posted to the subject account.
   /// http://developer.oanda.com/rest-live-v20/transaction-ep/#collapse_endpoint_6
   /// </summary>
   [JsonConverter(typeof(TransactionsStreamResponseConverter))]
   public class TransactionsStreamResponse : StreamResponse
   {
      /// <summary>
      /// The most recent Transaction completed for the Account
      /// </summary>
      public ITransaction transaction { get; set; }
   }

   public class TransactionsHeartbeat : Heartbeat
   {
      /// <summary>
      /// The ID of the most recent Transaction created for the Account
      /// </summary>
      public long? lastTransactionID { get; set; }
   }

   public class TransactionsSession : StreamSession<TransactionsStreamResponse>
   {
      public TransactionsSession(string accountID) : base(accountID)
      {
      }

      protected override async Task<WebResponse> GetSession()
      {
         return await Rest20.GetTransactionsStream(_accountID);
      }
   }
}
