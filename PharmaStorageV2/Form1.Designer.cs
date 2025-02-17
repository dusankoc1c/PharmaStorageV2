namespace PharmaStorageV2
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_contact = new System.Windows.Forms.Button();
            this.btn_enter = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_contact
            // 
            this.btn_contact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(203)))), ((int)(((byte)(201)))));
            this.btn_contact.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_contact.Location = new System.Drawing.Point(332, 358);
            this.btn_contact.Name = "btn_contact";
            this.btn_contact.Size = new System.Drawing.Size(103, 35);
            this.btn_contact.TabIndex = 5;
            this.btn_contact.Text = "Contact ";
            this.btn_contact.UseVisualStyleBackColor = false;
            this.btn_contact.Click += new System.EventHandler(this.btn_contact_Click);
            // 
            // btn_enter
            // 
            this.btn_enter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(203)))), ((int)(((byte)(201)))));
            this.btn_enter.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_enter.Location = new System.Drawing.Point(180, 358);
            this.btn_enter.Name = "btn_enter";
            this.btn_enter.Size = new System.Drawing.Size(103, 35);
            this.btn_enter.TabIndex = 4;
            this.btn_enter.Text = "Enter";
            this.btn_enter.UseVisualStyleBackColor = false;
            this.btn_enter.Click += new System.EventHandler(this.btn_enter_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(180, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 436);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(63)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(615, 454);
            this.Controls.Add(this.btn_contact);
            this.Controls.Add(this.btn_enter);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_contact;
        private System.Windows.Forms.Button btn_enter;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

