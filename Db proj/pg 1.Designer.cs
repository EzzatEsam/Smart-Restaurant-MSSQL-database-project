
namespace Db_proj
{
    partial class pg_1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Workersbtn = new System.Windows.Forms.Button();
            this.m_bttn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Workersbtn
            // 
            this.Workersbtn.Location = new System.Drawing.Point(133, 102);
            this.Workersbtn.Name = "Workersbtn";
            this.Workersbtn.Size = new System.Drawing.Size(145, 23);
            this.Workersbtn.TabIndex = 0;
            this.Workersbtn.Text = "View workers list";
            this.Workersbtn.UseVisualStyleBackColor = true;
            this.Workersbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // m_bttn
            // 
            this.m_bttn.Location = new System.Drawing.Point(133, 160);
            this.m_bttn.Name = "m_bttn";
            this.m_bttn.Size = new System.Drawing.Size(145, 23);
            this.m_bttn.TabIndex = 1;
            this.m_bttn.Text = "View menu";
            this.m_bttn.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(309, 14);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Sign out";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pg_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.m_bttn);
            this.Controls.Add(this.Workersbtn);
            this.Name = "pg_1";
            this.Size = new System.Drawing.Size(422, 291);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Workersbtn;
        private System.Windows.Forms.Button m_bttn;
        private System.Windows.Forms.Button button3;
    }
}
