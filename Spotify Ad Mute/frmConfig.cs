using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spotify_Ad_Mute
{
    public partial class frmConfig : Form
    {

        string version;                                     //String which stores the program version
        DateTime last_no_process_error = new DateTime();    //DateTime used to store when the last no process error was shown
        string now_playing_artist = "";                     //String which stores now playing artist
        string now_playing_track = "";                      //String which stores now playing track
        bool mute_flag;                                     //Boolean which stores whether the program has muted the system
        bool enabled = true;                                //Boolean which stores the enabled status of the program
        bool force_close = false;                           //When true, the program will actually close when close event triggers

        public frmConfig()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Returns the windows process ID of a running installation of spotify that has a valid window title.
        /// WARNING: Any other process called spotify can be caught by this. Unlikely but VERY possible.
        /// </summary>
        /// <returns>Process ID</returns>
        private int get_spotify_pid()
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

        /// <summary>
        /// Output string to console debug and GUI debug
        /// </summary>
        /// <param name="output">String to output</param>
        private void output(string output)
        {

            //Write output to debug
            Debug.WriteLine(output);

            //Add output to output list box
            listBoxOutput.Items.Add(output);

            //Move to to end of the output list box
            listBoxOutput.SelectedIndex = listBoxOutput.Items.Count - 1;
        }

        private void timerCheckSpotify_Tick(object sender, EventArgs e)
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
                if (mute_flag == true)
                {
                    Volume_Control.unmute(this.Handle);
                    mute_flag = false;
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
                    output("Now Playing: '" + now_playing_track + "' by '" + now_playing_artist + "'");
                }
            }

            //If the user is dragging something in the spotify interface, do nothing
            else if (window_title == "Drag") { }

            //If blank window title
            else if (window_title == "")
            {

                //Output error if one hasn't been outputted in the last 10 seconds.
                if ((DateTime.Now - last_no_process_error).TotalSeconds > 10)
                {
                    output("ERROR: Spotify process not found. Is spotify running and not minimised to the tray?");

                    //Set last no process date time to now
                    last_no_process_error = DateTime.Now;
                }
            }

            //Otherwise, nothing is playing
            else
            {
                //If not muted, mute
                if (mute_flag == false)
                {
                    output("Now Playing: Paused or Ad [Volume Muted]");
                    Volume_Control.mute(this.Handle);
                    mute_flag = true;
                }
            }
        }

        //===========================================================================
        // FORM EVENTS
        //===========================================================================

        private void frmConfig_Load(object sender, EventArgs e)
        {

            //Get the program version
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            version = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;

            //Output initial command line stuff
            output("Spotfy Ad Mute [Version " + version + "]");
            output("(c) 2015-2016 David Southgate");
            output("");

            //Unmute the volume and store that status in a boolean
            Volume_Control.unmute(this.Handle);
            mute_flag = false;
        }

        /// <summary>
        /// Show the form when the form is shown
        /// </summary>
        private void frmConfig_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// When the form is closing, just hide it instead (if force_close == false)
        /// </summary>
        private void frmConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!force_close)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        //===========================================================================
        // ENABLE DISABLE
        //===========================================================================

        /// <summary>
        /// Toggles whether program is enabled
        /// </summary>
        private void enabledtoggle()
        {

            //Toggle enabled
            enabled = !enabled;

            //Set notify icon menu item checked value
            contextMenuNotifyIconItemEnabled.Checked = enabled;

            //Set whether the timer is enabled
            timerCheckSpotify.Enabled = enabled;

            if(enabled)
            {
                output("Program Enabled");
            }
            else
            {
                output("Program Disabled");
            }
        }

        //===========================================================================
        // NOTIFY ICON
        //===========================================================================

        /// <summary>
        /// When the notify icon is double clicked, open the GUI
        /// </summary>
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        /// <summary>
        /// When the enabled context menu is clicked, toggle enabled
        /// </summary>
        private void contextMenuNotifyIconItemEnabled_Click(object sender, EventArgs e)
        {
            enabledtoggle();
        }

        /// <summary>
        /// When the enabled exit menu is clicked, exit the program
        /// </summary>
        private void contextMenuNotifyIconItemExit_Click(object sender, EventArgs e)
        {
            force_close = true;
            this.Close();
        }

        //===========================================================================
        // MENU STRIP
        //===========================================================================

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            force_close = true;
            this.Close();
        }

        private void menuStripItemAbout_Click(object sender, EventArgs e)
        {
            //Display about form
            frmAbout frmAbout = new frmAbout();
            frmAbout.ShowDialog(this);
        }
    }
}
