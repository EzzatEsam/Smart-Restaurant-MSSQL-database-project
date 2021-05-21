
namespace Db_proj
{
    partial class ad_pg3
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
            this.button1 = new System.Windows.Forms.Button();
            this.E_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.E_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.E_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.I_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.I_price});
            this.dataGridView1.Location = new System.Drawing.Point(37, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(335, 150);
            this.dataGridView1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(48, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Previous";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // E_id
            // 
            this.E_id.HeaderText = "Item number";
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
            this.E_type.HeaderText = "Category";
            this.E_type.Name = "E_type";
            this.E_type.ReadOnly = true;
            // 
            // I_price
            // 
            this.I_price.HeaderText = "Item price";
            this.I_price.Name = "I_price";
            this.I_price.ReadOnly = true;
            // 
            // ad_pg3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ad_pg3";
            this.Size = new System.Drawing.Size(408, 298);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn E_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn E_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn E_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn I_price;
        private System.Windows.Forms.Button button1;
    }
}
