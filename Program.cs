using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace WinForms
{
    class MainForm : Form
    {
        MainForm()
        {
            Text = "Main";
            /*Size = new Size(800, 600);*/
            BackColor = Color.Green;
            Opacity = 0.35;
            TransparencyKey = Color.Green;
            AllowTransparency = true;

            TopMost = true;
            /*var button = new Button() { Text = "Press me!", Dock = DockStyle.Left, BackColor = Color.Red };
            button.Click += (o, e) => MessageBox.Show("Got it.");
            Controls.Add(button);*/
            var picturebox1 = new PictureBox() { Dock = DockStyle.Fill, BackColor = Color.White, SizeMode = PictureBoxSizeMode.Zoom };
            var openfile = new OpenFileDialog();
            /*openfile.Filter = ".png";*/
            openfile.Title = "something";
            if (openfile.ShowDialog() == DialogResult.OK)
                picturebox1.Load(openfile.FileName);
                Controls.Add(picturebox1);



            CenterToScreen();
        }
        public static class WindowsServices
        {
            const int WS_EX_TRANSPARENT = 0x00000020;
            const int GWL_EXSTYLE = (-20);

            [DllImport("user32.dll")]
            static extern int GetWindowLong(IntPtr hwnd, int index);

            [DllImport("user32.dll")]
            static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);

            public static void SetWindowExTransparent(IntPtr hwnd)
            {
                var extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
                SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_TRANSPARENT);
            }
        }


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}