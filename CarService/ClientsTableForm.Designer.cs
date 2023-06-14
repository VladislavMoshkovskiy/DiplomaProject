
namespace CarService
{
    partial class ClientsTableForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientsTableForm));
            this.clientsDataGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.друкуватиЗвітToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вихідЗПрограмиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.додатиЗаписToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.видалилиЗаписToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редагуватиЗаписToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.інструкціяКористувачаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проПрограмуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.addRecordButton = new System.Windows.Forms.ToolStripButton();
            this.deleteRecordButton = new System.Windows.Forms.ToolStripButton();
            this.editRecordButton = new System.Windows.Forms.ToolStripButton();
            this.printReportButton = new System.Windows.Forms.ToolStripButton();
            this.refreshButton = new System.Windows.Forms.ToolStripButton();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.surnameSearchRadioButton = new System.Windows.Forms.RadioButton();
            this.passportSearchRadioButton = new System.Windows.Forms.RadioButton();
            this.phoneSearchRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.clientsDataGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clientsDataGridView
            // 
            this.clientsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clientsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.clientsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.clientsDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.clientsDataGridView.Location = new System.Drawing.Point(12, 117);
            this.clientsDataGridView.Name = "clientsDataGridView";
            this.clientsDataGridView.ReadOnly = true;
            this.clientsDataGridView.RowHeadersWidth = 51;
            this.clientsDataGridView.RowTemplate.Height = 24;
            this.clientsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.clientsDataGridView.Size = new System.Drawing.Size(1201, 473);
            this.clientsDataGridView.TabIndex = 4;
            this.clientsDataGridView.SelectionChanged += new System.EventHandler(this.clientsDataGridView_SelectionChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1225, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.друкуватиЗвітToolStripMenuItem,
            this.вихідЗПрограмиToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(59, 24);
            this.toolStripDropDownButton1.Text = "Файл";
            // 
            // друкуватиЗвітToolStripMenuItem
            // 
            this.друкуватиЗвітToolStripMenuItem.Name = "друкуватиЗвітToolStripMenuItem";
            this.друкуватиЗвітToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.друкуватиЗвітToolStripMenuItem.Text = "Друкувати звіт";
            this.друкуватиЗвітToolStripMenuItem.Click += new System.EventHandler(this.друкуватиЗвітToolStripMenuItem_Click);
            // 
            // вихідЗПрограмиToolStripMenuItem
            // 
            this.вихідЗПрограмиToolStripMenuItem.Name = "вихідЗПрограмиToolStripMenuItem";
            this.вихідЗПрограмиToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.вихідЗПрограмиToolStripMenuItem.Text = "Вихід з програми";
            this.вихідЗПрограмиToolStripMenuItem.Click += new System.EventHandler(this.вихідЗПрограмиToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.додатиЗаписToolStripMenuItem1,
            this.видалилиЗаписToolStripMenuItem,
            this.редагуватиЗаписToolStripMenuItem1});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(110, 24);
            this.toolStripDropDownButton2.Text = "Редагування";
            // 
            // додатиЗаписToolStripMenuItem1
            // 
            this.додатиЗаписToolStripMenuItem1.Name = "додатиЗаписToolStripMenuItem1";
            this.додатиЗаписToolStripMenuItem1.Size = new System.Drawing.Size(212, 26);
            this.додатиЗаписToolStripMenuItem1.Text = "Додати запис";
            this.додатиЗаписToolStripMenuItem1.Click += new System.EventHandler(this.додатиЗаписToolStripMenuItem1_Click);
            // 
            // видалилиЗаписToolStripMenuItem
            // 
            this.видалилиЗаписToolStripMenuItem.Name = "видалилиЗаписToolStripMenuItem";
            this.видалилиЗаписToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.видалилиЗаписToolStripMenuItem.Text = "Видалити запис";
            this.видалилиЗаписToolStripMenuItem.Click += new System.EventHandler(this.видалилиЗаписToolStripMenuItem_Click);
            // 
            // редагуватиЗаписToolStripMenuItem1
            // 
            this.редагуватиЗаписToolStripMenuItem1.Name = "редагуватиЗаписToolStripMenuItem1";
            this.редагуватиЗаписToolStripMenuItem1.Size = new System.Drawing.Size(212, 26);
            this.редагуватиЗаписToolStripMenuItem1.Text = "Редагувати запис";
            this.редагуватиЗаписToolStripMenuItem1.Click += new System.EventHandler(this.редагуватиЗаписToolStripMenuItem1_Click);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.інструкціяКористувачаToolStripMenuItem,
            this.проПрограмуToolStripMenuItem});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(77, 24);
            this.toolStripDropDownButton3.Text = "Довідка";
            // 
            // інструкціяКористувачаToolStripMenuItem
            // 
            this.інструкціяКористувачаToolStripMenuItem.Name = "інструкціяКористувачаToolStripMenuItem";
            this.інструкціяКористувачаToolStripMenuItem.Size = new System.Drawing.Size(252, 26);
            this.інструкціяКористувачаToolStripMenuItem.Text = "Інструкція користувача";
            // 
            // проПрограмуToolStripMenuItem
            // 
            this.проПрограмуToolStripMenuItem.Name = "проПрограмуToolStripMenuItem";
            this.проПрограмуToolStripMenuItem.Size = new System.Drawing.Size(252, 26);
            this.проПрограмуToolStripMenuItem.Text = "Про програму";
            this.проПрограмуToolStripMenuItem.Click += new System.EventHandler(this.проПрограмуToolStripMenuItem_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Положение";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.CountItemFormat = "of {0}";
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.addRecordButton,
            this.deleteRecordButton,
            this.editRecordButton,
            this.printReportButton,
            this.refreshButton});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 27);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.bindingNavigator1.Size = new System.Drawing.Size(1225, 27);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Переместить в начало";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Переместить назад";
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
            // 
            // addRecordButton
            // 
            this.addRecordButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addRecordButton.Image = ((System.Drawing.Image)(resources.GetObject("addRecordButton.Image")));
            this.addRecordButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addRecordButton.Name = "addRecordButton";
            this.addRecordButton.Size = new System.Drawing.Size(107, 24);
            this.addRecordButton.Text = "Додати запис";
            this.addRecordButton.Click += new System.EventHandler(this.addRecordButton_Click);
            // 
            // deleteRecordButton
            // 
            this.deleteRecordButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deleteRecordButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteRecordButton.Image")));
            this.deleteRecordButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteRecordButton.Name = "deleteRecordButton";
            this.deleteRecordButton.Size = new System.Drawing.Size(123, 24);
            this.deleteRecordButton.Text = "Видалити запис";
            this.deleteRecordButton.Click += new System.EventHandler(this.deleteRecordButton_Click);
            // 
            // editRecordButton
            // 
            this.editRecordButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.editRecordButton.Image = ((System.Drawing.Image)(resources.GetObject("editRecordButton.Image")));
            this.editRecordButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editRecordButton.Name = "editRecordButton";
            this.editRecordButton.Size = new System.Drawing.Size(133, 24);
            this.editRecordButton.Text = "Редагувати запис";
            this.editRecordButton.Click += new System.EventHandler(this.editRecordButton_Click);
            // 
            // printReportButton
            // 
            this.printReportButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.printReportButton.Image = ((System.Drawing.Image)(resources.GetObject("printReportButton.Image")));
            this.printReportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printReportButton.Name = "printReportButton";
            this.printReportButton.Size = new System.Drawing.Size(84, 24);
            this.printReportButton.Text = "Друкувати";
            this.printReportButton.Click += new System.EventHandler(this.printReportButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.refreshButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshButton.Image")));
            this.refreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(74, 24);
            this.refreshButton.Text = "Оновити";
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchTextBox.Location = new System.Drawing.Point(76, 13);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(593, 30);
            this.searchTextBox.TabIndex = 0;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Пошук:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.phoneSearchRadioButton);
            this.panel1.Controls.Add(this.passportSearchRadioButton);
            this.panel1.Controls.Add(this.surnameSearchRadioButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.searchTextBox);
            this.panel1.Location = new System.Drawing.Point(0, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1225, 56);
            this.panel1.TabIndex = 2;
            // 
            // surnameSearchRadioButton
            // 
            this.surnameSearchRadioButton.AutoSize = true;
            this.surnameSearchRadioButton.Checked = true;
            this.surnameSearchRadioButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.surnameSearchRadioButton.Location = new System.Drawing.Point(692, 16);
            this.surnameSearchRadioButton.Name = "surnameSearchRadioButton";
            this.surnameSearchRadioButton.Size = new System.Drawing.Size(119, 24);
            this.surnameSearchRadioButton.TabIndex = 5;
            this.surnameSearchRadioButton.TabStop = true;
            this.surnameSearchRadioButton.Text = "По прізвищу";
            this.surnameSearchRadioButton.UseVisualStyleBackColor = true;
            // 
            // passportSearchRadioButton
            // 
            this.passportSearchRadioButton.AutoSize = true;
            this.passportSearchRadioButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.passportSearchRadioButton.Location = new System.Drawing.Point(833, 16);
            this.passportSearchRadioButton.Name = "passportSearchRadioButton";
            this.passportSearchRadioButton.Size = new System.Drawing.Size(176, 24);
            this.passportSearchRadioButton.TabIndex = 6;
            this.passportSearchRadioButton.Text = "По номеру паспорта";
            this.passportSearchRadioButton.UseVisualStyleBackColor = true;
            // 
            // phoneSearchRadioButton
            // 
            this.phoneSearchRadioButton.AutoSize = true;
            this.phoneSearchRadioButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.phoneSearchRadioButton.Location = new System.Drawing.Point(1036, 16);
            this.phoneSearchRadioButton.Name = "phoneSearchRadioButton";
            this.phoneSearchRadioButton.Size = new System.Drawing.Size(177, 24);
            this.phoneSearchRadioButton.TabIndex = 7;
            this.phoneSearchRadioButton.Text = "По номеру телефона";
            this.phoneSearchRadioButton.UseVisualStyleBackColor = true;
            // 
            // ClientsTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1225, 608);
            this.Controls.Add(this.clientsDataGridView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientsTableForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Довідник клієнтів";
            this.Activated += new System.EventHandler(this.ClientsTableForm_Activated);
            this.Load += new System.EventHandler(this.ClientsTableForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientsDataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView clientsDataGridView;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem друкуватиЗвітToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вихідЗПрограмиToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem видалилиЗаписToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редагуватиЗаписToolStripMenuItem1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem інструкціяКористувачаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проПрограмуToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton addRecordButton;
        private System.Windows.Forms.ToolStripButton deleteRecordButton;
        private System.Windows.Forms.ToolStripButton editRecordButton;
        private System.Windows.Forms.ToolStripButton printReportButton;
        private System.Windows.Forms.ToolStripButton refreshButton;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem додатиЗаписToolStripMenuItem1;
        private System.Windows.Forms.RadioButton surnameSearchRadioButton;
        private System.Windows.Forms.RadioButton passportSearchRadioButton;
        private System.Windows.Forms.RadioButton phoneSearchRadioButton;
    }
}