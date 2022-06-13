namespace LunaMarketAdministration.Forms
{
    partial class DeliveryForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.deliveryTextBox = new System.Windows.Forms.TextBox();
            this.actionDeliveryButton = new System.Windows.Forms.Button();
            this.actionDeliveryComboBox = new System.Windows.Forms.ComboBox();
            this.selectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Название";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Выберите действие";
            // 
            // deliveryTextBox
            // 
            this.deliveryTextBox.Location = new System.Drawing.Point(12, 136);
            this.deliveryTextBox.Name = "deliveryTextBox";
            this.deliveryTextBox.Size = new System.Drawing.Size(166, 29);
            this.deliveryTextBox.TabIndex = 7;
            // 
            // actionDeliveryButton
            // 
            this.actionDeliveryButton.Location = new System.Drawing.Point(28, 181);
            this.actionDeliveryButton.Name = "actionDeliveryButton";
            this.actionDeliveryButton.Size = new System.Drawing.Size(130, 30);
            this.actionDeliveryButton.TabIndex = 6;
            this.actionDeliveryButton.UseVisualStyleBackColor = true;
            this.actionDeliveryButton.Click += new System.EventHandler(this.ActionDeliveryButtonOnClick);
            // 
            // actionDeliveryComboBox
            // 
            this.actionDeliveryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionDeliveryComboBox.FormattingEnabled = true;
            this.actionDeliveryComboBox.Items.AddRange(new object[] {
            "Добавление",
            "Изменение",
            "Удаление"});
            this.actionDeliveryComboBox.Location = new System.Drawing.Point(12, 33);
            this.actionDeliveryComboBox.Name = "actionDeliveryComboBox";
            this.actionDeliveryComboBox.Size = new System.Drawing.Size(166, 29);
            this.actionDeliveryComboBox.TabIndex = 5;
            this.actionDeliveryComboBox.SelectedIndexChanged += new System.EventHandler(this.ActionDeliveryComboBoxOnSelectedIndexChanged);
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(28, 79);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(130, 30);
            this.selectButton.TabIndex = 10;
            this.selectButton.Text = "Выбрать";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.SelectButtonOnClick);
            // 
            // DeliveryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 222);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deliveryTextBox);
            this.Controls.Add(this.actionDeliveryButton);
            this.Controls.Add(this.actionDeliveryComboBox);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "DeliveryForm";
            this.Text = "Доставка";
            this.Load += new System.EventHandler(this.DeliveryFormOnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox deliveryTextBox;
        private System.Windows.Forms.Button actionDeliveryButton;
        private System.Windows.Forms.ComboBox actionDeliveryComboBox;
        private System.Windows.Forms.Button selectButton;
    }
}