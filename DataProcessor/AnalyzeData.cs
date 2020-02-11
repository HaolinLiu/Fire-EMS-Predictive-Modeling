using System;
using System.Data;
using System.Collections.Generic;


namespace DataProcessor
{
	public class AnalyzeData
	{
        
        public static CallResponseData[] CombineData(DataTable callData, DataTable responseData)
		{
			Console.WriteLine("Number of datapoints: " + callData.Rows.Count);
			CallResponseData[] data = new CallResponseData[callData.Rows.Count];
			int rowCount = 0;

			foreach (DataRow row in callData.Rows)
			{
				string callID = row["CallID"].ToString();
				string natureCode = row["NatureCode"].ToString();
				DateTime callTime = DateTime.Parse(row["Date"].ToString());
				string address = row["Address"].ToString();

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

				CallResponseData newData = new CallResponseData(callID, natureCode, callTime, address, responses);
				data[rowCount] = newData;
				rowCount++;

			}

			return data;
		}

	}
}
