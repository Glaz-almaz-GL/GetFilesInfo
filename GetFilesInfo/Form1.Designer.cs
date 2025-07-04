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
            this.lbPath = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btView = new System.Windows.Forms.Button();
            this.lbLog = new System.Windows.Forms.Label();
            this.btStart = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btSortByFilePath = new System.Windows.Forms.Button();
            this.btSortByNameAsc = new System.Windows.Forms.Button();
            this.btSortByNameDesc = new System.Windows.Forms.Button();
            this.btSortByPagesDesc = new System.Windows.Forms.Button();
            this.btSortByPagesAsc = new System.Windows.Forms.Button();
            this.btSortByCRCAsc = new System.Windows.Forms.Button();
            this.btSortByCRCDesc = new System.Windows.Forms.Button();
            this.btSortByExtensionAsc = new System.Windows.Forms.Button();
            this.btSortByExtensionDesc = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chbShouldNumerable = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbPath
            // 
            this.lbPath.AutoSize = true;
            this.lbPath.Location = new System.Drawing.Point(12, 9);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(116, 13);
            this.lbPath.TabIndex = 0;
            this.lbPath.Text = "Путь до папки/файла";
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(15, 25);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(918, 20);
            this.txtPath.TabIndex = 1;
            // 
            // btView
            // 
            this.btView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btView.Location = new System.Drawing.Point(939, 23);
            this.btView.Name = "btView";
            this.btView.Size = new System.Drawing.Size(54, 23);
            this.btView.TabIndex = 2;
            this.btView.Text = "Обзор";
            this.btView.UseVisualStyleBackColor = true;
            this.btView.Click += new System.EventHandler(this.btView_Click);
            // 
            // lbLog
            // 
            this.lbLog.AutoSize = true;
            this.lbLog.Location = new System.Drawing.Point(12, 132);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(43, 13);
            this.lbLog.TabIndex = 4;
            this.lbLog.Text = "Вывод:";
            // 
            // btStart
            // 
            this.btStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btStart.Location = new System.Drawing.Point(15, 466);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(978, 34);
            this.btStart.TabIndex = 5;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(15, 148);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(978, 312);
            this.txtLog.TabIndex = 6;
            this.txtLog.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Сортиорвка:";
            // 
            // btSortByFilePath
            // 
            this.btSortByFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btSortByFilePath.Location = new System.Drawing.Point(3, 0);
            this.btSortByFilePath.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btSortByFilePath.Name = "btSortByFilePath";
            this.btSortByFilePath.Size = new System.Drawing.Size(102, 46);
            this.btSortByFilePath.TabIndex = 8;
            this.btSortByFilePath.Text = "Путь файла";
            this.btSortByFilePath.UseVisualStyleBackColor = true;
            this.btSortByFilePath.Click += new System.EventHandler(this.btSortByFilePath_Click);
            // 
            // btSortByNameAsc
            // 
            this.btSortByNameAsc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btSortByNameAsc.Location = new System.Drawing.Point(219, 0);
            this.btSortByNameAsc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btSortByNameAsc.Name = "btSortByNameAsc";
            this.btSortByNameAsc.Size = new System.Drawing.Size(102, 46);
            this.btSortByNameAsc.TabIndex = 9;
            this.btSortByNameAsc.Text = "Имя файла (↑)";
            this.btSortByNameAsc.UseVisualStyleBackColor = true;
            this.btSortByNameAsc.Click += new System.EventHandler(this.btSortByNameAsc_Click);
            // 
            // btSortByNameDesc
            // 
            this.btSortByNameDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btSortByNameDesc.Location = new System.Drawing.Point(111, 0);
            this.btSortByNameDesc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btSortByNameDesc.Name = "btSortByNameDesc";
            this.btSortByNameDesc.Size = new System.Drawing.Size(102, 46);
            this.btSortByNameDesc.TabIndex = 10;
            this.btSortByNameDesc.Text = "Имя файла (↓)";
            this.btSortByNameDesc.UseVisualStyleBackColor = true;
            this.btSortByNameDesc.Click += new System.EventHandler(this.btSortByNameDesc_Click);
            // 
            // btSortByPagesDesc
            // 
            this.btSortByPagesDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btSortByPagesDesc.Location = new System.Drawing.Point(435, 0);
            this.btSortByPagesDesc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btSortByPagesDesc.Name = "btSortByPagesDesc";
            this.btSortByPagesDesc.Size = new System.Drawing.Size(102, 46);
            this.btSortByPagesDesc.TabIndex = 11;
            this.btSortByPagesDesc.Text = "Страница (↓)";
            this.btSortByPagesDesc.UseVisualStyleBackColor = true;
            this.btSortByPagesDesc.Click += new System.EventHandler(this.btSortByPagesDesc_Click);
            // 
            // btSortByPagesAsc
            // 
            this.btSortByPagesAsc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btSortByPagesAsc.Location = new System.Drawing.Point(327, 0);
            this.btSortByPagesAsc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btSortByPagesAsc.Name = "btSortByPagesAsc";
            this.btSortByPagesAsc.Size = new System.Drawing.Size(102, 46);
            this.btSortByPagesAsc.TabIndex = 12;
            this.btSortByPagesAsc.Text = "Страница (↑)";
            this.btSortByPagesAsc.UseVisualStyleBackColor = true;
            this.btSortByPagesAsc.Click += new System.EventHandler(this.btSortByPagesAsc_Click);
            // 
            // btSortByCRCAsc
            // 
            this.btSortByCRCAsc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btSortByCRCAsc.Location = new System.Drawing.Point(759, 0);
            this.btSortByCRCAsc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btSortByCRCAsc.Name = "btSortByCRCAsc";
            this.btSortByCRCAsc.Size = new System.Drawing.Size(102, 46);
            this.btSortByCRCAsc.TabIndex = 13;
            this.btSortByCRCAsc.Text = "CRC (↑)";
            this.btSortByCRCAsc.UseVisualStyleBackColor = true;
            this.btSortByCRCAsc.Click += new System.EventHandler(this.btSortByCRCAsc_Click);
            // 
            // btSortByCRCDesc
            // 
            this.btSortByCRCDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btSortByCRCDesc.Location = new System.Drawing.Point(867, 0);
            this.btSortByCRCDesc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btSortByCRCDesc.Name = "btSortByCRCDesc";
            this.btSortByCRCDesc.Size = new System.Drawing.Size(108, 46);
            this.btSortByCRCDesc.TabIndex = 14;
            this.btSortByCRCDesc.Text = "CRC (↓)";
            this.btSortByCRCDesc.UseVisualStyleBackColor = true;
            this.btSortByCRCDesc.Click += new System.EventHandler(this.btSortByCRCDesc_Click);
            // 
            // btSortByExtensionAsc
            // 
            this.btSortByExtensionAsc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btSortByExtensionAsc.Location = new System.Drawing.Point(543, 0);
            this.btSortByExtensionAsc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btSortByExtensionAsc.Name = "btSortByExtensionAsc";
            this.btSortByExtensionAsc.Size = new System.Drawing.Size(102, 46);
            this.btSortByExtensionAsc.TabIndex = 15;
            this.btSortByExtensionAsc.Text = "Расширение (↑)";
            this.btSortByExtensionAsc.UseVisualStyleBackColor = true;
            this.btSortByExtensionAsc.Click += new System.EventHandler(this.btSortByExtensionAsc_Click);
            // 
            // btSortByExtensionDesc
            // 
            this.btSortByExtensionDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btSortByExtensionDesc.Location = new System.Drawing.Point(651, 0);
            this.btSortByExtensionDesc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btSortByExtensionDesc.Name = "btSortByExtensionDesc";
            this.btSortByExtensionDesc.Size = new System.Drawing.Size(102, 46);
            this.btSortByExtensionDesc.TabIndex = 16;
            this.btSortByExtensionDesc.Text = "Расширение (↓)";
            this.btSortByExtensionDesc.UseVisualStyleBackColor = true;
            this.btSortByExtensionDesc.Click += new System.EventHandler(this.btSortByExtensionDesc_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.Controls.Add(this.btSortByFilePath, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btSortByCRCDesc, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.btSortByNameDesc, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btSortByCRCAsc, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.btSortByNameAsc, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btSortByExtensionDesc, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btSortByPagesAsc, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btSortByPagesDesc, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btSortByExtensionAsc, 5, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 86);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(978, 46);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // chbShouldNumerable
            // 
            this.chbShouldNumerable.AutoSize = true;
            this.chbShouldNumerable.Location = new System.Drawing.Point(15, 51);
            this.chbShouldNumerable.Name = "chbShouldNumerable";
            this.chbShouldNumerable.Size = new System.Drawing.Size(141, 17);
            this.chbShouldNumerable.TabIndex = 18;
            this.chbShouldNumerable.Text = "Включить нумерацию?";
            this.chbShouldNumerable.UseVisualStyleBackColor = true;
            this.chbShouldNumerable.CheckedChanged += new System.EventHandler(this.chbShouldNumerable_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 512);
            this.Controls.Add(this.chbShouldNumerable);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.btView);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lbPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Get Files Info";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button btSortByCRCAsc;
        private System.Windows.Forms.Button btSortByCRCDesc;
        private System.Windows.Forms.Button btSortByExtensionDesc;
        private System.Windows.Forms.Button btSortByExtensionAsc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chbShouldNumerable;
    }
}

