using System;
using System.Data;
using System.Collections.Generic;


namespace DataProcessor
{	
	
	public class AnalyzeData
	{
	
		int NatureCodeNum = 0;
        // how many nature code types

		public int UnitTypeNum = 0;
		// how many unit types
        public string[] UnitTypeName = new string[100]; 
		// for store name of unit types

        int callCount = 0;


		public int AddTypeName(string role){
			for ( int i = 0; i < UnitTypeNum; i++ )
			// check all the exist unit type
            {
               if(UnitTypeName[i] == role){
				// if their name are same, return its id
				   return i;
			   }
            }

			// if there is no this type, add it and incrise the number
			UnitTypeName[UnitTypeNum] = role;
			UnitTypeNum++;

			// return its new id
			return UnitTypeNum-1;
		}


        public CallResponseData[] CombineData(DataTable callData, DataTable responseData)
		{	
			//Array of data objects
			CallResponseData[] data = new CallResponseData[callData.Rows.Count];
			
			//Counter to track what data item we are on
			int rowCount = 0;

            //set all nature code type to false. When add a call, change its code to 1
            bool[] NatureCodeType = new bool[1000];
            for ( int i = 0; i < 1000; i++ )
            {
                NatureCodeType[i] = false;
            }


			foreach (DataRow row in callData.Rows)
			{
				//read the relevent data out of the data table
				string callID = row["CallID"].ToString();
				string natureCode = row["NatureCode"].ToString();
				DateTime callTime = DateTime.Parse(row["Date"].ToString());
				string address = row["Address"].ToString();
				
				// change the nature code to ture, like NatureCodeType[321] = true
                NatureCodeType[Int16.Parse(natureCode)] = true;

				//Get all response entries for the current call
				DataRow[] responsesToCall = responseData.Select("CallID = '" + callID.ToString() + "'");

				List<CallResponseData.Response> responses = new List<CallResponseData.Response>();

                int responsesNum = 0;
				long result = 0;

				foreach (DataRow responseRow in responsesToCall)
				{
					string unitID = responseRow["Unit"].ToString();
					string unitType = responseRow["Role"].ToString();
					DateTime dispatched = DateTime.Parse(responseRow["Responding"].ToString());
					DateTime arrived = DateTime.Parse(responseRow["Arrived"].ToString());

					CallResponseData.Response response = new CallResponseData.Response(unitID, unitType, dispatched, arrived);
					responses.Add(response);
                    
                    responsesNum++;

					result = result + (long)System.Math.Pow(10, AddTypeName(unitType)); 
				}

				//create the new object and store it in the array at the relevent spot
				CallResponseData newData = new CallResponseData(callID, natureCode, callTime, address, responses, responsesNum, result);
				data[rowCount] = newData;
				rowCount++;

                callCount++;

			}


			// get number of different nature code type
            int NatureCodeTypeNum = 0;

            for ( int i = 0; i < 1000; i++ )
            {
                if (NatureCodeType[i] == true){
                    NatureCodeTypeNum++;
                }
            }

			return data;
		}

		public void SummaryData(CallResponseData Data){

			Console.WriteLine("Call numbers:");
			Console.WriteLine("Response Numbers:");
			Console.WriteLine("Average response numbers:");
			Console.WriteLine("Nature code type numbers:");
			Console.WriteLine("Response unit type:");
			Console.WriteLine("Start data:");
			Console.WriteLine("End data");

		}

	}
}