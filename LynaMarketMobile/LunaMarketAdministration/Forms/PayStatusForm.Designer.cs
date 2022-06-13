namespace LunaMarketAdministration.Forms
{
    partial class PayStatusForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayStatusForm));
            this.selectButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.payStatusTextBox = new System.Windows.Forms.TextBox();
            this.actionPayStatusButton = new System.Windows.Forms.Button();
            this.actionPayStatusComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(44, 93);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(130, 30);
            this.selectButton.TabIndex = 28;
            this.selectButton.Text = "Выбрать";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.SelectButtonOnClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 24);
            this.label3.TabIndex = 27;
            this.label3.Text = "Название";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 24);
            this.label1.TabIndex = 26;
            this.label1.Text = "Выберите действие";
            // 
            // payStatusTextBox
            // 
            this.payStatusTextBox.Location = new System.Drawing.Point(28, 150);
            this.payStatusTextBox.Name = "payStatusTextBox";
            this.payStatusTextBox.Size = new System.Drawing.Size(166, 29);
            this.payStatusTextBox.TabIndex = 25;
            // 
            // actionPayStatusButton
            // 
            this.actionPayStatusButton.Location = new System.Drawing.Point(44, 195);
            this.actionPayStatusButton.Name = "actionPayStatusButton";
            this.actionPayStatusButton.Size = new System.Drawing.Size(130, 30);
            this.actionPayStatusButton.TabIndex = 24;
            this.actionPayStatusButton.UseVisualStyleBackColor = true;
            this.actionPayStatusButton.Click += new System.EventHandler(this.ActionPayStatusButtonOnClick);
            // 
            // actionPayStatusComboBox
            // 
            this.actionPayStatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionPayStatusComboBox.FormattingEnabled = true;
            this.actionPayStatusComboBox.Items.AddRange(new object[] {
            "Добавление",
            "Изменение",
            "Удаление"});
            this.actionPayStatusComboBox.Location = new System.Drawing.Point(28, 47);
            this.actionPayStatusComboBox.Name = "actionPayStatusComboBox";
            this.actionPayStatusComboBox.Size = new System.Drawing.Size(166, 32);
            this.actionPayStatusComboBox.TabIndex = 23;
            this.actionPayStatusComboBox.SelectedIndexChanged += new System.EventHandler(this.ActionPayStatusComboBoxOnSelectedIndexChanged);
            // 
            // PayStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 245);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.payStatusTextBox);
            this.Controls.Add(this.actionPayStatusButton);
            this.Controls.Add(this.actionPayStatusComboBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(251, 284);
            this.MinimumSize = new System.Drawing.Size(251, 284);
            this.Name = "PayStatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Статус оплаты";
            this.Load += new System.EventHandler(this.PayStatusForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox payStatusTextBox;
        private System.Windows.Forms.Button actionPayStatusButton;
        private System.Windows.Forms.ComboBox actionPayStatusComboBox;
    }
}