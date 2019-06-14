using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    [DataContract]
    class Sale : IEntity
    {
        [DataMember]
        public long Id { get; private set; }

        [DataMember]
        public long BuyerId { get; private set; }
        [DataMember]
        public long ShopId { get; private set; }
        [DataMember]
        public long GoodId { get; private set; }
        [DataMember]
        public long Amount { get; private set; }
        [DataMember]
        public long Price { get; private set; }

        public Sale(long id, long buyerId, long shopId, long goodId, long amount, long price)
        {
            Id = id;
            BuyerId = buyerId;
            ShopId = shopId;
            GoodId = goodId;
            Amount = amount;
            Price = price;
        }
    }
}
