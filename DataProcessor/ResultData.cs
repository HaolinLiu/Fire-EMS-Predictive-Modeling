using System;
using System.Collections.Generic;
using System.Text;

namespace DataProcessor
{
    class ResultData
    {   
        public List<string> NatureCode;
        // Store all the nature code like 321

        public int NatureCodeNum;
        // Store the number of nature codes

        public List<string> UnitTypeName;
        // Store all the unit type name;

        public int UnitTypeNum;
        // Store the number of unit types

        public List<long> Result;
        // Store the result of sending units like 010200
        // 2 UnitTypeName[2] and 1 UnitTypeName[4]

        public ResultData(List<string> NatureCode, int NatureCodeNum, List<string> UnitTypeName, int UnitTypeNum, List<long> Result){
            this.NatureCode = NatureCode;
            this.NatureCodeNum = NatureCodeNum;
            this.UnitTypeName = UnitTypeName;
            this.UnitTypeNum = UnitTypeNum;
            this.Result = Result;
        }

        public void PrintResult(){
            long result;

            Console.WriteLine("Result:\n");

            for (int i=1; i<=NatureCodeNum; i++){

                Console.WriteLine("Nature code:{0}.", NatureCode[i]);

                result = Result[i];

                for (int j=0; j<UnitTypeNum; j++) {
                    Console.WriteLine("{0} {1}", result % 10, UnitTypeName[j]);
                    // get last digit
                    result = result / 10;
                    // delete last digit
                }
            }
        }
    }
}
