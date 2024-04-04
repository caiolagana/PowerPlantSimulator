
namespace UHESSimao
{
    partial class Form_Partida_04
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Partida_04));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.led2 = new UHESSimao.LED();
            this.led1 = new UHESSimao.LED();
            this.led_EnergizacaoReleParada_UG4 = new UHESSimao.LED();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_Passo2_UG4 = new System.Windows.Forms.Button();
            this.button_Passo1_UG4 = new System.Windows.Forms.Button();
            this.button_Passo3_UG4 = new System.Windows.Forms.Button();
            this.button_Passo4_UG4 = new System.Windows.Forms.Button();
            this.button_Passo5_UG4 = new System.Windows.Forms.Button();
            this.button_Passo6_UG4 = new System.Windows.Forms.Button();
            this.button_Passo7_UG4 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 37);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1920, 960);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage1.BackgroundImage")));
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.button_Passo7_UG4);
            this.tabPage1.Controls.Add(this.button_Passo6_UG4);
            this.tabPage1.Controls.Add(this.button_Passo5_UG4);
            this.tabPage1.Controls.Add(this.button_Passo4_UG4);
            this.tabPage1.Controls.Add(this.button_Passo3_UG4);
            this.tabPage1.Controls.Add(this.button_Passo1_UG4);
            this.tabPage1.Controls.Add(this.button_Passo2_UG4);
            this.tabPage1.Controls.Add(this.led2);
            this.tabPage1.Controls.Add(this.led1);
            this.tabPage1.Controls.Add(this.led_EnergizacaoReleParada_UG4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1912, 934);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "UG04";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // led2
            // 
            this.led2.BackColor = System.Drawing.Color.LightGreen;
            this.led2.Estado = true;
            this.led2.Link = "barra_FluxoOleoMGuiaInferior_UG4";
            this.led2.Location = new System.Drawing.Point(169, 528);
            this.led2.Name = "led2";
            this.led2.Size = new System.Drawing.Size(26, 18);
            this.led2.TabIndex = 2;
            this.led2.V = 0D;
            this.led2.Text = "led2";
            this.led2.Transforma = 1D;
            // 
            // led1
            // 
            this.led1.BackColor = System.Drawing.Color.LightGreen;
            this.led1.Estado = true;
            this.led1.Link = "barra_BombaRV_UG4";
            this.led1.Location = new System.Drawing.Point(169, 494);
            this.led1.Name = "led1";
            this.led1.Size = new System.Drawing.Size(26, 18);
            this.led1.TabIndex = 1;
            this.led1.V = 0D;
            this.led1.Text = "led1";
            this.led1.Transforma = 1D;
            // 
            // led_EnergizacaoReleParada_UG4
            // 
            this.led_EnergizacaoReleParada_UG4.BackColor = System.Drawing.Color.LightGreen;
            this.led_EnergizacaoReleParada_UG4.Estado = true;
            this.led_EnergizacaoReleParada_UG4.Link = "barra_Passo1_UG4";
            this.led_EnergizacaoReleParada_UG4.Location = new System.Drawing.Point(169, 233);
            this.led_EnergizacaoReleParada_UG4.Name = "led_EnergizacaoReleParada_UG4";
            this.led_EnergizacaoReleParada_UG4.Size = new System.Drawing.Size(26, 18);
            this.led_EnergizacaoReleParada_UG4.TabIndex = 0;
            this.led_EnergizacaoReleParada_UG4.V = 0D;
            this.led_EnergizacaoReleParada_UG4.Text = "led1";
            this.led_EnergizacaoReleParada_UG4.Transforma = 1D;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1912, 934);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(1856, 1003);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(45, 45);
            this.panel2.TabIndex = 10;
            // 
            // button_Passo2_UG4
            // 
            this.button_Passo2_UG4.Location = new System.Drawing.Point(665, 284);
            this.button_Passo2_UG4.Name = "button_Passo2_UG4";
            this.button_Passo2_UG4.Size = new System.Drawing.Size(75, 366);
            this.button_Passo2_UG4.TabIndex = 3;
            this.button_Passo2_UG4.Text = "2";
            this.button_Passo2_UG4.UseVisualStyleBackColor = true;
            this.button_Passo2_UG4.Click += new System.EventHandler(this.button_Passo2_UG4_Click);
            // 
            // button_Passo1_UG4
            // 
            this.button_Passo1_UG4.Location = new System.Drawing.Point(665, 219);
            this.button_Passo1_UG4.Name = "button_Passo1_UG4";
            this.button_Passo1_UG4.Size = new System.Drawing.Size(75, 59);
            this.button_Passo1_UG4.TabIndex = 4;
            this.button_Passo1_UG4.Text = "1";
            this.button_Passo1_UG4.UseVisualStyleBackColor = true;
            this.button_Passo1_UG4.Click += new System.EventHandler(this.button_Passo1_UG4_Click);
            // 
            // button_Passo3_UG4
            // 
            this.button_Passo3_UG4.Location = new System.Drawing.Point(665, 663);
            this.button_Passo3_UG4.Name = "button_Passo3_UG4";
            this.button_Passo3_UG4.Size = new System.Drawing.Size(75, 139);
            this.button_Passo3_UG4.TabIndex = 5;
            this.button_Passo3_UG4.Text = "3";
            this.button_Passo3_UG4.UseVisualStyleBackColor = true;
            this.button_Passo3_UG4.Click += new System.EventHandler(this.button_Passo3_UG4_Click);
            // 
            // button_Passo4_UG4
            // 
            this.button_Passo4_UG4.Location = new System.Drawing.Point(1416, 219);
            this.button_Passo4_UG4.Name = "button_Passo4_UG4";
            this.button_Passo4_UG4.Size = new System.Drawing.Size(75, 139);
            this.button_Passo4_UG4.TabIndex = 6;
            this.button_Passo4_UG4.Text = "4";
            this.button_Passo4_UG4.UseVisualStyleBackColor = true;
            this.button_Passo4_UG4.Click += new System.EventHandler(this.button_Passo4_UG4_Click);
            // 
            // button_Passo5_UG4
            // 
            this.button_Passo5_UG4.Location = new System.Drawing.Point(1416, 398);
            this.button_Passo5_UG4.Name = "button_Passo5_UG4";
            this.button_Passo5_UG4.Size = new System.Drawing.Size(75, 139);
            this.button_Passo5_UG4.TabIndex = 7;
            this.button_Passo5_UG4.Text = "5";
            this.button_Passo5_UG4.UseVisualStyleBackColor = true;
            // 
            // button_Passo6_UG4
            // 
            this.button_Passo6_UG4.Location = new System.Drawing.Point(1416, 575);
            this.button_Passo6_UG4.Name = "button_Passo6_UG4";
            this.button_Passo6_UG4.Size = new System.Drawing.Size(75, 139);
            this.button_Passo6_UG4.TabIndex = 8;
            this.button_Passo6_UG4.Text = "6";
            this.button_Passo6_UG4.UseVisualStyleBackColor = true;
            // 
            // button_Passo7_UG4
            // 
            this.button_Passo7_UG4.Location = new System.Drawing.Point(1416, 720);
            this.button_Passo7_UG4.Name = "button_Passo7_UG4";
            this.button_Passo7_UG4.Size = new System.Drawing.Size(75, 93);
            this.button_Passo7_UG4.TabIndex = 9;
            this.button_Passo7_UG4.Text = "7";
            this.button_Passo7_UG4.UseVisualStyleBackColor = true;
            // 
            // Form_Partida_04
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1596, 873);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1598, 858);
            this.Name = "Form_Partida_04";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Partida";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private LED led_EnergizacaoReleParada_UG4;
        private LED led1;
        private LED led2;
        private System.Windows.Forms.Button button_Passo2_UG4;
        private System.Windows.Forms.Button button_Passo7_UG4;
        private System.Windows.Forms.Button button_Passo6_UG4;
        private System.Windows.Forms.Button button_Passo5_UG4;
        private System.Windows.Forms.Button button_Passo4_UG4;
        private System.Windows.Forms.Button button_Passo3_UG4;
        private System.Windows.Forms.Button button_Passo1_UG4;
    }
}