namespace LunaMarketAdministration.Forms
{
    partial class OrderProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderProductForm));
            this.productDGV = new System.Windows.Forms.DataGridView();
            this.IdOrderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdProductColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idOrderLabel = new System.Windows.Forms.Label();
            this.selectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.actionComboBox = new System.Windows.Forms.ComboBox();
            this.selectProductButton = new System.Windows.Forms.Button();
            this.productTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.actionOrderProductButton = new System.Windows.Forms.Button();
            this.updateProductButton = new System.Windows.Forms.Button();
            this.amountNUD = new System.Windows.Forms.NumericUpDown();
            this.priceNUD = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.productDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // productDGV
            // 
            this.productDGV.AllowUserToAddRows = false;
            this.productDGV.AllowUserToDeleteRows = false;
            this.productDGV.BackgroundColor = System.Drawing.Color.White;
            this.productDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdOrderColumn,
            this.IdProductColumn,
            this.PriceColumn,
            this.AmountColumn});
            this.productDGV.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.productDGV.Location = new System.Drawing.Point(0, 327);
            this.productDGV.Name = "productDGV";
            this.productDGV.ReadOnly = true;
            this.productDGV.Size = new System.Drawing.Size(591, 174);
            this.productDGV.TabIndex = 0;
            // 
            // IdOrderColumn
            // 
            this.IdOrderColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IdOrderColumn.DataPropertyName = "IdOrder";
            this.IdOrderColumn.HeaderText = "Код заказа";
            this.IdOrderColumn.Name = "IdOrderColumn";
            this.IdOrderColumn.ReadOnly = true;
            this.IdOrderColumn.Width = 134;
            // 
            // IdProductColumn
            // 
            this.IdProductColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IdProductColumn.DataPropertyName = "IdProduct";
            this.IdProductColumn.HeaderText = "Код товара";
            this.IdProductColumn.Name = "IdProductColumn";
            this.IdProductColumn.ReadOnly = true;
            this.IdProductColumn.Width = 138;
            // 
            // PriceColumn
            // 
            this.PriceColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PriceColumn.DataPropertyName = "Price";
            this.PriceColumn.HeaderText = "Стоимость";
            this.PriceColumn.Name = "PriceColumn";
            this.PriceColumn.ReadOnly = true;
            this.PriceColumn.Width = 135;
            // 
            // AmountColumn
            // 
            this.AmountColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.AmountColumn.DataPropertyName = "Amount";
            this.AmountColumn.HeaderText = "Количество";
            this.AmountColumn.Name = "AmountColumn";
            this.AmountColumn.ReadOnly = true;
            this.AmountColumn.Width = 142;
            // 
            // idOrderLabel
            // 
            this.idOrderLabel.AutoSize = true;
            this.idOrderLabel.Location = new System.Drawing.Point(41, 115);
            this.idOrderLabel.Name = "idOrderLabel";
            this.idOrderLabel.Size = new System.Drawing.Size(120, 24);
            this.idOrderLabel.TabIndex = 36;
            this.idOrderLabel.Text = "idOrderLabel";
            this.idOrderLabel.Visible = false;
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(227, 43);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(184, 30);
            this.selectButton.TabIndex = 35;
            this.selectButton.Text = "Выбрать заказ";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.SelectButtonOnClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 24);
            this.label1.TabIndex = 34;
            this.label1.Text = "Выберите действие";
            // 
            // actionComboBox
            // 
            this.actionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionComboBox.FormattingEnabled = true;
            this.actionComboBox.Items.AddRange(new object[] {
            "Добавление",
            "Изменение",
            "Удаление"});
            this.actionComboBox.Location = new System.Drawing.Point(12, 41);
            this.actionComboBox.Name = "actionComboBox";
            this.actionComboBox.Size = new System.Drawing.Size(185, 32);
            this.actionComboBox.TabIndex = 33;
            this.actionComboBox.SelectedIndexChanged += new System.EventHandler(this.ActionComboBoxOnSelectedIndexChanged);
            // 
            // selectProductButton
            // 
            this.selectProductButton.Location = new System.Drawing.Point(12, 291);
            this.selectProductButton.Name = "selectProductButton";
            this.selectProductButton.Size = new System.Drawing.Size(185, 30);
            this.selectProductButton.TabIndex = 37;
            this.selectProductButton.Text = "Выбрать товар";
            this.selectProductButton.UseVisualStyleBackColor = true;
            this.selectProductButton.Click += new System.EventHandler(this.SelectProductButtonOnClick);
            // 
            // productTextBox
            // 
            this.productTextBox.Location = new System.Drawing.Point(317, 115);
            this.productTextBox.Name = "productTextBox";
            this.productTextBox.ReadOnly = true;
            this.productTextBox.Size = new System.Drawing.Size(217, 29);
            this.productTextBox.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 24);
            this.label2.TabIndex = 42;
            this.label2.Text = "Товар";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 24);
            this.label3.TabIndex = 43;
            this.label3.Text = "Общая стоимость";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(364, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 24);
            this.label4.TabIndex = 44;
            this.label4.Text = "Количество";
            // 
            // actionOrderProductButton
            // 
            this.actionOrderProductButton.Location = new System.Drawing.Point(404, 291);
            this.actionOrderProductButton.Name = "actionOrderProductButton";
            this.actionOrderProductButton.Size = new System.Drawing.Size(130, 30);
            this.actionOrderProductButton.TabIndex = 48;
            this.actionOrderProductButton.UseVisualStyleBackColor = true;
            this.actionOrderProductButton.Click += new System.EventHandler(this.ActionOrderProductButtonOnClick);
            // 
            // updateProductButton
            // 
            this.updateProductButton.Location = new System.Drawing.Point(337, 150);
            this.updateProductButton.Name = "updateProductButton";
            this.updateProductButton.Size = new System.Drawing.Size(185, 30);
            this.updateProductButton.TabIndex = 49;
            this.updateProductButton.Text = "Выбрать товар";
            this.updateProductButton.UseVisualStyleBackColor = true;
            this.updateProductButton.Click += new System.EventHandler(this.UpdateProductButtonOnClick);
            // 
            // amountNUD
            // 
            this.amountNUD.Location = new System.Drawing.Point(317, 223);
            this.amountNUD.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.amountNUD.Name = "amountNUD";
            this.amountNUD.Size = new System.Drawing.Size(217, 29);
            this.amountNUD.TabIndex = 51;
            // 
            // priceNUD
            // 
            this.priceNUD.Location = new System.Drawing.Point(25, 223);
            this.priceNUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.priceNUD.Name = "priceNUD";
            this.priceNUD.Size = new System.Drawing.Size(217, 29);
            this.priceNUD.TabIndex = 52;
            // 
            // OrderProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(591, 501);
            this.Controls.Add(this.priceNUD);
            this.Controls.Add(this.amountNUD);
            this.Controls.Add(this.updateProductButton);
            this.Controls.Add(this.actionOrderProductButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.productTextBox);
            this.Controls.Add(this.selectProductButton);
            this.Controls.Add(this.idOrderLabel);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.actionComboBox);
            this.Controls.Add(this.productDGV);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "OrderProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Заказанные товары";
            this.Load += new System.EventHandler(this.OrderProductFormOnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.productDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView productDGV;
        private System.Windows.Forms.Label idOrderLabel;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox actionComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdOrderColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProductColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountColumn;
        private System.Windows.Forms.Button selectProductButton;
        private System.Windows.Forms.TextBox productTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button actionOrderProductButton;
        private System.Windows.Forms.Button updateProductButton;
        private System.Windows.Forms.NumericUpDown amountNUD;
        private System.Windows.Forms.NumericUpDown priceNUD;
    }
}