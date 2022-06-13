namespace LunaMarketAdministration.Forms
{
    partial class OrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderForm));
            this.selectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.actionOrderComboBox = new System.Windows.Forms.ComboBox();
            this.idOrderLabel = new System.Windows.Forms.Label();
            this.customerTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.orderStatusTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.payMethodTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.payStatusTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.deliveryTypeTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.actionOrderButton = new System.Windows.Forms.Button();
            this.selectCustomerButton = new System.Windows.Forms.Button();
            this.selectOrderStatusButton = new System.Windows.Forms.Button();
            this.selectPayMethodButton = new System.Windows.Forms.Button();
            this.selectDeliveryButton = new System.Windows.Forms.Button();
            this.selectPayStatusButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(35, 88);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(130, 30);
            this.selectButton.TabIndex = 31;
            this.selectButton.Text = "Выбрать";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.SelectButtonOnClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 24);
            this.label1.TabIndex = 30;
            this.label1.Text = "Выберите действие";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // actionOrderComboBox
            // 
            this.actionOrderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionOrderComboBox.FormattingEnabled = true;
            this.actionOrderComboBox.Items.AddRange(new object[] {
            "Добавление",
            "Изменение",
            "Удаление"});
            this.actionOrderComboBox.Location = new System.Drawing.Point(19, 36);
            this.actionOrderComboBox.Name = "actionOrderComboBox";
            this.actionOrderComboBox.Size = new System.Drawing.Size(185, 32);
            this.actionOrderComboBox.TabIndex = 29;
            this.actionOrderComboBox.SelectedIndexChanged += new System.EventHandler(this.ActionOrderComboBoxOnSelectedIndexChanged);
            // 
            // idOrderLabel
            // 
            this.idOrderLabel.AutoSize = true;
            this.idOrderLabel.Location = new System.Drawing.Point(333, 64);
            this.idOrderLabel.Name = "idOrderLabel";
            this.idOrderLabel.Size = new System.Drawing.Size(120, 24);
            this.idOrderLabel.TabIndex = 32;
            this.idOrderLabel.Text = "idOrderLabel";
            this.idOrderLabel.Click += new System.EventHandler(this.idOrderLabel_Click);
            // 
            // customerTextBox
            // 
            this.customerTextBox.Location = new System.Drawing.Point(19, 161);
            this.customerTextBox.Name = "customerTextBox";
            this.customerTextBox.ReadOnly = true;
            this.customerTextBox.Size = new System.Drawing.Size(228, 29);
            this.customerTextBox.TabIndex = 33;
            this.customerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 24);
            this.label2.TabIndex = 34;
            this.label2.Text = "Код заказчика";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(327, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 24);
            this.label3.TabIndex = 36;
            this.label3.Text = "Статус заказа";
            // 
            // orderStatusTextBox
            // 
            this.orderStatusTextBox.Location = new System.Drawing.Point(285, 161);
            this.orderStatusTextBox.Name = "orderStatusTextBox";
            this.orderStatusTextBox.ReadOnly = true;
            this.orderStatusTextBox.Size = new System.Drawing.Size(228, 29);
            this.orderStatusTextBox.TabIndex = 35;
            this.orderStatusTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(591, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 24);
            this.label4.TabIndex = 38;
            this.label4.Text = "Метод оплаты";
            // 
            // payMethodTextBox
            // 
            this.payMethodTextBox.Location = new System.Drawing.Point(549, 161);
            this.payMethodTextBox.Name = "payMethodTextBox";
            this.payMethodTextBox.ReadOnly = true;
            this.payMethodTextBox.Size = new System.Drawing.Size(228, 29);
            this.payMethodTextBox.TabIndex = 37;
            this.payMethodTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 24);
            this.label5.TabIndex = 40;
            this.label5.Text = "Статус оплаты";
            // 
            // payStatusTextBox
            // 
            this.payStatusTextBox.Location = new System.Drawing.Point(12, 291);
            this.payStatusTextBox.Name = "payStatusTextBox";
            this.payStatusTextBox.ReadOnly = true;
            this.payStatusTextBox.Size = new System.Drawing.Size(235, 29);
            this.payStatusTextBox.TabIndex = 39;
            this.payStatusTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(319, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 24);
            this.label6.TabIndex = 42;
            this.label6.Text = "Способ доставки";
            // 
            // deliveryTypeTextBox
            // 
            this.deliveryTypeTextBox.Location = new System.Drawing.Point(283, 291);
            this.deliveryTypeTextBox.Name = "deliveryTypeTextBox";
            this.deliveryTypeTextBox.ReadOnly = true;
            this.deliveryTypeTextBox.Size = new System.Drawing.Size(228, 29);
            this.deliveryTypeTextBox.TabIndex = 41;
            this.deliveryTypeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(597, 264);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 24);
            this.label7.TabIndex = 44;
            this.label7.Text = "Дата заказа";
            // 
            // dateTextBox
            // 
            this.dateTextBox.Location = new System.Drawing.Point(549, 291);
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.ReadOnly = true;
            this.dateTextBox.Size = new System.Drawing.Size(228, 29);
            this.dateTextBox.TabIndex = 43;
            this.dateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 369);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 24);
            this.label8.TabIndex = 46;
            this.label8.Text = "Адрес доставки";
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(19, 396);
            this.addressTextBox.Multiline = true;
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(494, 128);
            this.addressTextBox.TabIndex = 45;
            // 
            // actionOrderButton
            // 
            this.actionOrderButton.Location = new System.Drawing.Point(601, 452);
            this.actionOrderButton.Name = "actionOrderButton";
            this.actionOrderButton.Size = new System.Drawing.Size(130, 30);
            this.actionOrderButton.TabIndex = 47;
            this.actionOrderButton.UseVisualStyleBackColor = true;
            this.actionOrderButton.Click += new System.EventHandler(this.ActionOrderButtonOnClick);
            // 
            // selectCustomerButton
            // 
            this.selectCustomerButton.Location = new System.Drawing.Point(19, 196);
            this.selectCustomerButton.Name = "selectCustomerButton";
            this.selectCustomerButton.Size = new System.Drawing.Size(228, 30);
            this.selectCustomerButton.TabIndex = 48;
            this.selectCustomerButton.Text = "Выбрать заказчика";
            this.selectCustomerButton.UseVisualStyleBackColor = true;
            this.selectCustomerButton.Click += new System.EventHandler(this.SelectCustomerButtonOnClick);
            // 
            // selectOrderStatusButton
            // 
            this.selectOrderStatusButton.Location = new System.Drawing.Point(285, 196);
            this.selectOrderStatusButton.Name = "selectOrderStatusButton";
            this.selectOrderStatusButton.Size = new System.Drawing.Size(228, 30);
            this.selectOrderStatusButton.TabIndex = 49;
            this.selectOrderStatusButton.Text = "Выбрать статус заказа";
            this.selectOrderStatusButton.UseVisualStyleBackColor = true;
            this.selectOrderStatusButton.Click += new System.EventHandler(this.SelectOrderStatusButtonOnClick);
            // 
            // selectPayMethodButton
            // 
            this.selectPayMethodButton.Location = new System.Drawing.Point(549, 196);
            this.selectPayMethodButton.Name = "selectPayMethodButton";
            this.selectPayMethodButton.Size = new System.Drawing.Size(228, 30);
            this.selectPayMethodButton.TabIndex = 50;
            this.selectPayMethodButton.Text = "Выбрать метод оплаты";
            this.selectPayMethodButton.UseVisualStyleBackColor = true;
            this.selectPayMethodButton.Click += new System.EventHandler(this.SelectPayMethodButtonOnClick);
            // 
            // selectDeliveryButton
            // 
            this.selectDeliveryButton.Location = new System.Drawing.Point(285, 326);
            this.selectDeliveryButton.Name = "selectDeliveryButton";
            this.selectDeliveryButton.Size = new System.Drawing.Size(226, 30);
            this.selectDeliveryButton.TabIndex = 51;
            this.selectDeliveryButton.Text = "Выбрать доставку";
            this.selectDeliveryButton.UseVisualStyleBackColor = true;
            this.selectDeliveryButton.Click += new System.EventHandler(this.SelectDeliveryButtonOnClick);
            // 
            // selectPayStatusButton
            // 
            this.selectPayStatusButton.Location = new System.Drawing.Point(12, 326);
            this.selectPayStatusButton.Name = "selectPayStatusButton";
            this.selectPayStatusButton.Size = new System.Drawing.Size(235, 30);
            this.selectPayStatusButton.TabIndex = 53;
            this.selectPayStatusButton.Text = "Выбрать статус оплаты";
            this.selectPayStatusButton.UseVisualStyleBackColor = true;
            this.selectPayStatusButton.Click += new System.EventHandler(this.SelectPayStatusButtonOnClick);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 537);
            this.Controls.Add(this.selectPayStatusButton);
            this.Controls.Add(this.selectDeliveryButton);
            this.Controls.Add(this.selectPayMethodButton);
            this.Controls.Add(this.selectOrderStatusButton);
            this.Controls.Add(this.selectCustomerButton);
            this.Controls.Add(this.actionOrderButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.deliveryTypeTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.payStatusTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.payMethodTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.orderStatusTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.customerTextBox);
            this.Controls.Add(this.idOrderLabel);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.actionOrderComboBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(820, 576);
            this.MinimumSize = new System.Drawing.Size(820, 576);
            this.Name = "OrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Заказы";
            this.Load += new System.EventHandler(this.OrderFormOnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox actionOrderComboBox;
        private System.Windows.Forms.Label idOrderLabel;
        private System.Windows.Forms.TextBox customerTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox orderStatusTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox payMethodTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox payStatusTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox deliveryTypeTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox dateTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Button actionOrderButton;
        private System.Windows.Forms.Button selectCustomerButton;
        private System.Windows.Forms.Button selectOrderStatusButton;
        private System.Windows.Forms.Button selectPayMethodButton;
        private System.Windows.Forms.Button selectDeliveryButton;
        private System.Windows.Forms.Button selectPayStatusButton;
    }
}