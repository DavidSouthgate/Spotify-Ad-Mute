/* The MIT License (MIT)
 *
 * Copyright (c) 2015-2016 David Southgate
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

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

            //Get the program version
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            string version = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;

            DateTime last_no_process_error = new DateTime();
            string now_playing_artist = "";
            string now_playing_track = "";

            //Output initial command line stuff
            Console.WriteLine("Spotfy Ad Mute [Version " + version + "]");
            Console.WriteLine("(c) 2015-2016 David Southgate");
            Console.WriteLine();

            //Start the program once a key has been pressed
            Console.WriteLine("Press Any Key To Start");
            Console.ReadKey();
            Console.WriteLine();

            //Unmute the volume and store that status in a boolean
            Volume_Control.unmute();
            bool mute = false;

            //Loop while loop_again is true
            while(true)
            {

                //Get spotify process id
                int process_id = get_spotify_pid();

                //Get the window title of the running spotify installation
                string window_title = Process.GetProcessById(process_id).MainWindowTitle;

                //Use regex to detect now playing
                Regex r = new Regex("([^-]*)( - )([^-]*)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                Match m = r.Match(window_title);

                //If successful match, something is playing
                if (m.Success)
                {

                    //If muted, unmute
                    if (mute == true)
                    {
                        Volume_Control.unmute();
                        mute = false;
                    }

                    //Get new now playing details
                    string now_playing_artist_new = m.Groups[1].ToString().Trim();
                    string now_playing_track_new = m.Groups[3].ToString().Trim();

                    //If new now playing details different than old
                    if (now_playing_artist_new != now_playing_artist && now_playing_track_new != now_playing_track)
                    {

                        //Change now playing variables to new values
                        now_playing_artist = now_playing_artist_new;
                        now_playing_track = now_playing_track_new;

                        //Output now playing
                        Console.WriteLine("Now Playing: '" + now_playing_track + "' by '" + now_playing_artist + "'");
                    }
                }

                //If blank window title
                else if (window_title == "")
                {

                    //Output error if one hasn't been outputted in the last 10 seconds.
                    if ((DateTime.Now - last_no_process_error).TotalSeconds > 10)
                    {
                        Console.WriteLine("ERROR: Spotify process not found. Is spotify running and not minimused to the tray?");

                        //Set last no process date time to now
                        last_no_process_error = DateTime.Now;
                    }
                }

                //Otherwise, nothing is playing
                else
                {
                    //If not muted, mute
                    if (mute == false)
                    {
                        Console.WriteLine("Now Playing: Paused or Ad [Volume Muted]");
                        Volume_Control.mute();
                        mute = true;
                    }
                }

                //Sleep for 1 seccond
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
