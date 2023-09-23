using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Generator
{
    public partial class UI : Form
    {
        public UI()
        {
            InitializeComponent();
        }

        private void siticoneCustomCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        private void Form1_Load(object sender, EventArgs e)
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private const string Numbers = "0123456789";
        private const string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        private const string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Symbols = "!@#$%^&*()-_=+[]{}|;:,.<>?/";

        public static string GeneratePassword(bool includeNumbers, bool includeLowercase, bool includeUppercase, bool includeSymbols, int length)
        {
            string characterSet = "";

            if (includeNumbers)
                characterSet += Numbers;
            if (includeLowercase)
                characterSet += LowercaseChars;
            if (includeUppercase)
                characterSet += UppercaseChars;
            if (includeSymbols)
                characterSet += Symbols;

            if (characterSet.Length == 0)
            {
                throw new ArgumentException("At least one character set must be selected.");
            }

            StringBuilder password = new StringBuilder(length);
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                int randomIndex = random.Next(0, characterSet.Length);
                password.Append(characterSet[randomIndex]);
            }

            return password.ToString();
        }

        public bool num_check = false;
        public bool low_check = false;
        public bool up_check = false;
        public bool smb_check = false;
        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            if (siticoneCheckBox1.Checked == true) { 
                num_check = true;
            }
            else
            {
                num_check = false;
            }

            if (siticoneCheckBox3.Checked == true){
                low_check = true;
            }
            else
            {
                low_check = false;
            }

            if (siticoneCheckBox4.Checked == true){
                up_check = true;
            }
            else
            {
                up_check = false;
            }

            if (siticoneCheckBox5.Checked == true){
                smb_check = true;
            }
            else
            {
                smb_check = false;
            }

            string response = GeneratePassword(num_check, low_check, up_check, smb_check, siticoneTrackBar1.Value);
            siticoneTextBox1.Text = response;
        }

        private void siticoneTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label3.Text = siticoneTrackBar1.Value.ToString();
        }

        private void siticoneTextBox1_IconRightClick(object sender, EventArgs e)
        {
            Clipboard.SetText(siticoneTextBox1.Text);
            MessageBox.Show("Copied secured password to clipboard. Use Ctrl+V to paste into directed location.", "Password Generator", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
