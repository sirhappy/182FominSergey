using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    class Sale : IEntity
    {
        public long Id { get; private set; }

        public long BuyerId { get; private set; }
        public long ShopId { get; private set; }
        public long GoodId { get; private set; }
        public long Amount { get; private set; }
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
