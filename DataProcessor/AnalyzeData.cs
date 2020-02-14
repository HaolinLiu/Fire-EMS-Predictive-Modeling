using System;
using System.Data;
using System.Collections.Generic;



namespace DataProcessor
{
	public class AnalyzeData
	{
        
        public static CallResponseData[] CombineData(DataTable callData, DataTable responseData)
		{	
			//Array of data objects
			CallResponseData[] data = new CallResponseData[callData.Rows.Count];
			
			//Counter to track what data item we are on
			int rowCount = 0;

			foreach (DataRow row in callData.Rows)
			{
				//read the relevent data out of the data table
				string callID = row["CallID"].ToString();
				string natureCode = row["NatureCode"].ToString();
				DateTime callTime = DateTime.Parse(row["Date"].ToString());
				string address = row["Address"].ToString();

				//Get all response entries for the current call
				DataRow[] responsesToCall = responseData.Select("CallID = '" + callID.ToString() + "'");

				List<CallResponseData.Response> responses = new List<CallResponseData.Response>();

				foreach (DataRow responseRow in responsesToCall)
				{
					string unitID = responseRow["Unit"].ToString();
					string unitType = responseRow["Role"].ToString();
					DateTime dispatched = DateTime.Parse(responseRow["Responding"].ToString());
					DateTime arrived = DateTime.Parse(responseRow["Arrived"].ToString());

					CallResponseData.Response response = new CallResponseData.Response(unitID, unitType, dispatched, arrived);
					responses.Add(response);
				}

				//create the new object and store it in the array at the relevent spot
				CallResponseData newData = new CallResponseData(callID, natureCode, callTime, address, responses);
				data[rowCount] = newData;
				rowCount++;

			}

			return data;
		}

	}
}
