using System;
using System.Windows.Forms;

namespace Calculatriceu
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox textBox;
        private Button[] buttons;

     
      private void InitializeComponent()
{
    this.textBox = new TextBox();
    this.buttons = new Button[16]; 
    this.textBox.Location = new System.Drawing.Point(15, 30);
    this.textBox.Name = "textBox";
    this.textBox.Size = new System.Drawing.Size(250, 150); 
    this.textBox.ReadOnly = true;
    this.textBox.TabIndex = 0;
    this.Controls.Add(this.textBox);

    // Création du bouton "Suppr"
    Button buttonSuppr = new Button();
    buttonSuppr.Text = "C";
    buttonSuppr.Size = new System.Drawing.Size(70, 50);
    buttonSuppr.Location = new System.Drawing.Point(290, 30);
    buttonSuppr.Click += SupprButton_Click; 
    this.Controls.Add(buttonSuppr);

    string[] buttonLabels = new string[] 
    {
        "1", "2", "3", "+",
        "4", "5", "6", "-",
        "7", "8", "9", "*",
        ".", "0", "/", "="
    };

    int x = 10, y = 100;
    for (int i = 0; i < buttonLabels.Length; i++)
    {
        buttons[i] = new Button();
        buttons[i].Text = buttonLabels[i];
        buttons[i].Size = new System.Drawing.Size(80, 100);
        buttons[i].Location = new System.Drawing.Point(x, y);
        buttons[i].Click += Button_Click;
        this.Controls.Add(buttons[i]);

        x += 90;
        if ((i + 1) % 4 == 0)
        {
            x = 10;
            y += 100;
        }
    }

    this.ClientSize = new System.Drawing.Size(380, 520); 
    this.Name = "Form1";
    this.Text = "Calculatrice";

    this.ResumeLayout(false);
    this.PerformLayout();
}


        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            string buttonText = clickedButton.Text;

            if (buttonText == "=")
            {
                try
                {
                    var result = new System.Data.DataTable().Compute(this.textBox.Text, null);
                    this.textBox.Text = result.ToString();
                }
                catch
                {
                    this.textBox.Text = "Erreur";
                }
            }
            else
            {
                this.textBox.Text += buttonText;
            }
        }

private void SupprButton_Click(object sender, EventArgs e)
{
    if (this.textBox.Text.Length > 0)
    {
      
        this.textBox.Text = this.textBox.Text.Substring(0, this.textBox.Text.Length - 1);
    }
}

       
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
