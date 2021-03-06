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
            this.EditNewsButton = new System.Windows.Forms.Button();
            this.editLookButton = new System.Windows.Forms.Button();
            this.editManufacturerButton = new System.Windows.Forms.Button();
            this.editCategoriesButton = new System.Windows.Forms.Button();
            this.editDeliveryButton = new System.Windows.Forms.Button();
            this.editUsersButton = new System.Windows.Forms.Button();
            this.editProductsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EditNewsButton
            // 
            this.EditNewsButton.Location = new System.Drawing.Point(30, 28);
            this.EditNewsButton.Name = "EditNewsButton";
            this.EditNewsButton.Size = new System.Drawing.Size(115, 38);
            this.EditNewsButton.TabIndex = 0;
            this.EditNewsButton.Text = "Новости";
            this.EditNewsButton.UseVisualStyleBackColor = true;
            this.EditNewsButton.Click += new System.EventHandler(this.EditNewsButtonOnClick);
            // 
            // editLookButton
            // 
            this.editLookButton.Location = new System.Drawing.Point(30, 91);
            this.editLookButton.Name = "editLookButton";
            this.editLookButton.Size = new System.Drawing.Size(115, 51);
            this.editLookButton.TabIndex = 1;
            this.editLookButton.Text = "Внешний вид";
            this.editLookButton.UseVisualStyleBackColor = true;
            this.editLookButton.Click += new System.EventHandler(this.EditLookButtonOnClick);
            // 
            // editManufacturerButton
            // 
            this.editManufacturerButton.Location = new System.Drawing.Point(187, 28);
            this.editManufacturerButton.Name = "editManufacturerButton";
            this.editManufacturerButton.Size = new System.Drawing.Size(157, 41);
            this.editManufacturerButton.TabIndex = 2;
            this.editManufacturerButton.Text = "Производитель";
            this.editManufacturerButton.UseVisualStyleBackColor = true;
            this.editManufacturerButton.Click += new System.EventHandler(this.EditManufacturerButtonOnClick);
            // 
            // editCategoriesButton
            // 
            this.editCategoriesButton.Location = new System.Drawing.Point(187, 91);
            this.editCategoriesButton.Name = "editCategoriesButton";
            this.editCategoriesButton.Size = new System.Drawing.Size(157, 51);
            this.editCategoriesButton.TabIndex = 3;
            this.editCategoriesButton.Text = "Категории";
            this.editCategoriesButton.UseVisualStyleBackColor = true;
            this.editCategoriesButton.Click += new System.EventHandler(this.EditCategoriesButtonOnClick);
            // 
            // editDeliveryButton
            // 
            this.editDeliveryButton.Location = new System.Drawing.Point(30, 166);
            this.editDeliveryButton.Name = "editDeliveryButton";
            this.editDeliveryButton.Size = new System.Drawing.Size(115, 51);
            this.editDeliveryButton.TabIndex = 4;
            this.editDeliveryButton.Text = "Доставка";
            this.editDeliveryButton.UseVisualStyleBackColor = true;
            this.editDeliveryButton.Click += new System.EventHandler(this.EditDeliveryButtonOnClick);
            // 
            // editUsersButton
            // 
            this.editUsersButton.Location = new System.Drawing.Point(187, 166);
            this.editUsersButton.Name = "editUsersButton";
            this.editUsersButton.Size = new System.Drawing.Size(157, 51);
            this.editUsersButton.TabIndex = 5;
            this.editUsersButton.Text = "Пользователи";
            this.editUsersButton.UseVisualStyleBackColor = true;
            this.editUsersButton.Click += new System.EventHandler(this.EditUsersButtonOnClick);
            // 
            // editProductsButton
            // 
            this.editProductsButton.Location = new System.Drawing.Point(30, 239);
            this.editProductsButton.Name = "editProductsButton";
            this.editProductsButton.Size = new System.Drawing.Size(115, 51);
            this.editProductsButton.TabIndex = 6;
            this.editProductsButton.Text = "Товары";
            this.editProductsButton.UseVisualStyleBackColor = true;
            this.editProductsButton.Click += new System.EventHandler(this.EditProductsButtonOnClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.editProductsButton);
            this.Controls.Add(this.editUsersButton);
            this.Controls.Add(this.editDeliveryButton);
            this.Controls.Add(this.editCategoriesButton);
            this.Controls.Add(this.editManufacturerButton);
            this.Controls.Add(this.editLookButton);
            this.Controls.Add(this.EditNewsButton);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainForm";
            this.Text = "MainForm";
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
    }
}