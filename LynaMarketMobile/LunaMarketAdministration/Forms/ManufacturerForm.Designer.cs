namespace LunaMarketAdministration.Forms
{
    partial class ManufacturerForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.manufacturerTextBox = new System.Windows.Forms.TextBox();
            this.actionManufacturerButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.actionManufacturerComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 21);
            this.label4.TabIndex = 12;
            this.label4.Text = "Название";
            // 
            // manufacturerTextBox
            // 
            this.manufacturerTextBox.Location = new System.Drawing.Point(12, 100);
            this.manufacturerTextBox.Name = "manufacturerTextBox";
            this.manufacturerTextBox.Size = new System.Drawing.Size(166, 29);
            this.manufacturerTextBox.TabIndex = 11;
            // 
            // actionManufacturerButton
            // 
            this.actionManufacturerButton.Location = new System.Drawing.Point(34, 139);
            this.actionManufacturerButton.Name = "actionManufacturerButton";
            this.actionManufacturerButton.Size = new System.Drawing.Size(130, 30);
            this.actionManufacturerButton.TabIndex = 10;
            this.actionManufacturerButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "Выберите действие";
            // 
            // actionManufacturerComboBox
            // 
            this.actionManufacturerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionManufacturerComboBox.FormattingEnabled = true;
            this.actionManufacturerComboBox.Items.AddRange(new object[] {
            "Добавление",
            "Изменение",
            "Удаление"});
            this.actionManufacturerComboBox.Location = new System.Drawing.Point(12, 33);
            this.actionManufacturerComboBox.Name = "actionManufacturerComboBox";
            this.actionManufacturerComboBox.Size = new System.Drawing.Size(166, 29);
            this.actionManufacturerComboBox.TabIndex = 8;
            this.actionManufacturerComboBox.SelectedIndexChanged += new System.EventHandler(this.ActionManufacturerComboBoxOnSelectedIndexChanged);
            // 
            // ManufacturerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 190);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.manufacturerTextBox);
            this.Controls.Add(this.actionManufacturerButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.actionManufacturerComboBox);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ManufacturerForm";
            this.Text = "Производители";
            this.Load += new System.EventHandler(this.ManufacturerFormOnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox manufacturerTextBox;
        private System.Windows.Forms.Button actionManufacturerButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox actionManufacturerComboBox;
    }
}