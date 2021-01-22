
namespace SERVERFORM1
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_port_1 = new System.Windows.Forms.Label();
            this.textBox_port_1 = new System.Windows.Forms.TextBox();
            this.button_ServerStart = new System.Windows.Forms.Button();
            this.textBox_maxPlayer_1 = new System.Windows.Forms.TextBox();
            this.label_maxPlayer_1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_port_1
            // 
            this.label_port_1.AutoSize = true;
            this.label_port_1.Location = new System.Drawing.Point(30, 35);
            this.label_port_1.Name = "label_port_1";
            this.label_port_1.Size = new System.Drawing.Size(37, 13);
            this.label_port_1.TabIndex = 2;
            this.label_port_1.Text = "PORT";
            // 
            // textBox_port_1
            // 
            this.textBox_port_1.Location = new System.Drawing.Point(58, 51);
            this.textBox_port_1.Name = "textBox_port_1";
            this.textBox_port_1.Size = new System.Drawing.Size(115, 20);
            this.textBox_port_1.TabIndex = 4;
            // 
            // button_ServerStart
            // 
            this.button_ServerStart.Location = new System.Drawing.Point(58, 143);
            this.button_ServerStart.Name = "button_ServerStart";
            this.button_ServerStart.Size = new System.Drawing.Size(115, 23);
            this.button_ServerStart.TabIndex = 5;
            this.button_ServerStart.Text = "Server\'i başlat";
            this.button_ServerStart.UseVisualStyleBackColor = true;
            this.button_ServerStart.Click += new System.EventHandler(this.button_ServerStart_Click);
            // 
            // textBox_maxPlayer_1
            // 
            this.textBox_maxPlayer_1.Location = new System.Drawing.Point(58, 106);
            this.textBox_maxPlayer_1.Name = "textBox_maxPlayer_1";
            this.textBox_maxPlayer_1.Size = new System.Drawing.Size(115, 20);
            this.textBox_maxPlayer_1.TabIndex = 7;
            // 
            // label_maxPlayer_1
            // 
            this.label_maxPlayer_1.AutoSize = true;
            this.label_maxPlayer_1.Location = new System.Drawing.Point(30, 90);
            this.label_maxPlayer_1.Name = "label_maxPlayer_1";
            this.label_maxPlayer_1.Size = new System.Drawing.Size(75, 13);
            this.label_maxPlayer_1.TabIndex = 6;
            this.label_maxPlayer_1.Text = "MAX PLAYER";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 292);
            this.Controls.Add(this.textBox_maxPlayer_1);
            this.Controls.Add(this.label_maxPlayer_1);
            this.Controls.Add(this.button_ServerStart);
            this.Controls.Add(this.textBox_port_1);
            this.Controls.Add(this.label_port_1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_port_1;
        private System.Windows.Forms.TextBox textBox_port_1;
        private System.Windows.Forms.Button button_ServerStart;
        private System.Windows.Forms.TextBox textBox_maxPlayer_1;
        private System.Windows.Forms.Label label_maxPlayer_1;
    }
}

