
namespace Db_proj
{
    partial class ad_pg_2
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.E_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.E_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.E_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.E_stats = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.E_id,
            this.E_name,
            this.E_type,
            this.E_stats});
            this.dataGridView1.Location = new System.Drawing.Point(3, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(444, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // E_id
            // 
            this.E_id.HeaderText = "ID";
            this.E_id.Name = "E_id";
            this.E_id.ReadOnly = true;
            // 
            // E_name
            // 
            this.E_name.HeaderText = "Name";
            this.E_name.Name = "E_name";
            this.E_name.ReadOnly = true;
            // 
            // E_type
            // 
            this.E_type.HeaderText = "Type";
            this.E_type.Name = "E_type";
            this.E_type.ReadOnly = true;
            // 
            // E_stats
            // 
            this.E_stats.HeaderText = "Current status";
            this.E_stats.Name = "E_stats";
            this.E_stats.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Previous";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ad_pg_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ad_pg_2";
            this.Size = new System.Drawing.Size(470, 302);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn E_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn E_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn E_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn E_stats;
        private System.Windows.Forms.Button button1;
    }
}
