namespace Rental
{
    partial class FormApartmantAdd
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.cbOwner = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbDailyPrice = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.listViewIncludes = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewSpecials = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddIncludes = new System.Windows.Forms.Button();
            this.btnAddSpecials = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbNumer = new System.Windows.Forms.TextBox();
            this.cbOffer = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbDescriptionSpecial = new System.Windows.Forms.TextBox();
            this.tbPriceSPecial = new System.Windows.Forms.TextBox();
            this.tbPostal = new System.Windows.Forms.TextBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(128, 23);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(121, 20);
            this.tbName.TabIndex = 1;
            // 
            // cbOwner
            // 
            this.cbOwner.FormattingEnabled = true;
            this.cbOwner.Location = new System.Drawing.Point(447, 23);
            this.cbOwner.Name = "cbOwner";
            this.cbOwner.Size = new System.Drawing.Size(134, 21);
            this.cbOwner.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(183, 312);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(374, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Owner:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(374, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "DailyPrice:";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(128, 55);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(223, 20);
            this.tbDescription.TabIndex = 7;
            // 
            // tbDailyPrice
            // 
            this.tbDailyPrice.Location = new System.Drawing.Point(447, 58);
            this.tbDailyPrice.Name = "tbDailyPrice";
            this.tbDailyPrice.Size = new System.Drawing.Size(134, 20);
            this.tbDailyPrice.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(307, 312);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // listViewIncludes
            // 
            this.listViewIncludes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewIncludes.Location = new System.Drawing.Point(183, 138);
            this.listViewIncludes.Name = "listViewIncludes";
            this.listViewIncludes.Size = new System.Drawing.Size(132, 141);
            this.listViewIncludes.TabIndex = 10;
            this.listViewIncludes.UseCompatibleStateImageBehavior = false;
            this.listViewIncludes.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Number";
            this.columnHeader1.Width = 49;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Offer";
            this.columnHeader2.Width = 74;
            // 
            // listViewSpecials
            // 
            this.listViewSpecials.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listViewSpecials.Location = new System.Drawing.Point(511, 138);
            this.listViewSpecials.Name = "listViewSpecials";
            this.listViewSpecials.Size = new System.Drawing.Size(200, 138);
            this.listViewSpecials.TabIndex = 11;
            this.listViewSpecials.UseCompatibleStateImageBehavior = false;
            this.listViewSpecials.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Description";
            this.columnHeader3.Width = 141;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Price[€]";
            this.columnHeader4.Width = 50;
            // 
            // btnAddIncludes
            // 
            this.btnAddIncludes.Location = new System.Drawing.Point(35, 253);
            this.btnAddIncludes.Name = "btnAddIncludes";
            this.btnAddIncludes.Size = new System.Drawing.Size(103, 23);
            this.btnAddIncludes.TabIndex = 12;
            this.btnAddIncludes.Text = "Add Includes";
            this.btnAddIncludes.UseVisualStyleBackColor = true;
            this.btnAddIncludes.Click += new System.EventHandler(this.btnAddIncludes_Click);
            // 
            // btnAddSpecials
            // 
            this.btnAddSpecials.Location = new System.Drawing.Point(335, 253);
            this.btnAddSpecials.Name = "btnAddSpecials";
            this.btnAddSpecials.Size = new System.Drawing.Size(105, 23);
            this.btnAddSpecials.TabIndex = 13;
            this.btnAddSpecials.Text = "Add Specials";
            this.btnAddSpecials.UseVisualStyleBackColor = true;
            this.btnAddSpecials.Click += new System.EventHandler(this.btnAddSpecials_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Offer:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Number:";
            // 
            // tbNumer
            // 
            this.tbNumer.Location = new System.Drawing.Point(73, 199);
            this.tbNumer.Name = "tbNumer";
            this.tbNumer.Size = new System.Drawing.Size(93, 20);
            this.tbNumer.TabIndex = 16;
            // 
            // cbOffer
            // 
            this.cbOffer.FormattingEnabled = true;
            this.cbOffer.Location = new System.Drawing.Point(73, 163);
            this.cbOffer.Name = "cbOffer";
            this.cbOffer.Size = new System.Drawing.Size(93, 21);
            this.cbOffer.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(321, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Description:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(321, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Price:";
            // 
            // tbDescriptionSpecial
            // 
            this.tbDescriptionSpecial.Location = new System.Drawing.Point(390, 164);
            this.tbDescriptionSpecial.Name = "tbDescriptionSpecial";
            this.tbDescriptionSpecial.Size = new System.Drawing.Size(105, 20);
            this.tbDescriptionSpecial.TabIndex = 20;
            // 
            // tbPriceSPecial
            // 
            this.tbPriceSPecial.Location = new System.Drawing.Point(390, 199);
            this.tbPriceSPecial.Name = "tbPriceSPecial";
            this.tbPriceSPecial.Size = new System.Drawing.Size(105, 20);
            this.tbPriceSPecial.TabIndex = 21;
            // 
            // tbPostal
            // 
            this.tbPostal.Location = new System.Drawing.Point(447, 91);
            this.tbPostal.Name = "tbPostal";
            this.tbPostal.Size = new System.Drawing.Size(134, 20);
            this.tbPostal.TabIndex = 25;
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(128, 91);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(223, 20);
            this.tbAddress.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(374, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Postal Code:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Address:";
            // 
            // FormApartmantAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 344);
            this.Controls.Add(this.tbPostal);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbPriceSPecial);
            this.Controls.Add(this.tbDescriptionSpecial);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbOffer);
            this.Controls.Add(this.tbNumer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAddSpecials);
            this.Controls.Add(this.btnAddIncludes);
            this.Controls.Add(this.listViewSpecials);
            this.Controls.Add(this.listViewIncludes);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbDailyPrice);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbOwner);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.Name = "FormApartmantAdd";
            this.Text = "Add Apartmant";
            this.Load += new System.EventHandler(this.FormApartmantAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.ComboBox cbOwner;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbDailyPrice;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView listViewIncludes;
        private System.Windows.Forms.ListView listViewSpecials;
        private System.Windows.Forms.Button btnAddIncludes;
        private System.Windows.Forms.Button btnAddSpecials;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbNumer;
        private System.Windows.Forms.ComboBox cbOffer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbDescriptionSpecial;
        private System.Windows.Forms.TextBox tbPriceSPecial;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox tbPostal;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}