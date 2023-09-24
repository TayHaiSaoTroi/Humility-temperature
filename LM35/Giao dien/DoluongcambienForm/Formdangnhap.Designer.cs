namespace DoluongcambienForm
{
    partial class Formdangnhap
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
            this.label3 = new System.Windows.Forms.Label();
            this.dangnhapbtn = new System.Windows.Forms.Button();
            this.Exitbtn = new System.Windows.Forms.Button();
            this.txtTentaikhoan = new System.Windows.Forms.TextBox();
            this.txtMasosinhvien = new System.Windows.Forms.TextBox();
            this.txtMatkhau = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(146, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên tài khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(146, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã số sinh viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(146, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật khẩu";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // dangnhapbtn
            // 
            this.dangnhapbtn.BackColor = System.Drawing.Color.Yellow;
            this.dangnhapbtn.Location = new System.Drawing.Point(503, 357);
            this.dangnhapbtn.Name = "dangnhapbtn";
            this.dangnhapbtn.Size = new System.Drawing.Size(92, 47);
            this.dangnhapbtn.TabIndex = 3;
            this.dangnhapbtn.Text = "Đăng nhập";
            this.dangnhapbtn.UseVisualStyleBackColor = false;
            this.dangnhapbtn.Click += new System.EventHandler(this.dangnhapbtn_Click);
            // 
            // Exitbtn
            // 
            this.Exitbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Exitbtn.Location = new System.Drawing.Point(623, 357);
            this.Exitbtn.Name = "Exitbtn";
            this.Exitbtn.Size = new System.Drawing.Size(92, 47);
            this.Exitbtn.TabIndex = 4;
            this.Exitbtn.Text = "Thoát";
            this.Exitbtn.UseVisualStyleBackColor = false;
            this.Exitbtn.Click += new System.EventHandler(this.Exitbtn_Click);
            // 
            // txtTentaikhoan
            // 
            this.txtTentaikhoan.Location = new System.Drawing.Point(383, 32);
            this.txtTentaikhoan.Name = "txtTentaikhoan";
            this.txtTentaikhoan.Size = new System.Drawing.Size(248, 22);
            this.txtTentaikhoan.TabIndex = 5;
            this.txtTentaikhoan.TextChanged += new System.EventHandler(this.txtTentaikhoan_TextChanged);
            // 
            // txtMasosinhvien
            // 
            this.txtMasosinhvien.Location = new System.Drawing.Point(383, 89);
            this.txtMasosinhvien.Name = "txtMasosinhvien";
            this.txtMasosinhvien.Size = new System.Drawing.Size(248, 22);
            this.txtMasosinhvien.TabIndex = 6;
            // 
            // txtMatkhau
            // 
            this.txtMatkhau.Location = new System.Drawing.Point(383, 145);
            this.txtMatkhau.Name = "txtMatkhau";
            this.txtMatkhau.Size = new System.Drawing.Size(248, 22);
            this.txtMatkhau.TabIndex = 7;
            this.txtMatkhau.UseSystemPasswordChar = true;
            this.txtMatkhau.TextChanged += new System.EventHandler(this.txtMatkhau_TextChanged);
            // 
            // Formdangnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(783, 446);
            this.Controls.Add(this.txtMatkhau);
            this.Controls.Add(this.txtMasosinhvien);
            this.Controls.Add(this.txtTentaikhoan);
            this.Controls.Add(this.Exitbtn);
            this.Controls.Add(this.dangnhapbtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Formdangnhap";
            this.Text = "Formdangnhap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button dangnhapbtn;
        private System.Windows.Forms.Button Exitbtn;
        private System.Windows.Forms.TextBox txtTentaikhoan;
        private System.Windows.Forms.TextBox txtMasosinhvien;
        private System.Windows.Forms.TextBox txtMatkhau;
    }
}