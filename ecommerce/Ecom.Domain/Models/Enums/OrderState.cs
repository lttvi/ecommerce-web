using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Domain.Models
{
    public enum OrderState
    {
        InCart,
        Placed,
        Shipping,
        Finished
    }
}
