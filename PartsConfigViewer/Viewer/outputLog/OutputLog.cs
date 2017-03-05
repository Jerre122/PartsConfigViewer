using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Viewer.outputLog
{
    class OutputLog
    {
        private string outputLogFilename;
        private bool fileRead = false;
        private bool readError = false;

        public OutputLog(string outputLogFilename)
        {
            this.outputLogFilename = outputLogFilename;
        }

        public bool readContent()
        {
            if (fileRead)
                return false;
            if (!File.Exists(outputLogFilename))
            {
                Console.WriteLine("Could not find output logfile " + outputLogFilename);
                return false;
            }

            int counter = 0;
            string line;

            // Read the file and display it line by line.
            StreamReader file = new StreamReader(outputLogFilename);
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                counter++;
            }

            file.Close();

            // Suspend the screen.
            Console.ReadLine();


            return true;
        }
    }
}
