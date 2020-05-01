# Fire-EMS-Predictive-Modeling
1. Run WindowsFormsApp2.sln and push Start.
2. Click Import. 
    Choose EasierSampleCalls.csv as call data. 
    Choose EasierSampleResponses.csv as response data.
   Wait to see the result.
3. Click Analyse. Wait to see the degree of accuracy. It may take minutes depands on computer and data.

You can move the window by pressing the black area and moving.
The data is fake.
You need to choose call data first and response data second.
Configuration could only be x64 or x86.
If it shows "can't find CpuMathNative.dll", you need to add this file to bin/x64/Debug. This is a bug of ML.NET. You can find it online or email me for it.
The importer branch has the program running on console. It is easy and fast to see the result.
