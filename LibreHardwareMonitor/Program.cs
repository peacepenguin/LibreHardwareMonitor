// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at http://mozilla.org/MPL/2.0/.
// Copyright (C) LibreHardwareMonitor and Contributors.
// Partial Copyright (C) Michael Möller <mmoeller@openhardwaremonitor.org> and Contributors.
// All Rights Reserved.

using System;
using System.IO;
using System.Windows.Forms;
using LibreHardwareMonitor.UI;

namespace LibreHardwareMonitor
{
    public static class Program
    {

        //fan curve config global variables:

        public static string Gpuhardwarename = "AMD Radeon RX 6800 XT";
        public static string Gpusensorname = "GPU Core";

        public static string Cpuhardwarename = "AMD Ryzen 9 5900X";
        public static string Cpusensorname = "Core (Tctl/Tdie)";

        //string cpuhardwarename = "Intel Core i7-4810MQ";
        //string cputempname = "CPU Package";

        // Fan identifiers:
        //ASUS TUF GAMING X570-PLUS, Nuvoton NCT6798D, Fan Control #3, 32.941177, Control //front intake
        //ASUS TUF GAMING X570-PLUS, Nuvoton NCT6798D, Fan Control #4, 32.941177, Control //rear exhaust

        public static string FanAhardwarename = "ASUS TUF GAMING X570-PLUS";
        public static string FanBhardwarename = "ASUS TUF GAMING X570-PLUS";
        public static string FanAsubhardwarename = "Nuvoton NCT6798D";
        public static string FanBsubhardwarename = "Nuvoton NCT6798D";
        public static string FanAsensorname = "Fan #3";
        public static string FanBsensorname = "Fan #4";
        public static string FanAcontrolname = "Fan Control #3";
        public static string FanBcontrolname = "Fan Control #4";

        public static int FanArpm = 0;
        public static int FanBrpm = 0;

        
        // we're using the CPU and GPU as an aggregate input,
        // take the SUM of the temperatures, and adjust the curve to that temp.
        // The total heat of the system = ~ CPU + GPU temp
        // when controlling chassis fans, the entire system load should be considered
        // when controlling aio pumps, or cpu fans, only the cpu load should be considered

        // initial point on the curve, defines the lowest possible fan speed:
        public static float CurveAtemp1 = 80;
        public static float CurveAspeed1 = 20;

        // light load point
        public static float CurveAtemp2 = 100;
        public static float CurveAspeed2 = 40;

        // medium load point
        public static float CurveAtemp3 = 120;
        public static float CurveAspeed3 = 80;

        // max load point
        public static float CurveAtemp4 = 140;
        public static float CurveAspeed4 = 100;  //final point should always be 100, or the "max" value for the curve.

        // hysterysis value (ie. don't change the fan speed unless the new temp is <value> more or less than the temp when the speed was set most recently)
        public static int Temphysterysis = 8;

        public static bool Speedchange = false;


        // end config 

        // get the slope of the points:    each point of curve is just an (x, y) coordinate. x is temp, y is speed on our fan curve.
        public static float Slope1to2 = (CurveAspeed2 - CurveAspeed1) / (CurveAtemp2 - CurveAtemp1);
        public static float Slope2to3 = (CurveAspeed3 - CurveAspeed2) / (CurveAtemp3 - CurveAtemp2);
        public static float Slope3to4 = (CurveAspeed4 - CurveAspeed3) / (CurveAtemp4 - CurveAtemp3);

        //calculate the lines 'b' value (from the Direct method/equation to a line)
        public static float Slope1to2bvalue = CurveAspeed1 - (Slope1to2 * CurveAtemp1);
        public static float Slope2to3bvalue = CurveAspeed2 - (Slope2to3 * CurveAtemp2);
        public static float Slope3to4bvalue = CurveAspeed3 - (Slope3to4 * CurveAtemp3);


        // doing bvalue calcs in advance now instead of in the loop for efficiency 
        //float bvalue;


        public static float Gpucurrenttemp = 0;
        public static float Cpucurrenttemp = 0;

        public static float Sumoftemps = 0;
        public static float Sumoftempslastused = 0;


        public static int Speedtoset = 40;  //set an initial value to ensure the fans are set to something besides null or 0 if an exception occurs.
        public static int Speedlastset = 0;

        // end of fan curve global variables ///





        [STAThread]
        public static void Main()
        {
            if (!AllRequiredFilesAvailable())
                Environment.Exit(0);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (MainForm form = new MainForm())
            {
                form.FormClosed += delegate
                {
                    Application.Exit();
                };
                Application.Run();
            }
        }

        private static bool IsFileAvailable(string fileName)
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar;
            if (!File.Exists(path + fileName))
            {
                MessageBox.Show("The following file could not be found: " + fileName +
                  "\nPlease extract all files from the archive.", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private static bool AllRequiredFilesAvailable()
        {
            if (!IsFileAvailable("Aga.Controls.dll"))
                return false;

            if (!IsFileAvailable("LibreHardwareMonitorLib.dll"))
                return false;

            if (!IsFileAvailable("OxyPlot.dll"))
                return false;

            if (!IsFileAvailable("OxyPlot.WindowsForms.dll"))
                return false;

            return true;
        }
    }
}
