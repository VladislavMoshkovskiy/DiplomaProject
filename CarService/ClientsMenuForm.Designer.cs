
namespace CarService
{
    partial class ClientsMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientsMenuForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clientOrderButton = new System.Windows.Forms.Button();
            this.clientsTableButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ordersTableButton = new System.Windows.Forms.Button();
            this.createOrderButton = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clientOrderButton);
            this.groupBox1.Controls.Add(this.clientsTableButton);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 269);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Клієнти";
            // 
            // clientOrderButton
            // 
            this.clientOrderButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.clientOrderButton.FlatAppearance.BorderSize = 0;
            this.clientOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clientOrderButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clientOrderButton.ForeColor = System.Drawing.Color.White;
            this.clientOrderButton.Location = new System.Drawing.Point(134, 159);
            this.clientOrderButton.Name = "clientOrderButton";
            this.clientOrderButton.Size = new System.Drawing.Size(310, 85);
            this.clientOrderButton.TabIndex = 3;
            this.clientOrderButton.Text = "Замовлення конкретного клієнта";
            this.clientOrderButton.UseVisualStyleBackColor = false;
            this.clientOrderButton.Click += new System.EventHandler(this.clientOrderButton_Click);
            // 
            // clientsTableButton
            // 
            this.clientsTableButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.clientsTableButton.FlatAppearance.BorderSize = 0;
            this.clientsTableButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clientsTableButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clientsTableButton.ForeColor = System.Drawing.Color.White;
            this.clientsTableButton.Location = new System.Drawing.Point(134, 43);
            this.clientsTableButton.Name = "clientsTableButton";
            this.clientsTableButton.Size = new System.Drawing.Size(310, 85);
            this.clientsTableButton.TabIndex = 2;
            this.clientsTableButton.Text = "Довідник клієнтів";
            this.clientsTableButton.UseVisualStyleBackColor = false;
            this.clientsTableButton.Click += new System.EventHandler(this.clientsTableButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CarService.Properties.Resources.order;
            this.pictureBox2.Location = new System.Drawing.Point(18, 159);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(85, 85);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CarService.Properties.Resources.client;
            this.pictureBox1.Location = new System.Drawing.Point(18, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ordersTableButton);
            this.groupBox2.Controls.Add(this.createOrderButton);
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Controls.Add(this.pictureBox4);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox2.Location = new System.Drawing.Point(14, 287);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(462, 269);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Замовлення";
            // 
            // ordersTableButton
            // 
            this.ordersTableButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.ordersTableButton.FlatAppearance.BorderSize = 0;
            this.ordersTableButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ordersTableButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ordersTableButton.ForeColor = System.Drawing.Color.White;
            this.ordersTableButton.Location = new System.Drawing.Point(134, 159);
            this.ordersTableButton.Name = "ordersTableButton";
            this.ordersTableButton.Size = new System.Drawing.Size(310, 85);
            this.ordersTableButton.TabIndex = 3;
            this.ordersTableButton.Text = "Довідник замовлень";
            this.ordersTableButton.UseVisualStyleBackColor = false;
            this.ordersTableButton.Click += new System.EventHandler(this.ordersTableButton_Click);
            // 
            // createOrderButton
            // 
            this.createOrderButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.createOrderButton.FlatAppearance.BorderSize = 0;
            this.createOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createOrderButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createOrderButton.ForeColor = System.Drawing.Color.White;
            this.createOrderButton.Location = new System.Drawing.Point(134, 43);
            this.createOrderButton.Name = "createOrderButton";
            this.createOrderButton.Size = new System.Drawing.Size(310, 85);
            this.createOrderButton.TabIndex = 2;
            this.createOrderButton.Text = "Оформити замовлення";
            this.createOrderButton.UseVisualStyleBackColor = false;
            this.createOrderButton.Click += new System.EventHandler(this.createOrderButton_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CarService.Properties.Resources.storage;
            this.pictureBox3.Location = new System.Drawing.Point(18, 159);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(85, 85);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::CarService.Properties.Resources.checklist;
            this.pictureBox4.Location = new System.Drawing.Point(18, 43);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(85, 85);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // ClientsMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(491, 571);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(509, 618);
            this.MinimumSize = new System.Drawing.Size(509, 618);
            this.Name = "ClientsMenuForm";
            this.Text = "Робота з клієнтами";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button clientOrderButton;
        private System.Windows.Forms.Button clientsTableButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ordersTableButton;
        private System.Windows.Forms.Button createOrderButton;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}