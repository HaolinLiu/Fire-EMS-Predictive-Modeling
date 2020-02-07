using System;
using System.Collections.Generic;
using System.Text;

namespace DataProcessor
{
    struct Response
    {
        string UnitID;
        string UnitType;
        DateTime Dispatched;
        DateTime Arrived;
    }

    struct CallResponseData
    {
        string CallID;
        string NatureCode;
        DateTime CallRecived;
        string Address;
        Response[] Responces;
    }
}
