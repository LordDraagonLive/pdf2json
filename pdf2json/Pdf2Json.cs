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

namespace pdf2json
{
    public partial class Pdf2Json : Form
    {
        public Pdf2Json()
        {
            InitializeComponent();
        }

        private void openFolderBtn_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = Environment.CurrentDirectory;
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    List<string> filesList = new List<string>(files);
                    var fileNameList = filesList.Select(x => { x = x.Split('\\').Last(); return x; }).ToList();
                    var filesDic = fileNameList.Zip(filesList, (k, v) => new { k, v })
                                .ToDictionary(x => x.k, x => x.v);

                    filesLsBx.DataSource = new BindingSource(filesDic, null);

                    filesLsBx.DisplayMember = "Key";
                    filesLsBx.ValueMember = "Value";

                    //foreach (var file in files)
                    //{
                    //    System.Windows.Forms.MessageBox.Show("Files Path: " + file, "Message");
                    //}

                    System.Windows.Forms.MessageBox.Show("Files found: " + filesList.Count.ToString(), "Message");
                }
            }
        }
    }
}
