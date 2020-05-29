using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Models
{
    public enum BuyStatus
    {
        ORDER_PAYMENT_TYPE_NOT_FOUND,
        ORDER_CODE_NOT_FOUND,
        CUSTOMER_NAME_NOT_FOUND,
        CUSTOMER_ADDRESS_NOT_FOUND,
        CUSTOMER_MOBILE_NOT_FOUND,
        PRODUCT_NOT_FOUND,
        ORDER_CODE_IS_EXISTS,
    }
}
