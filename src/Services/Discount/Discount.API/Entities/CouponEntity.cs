﻿namespace Discount.API.Entities
{
    public class CouponEntity
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }
    }
}
