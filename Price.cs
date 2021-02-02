using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;


namespace zfxApi
{
    public class Price
    {
        public Price() { }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Source { get; set; }
        public string Pair { get; set; }

        public double Bid
        {
            get => curBid;
            set
            {
                lastBid = curBid;
                curBid = value;
            }
        }
        public double Ask
        {
            get => curAsk;
            set
            {
                lastAsk = curAsk;
                curAsk = value;
            }
        }
        private double lastBid;
        private double lastAsk;
        private double curBid;
        private double curAsk;

        public DateTime Time { get; set; }
        public Price(string source, string pair)
        {
            Source = source;
            Pair = pair;
        }

        public Price(Price pr)
        {
            this.Id = ObjectId.GenerateNewId().ToString();
            this.Source = pr.Source;
            this.Ask = pr.Ask;
            this.Bid = pr.Bid;
            this.Time = pr.Time;
        }
        public bool IsPriceChanged()
        {
            if (lastBid == curBid && lastAsk == curAsk)
            {
                return false;
            }
            return true;
        }

    }
}