namespace LunaMarketAdministration.Forms
{
    partial class LookForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LookForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.selectMaterialButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.materialTextBox = new System.Windows.Forms.TextBox();
            this.actionMaterialButton = new System.Windows.Forms.Button();
            this.actionMaterialComboBox = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.selectColorButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.colorTextBox = new System.Windows.Forms.TextBox();
            this.actionColorButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.actionColorComboBox = new System.Windows.Forms.ComboBox();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(203, 299);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.selectMaterialButton);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.materialTextBox);
            this.tabPage1.Controls.Add(this.actionMaterialButton);
            this.tabPage1.Controls.Add(this.actionMaterialComboBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(195, 265);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Материал";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // selectMaterialButton
            // 
            this.selectMaterialButton.Location = new System.Drawing.Point(28, 90);
            this.selectMaterialButton.Name = "selectMaterialButton";
            this.selectMaterialButton.Size = new System.Drawing.Size(130, 30);
            this.selectMaterialButton.TabIndex = 5;
            this.selectMaterialButton.Text = "Выбрать";
            this.selectMaterialButton.UseVisualStyleBackColor = true;
            this.selectMaterialButton.Click += new System.EventHandler(this.SelectMaterialButtonOnClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Название";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Выберите действие";
            // 
            // materialTextBox
            // 
            this.materialTextBox.Location = new System.Drawing.Point(13, 159);
            this.materialTextBox.Name = "materialTextBox";
            this.materialTextBox.Size = new System.Drawing.Size(166, 29);
            this.materialTextBox.TabIndex = 2;
            // 
            // actionMaterialButton
            // 
            this.actionMaterialButton.Location = new System.Drawing.Point(28, 207);
            this.actionMaterialButton.Name = "actionMaterialButton";
            this.actionMaterialButton.Size = new System.Drawing.Size(130, 30);
            this.actionMaterialButton.TabIndex = 1;
            this.actionMaterialButton.UseVisualStyleBackColor = true;
            this.actionMaterialButton.Click += new System.EventHandler(this.ActionMaterialButtonOnClick);
            // 
            // actionMaterialComboBox
            // 
            this.actionMaterialComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionMaterialComboBox.FormattingEnabled = true;
            this.actionMaterialComboBox.Items.AddRange(new object[] {
            "Добавление",
            "Изменение",
            "Удаление"});
            this.actionMaterialComboBox.Location = new System.Drawing.Point(9, 45);
            this.actionMaterialComboBox.Name = "actionMaterialComboBox";
            this.actionMaterialComboBox.Size = new System.Drawing.Size(166, 29);
            this.actionMaterialComboBox.TabIndex = 0;
            this.actionMaterialComboBox.SelectedIndexChanged += new System.EventHandler(this.ActionMaterialComboBoxOnSelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.selectColorButton);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.colorTextBox);
            this.tabPage2.Controls.Add(this.actionColorButton);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.actionColorComboBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(195, 265);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Цвет";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // selectColorButton
            // 
            this.selectColorButton.Location = new System.Drawing.Point(31, 97);
            this.selectColorButton.Name = "selectColorButton";
            this.selectColorButton.Size = new System.Drawing.Size(130, 30);
            this.selectColorButton.TabIndex = 8;
            this.selectColorButton.Text = "Выбрать";
            this.selectColorButton.UseVisualStyleBackColor = true;
            this.selectColorButton.Click += new System.EventHandler(this.SelectColorButtonOnClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Название";
            // 
            // colorTextBox
            // 
            this.colorTextBox.Location = new System.Drawing.Point(9, 180);
            this.colorTextBox.Name = "colorTextBox";
            this.colorTextBox.Size = new System.Drawing.Size(166, 29);
            this.colorTextBox.TabIndex = 6;
            // 
            // actionColorButton
            // 
            this.actionColorButton.Location = new System.Drawing.Point(31, 215);
            this.actionColorButton.Name = "actionColorButton";
            this.actionColorButton.Size = new System.Drawing.Size(130, 30);
            this.actionColorButton.TabIndex = 5;
            this.actionColorButton.UseVisualStyleBackColor = true;
            this.actionColorButton.Click += new System.EventHandler(this.ActionColorButtonOnClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Выберите действие";
            // 
            // actionColorComboBox
            // 
            this.actionColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionColorComboBox.FormattingEnabled = true;
            this.actionColorComboBox.Items.AddRange(new object[] {
            "Добавление",
            "Изменение",
            "Удаление"});
            this.actionColorComboBox.Location = new System.Drawing.Point(9, 38);
            this.actionColorComboBox.Name = "actionColorComboBox";
            this.actionColorComboBox.Size = new System.Drawing.Size(166, 29);
            this.actionColorComboBox.TabIndex = 1;
            this.actionColorComboBox.SelectedIndexChanged += new System.EventHandler(this.ActionColorComboBoxOnSelectedIndexChanged);
            // 
            // LookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 299);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(219, 338);
            this.MinimumSize = new System.Drawing.Size(219, 338);
            this.Name = "LookForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Внешний вид";
            this.Load += new System.EventHandler(this.LookFormOnLoad);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox actionMaterialComboBox;
        private System.Windows.Forms.ComboBox actionColorComboBox;
        private System.Windows.Forms.Button actionMaterialButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox materialTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox colorTextBox;
        private System.Windows.Forms.Button actionColorButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button selectMaterialButton;
        private System.Windows.Forms.Button selectColorButton;
    }
}