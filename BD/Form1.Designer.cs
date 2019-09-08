namespace BD
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonDoc = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClient = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonProcedure = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDepartment = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUpdate = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboBoxDep = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonShow = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxIDDep = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxID_Doc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonRecordDoc = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxID_Pat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRecordPat = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonRecord = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonDoc,
            this.toolStripButtonClient,
            this.toolStripButtonProcedure,
            this.toolStripButtonReport,
            this.toolStripButtonDepartment,
            this.toolStripButtonUpdate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1029, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonDoc
            // 
            this.toolStripButtonDoc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDoc.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDoc.Image")));
            this.toolStripButtonDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDoc.Name = "toolStripButtonDoc";
            this.toolStripButtonDoc.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonDoc.Text = "Врачи";
            this.toolStripButtonDoc.Click += new System.EventHandler(this.toolStripButtonDoc_Click);
            // 
            // toolStripButtonClient
            // 
            this.toolStripButtonClient.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClient.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClient.Image")));
            this.toolStripButtonClient.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClient.Name = "toolStripButtonClient";
            this.toolStripButtonClient.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonClient.Text = "Клиенты";
            this.toolStripButtonClient.Click += new System.EventHandler(this.toolStripButtonClient_Click);
            // 
            // toolStripButtonProcedure
            // 
            this.toolStripButtonProcedure.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonProcedure.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonProcedure.Image")));
            this.toolStripButtonProcedure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonProcedure.Name = "toolStripButtonProcedure";
            this.toolStripButtonProcedure.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonProcedure.Text = "Услуги";
            this.toolStripButtonProcedure.Click += new System.EventHandler(this.toolStripButtonProcedure_Click);
            // 
            // toolStripButtonReport
            // 
            this.toolStripButtonReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonReport.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonReport.Image")));
            this.toolStripButtonReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonReport.Name = "toolStripButtonReport";
            this.toolStripButtonReport.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonReport.Text = "Отчеты";
            this.toolStripButtonReport.Click += new System.EventHandler(this.toolStripButtonReport_Click);
            // 
            // toolStripButtonDepartment
            // 
            this.toolStripButtonDepartment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDepartment.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDepartment.Image")));
            this.toolStripButtonDepartment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDepartment.Name = "toolStripButtonDepartment";
            this.toolStripButtonDepartment.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonDepartment.Text = "Отделения";
            this.toolStripButtonDepartment.Click += new System.EventHandler(this.toolStripButtonDepartment_Click);
            // 
            // toolStripButtonUpdate
            // 
            this.toolStripButtonUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUpdate.Name = "toolStripButtonUpdate";
            this.toolStripButtonUpdate.Size = new System.Drawing.Size(237, 24);
            this.toolStripButtonUpdate.Text = "Отобразить данные по записям";
            this.toolStripButtonUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.toolStripButtonUpdate.Click += new System.EventHandler(this.toolStripButtonUpdate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.buttonUpdate);
            this.groupBox1.Controls.Add(this.buttonDelete);
            this.groupBox1.Controls.Add(this.buttonRecord);
            this.groupBox1.Controls.Add(this.dataGridView);
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1005, 709);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Запись";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboBoxDep);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.buttonShow);
            this.groupBox5.Location = new System.Drawing.Point(17, 591);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(630, 90);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Вывод услуг отделения";
            // 
            // comboBoxDep
            // 
            this.comboBoxDep.FormattingEnabled = true;
            this.comboBoxDep.Location = new System.Drawing.Point(9, 49);
            this.comboBoxDep.Name = "comboBoxDep";
            this.comboBoxDep.Size = new System.Drawing.Size(267, 24);
            this.comboBoxDep.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Отделение";
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(321, 27);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(303, 46);
            this.buttonShow.TabIndex = 5;
            this.buttonShow.Text = "Вывести";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxIDDep);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.buttonSearch);
            this.groupBox4.Location = new System.Drawing.Point(17, 495);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(630, 90);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Поиск врача по коду отделения";
            // 
            // textBoxIDDep
            // 
            this.textBoxIDDep.Location = new System.Drawing.Point(9, 51);
            this.textBoxIDDep.Name = "textBoxIDDep";
            this.textBoxIDDep.Size = new System.Drawing.Size(267, 22);
            this.textBoxIDDep.TabIndex = 8;
            this.textBoxIDDep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIDDep_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Код отделения";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(321, 27);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(303, 46);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = "Поиск";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxID_Doc);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.buttonRecordDoc);
            this.groupBox3.Location = new System.Drawing.Point(17, 398);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(630, 91);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Поиск записей к врачу";
            // 
            // textBoxID_Doc
            // 
            this.textBoxID_Doc.Location = new System.Drawing.Point(9, 51);
            this.textBoxID_Doc.Name = "textBoxID_Doc";
            this.textBoxID_Doc.Size = new System.Drawing.Size(267, 22);
            this.textBoxID_Doc.TabIndex = 8;
            this.textBoxID_Doc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Код врача";
            // 
            // buttonRecordDoc
            // 
            this.buttonRecordDoc.Location = new System.Drawing.Point(321, 27);
            this.buttonRecordDoc.Name = "buttonRecordDoc";
            this.buttonRecordDoc.Size = new System.Drawing.Size(303, 46);
            this.buttonRecordDoc.TabIndex = 5;
            this.buttonRecordDoc.Text = "Записи к врачу со статусом \"Ожидание\"";
            this.buttonRecordDoc.UseVisualStyleBackColor = true;
            this.buttonRecordDoc.Click += new System.EventHandler(this.buttonRecordDoc_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxID_Pat);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.buttonRecordPat);
            this.groupBox2.Location = new System.Drawing.Point(17, 299);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(630, 93);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Поиск записей клиента";
            // 
            // textBoxID_Pat
            // 
            this.textBoxID_Pat.Location = new System.Drawing.Point(9, 54);
            this.textBoxID_Pat.Name = "textBoxID_Pat";
            this.textBoxID_Pat.Size = new System.Drawing.Size(267, 22);
            this.textBoxID_Pat.TabIndex = 6;
            this.textBoxID_Pat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxID_Pat_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Код клиента";
            // 
            // buttonRecordPat
            // 
            this.buttonRecordPat.Location = new System.Drawing.Point(321, 30);
            this.buttonRecordPat.Name = "buttonRecordPat";
            this.buttonRecordPat.Size = new System.Drawing.Size(303, 46);
            this.buttonRecordPat.TabIndex = 7;
            this.buttonRecordPat.Text = "Записи клиента";
            this.buttonRecordPat.Click += new System.EventHandler(this.buttonRecordPat_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(696, 441);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(303, 41);
            this.buttonUpdate.TabIndex = 3;
            this.buttonUpdate.Text = "Изменить запись на прием";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(696, 373);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(303, 41);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Отменить запись на прием";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonRecord
            // 
            this.buttonRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRecord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonRecord.Location = new System.Drawing.Point(696, 305);
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Size = new System.Drawing.Size(303, 41);
            this.buttonRecord.TabIndex = 1;
            this.buttonRecord.Text = "Записать на прием";
            this.buttonRecord.UseVisualStyleBackColor = true;
            this.buttonRecord.Click += new System.EventHandler(this.buttonRecord_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(6, 21);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(993, 258);
            this.dataGridView.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1029, 751);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Клиника";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonDoc;
        private System.Windows.Forms.ToolStripButton toolStripButtonClient;
        private System.Windows.Forms.ToolStripButton toolStripButtonProcedure;
        private System.Windows.Forms.ToolStripButton toolStripButtonReport;
        private System.Windows.Forms.ToolStripButton toolStripButtonDepartment;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonRecord;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxID_Doc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonRecordDoc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxID_Pat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRecordPat;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxIDDep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ComboBox comboBoxDep;
        private System.Windows.Forms.ToolStripButton toolStripButtonUpdate;
    }
}

