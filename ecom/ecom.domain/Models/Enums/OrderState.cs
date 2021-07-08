using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecom.domain.Models
{
    public enum OrderState
    {
        InCart = 1,
        Placed = 2,
        Shipping = 3,
        Finished = 4
    }
}
