namespace GetFilesInfo
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            lbPath = new System.Windows.Forms.Label();
            txtPath = new System.Windows.Forms.TextBox();
            btView = new System.Windows.Forms.Button();
            lbLog = new System.Windows.Forms.Label();
            btStart = new System.Windows.Forms.Button();
            txtLog = new System.Windows.Forms.RichTextBox();
            label1 = new System.Windows.Forms.Label();
            btSortByFilePath = new System.Windows.Forms.Button();
            btSortByNameAsc = new System.Windows.Forms.Button();
            btSortByNameDesc = new System.Windows.Forms.Button();
            btSortByPagesDesc = new System.Windows.Forms.Button();
            btSortByPagesAsc = new System.Windows.Forms.Button();
            btSortByHashAsc = new System.Windows.Forms.Button();
            btSortByHashDesc = new System.Windows.Forms.Button();
            btSortByExtensionAsc = new System.Windows.Forms.Button();
            btSortByExtensionDesc = new System.Windows.Forms.Button();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            chbShouldNumerable = new System.Windows.Forms.CheckBox();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            tsmAboutInfo = new System.Windows.Forms.ToolStripMenuItem();
            tsmCheckForUpdates = new System.Windows.Forms.ToolStripMenuItem();
            btExport = new System.Windows.Forms.Button();
            tableLayoutPanel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lbPath
            // 
            lbPath.AutoSize = true;
            lbPath.Location = new System.Drawing.Point(14, 44);
            lbPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbPath.Name = "lbPath";
            lbPath.Size = new System.Drawing.Size(125, 15);
            lbPath.TabIndex = 0;
            lbPath.Text = "Путь до папки/файла";
            // 
            // txtPath
            // 
            txtPath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtPath.Location = new System.Drawing.Point(18, 62);
            txtPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtPath.Name = "txtPath";
            txtPath.Size = new System.Drawing.Size(946, 23);
            txtPath.TabIndex = 1;
            // 
            // btView
            // 
            btView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btView.Location = new System.Drawing.Point(971, 60);
            btView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btView.Name = "btView";
            btView.Size = new System.Drawing.Size(63, 27);
            btView.TabIndex = 2;
            btView.Text = "Обзор";
            btView.UseVisualStyleBackColor = true;
            btView.Click += btView_Click;
            // 
            // lbLog
            // 
            lbLog.AutoSize = true;
            lbLog.Location = new System.Drawing.Point(14, 200);
            lbLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbLog.Name = "lbLog";
            lbLog.Size = new System.Drawing.Size(45, 15);
            lbLog.TabIndex = 4;
            lbLog.Text = "Вывод:";
            // 
            // btStart
            // 
            btStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btStart.Location = new System.Drawing.Point(18, 642);
            btStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(904, 51);
            btStart.TabIndex = 5;
            btStart.Text = "Старт";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // txtLog
            // 
            txtLog.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtLog.Location = new System.Drawing.Point(18, 218);
            txtLog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.Size = new System.Drawing.Size(1016, 418);
            txtLog.TabIndex = 6;
            txtLog.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(14, 132);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(76, 15);
            label1.TabIndex = 7;
            label1.Text = "Сортиорвка:";
            // 
            // btSortByFilePath
            // 
            btSortByFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            btSortByFilePath.Location = new System.Drawing.Point(4, 0);
            btSortByFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            btSortByFilePath.Name = "btSortByFilePath";
            btSortByFilePath.Size = new System.Drawing.Size(104, 53);
            btSortByFilePath.TabIndex = 8;
            btSortByFilePath.Text = "Путь файла";
            btSortByFilePath.UseVisualStyleBackColor = true;
            btSortByFilePath.Click += SortButton_Click;
            // 
            // btSortByNameAsc
            // 
            btSortByNameAsc.Dock = System.Windows.Forms.DockStyle.Fill;
            btSortByNameAsc.Location = new System.Drawing.Point(228, 0);
            btSortByNameAsc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            btSortByNameAsc.Name = "btSortByNameAsc";
            btSortByNameAsc.Size = new System.Drawing.Size(104, 53);
            btSortByNameAsc.TabIndex = 9;
            btSortByNameAsc.Text = "Имя файла (↑)";
            btSortByNameAsc.UseVisualStyleBackColor = true;
            btSortByNameAsc.Click += SortButton_Click;
            // 
            // btSortByNameDesc
            // 
            btSortByNameDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            btSortByNameDesc.Location = new System.Drawing.Point(116, 0);
            btSortByNameDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            btSortByNameDesc.Name = "btSortByNameDesc";
            btSortByNameDesc.Size = new System.Drawing.Size(104, 53);
            btSortByNameDesc.TabIndex = 10;
            btSortByNameDesc.Text = "Имя файла (↓)";
            btSortByNameDesc.UseVisualStyleBackColor = true;
            btSortByNameDesc.Click += SortButton_Click;
            // 
            // btSortByPagesDesc
            // 
            btSortByPagesDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            btSortByPagesDesc.Location = new System.Drawing.Point(452, 0);
            btSortByPagesDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            btSortByPagesDesc.Name = "btSortByPagesDesc";
            btSortByPagesDesc.Size = new System.Drawing.Size(104, 53);
            btSortByPagesDesc.TabIndex = 11;
            btSortByPagesDesc.Text = "Страница (↓)";
            btSortByPagesDesc.UseVisualStyleBackColor = true;
            btSortByPagesDesc.Click += SortButton_Click;
            // 
            // btSortByPagesAsc
            // 
            btSortByPagesAsc.Dock = System.Windows.Forms.DockStyle.Fill;
            btSortByPagesAsc.Location = new System.Drawing.Point(340, 0);
            btSortByPagesAsc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            btSortByPagesAsc.Name = "btSortByPagesAsc";
            btSortByPagesAsc.Size = new System.Drawing.Size(104, 53);
            btSortByPagesAsc.TabIndex = 12;
            btSortByPagesAsc.Text = "Страница (↑)";
            btSortByPagesAsc.UseVisualStyleBackColor = true;
            btSortByPagesAsc.Click += SortButton_Click;
            // 
            // btSortByHashAsc
            // 
            btSortByHashAsc.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btSortByHashAsc.Location = new System.Drawing.Point(788, 0);
            btSortByHashAsc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            btSortByHashAsc.Name = "btSortByHashAsc";
            btSortByHashAsc.Size = new System.Drawing.Size(104, 53);
            btSortByHashAsc.TabIndex = 13;
            btSortByHashAsc.Text = "Хэш (↑)";
            btSortByHashAsc.UseVisualStyleBackColor = true;
            btSortByHashAsc.Click += SortButton_Click;
            // 
            // btSortByHashDesc
            // 
            btSortByHashDesc.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btSortByHashDesc.Location = new System.Drawing.Point(900, 0);
            btSortByHashDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            btSortByHashDesc.Name = "btSortByHashDesc";
            btSortByHashDesc.Size = new System.Drawing.Size(112, 53);
            btSortByHashDesc.TabIndex = 14;
            btSortByHashDesc.Text = "Хэш (↓)";
            btSortByHashDesc.UseVisualStyleBackColor = true;
            btSortByHashDesc.Click += SortButton_Click;
            // 
            // btSortByExtensionAsc
            // 
            btSortByExtensionAsc.Dock = System.Windows.Forms.DockStyle.Fill;
            btSortByExtensionAsc.Location = new System.Drawing.Point(564, 0);
            btSortByExtensionAsc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            btSortByExtensionAsc.Name = "btSortByExtensionAsc";
            btSortByExtensionAsc.Size = new System.Drawing.Size(104, 53);
            btSortByExtensionAsc.TabIndex = 15;
            btSortByExtensionAsc.Text = "Расширение (↑)";
            btSortByExtensionAsc.UseVisualStyleBackColor = true;
            btSortByExtensionAsc.Click += SortButton_Click;
            // 
            // btSortByExtensionDesc
            // 
            btSortByExtensionDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            btSortByExtensionDesc.Location = new System.Drawing.Point(676, 0);
            btSortByExtensionDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            btSortByExtensionDesc.Name = "btSortByExtensionDesc";
            btSortByExtensionDesc.Size = new System.Drawing.Size(104, 53);
            btSortByExtensionDesc.TabIndex = 16;
            btSortByExtensionDesc.Text = "Расширение (↓)";
            btSortByExtensionDesc.UseVisualStyleBackColor = true;
            btSortByExtensionDesc.Click += SortButton_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 9;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            tableLayoutPanel1.Controls.Add(btSortByFilePath, 0, 0);
            tableLayoutPanel1.Controls.Add(btSortByHashDesc, 8, 0);
            tableLayoutPanel1.Controls.Add(btSortByNameDesc, 1, 0);
            tableLayoutPanel1.Controls.Add(btSortByHashAsc, 7, 0);
            tableLayoutPanel1.Controls.Add(btSortByNameAsc, 2, 0);
            tableLayoutPanel1.Controls.Add(btSortByExtensionDesc, 6, 0);
            tableLayoutPanel1.Controls.Add(btSortByPagesAsc, 3, 0);
            tableLayoutPanel1.Controls.Add(btSortByPagesDesc, 4, 0);
            tableLayoutPanel1.Controls.Add(btSortByExtensionAsc, 5, 0);
            tableLayoutPanel1.Location = new System.Drawing.Point(18, 147);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(1016, 53);
            tableLayoutPanel1.TabIndex = 17;
            // 
            // chbShouldNumerable
            // 
            chbShouldNumerable.AutoSize = true;
            chbShouldNumerable.Checked = true;
            chbShouldNumerable.CheckState = System.Windows.Forms.CheckState.Checked;
            chbShouldNumerable.Location = new System.Drawing.Point(18, 91);
            chbShouldNumerable.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chbShouldNumerable.Name = "chbShouldNumerable";
            chbShouldNumerable.Size = new System.Drawing.Size(199, 19);
            chbShouldNumerable.TabIndex = 18;
            chbShouldNumerable.Text = "Включить нумерацию файлов?";
            chbShouldNumerable.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmAboutInfo, tsmCheckForUpdates });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(1048, 24);
            menuStrip1.TabIndex = 21;
            menuStrip1.Text = "menuStrip1";
            // 
            // tsmAboutInfo
            // 
            tsmAboutInfo.Name = "tsmAboutInfo";
            tsmAboutInfo.Size = new System.Drawing.Size(76, 20);
            tsmAboutInfo.Text = "&About Info";
            tsmAboutInfo.Click += tsmAboutInfo_Click;
            // 
            // tsmCheckForUpdates
            // 
            tsmCheckForUpdates.Name = "tsmCheckForUpdates";
            tsmCheckForUpdates.Size = new System.Drawing.Size(116, 20);
            tsmCheckForUpdates.Text = "&Check for Updates";
            tsmCheckForUpdates.Click += tsmCheckForUpdates_Click;
            // 
            // btExport
            // 
            btExport.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btExport.Location = new System.Drawing.Point(929, 642);
            btExport.Name = "btExport";
            btExport.Size = new System.Drawing.Size(105, 51);
            btExport.TabIndex = 22;
            btExport.Text = "Экспортировать вывод";
            btExport.UseVisualStyleBackColor = true;
            btExport.Click += btExport_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1048, 705);
            Controls.Add(btExport);
            Controls.Add(menuStrip1);
            Controls.Add(chbShouldNumerable);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(label1);
            Controls.Add(txtLog);
            Controls.Add(btStart);
            Controls.Add(lbLog);
            Controls.Add(btView);
            Controls.Add(txtPath);
            Controls.Add(lbPath);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "frmMain";
            Text = "Get Files Info";
            tableLayoutPanel1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btView;
        private System.Windows.Forms.Label lbLog;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSortByFilePath;
        private System.Windows.Forms.Button btSortByNameAsc;
        private System.Windows.Forms.Button btSortByNameDesc;
        private System.Windows.Forms.Button btSortByPagesDesc;
        private System.Windows.Forms.Button btSortByPagesAsc;
        private System.Windows.Forms.Button btSortByHashAsc;
        private System.Windows.Forms.Button btSortByHashDesc;
        private System.Windows.Forms.Button btSortByExtensionDesc;
        private System.Windows.Forms.Button btSortByExtensionAsc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chbShouldNumerable;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmAboutInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmCheckForUpdates;
        private System.Windows.Forms.Button btExport;
    }
}

