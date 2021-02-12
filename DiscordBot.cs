using Discord.WebSocket;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace zfxApi
{
    public class DiscordBot
    {
        private const int MaxQueueSize = 1024;
        public string Token;
        public ulong ChannelID;

        public DiscordBot(string token, ulong channelID)
        {
            this.Token = token;
            this.ChannelID = channelID;
            messageQueue = new BlockingCollection<string>(MaxQueueSize);
        }

        private BlockingCollection<string> messageQueue;
        private DiscordSocketClient client;
        private SocketTextChannel channel;
        public volatile bool ExitFlag = false;

        public async void Start()
        {
            if (string.IsNullOrEmpty(Token))
            {
                Console.WriteLine("DiscordBot: Token is empty.shutting down..");
                return;
            }
            //      別スレッドで処理
            await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(Token))
                    return;

                client = new DiscordSocketClient();
                client.LoginAsync(Discord.TokenType.Bot, Token);
                client.StartAsync();
                client.MessageReceived += OnMessageReceived;
                client.Ready += OnClientReady;

                for (; ; )
                {
                    string data;
                    if (messageQueue.TryTake(out data, System.Threading.Timeout.Infinite))
                    {
                        SendMessageAsync(data);
                    }

                    if (ExitFlag)
                    {
                        break;
                    }
                }
                client.Dispose();
                messageQueue.Dispose();
            });
        }

        public void SendMessage(string text)
        {
            messageQueue?.TryAdd(text);
        }

        private void SendMessageAsync(string text)
        {
            if (client == null)
            {
                return;
            }

            if (channel == null)
                channel = client.GetChannel(ChannelID) as SocketTextChannel;
            channel?.SendMessageAsync(text);
        }

        private async Task OnMessageReceived(SocketMessage arg)
        {
            if (arg.Author.IsBot)
                return;

            if(arg.Content.Equals("price"))
            {
                var priceDic = TradeEngine.Instance.OandaPrice;
                foreach(var key in priceDic.Keys)
                {
                    var price = priceDic[key];
                    channel?.SendMessageAsync(price.GetInformation());
                }
            }
            
 //           await arg.Channel.SendMessageAsync(arg.Content);
        }

        private async Task OnClientReady()
        {
            if(channel == null)
            {
                channel = client.GetChannel(ChannelID) as SocketTextChannel;
                SendMessageAsync("[zfxApi] 起動しました");
            }
        }
    }
}