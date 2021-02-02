using Newtonsoft.Json;
using OkonkwoOandaV20.Framework.Factories;
using OkonkwoOandaV20.TradeLibrary.Instrument;
using System;
using System.Threading.Tasks;

namespace OkonkwoOandaV20.TradeLibrary.REST
{
   /// <summary>
   /// http://developer.oanda.com/rest-live-v20/account-ep/
   /// </summary>
   public partial class Rest20
   {
      /// <summary>
      /// Fetch a position book for an instrument
      /// </summary>
      /// <param name="instrument">Name of the Instrument [required]</param>
      /// <param name="parameters">the parameters for the request</param>
      /// <returns>a PositionBook object</returns>
      public static async Task<PositionBook> GetInstrumentPositionBookAsync(string instrument, InstrumentPositionBookParameters parameters)
      {
         string uri = ServerUri(EServer.Account) + "instruments/" + instrument + "/positionBook";
         var requestParams = ConvertToDictionary(parameters);

         InstrumentPositionBookResponse response = null;
         try { response = await MakeRequestAsync<InstrumentPositionBookResponse, InstrumentPositionBookErrorResponse>(uri, "GET", requestParams); }
         catch (Exception ex)
         {
            if (parameters.getLastTimeOnFailure)
            {
               parameters.time = null;
               response = await MakeRequestAsync<InstrumentPositionBookResponse, InstrumentPositionBookErrorResponse>(uri, "GET", requestParams);
            }            
            else
               throw ex;
         }

         return response.positionBook;
      } 

      public class InstrumentPositionBookParameters
      {
         public InstrumentPositionBookParameters(bool getLastTimeOnFailure = true)
         {
            this.getLastTimeOnFailure = getLastTimeOnFailure;
         }

         /// <summary>
         /// The time of the snapshot to fetch. If not specified, then the most recent snapshot 
         /// is fetched.
         /// </summary>
         public string time { get; set; }

         /// <summary>
         /// 
         /// </summary>
         [JsonIgnore]
         public bool getLastTimeOnFailure { get; set; }
      }
   }

   /// <summary>
   /// The GET success response received from instruments/instrument/positionBook
   /// </summary>
   public class InstrumentPositionBookResponse : Response
   {
      /// <summary>
      /// The instrument’s position book
      /// </summary>
      public PositionBook positionBook;
   }

   /// <summary>
   /// The GET error response received from instruments/instrument/positionBook
   /// </summary>
   public class InstrumentPositionBookErrorResponse : ErrorResponse
   {
   }
}