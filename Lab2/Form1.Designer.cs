
namespace Lab2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.submitGetInfoButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resolution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorDepth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompressionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folderSelectButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // submitGetInfoButton
            // 
            this.submitGetInfoButton.Location = new System.Drawing.Point(183, 60);
            this.submitGetInfoButton.Name = "submitGetInfoButton";
            this.submitGetInfoButton.Size = new System.Drawing.Size(110, 23);
            this.submitGetInfoButton.TabIndex = 2;
            this.submitGetInfoButton.Text = "Select image";
            this.submitGetInfoButton.UseVisualStyleBackColor = true;
            this.submitGetInfoButton.Click += new System.EventHandler(this.submitGetInfoButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.Size,
            this.Resolution,
            this.ColorDepth,
            this.CompressionColumn});
            this.dataGridView1.Location = new System.Drawing.Point(3, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1080, 338);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.MinimumWidth = 6;
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            this.NameColumn.Width = 125;
            // 
            // Size
            // 
            this.Size.HeaderText = "Size";
            this.Size.MinimumWidth = 6;
            this.Size.Name = "Size";
            this.Size.ReadOnly = true;
            this.Size.Width = 125;
            // 
            // Resolution
            // 
            this.Resolution.HeaderText = "Resolution";
            this.Resolution.MinimumWidth = 6;
            this.Resolution.Name = "Resolution";
            this.Resolution.ReadOnly = true;
            this.Resolution.Width = 125;
            // 
            // ColorDepth
            // 
            this.ColorDepth.HeaderText = "Color depth";
            this.ColorDepth.MinimumWidth = 6;
            this.ColorDepth.Name = "ColorDepth";
            this.ColorDepth.ReadOnly = true;
            this.ColorDepth.Width = 125;
            // 
            // CompressionColumn
            // 
            this.CompressionColumn.HeaderText = "Compression";
            this.CompressionColumn.MinimumWidth = 6;
            this.CompressionColumn.Name = "CompressionColumn";
            this.CompressionColumn.ReadOnly = true;
            this.CompressionColumn.Width = 125;
            // 
            // folderSelectButton
            // 
            this.folderSelectButton.Location = new System.Drawing.Point(12, 60);
            this.folderSelectButton.Name = "folderSelectButton";
            this.folderSelectButton.Size = new System.Drawing.Size(118, 23);
            this.folderSelectButton.TabIndex = 6;
            this.folderSelectButton.Text = "Select folder";
            this.folderSelectButton.UseVisualStyleBackColor = true;
            this.folderSelectButton.Click += new System.EventHandler(this.folderSelectButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 574);
            this.Controls.Add(this.folderSelectButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.submitGetInfoButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button submitGetInfoButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resolution;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorDepth;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompressionColumn;
        private System.Windows.Forms.Button folderSelectButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

