using System;
using System.IO;
using System.Collections.Generic;

namespace ApplicationEndpoints
{
    public static class StaffDetailsFromFile
    {
        public static List<Staff> getStaffDetailsFromFile()
        {
            string staffFileName = @"C:\stafflist.csv";
            var staffList = new List<Staff>();

            if (!File.Exists(staffFileName))
            {
                throw new Exception(" file not found");
            }
            else
            {
                // get data from file;
                var linesFromStaffFile = File.ReadLines(staffFileName);
                
                foreach (string lineRead in linesFromStaffFile)
                {
                    if (lineRead.Contains("Id"))
                    {
                        continue;
                    }
                    // else spilt data by comma
                    string[] getValuesfromEachLine=lineRead.Split(",");

                    Staff staffObject = new Staff(
                            Int32.Parse(getValuesfromEachLine[0]),
                            getValuesfromEachLine[1],
                            getValuesfromEachLine[2],
                            getValuesfromEachLine[3],
                            getValuesfromEachLine[4]

                        );
                    staffList.Add(staffObject);
                   
                }
            }


            return staffList;
        }
    }
}
