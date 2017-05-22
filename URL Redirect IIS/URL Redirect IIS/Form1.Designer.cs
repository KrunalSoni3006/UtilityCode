namespace URL_Redirect_IIS
{
    partial class Form1
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
            this.btnSelectslnFile = new System.Windows.Forms.Button();
            this.btnSelectFromURls = new System.Windows.Forms.Button();
            this.btnStartURLRedirect = new System.Windows.Forms.Button();
            this.btnSelectToUrls = new System.Windows.Forms.Button();
            this.lblselectsln = new System.Windows.Forms.Label();
            this.lblSelectFromURLs = new System.Windows.Forms.Label();
            this.lblSelectToURLs = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSelectslnFile
            // 
            this.btnSelectslnFile.Location = new System.Drawing.Point(12, 12);
            this.btnSelectslnFile.Name = "btnSelectslnFile";
            this.btnSelectslnFile.Size = new System.Drawing.Size(126, 23);
            this.btnSelectslnFile.TabIndex = 0;
            this.btnSelectslnFile.Text = "Select Project .sln FIle";
            this.btnSelectslnFile.UseVisualStyleBackColor = true;
            this.btnSelectslnFile.Click += new System.EventHandler(this.btnSelectslnFile_Click);
            // 
            // btnSelectFromURls
            // 
            this.btnSelectFromURls.Location = new System.Drawing.Point(12, 41);
            this.btnSelectFromURls.Name = "btnSelectFromURls";
            this.btnSelectFromURls.Size = new System.Drawing.Size(126, 23);
            this.btnSelectFromURls.TabIndex = 1;
            this.btnSelectFromURls.Text = "Select From URLs";
            this.btnSelectFromURls.UseVisualStyleBackColor = true;
            this.btnSelectFromURls.Click += new System.EventHandler(this.btnSelectFromURls_Click);
            // 
            // btnStartURLRedirect
            // 
            this.btnStartURLRedirect.Location = new System.Drawing.Point(12, 99);
            this.btnStartURLRedirect.Name = "btnStartURLRedirect";
            this.btnStartURLRedirect.Size = new System.Drawing.Size(569, 23);
            this.btnStartURLRedirect.TabIndex = 2;
            this.btnStartURLRedirect.Text = "Start URL Redirect";
            this.btnStartURLRedirect.UseVisualStyleBackColor = true;
            this.btnStartURLRedirect.Click += new System.EventHandler(this.btnStartURLRedirect_Click);
            // 
            // btnSelectToUrls
            // 
            this.btnSelectToUrls.Location = new System.Drawing.Point(12, 70);
            this.btnSelectToUrls.Name = "btnSelectToUrls";
            this.btnSelectToUrls.Size = new System.Drawing.Size(126, 23);
            this.btnSelectToUrls.TabIndex = 3;
            this.btnSelectToUrls.Text = "Select To URLs";
            this.btnSelectToUrls.UseVisualStyleBackColor = true;
            this.btnSelectToUrls.Click += new System.EventHandler(this.btnSelectToUrls_Click);
            // 
            // lblselectsln
            // 
            this.lblselectsln.AutoSize = true;
            this.lblselectsln.Location = new System.Drawing.Point(148, 17);
            this.lblselectsln.Name = "lblselectsln";
            this.lblselectsln.Size = new System.Drawing.Size(0, 13);
            this.lblselectsln.TabIndex = 4;
            // 
            // lblSelectFromURLs
            // 
            this.lblSelectFromURLs.AutoSize = true;
            this.lblSelectFromURLs.Location = new System.Drawing.Point(148, 46);
            this.lblSelectFromURLs.Name = "lblSelectFromURLs";
            this.lblSelectFromURLs.Size = new System.Drawing.Size(0, 13);
            this.lblSelectFromURLs.TabIndex = 5;
            // 
            // lblSelectToURLs
            // 
            this.lblSelectToURLs.AutoSize = true;
            this.lblSelectToURLs.Location = new System.Drawing.Point(148, 75);
            this.lblSelectToURLs.Name = "lblSelectToURLs";
            this.lblSelectToURLs.Size = new System.Drawing.Size(0, 13);
            this.lblSelectToURLs.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 311);
            this.Controls.Add(this.lblSelectToURLs);
            this.Controls.Add(this.lblSelectFromURLs);
            this.Controls.Add(this.lblselectsln);
            this.Controls.Add(this.btnSelectToUrls);
            this.Controls.Add(this.btnStartURLRedirect);
            this.Controls.Add(this.btnSelectFromURls);
            this.Controls.Add(this.btnSelectslnFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectslnFile;
        private System.Windows.Forms.Button btnSelectFromURls;
        private System.Windows.Forms.Button btnStartURLRedirect;
        private System.Windows.Forms.Button btnSelectToUrls;
        private System.Windows.Forms.Label lblselectsln;
        private System.Windows.Forms.Label lblSelectFromURLs;
        private System.Windows.Forms.Label lblSelectToURLs;
    }
}

