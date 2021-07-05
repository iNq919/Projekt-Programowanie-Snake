
namespace SnakeNS
{
    partial class Snake
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Wynik = new System.Windows.Forms.Label();
            this.Jedzenie = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtHighScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Wynik
            // 
            this.Wynik.AutoSize = true;
            this.Wynik.Location = new System.Drawing.Point(12, 9);
            this.Wynik.Name = "Wynik";
            this.Wynik.Size = new System.Drawing.Size(98, 21);
            this.Wynik.TabIndex = 0;
            this.Wynik.Text = "Wynik: 0";
            // 
            // Jedzenie
            // 
            this.Jedzenie.AutoSize = true;
            this.Jedzenie.BackColor = System.Drawing.Color.Red;
            this.Jedzenie.Location = new System.Drawing.Point(454, 121);
            this.Jedzenie.Name = "Jedzenie";
            this.Jedzenie.Size = new System.Drawing.Size(21, 21);
            this.Jedzenie.TabIndex = 1;
            this.Jedzenie.Text = " ";
            // 
            // txtHighScore
            // 
            this.txtHighScore.AutoSize = true;
            this.txtHighScore.Location = new System.Drawing.Point(12, 30);
            this.txtHighScore.Name = "txtHighScore";
            this.txtHighScore.Size = new System.Drawing.Size(186, 21);
            this.txtHighScore.TabIndex = 2;
            this.txtHighScore.Text = "Najlepszy wynik:";
            // 
            // Snake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.txtHighScore);
            this.Controls.Add(this.Jedzenie);
            this.Controls.Add(this.Wynik);
            this.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Snake";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.Load += new System.EventHandler(this.Snake_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Snake_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Wynik;
        private System.Windows.Forms.Label Jedzenie;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label txtHighScore;
    }
}

