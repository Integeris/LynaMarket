namespace LunaMarketAdministration.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.EditNewsButton = new System.Windows.Forms.Button();
            this.editLookButton = new System.Windows.Forms.Button();
            this.editManufacturerButton = new System.Windows.Forms.Button();
            this.editCategoriesButton = new System.Windows.Forms.Button();
            this.editDeliveryButton = new System.Windows.Forms.Button();
            this.editUsersButton = new System.Windows.Forms.Button();
            this.editProductsButton = new System.Windows.Forms.Button();
            this.editOfficeAddressButton = new System.Windows.Forms.Button();
            this.editOrderStatusButton = new System.Windows.Forms.Button();
            this.editPayMethodButton = new System.Windows.Forms.Button();
            this.editPayStatusButton = new System.Windows.Forms.Button();
            this.editOrderProductButton = new System.Windows.Forms.Button();
            this.editOrderButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EditNewsButton
            // 
            this.EditNewsButton.Location = new System.Drawing.Point(30, 28);
            this.EditNewsButton.Name = "EditNewsButton";
            this.EditNewsButton.Size = new System.Drawing.Size(160, 40);
            this.EditNewsButton.TabIndex = 0;
            this.EditNewsButton.Text = "Новости";
            this.EditNewsButton.UseVisualStyleBackColor = true;
            this.EditNewsButton.Click += new System.EventHandler(this.EditNewsButtonOnClick);
            // 
            // editLookButton
            // 
            this.editLookButton.Location = new System.Drawing.Point(30, 91);
            this.editLookButton.Name = "editLookButton";
            this.editLookButton.Size = new System.Drawing.Size(160, 40);
            this.editLookButton.TabIndex = 1;
            this.editLookButton.Text = "Внешний вид";
            this.editLookButton.UseVisualStyleBackColor = true;
            this.editLookButton.Click += new System.EventHandler(this.EditLookButtonOnClick);
            // 
            // editManufacturerButton
            // 
            this.editManufacturerButton.Location = new System.Drawing.Point(220, 28);
            this.editManufacturerButton.Name = "editManufacturerButton";
            this.editManufacturerButton.Size = new System.Drawing.Size(160, 40);
            this.editManufacturerButton.TabIndex = 2;
            this.editManufacturerButton.Text = "Производитель";
            this.editManufacturerButton.UseVisualStyleBackColor = true;
            this.editManufacturerButton.Click += new System.EventHandler(this.EditManufacturerButtonOnClick);
            // 
            // editCategoriesButton
            // 
            this.editCategoriesButton.Location = new System.Drawing.Point(220, 91);
            this.editCategoriesButton.Name = "editCategoriesButton";
            this.editCategoriesButton.Size = new System.Drawing.Size(160, 40);
            this.editCategoriesButton.TabIndex = 3;
            this.editCategoriesButton.Text = "Категории";
            this.editCategoriesButton.UseVisualStyleBackColor = true;
            this.editCategoriesButton.Click += new System.EventHandler(this.EditCategoriesButtonOnClick);
            // 
            // editDeliveryButton
            // 
            this.editDeliveryButton.Location = new System.Drawing.Point(30, 156);
            this.editDeliveryButton.Name = "editDeliveryButton";
            this.editDeliveryButton.Size = new System.Drawing.Size(160, 40);
            this.editDeliveryButton.TabIndex = 4;
            this.editDeliveryButton.Text = "Доставка";
            this.editDeliveryButton.UseVisualStyleBackColor = true;
            this.editDeliveryButton.Click += new System.EventHandler(this.EditDeliveryButtonOnClick);
            // 
            // editUsersButton
            // 
            this.editUsersButton.Location = new System.Drawing.Point(220, 156);
            this.editUsersButton.Name = "editUsersButton";
            this.editUsersButton.Size = new System.Drawing.Size(160, 40);
            this.editUsersButton.TabIndex = 5;
            this.editUsersButton.Text = "Пользователи";
            this.editUsersButton.UseVisualStyleBackColor = true;
            this.editUsersButton.Click += new System.EventHandler(this.EditUsersButtonOnClick);
            // 
            // editProductsButton
            // 
            this.editProductsButton.Location = new System.Drawing.Point(30, 222);
            this.editProductsButton.Name = "editProductsButton";
            this.editProductsButton.Size = new System.Drawing.Size(160, 40);
            this.editProductsButton.TabIndex = 6;
            this.editProductsButton.Text = "Товары";
            this.editProductsButton.UseVisualStyleBackColor = true;
            this.editProductsButton.Click += new System.EventHandler(this.EditProductsButtonOnClick);
            // 
            // editOfficeAddressButton
            // 
            this.editOfficeAddressButton.Location = new System.Drawing.Point(220, 222);
            this.editOfficeAddressButton.Name = "editOfficeAddressButton";
            this.editOfficeAddressButton.Size = new System.Drawing.Size(160, 40);
            this.editOfficeAddressButton.TabIndex = 7;
            this.editOfficeAddressButton.Text = "Адреса офисов";
            this.editOfficeAddressButton.UseVisualStyleBackColor = true;
            this.editOfficeAddressButton.Click += new System.EventHandler(this.EditOfficeAddressButtonOnClick);
            // 
            // editOrderStatusButton
            // 
            this.editOrderStatusButton.Location = new System.Drawing.Point(401, 28);
            this.editOrderStatusButton.Name = "editOrderStatusButton";
            this.editOrderStatusButton.Size = new System.Drawing.Size(160, 40);
            this.editOrderStatusButton.TabIndex = 8;
            this.editOrderStatusButton.Text = "Статус заказа";
            this.editOrderStatusButton.UseVisualStyleBackColor = true;
            this.editOrderStatusButton.Click += new System.EventHandler(this.EditOrderStatusButtonOnClick);
            // 
            // editPayMethodButton
            // 
            this.editPayMethodButton.Location = new System.Drawing.Point(401, 91);
            this.editPayMethodButton.Name = "editPayMethodButton";
            this.editPayMethodButton.Size = new System.Drawing.Size(160, 40);
            this.editPayMethodButton.TabIndex = 9;
            this.editPayMethodButton.Text = "Метод оплаты";
            this.editPayMethodButton.UseVisualStyleBackColor = true;
            this.editPayMethodButton.Click += new System.EventHandler(this.EditPayMethodButtonOnClick);
            // 
            // editPayStatusButton
            // 
            this.editPayStatusButton.Location = new System.Drawing.Point(401, 156);
            this.editPayStatusButton.Name = "editPayStatusButton";
            this.editPayStatusButton.Size = new System.Drawing.Size(160, 40);
            this.editPayStatusButton.TabIndex = 10;
            this.editPayStatusButton.Text = "Статус оплаты";
            this.editPayStatusButton.UseVisualStyleBackColor = true;
            this.editPayStatusButton.Click += new System.EventHandler(this.EditPayStatusButtonOnClick);
            // 
            // editOrderProductButton
            // 
            this.editOrderProductButton.Location = new System.Drawing.Point(401, 222);
            this.editOrderProductButton.Name = "editOrderProductButton";
            this.editOrderProductButton.Size = new System.Drawing.Size(160, 40);
            this.editOrderProductButton.TabIndex = 11;
            this.editOrderProductButton.Text = "Товары в заказе";
            this.editOrderProductButton.UseVisualStyleBackColor = true;
            this.editOrderProductButton.Click += new System.EventHandler(this.EditOrderProductButtonOnClick);
            // 
            // editOrderButton
            // 
            this.editOrderButton.Location = new System.Drawing.Point(220, 282);
            this.editOrderButton.Name = "editOrderButton";
            this.editOrderButton.Size = new System.Drawing.Size(160, 40);
            this.editOrderButton.TabIndex = 12;
            this.editOrderButton.Text = "Заказы";
            this.editOrderButton.UseVisualStyleBackColor = true;
            this.editOrderButton.Click += new System.EventHandler(this.EditOrderButtonOnClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 335);
            this.Controls.Add(this.editOrderButton);
            this.Controls.Add(this.editOrderProductButton);
            this.Controls.Add(this.editPayStatusButton);
            this.Controls.Add(this.editPayMethodButton);
            this.Controls.Add(this.editOrderStatusButton);
            this.Controls.Add(this.editOfficeAddressButton);
            this.Controls.Add(this.editProductsButton);
            this.Controls.Add(this.editUsersButton);
            this.Controls.Add(this.editDeliveryButton);
            this.Controls.Add(this.editCategoriesButton);
            this.Controls.Add(this.editManufacturerButton);
            this.Controls.Add(this.editLookButton);
            this.Controls.Add(this.EditNewsButton);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(619, 374);
            this.MinimumSize = new System.Drawing.Size(619, 374);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Мебельная компания \"Луна\"";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button EditNewsButton;
        private System.Windows.Forms.Button editLookButton;
        private System.Windows.Forms.Button editManufacturerButton;
        private System.Windows.Forms.Button editCategoriesButton;
        private System.Windows.Forms.Button editDeliveryButton;
        private System.Windows.Forms.Button editUsersButton;
        private System.Windows.Forms.Button editProductsButton;
        private System.Windows.Forms.Button editOfficeAddressButton;
        private System.Windows.Forms.Button editOrderStatusButton;
        private System.Windows.Forms.Button editPayMethodButton;
        private System.Windows.Forms.Button editPayStatusButton;
        private System.Windows.Forms.Button editOrderProductButton;
        private System.Windows.Forms.Button editOrderButton;
    }
}