using Newtonsoft.Json;
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
        string userSelecctedDir = "";
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
                    userSelecctedDir = fbd.SelectedPath;
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    List<string> filesList = new List<string>(files);
                    var fileNameList = filesList.Select(x => { x = x.Split('\\').Last(); return x; }).ToList();
                    var filesDic = fileNameList.Zip(filesList, (k, v) => new { k, v })
                                .ToDictionary(x => x.k, x => x.v);

                    filesLsBx.DataSource = new BindingSource(filesDic, null);

                    filesLsBx.DisplayMember = "Key";
                    filesLsBx.ValueMember = "Value";

                    filesLsBx.SelectionMode = SelectionMode.One;

                    System.Windows.Forms.MessageBox.Show("Files found: " + filesList.Count.ToString(), "Message");
                }
            }
        }

        private void filesLsBx_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(((KeyValuePair<string, string>)filesLsBx.SelectedItem).Value.ToString());
            //filesLsBx.ClearSelected();
        }

        private void genbtn_Click(object sender, EventArgs e)
        {
            if (userSelecctedDir != "")
            {
                try
                {
                    // get all form elements
                    var items = ActiveForm.Controls.Cast<Control>();
                    List<string> keys = new List<string>();
                    List<string> values = new List<string>();

                    foreach (var item in items)
                    {
                        if (item.Tag != null)
                        {
                            if (item.Tag.ToString() == "keys")
                            {
                                keys.Add(item.Text.ToString());

                            }
                            if (item.Tag.ToString() == "values")
                            {
                                values.Add(item.Text.ToString());

                            }
                        }
                    }

                    var keyValDic = keys.Zip(values, (k, v) => new { k, v })
                                        .ToDictionary(x => x.k, x => x.v);
                    //string path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
                    //string path = Application.StartupPath;
                    //string folderPath = Path.Combine(path, "output");
                    string createdFileName = Path.GetFileNameWithoutExtension(((KeyValuePair<string, string>)filesLsBx.SelectedItem).Value.ToString());

                    string fullFileName = Path.Combine(userSelecctedDir, createdFileName + ".json");

                    //System.IO.Directory.CreateDirectory(folderPath);
                    string jsonOutput = JsonConvert.SerializeObject(keyValDic, Newtonsoft.Json.Formatting.Indented);
                    System.IO.File.WriteAllText(fullFileName, jsonOutput);
                    System.Windows.Forms.MessageBox.Show("JSON File Saved Successfully! : " + fullFileName, "Message");
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("JSON File Creation and Saving Failed! : " + ex.Message, "Error Message");
                }

            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please select the PDFs Directory: ", "Message");
            }


        }
    }
}
