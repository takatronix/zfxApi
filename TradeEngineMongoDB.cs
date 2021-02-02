using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommonClass;
using Microsoft.Extensions.Configuration;

namespace zfxApi
{
    public partial class TradeEngine
    {
        private MongoManager mongoManager;
        private BlockingCollection<Price> priceQueue;
        private const int MaxPriceQueueSize = 1024;
        public volatile bool RunFlag = true;

        /// <summary>
        ///  データベース登録
        /// </summary>
        /// <param name="price"></param>
        public void Insert(Price price)
        {
            priceQueue?.TryAdd(price);
        }

        /////////////////////////////////////////////
        /// <summary>
        /// データベース登録スレッド
        /// </summary>
        public async void StartMongoDBThread(IConfiguration config)
        {
            priceQueue = new BlockingCollection<Price>(MaxPriceQueueSize);

            var server = config["MongoDB:Server"];
            var database = config["MongoDB:Database"];
            var user = config["MongoDB:User"];
            var password = config["MongoDB:Password"];
            var port = config.GetValue<int>("MongoDB:Port");
 
            if(server == null || user == null || password == null)
            {
                Log("[MongoDB] no server settings.");
                RunFlag = false;
                return;
            }
            /////////////////////////////////////////////
            //      別スレッドで処理
            await Task.Run(() =>
            {
                try
                {
                    mongoManager = new MongoManager(server, database, user, password,port); 
                }
                catch (Exception e)
                {
                    Log($"Database Connection Error:"+e.Message);
                    RunFlag = false;
                }

                while (RunFlag)
                {
                    if (!priceQueue.TryTake(out var price, Timeout.Infinite)) continue;
                    if (price == null)
                        continue;
                    try
                    {
                        mongoManager.Insert(price, price.Pair);
                    }
                    catch (Exception e)
                    {
                        Log(e.Message);
                    }
                }
                RunFlag = false;
            });
        }
    
    }
}
