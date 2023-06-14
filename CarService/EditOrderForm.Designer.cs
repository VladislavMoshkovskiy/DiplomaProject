
namespace CarService
{
    partial class EditOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditOrderForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.costTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.carTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.editClientButton = new System.Windows.Forms.Button();
            this.clientTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.editClientClick = new System.Windows.Forms.PictureBox();
            this.editCarClick = new System.Windows.Forms.PictureBox();
            this.receptionOrderDate = new System.Windows.Forms.DateTimePicker();
            this.completionOrderDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editClientClick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editCarClick)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelButton.Location = new System.Drawing.Point(331, 514);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(299, 42);
            this.cancelButton.TabIndex = 38;
            this.cancelButton.Text = "Скасувати";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // costTextBox
            // 
            this.costTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.costTextBox.Location = new System.Drawing.Point(164, 455);
            this.costTextBox.Name = "costTextBox";
            this.costTextBox.Size = new System.Drawing.Size(144, 30);
            this.costTextBox.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(84, 458);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 23);
            this.label5.TabIndex = 36;
            this.label5.Text = "Вартість";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(21, 412);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 23);
            this.label4.TabIndex = 34;
            this.label4.Text = "Дата виконання";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(11, 365);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 23);
            this.label3.TabIndex = 32;
            this.label3.Text = "Дата замовлення";
            // 
            // carTextBox
            // 
            this.carTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.carTextBox.Location = new System.Drawing.Point(164, 313);
            this.carTextBox.Name = "carTextBox";
            this.carTextBox.ReadOnly = true;
            this.carTextBox.Size = new System.Drawing.Size(426, 30);
            this.carTextBox.TabIndex = 31;
            this.carTextBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(57, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 23);
            this.label2.TabIndex = 30;
            this.label2.Text = "Автомобіль";
            // 
            // editClientButton
            // 
            this.editClientButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editClientButton.Location = new System.Drawing.Point(15, 514);
            this.editClientButton.Name = "editClientButton";
            this.editClientButton.Size = new System.Drawing.Size(310, 42);
            this.editClientButton.TabIndex = 29;
            this.editClientButton.Text = "Зберегти зміни";
            this.editClientButton.UseVisualStyleBackColor = true;
            this.editClientButton.Click += new System.EventHandler(this.editClientButton_Click);
            // 
            // clientTextBox
            // 
            this.clientTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clientTextBox.Location = new System.Drawing.Point(164, 264);
            this.clientTextBox.Name = "clientTextBox";
            this.clientTextBox.ReadOnly = true;
            this.clientTextBox.Size = new System.Drawing.Size(426, 30);
            this.clientTextBox.TabIndex = 28;
            this.clientTextBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(71, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 23);
            this.label1.TabIndex = 27;
            this.label1.Text = "Замовник";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CarService.Properties.Resources.checklist;
            this.pictureBox1.Location = new System.Drawing.Point(220, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // editClientClick
            // 
            this.editClientClick.Image = global::CarService.Properties.Resources.edit;
            this.editClientClick.Location = new System.Drawing.Point(596, 264);
            this.editClientClick.Name = "editClientClick";
            this.editClientClick.Size = new System.Drawing.Size(34, 30);
            this.editClientClick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.editClientClick.TabIndex = 39;
            this.editClientClick.TabStop = false;
            this.editClientClick.Click += new System.EventHandler(this.editClientClick_Click);
            // 
            // editCarClick
            // 
            this.editCarClick.Image = global::CarService.Properties.Resources.edit;
            this.editCarClick.Location = new System.Drawing.Point(596, 313);
            this.editCarClick.Name = "editCarClick";
            this.editCarClick.Size = new System.Drawing.Size(34, 30);
            this.editCarClick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.editCarClick.TabIndex = 40;
            this.editCarClick.TabStop = false;
            this.editCarClick.Click += new System.EventHandler(this.editCarClick_Click);
            // 
            // receptionOrderDate
            // 
            this.receptionOrderDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.receptionOrderDate.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.receptionOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.receptionOrderDate.Location = new System.Drawing.Point(164, 359);
            this.receptionOrderDate.Name = "receptionOrderDate";
            this.receptionOrderDate.Size = new System.Drawing.Size(241, 30);
            this.receptionOrderDate.TabIndex = 43;
            // 
            // completionOrderDate
            // 
            this.completionOrderDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.completionOrderDate.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.completionOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.completionOrderDate.Location = new System.Drawing.Point(164, 406);
            this.completionOrderDate.Name = "completionOrderDate";
            this.completionOrderDate.Size = new System.Drawing.Size(241, 30);
            this.completionOrderDate.TabIndex = 44;
            // 
            // EditOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(640, 572);
            this.Controls.Add(this.completionOrderDate);
            this.Controls.Add(this.receptionOrderDate);
            this.Controls.Add(this.editCarClick);
            this.Controls.Add(this.editClientClick);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.costTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.carTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.editClientButton);
            this.Controls.Add(this.clientTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(658, 619);
            this.MinimumSize = new System.Drawing.Size(658, 619);
            this.Name = "EditOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редагувати запис";
            this.Activated += new System.EventHandler(this.EditOrderForm_Activated);
            this.Load += new System.EventHandler(this.EditOrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editClientClick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editCarClick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox costTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox carTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button editClientButton;
        private System.Windows.Forms.TextBox clientTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox editCarClick;
        private System.Windows.Forms.DateTimePicker receptionOrderDate;
        private System.Windows.Forms.DateTimePicker completionOrderDate;
        private System.Windows.Forms.PictureBox editClientClick;
    }
}