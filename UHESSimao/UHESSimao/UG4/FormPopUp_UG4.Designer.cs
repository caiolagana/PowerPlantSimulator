namespace UHESSimao
{
    partial class FormPopUp_UG4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPopUp_UG4));
            this.Botao_Verde_I_UG4 = new UHESSimao.Losango();
            this.Botao_Vermelho_O_UG4 = new UHESSimao.Losango();
            this.SuspendLayout();
            // 
            // Botao_Verde_I_UG4
            // 
            this.Botao_Verde_I_UG4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Botao_Verde_I_UG4.BackgroundImage")));
            this.Botao_Verde_I_UG4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Botao_Verde_I_UG4.Especie = "OnOff";
            this.Botao_Verde_I_UG4.Estado = true;
            this.Botao_Verde_I_UG4.Location = new System.Drawing.Point(196, 296);
            this.Botao_Verde_I_UG4.Name = "Botao_Verde_I_UG4";
            this.Botao_Verde_I_UG4.Size = new System.Drawing.Size(35, 35);
            this.Botao_Verde_I_UG4.TabIndex = 0;
            this.Botao_Verde_I_UG4.Text = "losango1";
            this.Botao_Verde_I_UG4.Click += new System.EventHandler(this.Botao_Verde_I_UG4_Click);
            // 
            // Botao_Vermelho_O_UG4
            // 
            this.Botao_Vermelho_O_UG4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Botao_Vermelho_O_UG4.BackgroundImage")));
            this.Botao_Vermelho_O_UG4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Botao_Vermelho_O_UG4.Especie = "OnOff";
            this.Botao_Vermelho_O_UG4.Estado = false;
            this.Botao_Vermelho_O_UG4.Location = new System.Drawing.Point(1, 296);
            this.Botao_Vermelho_O_UG4.Name = "Botao_Vermelho_O_UG4";
            this.Botao_Vermelho_O_UG4.Size = new System.Drawing.Size(35, 35);
            this.Botao_Vermelho_O_UG4.TabIndex = 1;
            this.Botao_Vermelho_O_UG4.Text = "losango2";
            this.Botao_Vermelho_O_UG4.Click += new System.EventHandler(this.Botao_Vermelho_O_UG4_Click);
            // 
            // FormPopUp_UG4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UHESSimao.Properties.Resources.POPUP_CMD;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(235, 405);
            this.Controls.Add(this.Botao_Vermelho_O_UG4);
            this.Controls.Add(this.Botao_Verde_I_UG4);
            this.Name = "FormPopUp_UG4";
            this.Text = "FormPopUpPartida_04";
            this.ResumeLayout(false);

        }

        #endregion

        private Losango Botao_Verde_I_UG4;
        private Losango Botao_Vermelho_O_UG4;
    }
}