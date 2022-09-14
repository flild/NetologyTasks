using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NetologyTasks
{
    public class CycleTask
    {
        public int CycleWhile(int numberToReverse)
        {
            int reverseNumber = 0;
            while(numberToReverse > 0)
            {
                reverseNumber = reverseNumber*10 + numberToReverse % 10;
                numberToReverse /= 10;
            }
            return reverseNumber;
        }
    }
}