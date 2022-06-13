namespace LunaMarketAdministration.Forms
{
    partial class OrderStatusForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderStatusForm));
            this.selectButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.actionStatusButton = new System.Windows.Forms.Button();
            this.actionStatusComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(41, 89);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(130, 30);
            this.selectButton.TabIndex = 16;
            this.selectButton.Text = "Выбрать";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.SelectButtonOnClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "Название";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "Выберите действие";
            // 
            // statusTextBox
            // 
            this.statusTextBox.Location = new System.Drawing.Point(25, 146);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(166, 29);
            this.statusTextBox.TabIndex = 13;
            // 
            // actionStatusButton
            // 
            this.actionStatusButton.Location = new System.Drawing.Point(41, 191);
            this.actionStatusButton.Name = "actionStatusButton";
            this.actionStatusButton.Size = new System.Drawing.Size(130, 30);
            this.actionStatusButton.TabIndex = 12;
            this.actionStatusButton.UseVisualStyleBackColor = true;
            this.actionStatusButton.Click += new System.EventHandler(this.ActionStatusButtonOnClick);
            // 
            // actionStatusComboBox
            // 
            this.actionStatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionStatusComboBox.FormattingEnabled = true;
            this.actionStatusComboBox.Items.AddRange(new object[] {
            "Добавление",
            "Изменение",
            "Удаление"});
            this.actionStatusComboBox.Location = new System.Drawing.Point(25, 43);
            this.actionStatusComboBox.Name = "actionStatusComboBox";
            this.actionStatusComboBox.Size = new System.Drawing.Size(166, 32);
            this.actionStatusComboBox.TabIndex = 11;
            this.actionStatusComboBox.SelectedIndexChanged += new System.EventHandler(this.actionStatusComboBox_SelectedIndexChanged);
            // 
            // OrderStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 243);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.actionStatusButton);
            this.Controls.Add(this.actionStatusComboBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(246, 282);
            this.MinimumSize = new System.Drawing.Size(246, 282);
            this.Name = "OrderStatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Статус заказа";
            this.Load += new System.EventHandler(this.OrderStatusFormOnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.Button actionStatusButton;
        private System.Windows.Forms.ComboBox actionStatusComboBox;
    }
}