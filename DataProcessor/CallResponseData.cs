using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML.Data;

namespace DataProcessor
{

    public class CallResponseData
    {
        
        public string CallID;

        [LoadColumn(0)]
        public string NatureCode;

        public DateTime CallRecived;
        public string Address;
        public List<Response> Responses;
        public int ResponsesNum;
        public long Result;

        string responseStr;

        /// <summary>
        /// Data for a response to a call
        /// </summary>
        public struct Response
        {
            public string UnitID;
            public string UnitType;
            public DateTime Dispatched;
            public DateTime Arrived;

            /// <summary>
            /// Data about response to a call
            /// </summary>
            /// <param name="unitID">ID of responding unit</param>
            /// <param name="unitType">Type of Unit</param>
            /// <param name="dispatched">Time unit was dispached to scene</param>
            /// <param name="arrived">time unit arrived on scene</param>
            public Response(string unitID, string unitType, DateTime dispatched, DateTime arrived)
            {
                UnitID = unitID;
                UnitType = unitType;
                Dispatched = dispatched;
                Arrived = arrived;
            }
        }

        /// <summary>
        /// Data for a single call and all responses
        /// </summary>
        /// <param name="callID">ID of call</param>
        /// <param name="natureCode">Emergency code</param>
        /// <param name="callRecived">Tiem call was recived at dispach</param>
        /// <param name="address">Address of emergency</param>
        /// <param name="responses">Array of all units dispached to emergency site</param>
      
        public CallResponseData(string callID, string natureCode, DateTime callRecived, string address, List<Response> responses, int responsesNum, long result)
        {
            CallID = callID;
            NatureCode = natureCode;
            CallRecived = callRecived;
            Address = address;
            Responses = responses;
            ResponsesNum = responsesNum;
            Result = result;
        }
    }
    
}

