
namespace Db_proj
{
    partial class WorkersList
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
            this.tsk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
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
            this.E_stats,
            this.tsk,
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(27, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(610, 150);
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
            this.E_stats.HeaderText = "Idle";
            this.E_stats.Name = "E_stats";
            this.E_stats.ReadOnly = true;
            // 
            // tsk
            // 
            this.tsk.HeaderText = "Current Task";
            this.tsk.Name = "tsk";
            this.tsk.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Task type";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(27, 268);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "Previous";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(234, 268);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 46);
            this.button2.TabIndex = 2;
            this.button2.Text = "Add Worker";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Location = new System.Drawing.Point(430, 268);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 46);
            this.button3.TabIndex = 3;
            this.button3.Text = "Delete Selected";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // WorkersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "WorkersList";
            this.Size = new System.Drawing.Size(662, 333);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn E_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn E_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn E_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn E_stats;
        private System.Windows.Forms.DataGridViewTextBoxColumn tsk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}
