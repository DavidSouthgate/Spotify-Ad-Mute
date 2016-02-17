using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Spotify_Ad_Mute
{
    class Program
    {

        static int get_spotify_pid()
        {
            int process_id = 0;
            Process[] process_list = Process.GetProcessesByName("Spotify");

            for (int i = 0; i < process_list.Length; i++)
            {
                if (process_list[i].MainWindowTitle != "")
                {
                    process_id = process_list[i].Id;
                }
            }
            return process_id;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Spotfy Ad Mute [Version 1.0.0.0]");
            Console.WriteLine("(c) 2015 David Southgate");
            Console.WriteLine();
            Console.WriteLine("Press Any Key To Start");
            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine("Unmuting Volume");
            Volume_Control.unmute();
            bool mute = false;

            int process_id = get_spotify_pid();
            bool loop_again = true;

            while(loop_again == true)
            {
                string window_title = Process.GetProcessById(process_id).MainWindowTitle;

                //If blank window title
                if(window_title == "")
                {
                    process_id = get_spotify_pid();

                    if(process_id == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Application no longer running (or was never running)");
                        Console.WriteLine("Application does not work when minimised to tray!");
                        loop_again = false;
                    }
                }

                //If not playing music or ad is playing
                else if(window_title == "Spotify")
                {
                    if(mute == false)
                    {
                        Console.WriteLine("Muting Volume");
                        Volume_Control.mute();
                        mute = true;
                    }
                }

                else
                {
                    if (mute == true)
                    {
                        Console.WriteLine("Unmuting Volume");
                        Volume_Control.unmute();
                        mute = false;
                    }
                }

                System.Threading.Thread.Sleep(1000);
            }

            Console.WriteLine();
            Console.WriteLine("Press Any Key To Exit");
            Console.ReadKey();
        }
    }
}
