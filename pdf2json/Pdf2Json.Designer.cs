
namespace pdf2json
{
    partial class Pdf2Json
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.openFolderBtn = new System.Windows.Forms.Button();
            this.filesLsBx = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(353, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "PDF 2 JSON";
            // 
            // openFolderBtn
            // 
            this.openFolderBtn.Location = new System.Drawing.Point(13, 67);
            this.openFolderBtn.Name = "openFolderBtn";
            this.openFolderBtn.Size = new System.Drawing.Size(75, 23);
            this.openFolderBtn.TabIndex = 1;
            this.openFolderBtn.Text = "Open Folder";
            this.openFolderBtn.UseVisualStyleBackColor = true;
            this.openFolderBtn.Click += new System.EventHandler(this.openFolderBtn_Click);
            // 
            // filesLsBx
            // 
            this.filesLsBx.FormattingEnabled = true;
            this.filesLsBx.Location = new System.Drawing.Point(13, 113);
            this.filesLsBx.Name = "filesLsBx";
            this.filesLsBx.Size = new System.Drawing.Size(275, 173);
            this.filesLsBx.TabIndex = 2;
            // 
            // Pdf2Json
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.filesLsBx);
            this.Controls.Add(this.openFolderBtn);
            this.Controls.Add(this.label1);
            this.Name = "Pdf2Json";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button openFolderBtn;
        private System.Windows.Forms.ListBox filesLsBx;
    }
}

