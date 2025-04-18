using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Infrastructure.DataModels;

public enum OrderState
{
    New = 0,
    Confirmed = 1,
    Canceled = 2
}
