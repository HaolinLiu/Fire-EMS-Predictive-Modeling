# Fire-EMS-Predictive-Modeling
1. Run WindowsFormsApp2.sln and push Start.
    or bin/x64/debug/WindowsFormsApp2.exe
    
2. Click Import. 
    Choose EasierSampleCalls.csv as call data. 
    Choose EasierSampleResponses.csv as response data.
   Wait to see the result.
   It will shows files address, call numbers, code type numbers, unit type numbers, bad data numbers, earliest and latest time.
   
   The files need to be csv format. 
   Call column names need include "Call ID", "Nature Code", "Address", and "Date".
   Response column names need include "CallID", "Unit", "Role", "Responding", "Arrived".
   The words need to be exactly the same, but you can change them in the code or csv files.
   
3. Choose options in the bottom part of the software. You can choose month, day of week, year, and time preiods.
    Then click Select. It will shows how many items are selected, and pop out a message "selected".
    
    This will filter and output train and test file to "appPath/data/"
    The train items need to be large than 1000
    the test items need to be large than 100
    Start time need to be less than end time.


3. Click Analyse. Wait to see the degree of accuracy. It may take minutes depands on computer and data.
    it will shows the accuracy and options.
    
    Micro-Accuracy          The closer to 1.00, the better.
    Macro-Accuracy          The closer to 1.00, the better.
    Log-loss	            The closer to 0.00, the better.
    Log-Loss Reduction      Ranges from -inf and 1.00, where 1.00 is perfect predictions and 0.00 indicates mean predictions.
    
    Micro-Accuracy is the most important one in this kind of data.
    
    10k items take about 30s to run on my labtop.
    200k items take about 12 minutes.
    
4. You can save rules to a csv file after all.
    Click "Save Rules". A window will pop out for the name of file.
    The file will be saved to "appPath/data/{name}.csv"
    
    The step take about the same time like analyse.


You can select and analyse again after all. Don't need import again.

There will be alart or message after most steps.

You can move the window by pressing the black area and moving.

The data is fake.

You need to choose call data first and response data second.

Configuration could only be x64 or x86.

If it shows "can't find CpuMathNative.dll", you need to add this file to bin/x64/Debug. This is a bug of ML.NET. You can find it online or email me for it.

You can check console for the running information.

