namespace Sale_App
{
    partial class FormAddProduct
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
            this.label2 = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProName = new System.Windows.Forms.TextBox();
            this.txtProPrice = new System.Windows.Forms.TextBox();
            this.txtProStatus = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtCateId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.Location = new System.Drawing.Point(37, 84);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(33, 15);
            this.Price.TabIndex = 3;
            this.Price.Text = "Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "CategoryId";
            // 
            // txtProName
            // 
            this.txtProName.Location = new System.Drawing.Point(149, 47);
            this.txtProName.Name = "txtProName";
            this.txtProName.Size = new System.Drawing.Size(100, 23);
            this.txtProName.TabIndex = 7;
            // 
            // txtProPrice
            // 
            this.txtProPrice.Location = new System.Drawing.Point(149, 84);
            this.txtProPrice.Name = "txtProPrice";
            this.txtProPrice.Size = new System.Drawing.Size(100, 23);
            this.txtProPrice.TabIndex = 8;
            // 
            // txtProStatus
            // 
            this.txtProStatus.Location = new System.Drawing.Point(149, 125);
            this.txtProStatus.Name = "txtProStatus";
            this.txtProStatus.Size = new System.Drawing.Size(100, 23);
            this.txtProStatus.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(79, 221);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtCateId
            // 
            this.txtCateId.Location = new System.Drawing.Point(149, 168);
            this.txtCateId.Name = "txtCateId";
            this.txtCateId.Size = new System.Drawing.Size(100, 23);
            this.txtCateId.TabIndex = 12;
            // 
            // FormAddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtCateId);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtProStatus);
            this.Controls.Add(this.txtProPrice);
            this.Controls.Add(this.txtProName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.label2);
            this.Name = "FormAddProduct";
            this.Text = "FormAddProduct";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProName;
        private System.Windows.Forms.TextBox txtProPrice;
        private System.Windows.Forms.TextBox txtProStatus;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtCateId;
    }
}