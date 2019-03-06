using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Devenlab.Common
{
    public class IdleTimeFinder
    {
        // A module-level declare a variable of type integer, we call totalTime with initialized to zero. 
        // TotalTime we will indicate how many seconds we do not interact with keyboard and mouse. 
        int totaltime = 0;

        // Declare a new instance of the structure LASTINPUTINFO contained in GetLastInputInfo 
        LASTINPUTINFO lastInputInf = new LASTINPUTINFO();
        // The following code calls the library user32.dll GetLastInputInfo and function. 
        [DllImport("user32.dll")]
        public static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        // The DllImport attribute is very useful when reusing existing unmanaged code in a managed application. 
        // How can we find out within the term structure LASTINPUTINFO MarshalAs. 
        // Marshal is responsible to marshal data between managed and unmanaged code. 
        [StructLayout(LayoutKind.Sequential)]
        public struct LASTINPUTINFO
        {
            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public int dwTime;
        }

        // Function GetLastInputTime. 
        // This function returns the variable idletime and assigns the value of idle time spent, 
        // All converted in seconds for the initial value retrieved from this intruzione 
        // code = idletime Environment.TickCount - lastInputInf.dwTime and expressed in milliseconds. 
        // Inside the class MainWindows, also declare a variable of type integer and call idletime which will be enhanced by Function GetLastInputTime. 
        public int GetLastInputTime()
        {
            int idletime = 0;
            idletime = 0;
            lastInputInf.cbSize = Marshal.SizeOf(lastInputInf);
            lastInputInf.dwTime = 0;

            if (GetLastInputInfo(ref lastInputInf))
            {
                idletime = Environment.TickCount - lastInputInf.dwTime;
            }

            if (idletime != 0)
            {
                return lastInputInf.dwTime;
            }
            else
            {
                return 0;
            }
        } 

    }

    internal struct LASTINPUTINFO
    {
        public int cbSize;
        public int dwTime;
    }
}
