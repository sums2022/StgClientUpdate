namespace StgClientUpdater
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lbProject = new System.Windows.Forms.ListBox();
            this.lbCurrent2 = new System.Windows.Forms.Label();
            this.lbNew2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDescript = new System.Windows.Forms.TextBox();
            this.lbRemote = new System.Windows.Forms.Label();
            this.lbRelease = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnBuild = new System.Windows.Forms.Button();
            this.lbLocal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnRelease = new System.Windows.Forms.Button();
            this.btnAllInOne = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbProject
            // 
            this.lbProject.FormattingEnabled = true;
            this.lbProject.ItemHeight = 16;
            this.lbProject.Location = new System.Drawing.Point(14, 13);
            this.lbProject.Margin = new System.Windows.Forms.Padding(4);
            this.lbProject.Name = "lbProject";
            this.lbProject.Size = new System.Drawing.Size(325, 100);
            this.lbProject.TabIndex = 1;
            this.lbProject.SelectedIndexChanged += new System.EventHandler(this.lbProject_SelectedIndexChanged);
            // 
            // lbCurrent2
            // 
            this.lbCurrent2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCurrent2.AutoSize = true;
            this.lbCurrent2.Location = new System.Drawing.Point(11, 121);
            this.lbCurrent2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCurrent2.Name = "lbCurrent2";
            this.lbCurrent2.Size = new System.Drawing.Size(112, 16);
            this.lbCurrent2.TabIndex = 2;
            this.lbCurrent2.Text = "Release Version:";
            // 
            // lbNew2
            // 
            this.lbNew2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbNew2.AutoSize = true;
            this.lbNew2.Location = new System.Drawing.Point(11, 137);
            this.lbNew2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNew2.Name = "lbNew2";
            this.lbNew2.Size = new System.Drawing.Size(111, 16);
            this.lbNew2.TabIndex = 3;
            this.lbNew2.Text = "Remote Dev Ver:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 182);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Description:";
            // 
            // tbDescript
            // 
            this.tbDescript.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescript.Location = new System.Drawing.Point(12, 204);
            this.tbDescript.Multiline = true;
            this.tbDescript.Name = "tbDescript";
            this.tbDescript.Size = new System.Drawing.Size(327, 89);
            this.tbDescript.TabIndex = 5;
            // 
            // lbRemote
            // 
            this.lbRemote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbRemote.Location = new System.Drawing.Point(121, 137);
            this.lbRemote.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRemote.Name = "lbRemote";
            this.lbRemote.Size = new System.Drawing.Size(120, 16);
            this.lbRemote.TabIndex = 8;
            // 
            // lbRelease
            // 
            this.lbRelease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbRelease.Location = new System.Drawing.Point(121, 121);
            this.lbRelease.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRelease.Name = "lbRelease";
            this.lbRelease.Size = new System.Drawing.Size(120, 16);
            this.lbRelease.TabIndex = 7;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubmit.Location = new System.Drawing.Point(125, 299);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(90, 23);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "Submit Dev";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.Location = new System.Drawing.Point(90, 178);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(25, 25);
            this.btnNew.TabIndex = 10;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnBuild
            // 
            this.btnBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBuild.Location = new System.Drawing.Point(47, 299);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(75, 23);
            this.btnBuild.TabIndex = 12;
            this.btnBuild.Text = "Build";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // lbLocal
            // 
            this.lbLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbLocal.Location = new System.Drawing.Point(121, 153);
            this.lbLocal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLocal.Name = "lbLocal";
            this.lbLocal.Size = new System.Drawing.Size(120, 16);
            this.lbLocal.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 153);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 16);
            this.label10.TabIndex = 13;
            this.label10.Text = "Local Dev Ver:";
            // 
            // btnRelease
            // 
            this.btnRelease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRelease.Location = new System.Drawing.Point(221, 299);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(79, 23);
            this.btnRelease.TabIndex = 15;
            this.btnRelease.Text = "Release";
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // btnAllInOne
            // 
            this.btnAllInOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAllInOne.Location = new System.Drawing.Point(47, 328);
            this.btnAllInOne.Name = "btnAllInOne";
            this.btnAllInOne.Size = new System.Drawing.Size(253, 23);
            this.btnAllInOne.TabIndex = 16;
            this.btnAllInOne.Text = "ALL IN ONE";
            this.btnAllInOne.UseVisualStyleBackColor = true;
            this.btnAllInOne.Click += new System.EventHandler(this.btnAllInOne_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 359);
            this.Controls.Add(this.btnAllInOne);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.lbLocal);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lbRemote);
            this.Controls.Add(this.lbRelease);
            this.Controls.Add(this.tbDescript);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbNew2);
            this.Controls.Add(this.lbCurrent2);
            this.Controls.Add(this.lbProject);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "Update Maker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lbProject;
        private System.Windows.Forms.Label lbCurrent2;
        private System.Windows.Forms.Label lbNew2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDescript;
        private System.Windows.Forms.Label lbRemote;
        private System.Windows.Forms.Label lbRelease;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Label lbLocal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Button btnAllInOne;
    }
}

