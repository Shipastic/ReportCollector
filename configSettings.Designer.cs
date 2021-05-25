
namespace RepCol_2
{
    partial class ConfigSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigSettings));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ButLoad = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textDestinationPath = new System.Windows.Forms.TextBox();
            this.butSelectDestinPath = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textSourcePath = new System.Windows.Forms.TextBox();
            this.butSelectSourcePath = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textPathSet = new System.Windows.Forms.TextBox();
            this.butSetFolder = new System.Windows.Forms.Button();
            this.ButSaveSettings = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.ButLoad);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.ButSaveSettings);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(14, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 362);
            this.panel1.TabIndex = 9;
            // 
            // ButLoad
            // 
            this.ButLoad.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ButLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButLoad.Location = new System.Drawing.Point(14, 328);
            this.ButLoad.Name = "ButLoad";
            this.ButLoad.Size = new System.Drawing.Size(135, 27);
            this.ButLoad.TabIndex = 14;
            this.ButLoad.Text = "Загрузить";
            this.ButLoad.UseVisualStyleBackColor = false;
            this.ButLoad.Click += new System.EventHandler(this.ButLoad_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textDestinationPath);
            this.groupBox3.Controls.Add(this.butSelectDestinPath);
            this.groupBox3.Location = new System.Drawing.Point(7, 242);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(297, 78);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Установка каталога-приемника";
            // 
            // textDestinationPath
            // 
            this.textDestinationPath.Cursor = System.Windows.Forms.Cursors.No;
            this.textDestinationPath.Location = new System.Drawing.Point(7, 33);
            this.textDestinationPath.Name = "textDestinationPath";
            this.textDestinationPath.ReadOnly = true;
            this.textDestinationPath.Size = new System.Drawing.Size(135, 23);
            this.textDestinationPath.TabIndex = 6;
            // 
            // butSelectDestinPath
            // 
            this.butSelectDestinPath.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.butSelectDestinPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butSelectDestinPath.Location = new System.Drawing.Point(149, 30);
            this.butSelectDestinPath.Name = "butSelectDestinPath";
            this.butSelectDestinPath.Size = new System.Drawing.Size(135, 27);
            this.butSelectDestinPath.TabIndex = 8;
            this.butSelectDestinPath.Text = "Выбрать каталог";
            this.butSelectDestinPath.UseVisualStyleBackColor = false;
            this.butSelectDestinPath.Click += new System.EventHandler(this.ButSelectDestinPath_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textSourcePath);
            this.groupBox2.Controls.Add(this.butSelectSourcePath);
            this.groupBox2.Location = new System.Drawing.Point(7, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(297, 78);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Установка каталога-источника";
            // 
            // textSourcePath
            // 
            this.textSourcePath.Cursor = System.Windows.Forms.Cursors.No;
            this.textSourcePath.Location = new System.Drawing.Point(7, 32);
            this.textSourcePath.Name = "textSourcePath";
            this.textSourcePath.ReadOnly = true;
            this.textSourcePath.Size = new System.Drawing.Size(135, 23);
            this.textSourcePath.TabIndex = 5;
            // 
            // butSelectSourcePath
            // 
            this.butSelectSourcePath.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.butSelectSourcePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butSelectSourcePath.Location = new System.Drawing.Point(149, 29);
            this.butSelectSourcePath.Name = "butSelectSourcePath";
            this.butSelectSourcePath.Size = new System.Drawing.Size(135, 27);
            this.butSelectSourcePath.TabIndex = 7;
            this.butSelectSourcePath.Text = "Выбрать каталог";
            this.butSelectSourcePath.UseVisualStyleBackColor = false;
            this.butSelectSourcePath.Click += new System.EventHandler(this.ButSelectSourcePath_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textPathSet);
            this.groupBox1.Controls.Add(this.butSetFolder);
            this.groupBox1.Location = new System.Drawing.Point(7, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 78);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор конфиг. файла";
            // 
            // textPathSet
            // 
            this.textPathSet.Cursor = System.Windows.Forms.Cursors.No;
            this.textPathSet.Location = new System.Drawing.Point(7, 36);
            this.textPathSet.Name = "textPathSet";
            this.textPathSet.ReadOnly = true;
            this.textPathSet.Size = new System.Drawing.Size(135, 23);
            this.textPathSet.TabIndex = 1;
            // 
            // butSetFolder
            // 
            this.butSetFolder.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.butSetFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butSetFolder.Location = new System.Drawing.Point(149, 32);
            this.butSetFolder.Name = "butSetFolder";
            this.butSetFolder.Size = new System.Drawing.Size(135, 27);
            this.butSetFolder.TabIndex = 2;
            this.butSetFolder.Text = "Конфиг.файл";
            this.butSetFolder.UseVisualStyleBackColor = false;
            this.butSetFolder.Click += new System.EventHandler(this.ButSetFolder_Click);
            // 
            // ButSaveSettings
            // 
            this.ButSaveSettings.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ButSaveSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButSaveSettings.Location = new System.Drawing.Point(156, 328);
            this.ButSaveSettings.Name = "ButSaveSettings";
            this.ButSaveSettings.Size = new System.Drawing.Size(135, 27);
            this.ButSaveSettings.TabIndex = 10;
            this.ButSaveSettings.Text = "Сохранить";
            this.ButSaveSettings.UseVisualStyleBackColor = false;
            this.ButSaveSettings.Click += new System.EventHandler(this.ButSaveSettings_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Установка исходных значений";
            // 
            // configSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(350, 389);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(370, 432);
            this.MinimumSize = new System.Drawing.Size(370, 432);
            this.Name = "configSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка каталогов";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConfigSettings_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butSelectDestinPath;
        private System.Windows.Forms.TextBox textPathSet;
        private System.Windows.Forms.Button butSelectSourcePath;
        private System.Windows.Forms.Button butSetFolder;
        private System.Windows.Forms.TextBox textDestinationPath;
        private System.Windows.Forms.TextBox textSourcePath;
        private System.Windows.Forms.Button ButSaveSettings;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ButLoad;
    }
}