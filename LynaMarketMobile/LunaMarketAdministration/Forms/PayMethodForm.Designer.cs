namespace LunaMarketAdministration.Forms
{
    partial class PayMethodForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayMethodForm));
            this.selectButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.payMethodTextBox = new System.Windows.Forms.TextBox();
            this.actionPayMethodButton = new System.Windows.Forms.Button();
            this.actionPayMethodComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(48, 97);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(130, 30);
            this.selectButton.TabIndex = 22;
            this.selectButton.Text = "Выбрать";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.SelectButtonOnClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 24);
            this.label3.TabIndex = 21;
            this.label3.Text = "Название";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "Выберите действие";
            // 
            // payMethodTextBox
            // 
            this.payMethodTextBox.Location = new System.Drawing.Point(32, 154);
            this.payMethodTextBox.Name = "payMethodTextBox";
            this.payMethodTextBox.Size = new System.Drawing.Size(166, 29);
            this.payMethodTextBox.TabIndex = 19;
            // 
            // actionPayMethodButton
            // 
            this.actionPayMethodButton.Location = new System.Drawing.Point(48, 199);
            this.actionPayMethodButton.Name = "actionPayMethodButton";
            this.actionPayMethodButton.Size = new System.Drawing.Size(130, 30);
            this.actionPayMethodButton.TabIndex = 18;
            this.actionPayMethodButton.UseVisualStyleBackColor = true;
            this.actionPayMethodButton.Click += new System.EventHandler(this.ActionPayMethodButtonOnClick);
            // 
            // actionPayMethodComboBox
            // 
            this.actionPayMethodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionPayMethodComboBox.FormattingEnabled = true;
            this.actionPayMethodComboBox.Items.AddRange(new object[] {
            "Добавление",
            "Изменение",
            "Удаление"});
            this.actionPayMethodComboBox.Location = new System.Drawing.Point(32, 51);
            this.actionPayMethodComboBox.Name = "actionPayMethodComboBox";
            this.actionPayMethodComboBox.Size = new System.Drawing.Size(166, 32);
            this.actionPayMethodComboBox.TabIndex = 17;
            this.actionPayMethodComboBox.SelectedIndexChanged += new System.EventHandler(this.ActionPayMethodComboBoxOnSelectedIndexChanged);
            // 
            // PayMethodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 245);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.payMethodTextBox);
            this.Controls.Add(this.actionPayMethodButton);
            this.Controls.Add(this.actionPayMethodComboBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(251, 284);
            this.MinimumSize = new System.Drawing.Size(251, 284);
            this.Name = "PayMethodForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Методы оплаты";
            this.Load += new System.EventHandler(this.PayMethodFormOnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox payMethodTextBox;
        private System.Windows.Forms.Button actionPayMethodButton;
        private System.Windows.Forms.ComboBox actionPayMethodComboBox;
    }
}