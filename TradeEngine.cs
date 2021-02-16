using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using zfxApi;

namespace zfxApi
{
    public delegate int PriceChangedDelegate(Price price);
    public delegate int LogDelegate(string log);

    public partial class TradeEngine
    {
        private static readonly TradeEngine instance = new TradeEngine();
        public static TradeEngine Instance { get => instance; }

        //    Currency pairs constants
        public const string USDJPY = "USDJPY";
        public const string GBPJPY = "GBPJPY";
        public const string GBPUSD = "GBPUSD";
        public const string EURJPY = "EURJPY";
        public const string EURUSD = "EURUSD";

        public PriceChangedDelegate priceChangedDelegate;
        public LogDelegate logDelegate;

        public List<string> log = new List<string>();

        public void Start(IConfiguration config)
        {
            StartOandaAPIThread(config);
            StartMongoDBThread(config);
            StartDiscordBot(config);
        }
        public void Notify(string text)
        {
            discord?.SendMessage(text);
        }

         DiscordBot discord = null;
        public void StartDiscordBot(IConfiguration config)
        {
            var token = config["DiscordBot:Token"];
            var channel = config.GetValue<ulong>("DiscordBot:Channel");
            discord = new DiscordBot(token, channel);
            discord.Start();
        }
        public  void SendToDiscord(string message)
        {
            discord?.SendMessage(message);
        }

        private void OnPriceChanged(Price price)
        {
            Insert(price);
            priceChangedDelegate?.Invoke(price);
        }
        public int Log(string text)
        {
            log.Add($"{DateTime.Now.ToLocalTime()} {text}");
            if (log.Count > 1024)
                log.RemoveAt(0);

            Console.WriteLine(text);
            logDelegate?.Invoke(text);
            return 0;
        }
    }
}
