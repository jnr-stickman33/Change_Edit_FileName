using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ChangeFileNameExtentions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string[] dirs = Directory.GetDirectories(folderBrowser.SelectedPath);

                foreach (string dir in dirs)
                {

                    string[] files = System.IO.Directory.GetFiles(dir);
                    int total = files.Length;
                    int position = 1;
                    progressBar1.Maximum = files.Length;
                    progressBar1.Step = 1;
                    progressBar1.Value = 0;

                    foreach (string file in files)
                    {
                        try
                        {


                            string fullName = System.IO.Path.GetFileNameWithoutExtension(file);

                            var newName = String.Join(fullName, fullName + "- Arrested " + Path.GetFileName(dir));

                            //string newfullname = newName.Replace(fullName, newName);

                            //string newfilename = String.Format(newName);
                            File.Move(file, file.Replace(fullName, newName));
                            //File.Move(file, string.Format("- Arrested APRIL 2019", Path.GetFileNameWithoutExtension(file)));
                            //System.IO.File.Move(fullName, newName);

                        }
                        catch (Exception fe)
                        {

                            MessageBox.Show("Error : " + fe.ToString());

                        }



                    }
                    progressBar1.PerformStep();
                    progressBar1.Refresh();
                }

            }

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}

