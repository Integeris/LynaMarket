namespace LunaMarketAdministration.Forms
{
    partial class ProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductForm));
            this.actionComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.selectManufacturerButton = new System.Windows.Forms.Button();
            this.selectCategoryButton = new System.Windows.Forms.Button();
            this.heightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.widthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.depthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.amontNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.priceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.manufacturerTextBox = new System.Windows.Forms.TextBox();
            this.colorTextBox = new System.Windows.Forms.TextBox();
            this.selectColorButton = new System.Windows.Forms.Button();
            this.materialTextBox = new System.Windows.Forms.TextBox();
            this.selectMaterialButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.selectImageButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.selectProductButton = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.updatePictureBox = new System.Windows.Forms.PictureBox();
            this.deletePictureBox = new System.Windows.Forms.PictureBox();
            this.addPictureBox = new System.Windows.Forms.PictureBox();
            this.productPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amontNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updatePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deletePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // actionComboBox
            // 
            this.actionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionComboBox.FormattingEnabled = true;
            this.actionComboBox.Items.AddRange(new object[] {
            "Добавление",
            "Изменение",
            "Удаление"});
            this.actionComboBox.Location = new System.Drawing.Point(16, 33);
            this.actionComboBox.Name = "actionComboBox";
            this.actionComboBox.Size = new System.Drawing.Size(156, 29);
            this.actionComboBox.TabIndex = 1;
            this.actionComboBox.SelectedIndexChanged += new System.EventHandler(this.ActionComboBoxOnSelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Выберите действие";
            // 
            // selectManufacturerButton
            // 
            this.selectManufacturerButton.Location = new System.Drawing.Point(195, 74);
            this.selectManufacturerButton.Name = "selectManufacturerButton";
            this.selectManufacturerButton.Size = new System.Drawing.Size(152, 55);
            this.selectManufacturerButton.TabIndex = 3;
            this.selectManufacturerButton.Text = "Выберите производителя";
            this.selectManufacturerButton.UseVisualStyleBackColor = true;
            this.selectManufacturerButton.Click += new System.EventHandler(this.SelectManufacturerButtonOnClick);
            // 
            // selectCategoryButton
            // 
            this.selectCategoryButton.Location = new System.Drawing.Point(371, 74);
            this.selectCategoryButton.Name = "selectCategoryButton";
            this.selectCategoryButton.Size = new System.Drawing.Size(152, 55);
            this.selectCategoryButton.TabIndex = 5;
            this.selectCategoryButton.Text = "Выберите категорию";
            this.selectCategoryButton.UseVisualStyleBackColor = true;
            this.selectCategoryButton.Click += new System.EventHandler(this.SelectCategoryButtonOnClick);
            // 
            // heightNumericUpDown
            // 
            this.heightNumericUpDown.Location = new System.Drawing.Point(483, 176);
            this.heightNumericUpDown.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.heightNumericUpDown.Name = "heightNumericUpDown";
            this.heightNumericUpDown.Size = new System.Drawing.Size(77, 29);
            this.heightNumericUpDown.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(486, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Высота";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(561, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "мм";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(683, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 21);
            this.label7.TabIndex = 13;
            this.label7.Text = "мм";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(608, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 21);
            this.label8.TabIndex = 12;
            this.label8.Text = "Ширина";
            // 
            // widthNumericUpDown
            // 
            this.widthNumericUpDown.Location = new System.Drawing.Point(605, 176);
            this.widthNumericUpDown.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.widthNumericUpDown.Name = "widthNumericUpDown";
            this.widthNumericUpDown.Size = new System.Drawing.Size(77, 29);
            this.widthNumericUpDown.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(685, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 21);
            this.label9.TabIndex = 16;
            this.label9.Text = "мм";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(610, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 21);
            this.label10.TabIndex = 15;
            this.label10.Text = "Глубина";
            // 
            // depthNumericUpDown
            // 
            this.depthNumericUpDown.Location = new System.Drawing.Point(607, 98);
            this.depthNumericUpDown.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.depthNumericUpDown.Name = "depthNumericUpDown";
            this.depthNumericUpDown.Size = new System.Drawing.Size(77, 29);
            this.depthNumericUpDown.TabIndex = 14;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(548, 33);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(180, 29);
            this.titleTextBox.TabIndex = 17;
            this.titleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(367, 311);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(357, 210);
            this.descriptionTextBox.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(368, 287);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(147, 21);
            this.label11.TabIndex = 19;
            this.label11.Text = "Описание товара";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(468, 214);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 21);
            this.label12.TabIndex = 21;
            this.label12.Text = "Количество";
            // 
            // amontNumericUpDown
            // 
            this.amontNumericUpDown.Location = new System.Drawing.Point(479, 238);
            this.amontNumericUpDown.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.amontNumericUpDown.Name = "amontNumericUpDown";
            this.amontNumericUpDown.Size = new System.Drawing.Size(77, 29);
            this.amontNumericUpDown.TabIndex = 20;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(603, 214);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 21);
            this.label14.TabIndex = 24;
            this.label14.Text = "Стоимость";
            // 
            // priceNumericUpDown
            // 
            this.priceNumericUpDown.Location = new System.Drawing.Point(607, 238);
            this.priceNumericUpDown.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.priceNumericUpDown.Name = "priceNumericUpDown";
            this.priceNumericUpDown.Size = new System.Drawing.Size(77, 29);
            this.priceNumericUpDown.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(685, 246);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 21);
            this.label13.TabIndex = 25;
            this.label13.Text = "₽";
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.Location = new System.Drawing.Point(371, 33);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.ReadOnly = true;
            this.categoryTextBox.Size = new System.Drawing.Size(152, 29);
            this.categoryTextBox.TabIndex = 26;
            this.categoryTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // manufacturerTextBox
            // 
            this.manufacturerTextBox.Location = new System.Drawing.Point(195, 33);
            this.manufacturerTextBox.Name = "manufacturerTextBox";
            this.manufacturerTextBox.ReadOnly = true;
            this.manufacturerTextBox.Size = new System.Drawing.Size(150, 29);
            this.manufacturerTextBox.TabIndex = 27;
            this.manufacturerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colorTextBox
            // 
            this.colorTextBox.Location = new System.Drawing.Point(19, 176);
            this.colorTextBox.Name = "colorTextBox";
            this.colorTextBox.ReadOnly = true;
            this.colorTextBox.Size = new System.Drawing.Size(150, 29);
            this.colorTextBox.TabIndex = 29;
            this.colorTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // selectColorButton
            // 
            this.selectColorButton.Location = new System.Drawing.Point(19, 217);
            this.selectColorButton.Name = "selectColorButton";
            this.selectColorButton.Size = new System.Drawing.Size(152, 55);
            this.selectColorButton.TabIndex = 28;
            this.selectColorButton.Text = "Выберите цвет";
            this.selectColorButton.UseVisualStyleBackColor = true;
            this.selectColorButton.Click += new System.EventHandler(this.SelectColorButtonOnClick);
            // 
            // materialTextBox
            // 
            this.materialTextBox.Location = new System.Drawing.Point(195, 176);
            this.materialTextBox.Name = "materialTextBox";
            this.materialTextBox.ReadOnly = true;
            this.materialTextBox.Size = new System.Drawing.Size(150, 29);
            this.materialTextBox.TabIndex = 31;
            this.materialTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // selectMaterialButton
            // 
            this.selectMaterialButton.Location = new System.Drawing.Point(195, 217);
            this.selectMaterialButton.Name = "selectMaterialButton";
            this.selectMaterialButton.Size = new System.Drawing.Size(152, 55);
            this.selectMaterialButton.TabIndex = 30;
            this.selectMaterialButton.Text = "Выберите материал";
            this.selectMaterialButton.UseVisualStyleBackColor = true;
            this.selectMaterialButton.Click += new System.EventHandler(this.SelectMaterialButtonOnClick);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(598, 527);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(126, 32);
            this.editButton.TabIndex = 32;
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.EditButtonOnClick);
            // 
            // selectImageButton
            // 
            this.selectImageButton.Location = new System.Drawing.Point(159, 527);
            this.selectImageButton.Name = "selectImageButton";
            this.selectImageButton.Size = new System.Drawing.Size(226, 32);
            this.selectImageButton.TabIndex = 34;
            this.selectImageButton.Text = "Выбрать изображение";
            this.selectImageButton.UseVisualStyleBackColor = true;
            this.selectImageButton.Click += new System.EventHandler(this.SelectImageButtonOnClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 21);
            this.label1.TabIndex = 35;
            this.label1.Text = "Производитель";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(401, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 21);
            this.label3.TabIndex = 36;
            this.label3.Text = "Категория";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(544, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 21);
            this.label4.TabIndex = 37;
            this.label4.Text = "Наименование товара";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(69, 152);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 21);
            this.label15.TabIndex = 38;
            this.label15.Text = "Цвет";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(226, 152);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(87, 21);
            this.label16.TabIndex = 39;
            this.label16.Text = "Материал";
            // 
            // selectProductButton
            // 
            this.selectProductButton.Location = new System.Drawing.Point(17, 74);
            this.selectProductButton.Name = "selectProductButton";
            this.selectProductButton.Size = new System.Drawing.Size(155, 55);
            this.selectProductButton.TabIndex = 40;
            this.selectProductButton.Text = "Выберите товар";
            this.selectProductButton.UseVisualStyleBackColor = true;
            this.selectProductButton.Click += new System.EventHandler(this.SelectProductButtonOnClick);
            // 
            // listView
            // 
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(19, 296);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(118, 225);
            this.listView.TabIndex = 41;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListViewOnItemSelectionChanged);
            // 
            // updatePictureBox
            // 
            this.updatePictureBox.Image = global::LunaMarketAdministration.Properties.Resources._260_2603638_arrows_round_trip_green_png_image_repeated_icon;
            this.updatePictureBox.InitialImage = null;
            this.updatePictureBox.Location = new System.Drawing.Point(64, 527);
            this.updatePictureBox.Name = "updatePictureBox";
            this.updatePictureBox.Size = new System.Drawing.Size(29, 27);
            this.updatePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.updatePictureBox.TabIndex = 44;
            this.updatePictureBox.TabStop = false;
            this.updatePictureBox.Click += new System.EventHandler(this.UpdatePictureBoxOnClick);
            // 
            // deletePictureBox
            // 
            this.deletePictureBox.Image = global::LunaMarketAdministration.Properties.Resources.delete1;
            this.deletePictureBox.InitialImage = null;
            this.deletePictureBox.Location = new System.Drawing.Point(108, 527);
            this.deletePictureBox.Name = "deletePictureBox";
            this.deletePictureBox.Size = new System.Drawing.Size(29, 27);
            this.deletePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.deletePictureBox.TabIndex = 43;
            this.deletePictureBox.TabStop = false;
            this.deletePictureBox.Click += new System.EventHandler(this.DeletePictureBoxOnClick);
            // 
            // addPictureBox
            // 
            this.addPictureBox.Image = global::LunaMarketAdministration.Properties.Resources.PlusSignIcon;
            this.addPictureBox.Location = new System.Drawing.Point(12, 527);
            this.addPictureBox.Name = "addPictureBox";
            this.addPictureBox.Size = new System.Drawing.Size(38, 27);
            this.addPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.addPictureBox.TabIndex = 42;
            this.addPictureBox.TabStop = false;
            this.addPictureBox.Click += new System.EventHandler(this.AddPictureBoxOnClick);
            // 
            // productPictureBox
            // 
            this.productPictureBox.Location = new System.Drawing.Point(159, 296);
            this.productPictureBox.Name = "productPictureBox";
            this.productPictureBox.Size = new System.Drawing.Size(188, 225);
            this.productPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.productPictureBox.TabIndex = 33;
            this.productPictureBox.TabStop = false;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(742, 566);
            this.Controls.Add(this.updatePictureBox);
            this.Controls.Add(this.deletePictureBox);
            this.Controls.Add(this.addPictureBox);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.selectProductButton);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectImageButton);
            this.Controls.Add(this.productPictureBox);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.materialTextBox);
            this.Controls.Add(this.selectMaterialButton);
            this.Controls.Add(this.colorTextBox);
            this.Controls.Add(this.selectColorButton);
            this.Controls.Add(this.manufacturerTextBox);
            this.Controls.Add(this.categoryTextBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.priceNumericUpDown);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.amontNumericUpDown);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.depthNumericUpDown);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.widthNumericUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.heightNumericUpDown);
            this.Controls.Add(this.selectCategoryButton);
            this.Controls.Add(this.selectManufacturerButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.actionComboBox);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(758, 605);
            this.MinimumSize = new System.Drawing.Size(758, 605);
            this.Name = "ProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Товары";
            this.Load += new System.EventHandler(this.ProductFormOnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.heightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amontNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updatePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deletePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox actionComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button selectManufacturerButton;
        private System.Windows.Forms.Button selectCategoryButton;
        private System.Windows.Forms.NumericUpDown heightNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown widthNumericUpDown;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown depthNumericUpDown;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown amontNumericUpDown;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown priceNumericUpDown;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox categoryTextBox;
        private System.Windows.Forms.TextBox manufacturerTextBox;
        private System.Windows.Forms.TextBox colorTextBox;
        private System.Windows.Forms.Button selectColorButton;
        private System.Windows.Forms.TextBox materialTextBox;
        private System.Windows.Forms.Button selectMaterialButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.PictureBox productPictureBox;
        private System.Windows.Forms.Button selectImageButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button selectProductButton;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.PictureBox addPictureBox;
        private System.Windows.Forms.PictureBox deletePictureBox;
        private System.Windows.Forms.PictureBox updatePictureBox;
    }
}