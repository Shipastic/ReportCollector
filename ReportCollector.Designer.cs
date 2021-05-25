
namespace RepCol_2
{
    partial class ReportCollector
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportCollector));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sourceFolder = new System.Windows.Forms.TextBox();
            this.textSettingPath = new System.Windows.Forms.TextBox();
            this.butStartFormConfig = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.destinationFolder = new System.Windows.Forms.TextBox();
            this.unloadFile = new System.Windows.Forms.Button();
            this.SelectAll = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabNameBox = new System.Windows.Forms.ComboBox();
            this.TypeFile = new System.Windows.Forms.ComboBox();
            this.fileNameBox = new System.Windows.Forms.TextBox();
            this.countColumn = new System.Windows.Forms.TextBox();
            this.rowNumberCopy = new System.Windows.Forms.TextBox();
            this.RepColl = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sourceFolder);
            this.groupBox1.Controls.Add(this.textSettingPath);
            this.groupBox1.Controls.Add(this.butStartFormConfig);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.destinationFolder);
            this.groupBox1.Controls.Add(this.unloadFile);
            this.groupBox1.Controls.Add(this.SelectAll);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(17, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(625, 95);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор каталогов";
            // 
            // sourceFolder
            // 
            this.sourceFolder.BackColor = System.Drawing.SystemColors.Control;
            this.sourceFolder.Cursor = System.Windows.Forms.Cursors.No;
            this.sourceFolder.Location = new System.Drawing.Point(6, 54);
            this.sourceFolder.Name = "sourceFolder";
            this.sourceFolder.ReadOnly = true;
            this.sourceFolder.Size = new System.Drawing.Size(200, 25);
            this.sourceFolder.TabIndex = 14;
            // 
            // textSettingPath
            // 
            this.textSettingPath.BackColor = System.Drawing.SystemColors.Control;
            this.textSettingPath.Cursor = System.Windows.Forms.Cursors.No;
            this.textSettingPath.Location = new System.Drawing.Point(419, 53);
            this.textSettingPath.Name = "textSettingPath";
            this.textSettingPath.ReadOnly = true;
            this.textSettingPath.Size = new System.Drawing.Size(200, 25);
            this.textSettingPath.TabIndex = 13;
            // 
            // butStartFormConfig
            // 
            this.butStartFormConfig.BackColor = System.Drawing.SystemColors.Control;
            this.butStartFormConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butStartFormConfig.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butStartFormConfig.Location = new System.Drawing.Point(536, 22);
            this.butStartFormConfig.Name = "butStartFormConfig";
            this.butStartFormConfig.Size = new System.Drawing.Size(83, 27);
            this.butStartFormConfig.TabIndex = 11;
            this.butStartFormConfig.Text = "Запустить";
            this.butStartFormConfig.UseVisualStyleBackColor = false;
            this.butStartFormConfig.Click += new System.EventHandler(this.ButStartFormConfig_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(416, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 30);
            this.label8.TabIndex = 12;
            this.label8.Text = "Настройка\r\nконфиг. файла";
            // 
            // destinationFolder
            // 
            this.destinationFolder.BackColor = System.Drawing.SystemColors.Control;
            this.destinationFolder.Cursor = System.Windows.Forms.Cursors.No;
            this.destinationFolder.Location = new System.Drawing.Point(212, 54);
            this.destinationFolder.Name = "destinationFolder";
            this.destinationFolder.ReadOnly = true;
            this.destinationFolder.Size = new System.Drawing.Size(200, 25);
            this.destinationFolder.TabIndex = 4;
            // 
            // unloadFile
            // 
            this.unloadFile.BackColor = System.Drawing.SystemColors.Control;
            this.unloadFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.unloadFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.unloadFile.Location = new System.Drawing.Point(337, 24);
            this.unloadFile.Name = "unloadFile";
            this.unloadFile.Size = new System.Drawing.Size(75, 25);
            this.unloadFile.TabIndex = 3;
            this.unloadFile.Text = "Выбор";
            this.unloadFile.UseVisualStyleBackColor = false;
            this.unloadFile.Click += new System.EventHandler(this.UnloadFile_Click);
            // 
            // SelectAll
            // 
            this.SelectAll.BackColor = System.Drawing.SystemColors.Control;
            this.SelectAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SelectAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectAll.Location = new System.Drawing.Point(131, 24);
            this.SelectAll.Name = "SelectAll";
            this.SelectAll.Size = new System.Drawing.Size(75, 25);
            this.SelectAll.TabIndex = 2;
            this.SelectAll.Text = "Выбор";
            this.SelectAll.UseVisualStyleBackColor = false;
            this.SelectAll.Click += new System.EventHandler(this.SelectAll_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(209, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Выгрузка";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Источник";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabNameBox);
            this.groupBox2.Controls.Add(this.TypeFile);
            this.groupBox2.Controls.Add(this.fileNameBox);
            this.groupBox2.Controls.Add(this.countColumn);
            this.groupBox2.Controls.Add(this.rowNumberCopy);
            this.groupBox2.Controls.Add(this.RepColl);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(17, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(625, 230);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры";
            // 
            // tabNameBox
            // 
            this.tabNameBox.BackColor = System.Drawing.SystemColors.Control;
            this.tabNameBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tabNameBox.FormattingEnabled = true;
            this.tabNameBox.Location = new System.Drawing.Point(10, 66);
            this.tabNameBox.Name = "tabNameBox";
            this.tabNameBox.Size = new System.Drawing.Size(168, 25);
            this.tabNameBox.TabIndex = 2;
            this.tabNameBox.SelectedIndexChanged += new System.EventHandler(this.tabNameBox_SelectedIndexChanged);
            // 
            // TypeFile
            // 
            this.TypeFile.BackColor = System.Drawing.SystemColors.Control;
            this.TypeFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeFile.FormattingEnabled = true;
            this.TypeFile.Items.AddRange(new object[] {
            "ALL",
            "СУБПОДРЯД "});
            this.TypeFile.Location = new System.Drawing.Point(443, 67);
            this.TypeFile.Name = "TypeFile";
            this.TypeFile.Size = new System.Drawing.Size(168, 25);
            this.TypeFile.TabIndex = 2;
            // 
            // fileNameBox
            // 
            this.fileNameBox.Location = new System.Drawing.Point(10, 142);
            this.fileNameBox.Name = "fileNameBox";
            this.fileNameBox.Size = new System.Drawing.Size(601, 25);
            this.fileNameBox.TabIndex = 10;
            this.fileNameBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.fileNameBox_MouseClick);
            // 
            // countColumn
            // 
            this.countColumn.BackColor = System.Drawing.SystemColors.Control;
            this.countColumn.Location = new System.Drawing.Point(323, 67);
            this.countColumn.Name = "countColumn";
            this.countColumn.Size = new System.Drawing.Size(100, 25);
            this.countColumn.TabIndex = 8;
            // 
            // rowNumberCopy
            // 
            this.rowNumberCopy.BackColor = System.Drawing.SystemColors.Control;
            this.rowNumberCopy.Location = new System.Drawing.Point(202, 67);
            this.rowNumberCopy.Name = "rowNumberCopy";
            this.rowNumberCopy.Size = new System.Drawing.Size(100, 25);
            this.rowNumberCopy.TabIndex = 7;
            // 
            // RepColl
            // 
            this.RepColl.BackColor = System.Drawing.SystemColors.Control;
            this.RepColl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RepColl.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.RepColl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RepColl.Image = ((System.Drawing.Image)(resources.GetObject("RepColl.Image")));
            this.RepColl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RepColl.Location = new System.Drawing.Point(233, 173);
            this.RepColl.Name = "RepColl";
            this.RepColl.Size = new System.Drawing.Size(162, 31);
            this.RepColl.TabIndex = 4;
            this.RepColl.Text = "Сформировать отчет";
            this.RepColl.UseVisualStyleBackColor = false;
            this.RepColl.Click += new System.EventHandler(this.RepColl_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(279, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Имя файла";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(440, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Тип файла";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(320, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 30);
            this.label5.TabIndex = 4;
            this.label5.Text = "Количество \r\nколонок";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(199, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 30);
            this.label4.TabIndex = 3;
            this.label4.Text = "Номер строки \r\nначала данных";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(7, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Имя вкладки";
            // 
            // ReportCollector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(650, 357);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(670, 400);
            this.MinimumSize = new System.Drawing.Size(670, 400);
            this.Name = "ReportCollector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Утилита по формированию отчета";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox fileNameBox;
        private System.Windows.Forms.TextBox countColumn;
        private System.Windows.Forms.TextBox rowNumberCopy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox TypeFile;
        public System.Windows.Forms.Button unloadFile;
        public System.Windows.Forms.Button SelectAll;
        public System.Windows.Forms.Button RepColl;
        private System.Windows.Forms.ComboBox tabNameBox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button butStartFormConfig;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox destinationFolder;
        public System.Windows.Forms.TextBox textSettingPath;
        public System.Windows.Forms.TextBox sourceFolder;
    }
}

