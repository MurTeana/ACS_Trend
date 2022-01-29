namespace Fond_wf
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
            this.approxy_btn = new System.Windows.Forms.Button();
            this.normalgr_btn = new System.Windows.Forms.Button();
            this.kAproxy_txtbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.path_txtbox = new System.Windows.Forms.TextBox();
            this.path_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.startp_txtbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.qGO2_txtbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tol1_txtbox = new System.Windows.Forms.TextBox();
            this.tol2_txtbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.timeExp_txtbox = new System.Windows.Forms.TextBox();
            this.grafanalize_btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.loadData_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // approxy_btn
            // 
            this.approxy_btn.Location = new System.Drawing.Point(716, 33);
            this.approxy_btn.Name = "approxy_btn";
            this.approxy_btn.Size = new System.Drawing.Size(123, 23);
            this.approxy_btn.TabIndex = 1;
            this.approxy_btn.Text = "Анализ данных";
            this.approxy_btn.UseVisualStyleBackColor = true;
            this.approxy_btn.Click += new System.EventHandler(this.approxy_btn_Click);
            // 
            // normalgr_btn
            // 
            this.normalgr_btn.Location = new System.Drawing.Point(845, 3);
            this.normalgr_btn.Name = "normalgr_btn";
            this.normalgr_btn.Size = new System.Drawing.Size(142, 23);
            this.normalgr_btn.TabIndex = 2;
            this.normalgr_btn.Text = "Исходный график";
            this.normalgr_btn.UseVisualStyleBackColor = true;
            this.normalgr_btn.Click += new System.EventHandler(this.normalgr_btn_Click);
            // 
            // kAproxy_txtbox
            // 
            this.kAproxy_txtbox.Location = new System.Drawing.Point(69, 33);
            this.kAproxy_txtbox.Name = "kAproxy_txtbox";
            this.kAproxy_txtbox.Size = new System.Drawing.Size(75, 20);
            this.kAproxy_txtbox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "kAproxy";
            // 
            // path_txtbox
            // 
            this.path_txtbox.Location = new System.Drawing.Point(412, 5);
            this.path_txtbox.Name = "path_txtbox";
            this.path_txtbox.Size = new System.Drawing.Size(251, 20);
            this.path_txtbox.TabIndex = 5;
            // 
            // path_btn
            // 
            this.path_btn.Location = new System.Drawing.Point(669, 3);
            this.path_btn.Name = "path_btn";
            this.path_btn.Size = new System.Drawing.Size(30, 23);
            this.path_btn.TabIndex = 6;
            this.path_btn.Text = "...";
            this.path_btn.UseVisualStyleBackColor = true;
            this.path_btn.Click += new System.EventHandler(this.path_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "start point";
            // 
            // startp_txtbox
            // 
            this.startp_txtbox.Location = new System.Drawing.Point(69, 4);
            this.startp_txtbox.Name = "startp_txtbox";
            this.startp_txtbox.Size = new System.Drawing.Size(75, 20);
            this.startp_txtbox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "qGO2";
            // 
            // qGO2_txtbox
            // 
            this.qGO2_txtbox.Location = new System.Drawing.Point(69, 63);
            this.qGO2_txtbox.Name = "qGO2_txtbox";
            this.qGO2_txtbox.Size = new System.Drawing.Size(75, 20);
            this.qGO2_txtbox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(160, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "tolerance_kAproxy";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(160, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "tolerance_tgY";
            // 
            // tol1_txtbox
            // 
            this.tol1_txtbox.AcceptsReturn = true;
            this.tol1_txtbox.Location = new System.Drawing.Point(266, 5);
            this.tol1_txtbox.Name = "tol1_txtbox";
            this.tol1_txtbox.Size = new System.Drawing.Size(100, 20);
            this.tol1_txtbox.TabIndex = 11;
            // 
            // tol2_txtbox
            // 
            this.tol2_txtbox.Location = new System.Drawing.Point(266, 32);
            this.tol2_txtbox.Name = "tol2_txtbox";
            this.tol2_txtbox.Size = new System.Drawing.Size(100, 20);
            this.tol2_txtbox.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(160, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "timeExp";
            // 
            // timeExp_txtbox
            // 
            this.timeExp_txtbox.Location = new System.Drawing.Point(266, 60);
            this.timeExp_txtbox.Name = "timeExp_txtbox";
            this.timeExp_txtbox.Size = new System.Drawing.Size(100, 20);
            this.timeExp_txtbox.TabIndex = 14;
            // 
            // grafanalize_btn
            // 
            this.grafanalize_btn.Location = new System.Drawing.Point(845, 33);
            this.grafanalize_btn.Name = "grafanalize_btn";
            this.grafanalize_btn.Size = new System.Drawing.Size(142, 23);
            this.grafanalize_btn.TabIndex = 15;
            this.grafanalize_btn.Text = "Графики для анализа";
            this.grafanalize_btn.UseVisualStyleBackColor = true;
            this.grafanalize_btn.Click += new System.EventHandler(this.grafanalize_btn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 107);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.Size = new System.Drawing.Size(273, 562);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 0;
            // 
            // loadData_btn
            // 
            this.loadData_btn.Location = new System.Drawing.Point(716, 3);
            this.loadData_btn.Name = "loadData_btn";
            this.loadData_btn.Size = new System.Drawing.Size(123, 23);
            this.loadData_btn.TabIndex = 16;
            this.loadData_btn.Text = "Загрузить";
            this.loadData_btn.UseVisualStyleBackColor = true;
            this.loadData_btn.Click += new System.EventHandler(this.loadData_btn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 562);
            this.Controls.Add(this.loadData_btn);
            this.Controls.Add(this.grafanalize_btn);
            this.Controls.Add(this.timeExp_txtbox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tol2_txtbox);
            this.Controls.Add(this.tol1_txtbox);
            this.Controls.Add(this.qGO2_txtbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.startp_txtbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.path_btn);
            this.Controls.Add(this.path_txtbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kAproxy_txtbox);
            this.Controls.Add(this.normalgr_btn);
            this.Controls.Add(this.approxy_btn);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button approxy_btn;
        private System.Windows.Forms.Button normalgr_btn;
        private System.Windows.Forms.TextBox kAproxy_txtbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox path_txtbox;
        private System.Windows.Forms.Button path_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox startp_txtbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox qGO2_txtbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tol1_txtbox;
        private System.Windows.Forms.TextBox tol2_txtbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox timeExp_txtbox;
        private System.Windows.Forms.Button grafanalize_btn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button loadData_btn;
    }
}

