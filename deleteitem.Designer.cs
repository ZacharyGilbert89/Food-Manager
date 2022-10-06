namespace Food_
{
    partial class deleteitem
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
            this.label2 = new System.Windows.Forms.Label();
            this.itemNameDelete = new System.Windows.Forms.RichTextBox();
            this.deleteBTN = new System.Windows.Forms.Button();
            this.refreshBTN = new System.Windows.Forms.PictureBox();
            this.itemListTEXTBOX = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.refreshBTN)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(416, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Delete Item";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Item Name:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // itemNameDelete
            // 
            this.itemNameDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemNameDelete.Location = new System.Drawing.Point(119, 132);
            this.itemNameDelete.Name = "itemNameDelete";
            this.itemNameDelete.Size = new System.Drawing.Size(406, 45);
            this.itemNameDelete.TabIndex = 2;
            this.itemNameDelete.Text = "";
            // 
            // deleteBTN
            // 
            this.deleteBTN.Location = new System.Drawing.Point(292, 193);
            this.deleteBTN.Name = "deleteBTN";
            this.deleteBTN.Size = new System.Drawing.Size(129, 53);
            this.deleteBTN.TabIndex = 3;
            this.deleteBTN.Text = "Delete";
            this.deleteBTN.UseVisualStyleBackColor = true;
            this.deleteBTN.Click += new System.EventHandler(this.deleteBTN_Click);
            // 
            // refreshBTN
            // 
            this.refreshBTN.BackgroundImage = global::Food_.Properties.Resources.icons8_refresh_512;
            this.refreshBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refreshBTN.Location = new System.Drawing.Point(971, 133);
            this.refreshBTN.Name = "refreshBTN";
            this.refreshBTN.Size = new System.Drawing.Size(44, 44);
            this.refreshBTN.TabIndex = 5;
            this.refreshBTN.TabStop = false;
            this.refreshBTN.Click += new System.EventHandler(this.refreshBTN_Click);
            // 
            // itemListTEXTBOX
            // 
            this.itemListTEXTBOX.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemListTEXTBOX.Location = new System.Drawing.Point(553, 132);
            this.itemListTEXTBOX.Name = "itemListTEXTBOX";
            this.itemListTEXTBOX.ReadOnly = true;
            this.itemListTEXTBOX.Size = new System.Drawing.Size(412, 512);
            this.itemListTEXTBOX.TabIndex = 6;
            this.itemListTEXTBOX.Text = "";
            // 
            // deleteitem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 656);
            this.Controls.Add(this.itemListTEXTBOX);
            this.Controls.Add(this.refreshBTN);
            this.Controls.Add(this.deleteBTN);
            this.Controls.Add(this.itemNameDelete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "deleteitem";
            this.Text = "deleteitem";
            this.Load += new System.EventHandler(this.deleteitem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.refreshBTN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox itemNameDelete;
        private System.Windows.Forms.Button deleteBTN;
        private System.Windows.Forms.PictureBox refreshBTN;
        private System.Windows.Forms.RichTextBox itemListTEXTBOX;
    }
}