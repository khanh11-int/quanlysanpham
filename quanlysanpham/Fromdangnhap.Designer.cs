using System;

namespace quanlysanpham
{
    partial class Fromdangnhap
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
            this.tbnDangnhap = new System.Windows.Forms.Button();
            this.tbnThoat = new System.Windows.Forms.Button();
            this.taikhoan = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTaikhoan = new System.Windows.Forms.TextBox();
            this.txtMatkhau = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbnDangnhap
            // 
            this.tbnDangnhap.Location = new System.Drawing.Point(154, 238);
            this.tbnDangnhap.Name = "tbnDangnhap";
            this.tbnDangnhap.Size = new System.Drawing.Size(105, 46);
            this.tbnDangnhap.TabIndex = 0;
            this.tbnDangnhap.Text = "Đăng nhập";
            this.tbnDangnhap.UseVisualStyleBackColor = true;
            this.tbnDangnhap.Click += new System.EventHandler(this.tbnDangnhap_Click);
            // 
            // tbnThoat
            // 
            this.tbnThoat.Location = new System.Drawing.Point(376, 238);
            this.tbnThoat.Name = "tbnThoat";
            this.tbnThoat.Size = new System.Drawing.Size(105, 46);
            this.tbnThoat.TabIndex = 1;
            this.tbnThoat.Text = "Thoát";
            this.tbnThoat.UseVisualStyleBackColor = true;
            this.tbnThoat.Click += new System.EventHandler(this.tbnThoat_Click);
            // 
            // taikhoan
            // 
            this.taikhoan.AutoSize = true;
            this.taikhoan.Location = new System.Drawing.Point(151, 82);
            this.taikhoan.Name = "taikhoan";
            this.taikhoan.Size = new System.Drawing.Size(61, 16);
            this.taikhoan.TabIndex = 2;
            this.taikhoan.Text = "tài khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "mật khẩu";
            // 
            // txtTaikhoan
            // 
            this.txtTaikhoan.Location = new System.Drawing.Point(281, 82);
            this.txtTaikhoan.Name = "txtTaikhoan";
            this.txtTaikhoan.Size = new System.Drawing.Size(168, 22);
            this.txtTaikhoan.TabIndex = 4;
            // 
            // txtMatkhau
            // 
            this.txtMatkhau.Location = new System.Drawing.Point(281, 160);
            this.txtMatkhau.Name = "txtMatkhau";
            this.txtMatkhau.Size = new System.Drawing.Size(168, 22);
            this.txtMatkhau.TabIndex = 5;
            this.txtMatkhau.UseSystemPasswordChar = true;
            // 
            // Fromdangnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 324);
            this.Controls.Add(this.txtMatkhau);
            this.Controls.Add(this.txtTaikhoan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.taikhoan);
            this.Controls.Add(this.tbnThoat);
            this.Controls.Add(this.tbnDangnhap);
            this.Name = "Fromdangnhap";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Fromdangnhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Button tbnDangnhap;
        private System.Windows.Forms.Button tbnThoat;
        private System.Windows.Forms.Label taikhoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTaikhoan;
        private System.Windows.Forms.TextBox txtMatkhau;
    }
}

