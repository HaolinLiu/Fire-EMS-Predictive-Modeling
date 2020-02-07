using System;
using System.Collections.Generic;
using System.Text;

namespace DataProcessor
{
    struct CallResponseData
    {
        struct Response {

        string UnitID;
        string UnitType;
        DateTime Dispatched;
        DateTime Arrived;

        }

        string CallID;
    }
}
