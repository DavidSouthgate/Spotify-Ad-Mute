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

        /// <summary>
        /// Returns the windows process ID of a running installation of spotify that has a valid window title.
        /// WARNING: Any other process called spotify can be caught by this. Unlikely but VERY possible.
        /// </summary>
        /// <returns>Process ID</returns>
        static int get_spotify_pid()
        {

            //Set process ID to 0. If no processes are found, 0 will be returned
            int process_id = 0;

            //Get processes that have the name "Spotify"
            Process[] process_list = Process.GetProcessesByName("Spotify");

            //Loof for every spotify process
            for (int i = 0; i < process_list.Length; i++)
            {

                //If this process has a valid window title
                if (process_list[i].MainWindowTitle != "")
                {

                    //Change process ID to this process ID
                    process_id = process_list[i].Id;
                }
            }

            //Return the process ID
            return process_id;
        }

        static void Main(string[] args)
        {

            DateTime last_no_process_error = new DateTime();

            //Output initial command line stuff
            Console.WriteLine("Spotfy Ad Mute [Version DEV]");
            Console.WriteLine("(c) 2015-2016 David Southgate");
            Console.WriteLine();

            //Start the program once a key has been pressed
            Console.WriteLine("Press Any Key To Start");
            Console.ReadKey();
            Console.WriteLine();

            //Unmute the volume and store that status in a boolean
            Console.WriteLine("Unmuting Volume");
            Volume_Control.unmute();
            bool mute = false;

            //Loop while loop_again is true
            while(true)
            {

                //Get spotify process id
                int process_id = get_spotify_pid();

                //Get the window title of the running spotify installation
                string window_title = Process.GetProcessById(process_id).MainWindowTitle;

                //If blank window title
                if(window_title == "")
                {

                    //Output error if one hasn't been outputted in the last 10 seconds.
                    if((DateTime.Now - last_no_process_error).TotalSeconds > 10)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Spotify process not found. Is spotify running and not minimused to the tray?");

                        //Set last no process date time to now
                        last_no_process_error = DateTime.Now;
                    }
                }

                //If not playing music or ad is playing
                else if(window_title == "Spotify")
                {

                    //If not muted, mute
                    if(mute == false)
                    {
                        Console.WriteLine("Muting Volume");
                        Volume_Control.mute();
                        mute = true;
                    }
                }

                //Otherwise, should be playing music
                else
                {

                    //If muted, unmute
                    if (mute == true)
                    {
                        Console.WriteLine("Unmuting Volume");
                        Volume_Control.unmute();
                        mute = false;
                    }
                }

                //Sleep for 1 seccond
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
