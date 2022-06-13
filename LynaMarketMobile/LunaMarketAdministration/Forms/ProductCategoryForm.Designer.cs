namespace LunaMarketAdministration.Forms
{
    partial class ProductCategoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductCategoryForm));
            this.label4 = new System.Windows.Forms.Label();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.actionCategoryButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.actionCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.selectCategoryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(66, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 21);
            this.label4.TabIndex = 17;
            this.label4.Text = "Название";
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.categoryTextBox.Location = new System.Drawing.Point(17, 179);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.Size = new System.Drawing.Size(190, 29);
            this.categoryTextBox.TabIndex = 16;
            // 
            // actionCategoryButton
            // 
            this.actionCategoryButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.actionCategoryButton.Location = new System.Drawing.Point(46, 232);
            this.actionCategoryButton.Name = "actionCategoryButton";
            this.actionCategoryButton.Size = new System.Drawing.Size(130, 30);
            this.actionCategoryButton.TabIndex = 15;
            this.actionCategoryButton.UseVisualStyleBackColor = true;
            this.actionCategoryButton.Click += new System.EventHandler(this.ActionCategoryButtonOnClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(28, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 21);
            this.label2.TabIndex = 14;
            this.label2.Text = "Выберите действие";
            // 
            // actionCategoryComboBox
            // 
            this.actionCategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionCategoryComboBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.actionCategoryComboBox.FormattingEnabled = true;
            this.actionCategoryComboBox.Items.AddRange(new object[] {
            "Добавление",
            "Изменение",
            "Удаление"});
            this.actionCategoryComboBox.Location = new System.Drawing.Point(17, 39);
            this.actionCategoryComboBox.Name = "actionCategoryComboBox";
            this.actionCategoryComboBox.Size = new System.Drawing.Size(190, 29);
            this.actionCategoryComboBox.TabIndex = 13;
            this.actionCategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.ActionCategoryComboBoxOnSelectedIndexChanged);
            // 
            // selectCategoryButton
            // 
            this.selectCategoryButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.selectCategoryButton.Location = new System.Drawing.Point(17, 94);
            this.selectCategoryButton.Name = "selectCategoryButton";
            this.selectCategoryButton.Size = new System.Drawing.Size(190, 30);
            this.selectCategoryButton.TabIndex = 18;
            this.selectCategoryButton.Text = "Выбрать категорию";
            this.selectCategoryButton.UseVisualStyleBackColor = true;
            this.selectCategoryButton.Click += new System.EventHandler(this.SelectCategoryButtonOnClick);
            // 
            // ProductCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 267);
            this.Controls.Add(this.selectCategoryButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.categoryTextBox);
            this.Controls.Add(this.actionCategoryButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.actionCategoryComboBox);
            this.Font = new System.Drawing.Font("Magnolia Script", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(261, 306);
            this.MinimumSize = new System.Drawing.Size(261, 306);
            this.Name = "ProductCategoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Категория";
            this.Load += new System.EventHandler(this.ProductCategoryFormOnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox categoryTextBox;
        private System.Windows.Forms.Button actionCategoryButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox actionCategoryComboBox;
        private System.Windows.Forms.Button selectCategoryButton;
    }
}