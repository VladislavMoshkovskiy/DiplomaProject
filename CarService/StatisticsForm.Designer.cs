
namespace CarService
{
    partial class StatisticsForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsForm));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.allTimeRadioButton = new System.Windows.Forms.RadioButton();
            this.monthRadioButton = new System.Windows.Forms.RadioButton();
            this.printButton = new System.Windows.Forms.Button();
            this.yearRadioButton = new System.Windows.Forms.RadioButton();
            this.weekRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Вартість замовлень";
            series1.YValuesPerPoint = 4;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1136, 713);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            title1.Name = "Графік вартості замовлень";
            this.chart1.Titles.Add(title1);
            // 
            // allTimeRadioButton
            // 
            this.allTimeRadioButton.AutoSize = true;
            this.allTimeRadioButton.Checked = true;
            this.allTimeRadioButton.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.allTimeRadioButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.allTimeRadioButton.Location = new System.Drawing.Point(1156, 91);
            this.allTimeRadioButton.Name = "allTimeRadioButton";
            this.allTimeRadioButton.Size = new System.Drawing.Size(139, 28);
            this.allTimeRadioButton.TabIndex = 2;
            this.allTimeRadioButton.TabStop = true;
            this.allTimeRadioButton.Text = "За весь час";
            this.allTimeRadioButton.UseVisualStyleBackColor = true;
            this.allTimeRadioButton.CheckedChanged += new System.EventHandler(this.allTimeRadioButton_CheckedChanged);
            // 
            // monthRadioButton
            // 
            this.monthRadioButton.AutoSize = true;
            this.monthRadioButton.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.monthRadioButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.monthRadioButton.Location = new System.Drawing.Point(1156, 185);
            this.monthRadioButton.Name = "monthRadioButton";
            this.monthRadioButton.Size = new System.Drawing.Size(215, 28);
            this.monthRadioButton.TabIndex = 3;
            this.monthRadioButton.Text = "За поточний місяць";
            this.monthRadioButton.UseVisualStyleBackColor = true;
            this.monthRadioButton.CheckedChanged += new System.EventHandler(this.monthRadioButton_CheckedChanged);
            // 
            // printButton
            // 
            this.printButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.printButton.FlatAppearance.BorderSize = 0;
            this.printButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.printButton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.printButton.ForeColor = System.Drawing.Color.White;
            this.printButton.Location = new System.Drawing.Point(1156, 301);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(236, 54);
            this.printButton.TabIndex = 4;
            this.printButton.Text = "Друкувати графік";
            this.printButton.UseVisualStyleBackColor = false;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // yearRadioButton
            // 
            this.yearRadioButton.AutoSize = true;
            this.yearRadioButton.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yearRadioButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.yearRadioButton.Location = new System.Drawing.Point(1156, 138);
            this.yearRadioButton.Name = "yearRadioButton";
            this.yearRadioButton.Size = new System.Drawing.Size(178, 28);
            this.yearRadioButton.TabIndex = 5;
            this.yearRadioButton.Text = "За поточний рік";
            this.yearRadioButton.UseVisualStyleBackColor = true;
            // 
            // weekRadioButton
            // 
            this.weekRadioButton.AutoSize = true;
            this.weekRadioButton.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.weekRadioButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.weekRadioButton.Location = new System.Drawing.Point(1157, 233);
            this.weekRadioButton.Name = "weekRadioButton";
            this.weekRadioButton.Size = new System.Drawing.Size(235, 28);
            this.weekRadioButton.TabIndex = 6;
            this.weekRadioButton.Text = "За поточний тиждень";
            this.weekRadioButton.UseVisualStyleBackColor = true;
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1409, 737);
            this.Controls.Add(this.weekRadioButton);
            this.Controls.Add(this.yearRadioButton);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.monthRadioButton);
            this.Controls.Add(this.allTimeRadioButton);
            this.Controls.Add(this.chart1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1427, 784);
            this.MinimumSize = new System.Drawing.Size(1427, 784);
            this.Name = "StatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Аналіз діяльності";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.RadioButton allTimeRadioButton;
        private System.Windows.Forms.RadioButton monthRadioButton;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.RadioButton yearRadioButton;
        private System.Windows.Forms.RadioButton weekRadioButton;
    }
}