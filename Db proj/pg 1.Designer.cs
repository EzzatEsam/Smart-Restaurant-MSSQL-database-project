
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
            this.SuspendLayout();
            // 
            // Workersbtn
            // 
            this.Workersbtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Workersbtn.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Workersbtn.Location = new System.Drawing.Point(222, 157);
            this.Workersbtn.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Workersbtn.Name = "Workersbtn";
            this.Workersbtn.Size = new System.Drawing.Size(250, 88);
            this.Workersbtn.TabIndex = 0;
            this.Workersbtn.Text = "View workers list";
            this.Workersbtn.UseVisualStyleBackColor = false;
            this.Workersbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // m_bttn
            // 
            this.m_bttn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.m_bttn.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_bttn.Location = new System.Drawing.Point(222, 299);
            this.m_bttn.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.m_bttn.Name = "m_bttn";
            this.m_bttn.Size = new System.Drawing.Size(250, 88);
            this.m_bttn.TabIndex = 1;
            this.m_bttn.Text = "View menu";
            this.m_bttn.UseVisualStyleBackColor = false;
            this.m_bttn.Click += new System.EventHandler(this.m_bttn_Click);
            // 
            // pg_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_bttn);
            this.Controls.Add(this.Workersbtn);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "pg_1";
            this.Size = new System.Drawing.Size(703, 515);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Workersbtn;
        private System.Windows.Forms.Button m_bttn;
    }
}
