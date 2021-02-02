using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using static OkonkwoOandaV20.TradeLibrary.REST.Rest20;

namespace zfxApi
{
    //          Oanda現在値取得
    public partial class TradeEngine
    {

        private string OandaAPI_AccountID;
        private string OandaAPI_Token;
        private string OandaAPI_Environment;

        ///////////////////////////////////////////
        //      現在値(Oanda)
        public ConcurrentDictionary<string, Price> OandaPrice = new ConcurrentDictionary<string, Price>();

        //////////////////////////////////////////////////////////
        /// <summary>
        /// OandaAPIによる現在値取得スレッド
        /// </summary>
        private async void StartOandaAPIThread(IConfiguration config)
        {
            var source = "OandaAPI";
            OandaAPI_AccountID = config["OandaAPI:AccountID"];
            OandaAPI_Token = config["OandaAPI:Token"];
            OandaAPI_Environment = config["OandaAPI:Environment"];

            ////////////////////////////////////////////
            //      OandaAPI初期化
            ////////////////////////////////////////////
            EEnvironment env = EEnvironment.Practice;
            if (OandaAPI_Environment == "Trade")
            {
                env = EEnvironment.Trade;
            }
            Credentials.SetCredentials(env, OandaAPI_Token, OandaAPI_AccountID);

            ////////////////////////////////////////////
            //      取得通貨を設定する
            ////////////////////////////////////////////
            var param = new PricingParameters();
            param.instruments = new List<string>
            {
                "USD_JPY",
                "GBP_JPY",
                "GBP_USD",
                "EUR_JPY",
                "EUR_USD"
            };

            ////////////////////////////////////////////
            //      辞書の初期化
            ////////////////////////////////////////////
            OandaPrice.TryAdd(USDJPY, new Price(source, TradeEngine.USDJPY));
            OandaPrice.TryAdd(GBPJPY, new Price(source, TradeEngine.GBPJPY));
            OandaPrice.TryAdd(GBPUSD, new Price(source, TradeEngine.GBPUSD));
            OandaPrice.TryAdd(EURJPY, new Price(source, TradeEngine.EURJPY));
            OandaPrice.TryAdd(EURUSD, new Price(source, TradeEngine.EURUSD));

            Log("[Oanda] Server Started");

            ////////////////////////////////////////////
            //      現在値取得ループ
            ////////////////////////////////////////////
            for (; ; )
            {
                try
                {
                    var list = await GetPricingAsync(OandaAPI_AccountID, param);
                    if (list == null)
                    {
                        Log("[Oanda] Communication error");
                        continue;
                    }

                    foreach (var p in list)
                    {
                        if (p.instrument == "USD_JPY")
                        {
                            var price = OandaPrice[TradeEngine.USDJPY];
                            price.Ask = (double)p.closeoutAsk;
                            price.Bid = (double)p.closeoutBid;
                            price.Time = DateTime.Now;
                            if (price.IsPriceChanged())
                                OnPriceChanged(price);
                        }
                        if (p.instrument == "GBP_JPY")
                        {
                            var price = OandaPrice[TradeEngine.GBPJPY];
                            price.Ask = (double)p.closeoutAsk;
                            price.Bid = (double)p.closeoutBid;
                            price.Time = DateTime.Now;
                            if (price.IsPriceChanged())
                                OnPriceChanged(price);
                        }
                        if (p.instrument == "GBP_USD")
                        {
                            var price = OandaPrice[TradeEngine.GBPUSD];
                            price.Ask = (double)p.closeoutAsk;
                            price.Bid = (double)p.closeoutBid;
                            price.Time = DateTime.Now;
                            if (price.IsPriceChanged())
                                OnPriceChanged(price);
                        }
                        if (p.instrument == "EUR_JPY")
                        {
                            var price = OandaPrice[TradeEngine.EURJPY];
                            price.Ask = (double)p.closeoutAsk;
                            price.Bid = (double)p.closeoutBid;
                            price.Time = DateTime.Now;
                            if (price.IsPriceChanged())
                                OnPriceChanged(price);
                        }
                        if (p.instrument == "EUR_USD")
                        {
                            var price = OandaPrice[TradeEngine.EURUSD];
                            price.Ask = (double)p.closeoutAsk;
                            price.Bid = (double)p.closeoutBid;
                            price.Time = DateTime.Now;
                            if (price.IsPriceChanged())
                                OnPriceChanged(price);
                        }
                    }
                }
                catch(Exception e)
                {
                    Log($"[Oanda] {e.Message}");
                    continue;
                }
            }
        }
    }
}