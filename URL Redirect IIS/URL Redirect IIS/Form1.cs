using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace URL_Redirect_IIS
{
    public partial class Form1 : Form
    {
        public string ProjectSourcePath { get; private set; }
        public string FromURLs { get; private set; }
        public string ToURLs { get; private set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectslnFile_Click(object sender, EventArgs e)
        {
            ProjectSourcePath = OpenfileDialog("Project Solution File|*.sln", "Select .sln File Of Project");
            lblselectsln.Text = ProjectSourcePath;
        }

        private void btnSelectFromURls_Click(object sender, EventArgs e)
        {
            FromURLs = OpenfileDialog("From URL .txt File|*.txt", "Select From URLs File");
            lblSelectFromURLs.Text = FromURLs;
        }

        private void btnSelectToUrls_Click(object sender, EventArgs e)
        {
            ToURLs = OpenfileDialog("To URL .txt  File|*.txt", "Select To URLs File");
            lblSelectToURLs.Text = ToURLs;
        }

        private void btnStartURLRedirect_Click(object sender, EventArgs e)
        {

        }
        private string OpenfileDialog(string filter, string title)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = filter;
            dialog.Title = title;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }
            return "";
        }
    }
}
