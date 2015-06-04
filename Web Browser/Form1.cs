using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Web_Browser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// This function is called when the menu item is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// This will show a message when it is clicked on the menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Program was made by Winterseye in C# contact xscript@me.com with any issues.");
        }
        /// <summary>
        /// Navigate Function
        /// On Click on the button the web control will display the page requested in the text box(by url)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            NavigateToPage();
        }
        /// <summary>
        /// This is the core function that will provide all navigation and post processing
        /// </summary>
        private void NavigateToPage()
        {
            toolStripStatusLabel1.Text = "Navigation has Started";
            button1.Enabled = false;
            textBox1.Enabled = false;
            button2.Enabled = false;
            webBrowser1.Navigate(textBox1.Text);
        }
        /// <summary>
        /// This function will fire any time a key is pushed and released
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //If the key was enter then do something
            if(e.KeyChar == (char)ConsoleKey.Enter )
            {
                NavigateToPage();
            }
        }
        /// <summary>
        /// This will enable the button and text box after loading is complete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            button1.Enabled = true;
            textBox1.Enabled = true;
            button2.Enabled = true;
            toolStripStatusLabel1.Text = "Navigation Complete";
            textBox1.Text = webBrowser1.Url.ToString();
        }
        /// <summary>
        /// Progress Status Bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress > 0 & e.MaximumProgress > 0)
            {
                toolStripProgressBar1.ProgressBar.Value = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
            }
        }
        /// <summary>
        /// Function that refreshes the page when button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }
    }
}
