

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
            var picturebox1 = new PictureBox() { Dock = DockStyle.Fill, BackColor = Color.White, SizeMode = PictureBoxSizeMode.Zoom };
            var openfile = new OpenFileDialog();
            openfile.Title = "something";
            if (openfile.ShowDialog() == DialogResult.OK)
                picturebox1.Load(openfile.FileName);
            Controls.Add(picturebox1);



            CenterToScreen();
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