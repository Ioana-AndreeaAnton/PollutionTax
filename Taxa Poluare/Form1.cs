using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taxa_Poluare
{
    

    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Text = " ";
            comboBox1.Items.Add("Hibrid");
            comboBox1.Items.Add("Electric");
            comboBox1.Items.Add("Euro 6");
            comboBox1.Items.Add("Euro 5");
            comboBox1.Items.Add("Euro 4");
            comboBox1.Items.Add("Euro 3");
            comboBox1.Items.Add("Euro 2");
            comboBox1.Items.Add("Euro 1");
            comboBox1.Items.Add("Non-Euro");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBoxB.Clear();
            textBoxD.Clear();
            textBoxE.Clear();
            textBoxB.Enabled = false;
            textBoxD.Enabled = false;
            textBoxE.Enabled = false;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    textBox1.Text = "-";
                    textBox2.Text = "-";
                    textBoxB.Text="0";
                    textBoxD.Text = "0";
                   
                    break;
                case 1:
                    textBox1.Text = "-";
                    textBox2.Text = "-";
                    textBoxB.Text = "0";
                    textBoxD.Text = "0";
                    break;
                case 2:
                    textBox1.Text = "-";
                    textBox2.Text = "-";
                    textBoxB.Text = "0";
                    textBoxD.Text = "0";
                    break;
                case 6:
                    textBox1.Text = "-";
                    textBoxB.Text = "16";

                    break;
                case 7:
                    textBox1.Text = "-";
                    textBoxB.Text = "16";

                    break;
                case 8:
                    textBox1.Text = "-";
                    textBoxB.Text = "16";

                    break;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double A, B, C, D, E;
            //A=Emisia de CO2
            //B=Nivelul taxei specifice
            //C=cilindree
            //D=taxa specifica pe cilindree
            //E=cota de reducere a taxei
            //vom folosi conversia ToDouble
            //vom folosi blocuri try/catch
            try
            {
                if (textBox1.Text == "-") A = 1;
                else
                A = Convert.ToDouble(textBox1.Text);
                if(textBox1.Text=="-" && (comboBox1.Text == "Euro 2" || comboBox1.Text == "Euro 1" || comboBox1.Text == "Non-Euro"))
                {
                    A = 1;
                    textBoxB.Text = "16";

                }
                if (A <= 120 && (comboBox1.Text != "Euro 2" && comboBox1.Text != "Euro 1" && comboBox1.Text != "Non-Euro")) textBoxB.Text = "0";
                if (A >= 121 && A <= 210) textBoxB.Text = "1";
                if (A >= 211 && A <= 270) textBoxB.Text = "4";
                if (A >= 271) textBoxB.Text = "8";
                B = Convert.ToDouble(textBoxB.Text);


                try
                {
                    if (textBox2.Text == "-")
                    {
                        C = 1;
                       //D = Convert.ToDouble(textBoxD.Text);
                    }
                    else
                        C = Convert.ToDouble(textBox2.Text);
                    if (C <= 2000 && comboBox1.Text == "Euro 5")
                    {
                        textBoxD.Text = "1.3";
                       // D = Convert.ToDouble(textBoxD.Text);
                    }
                    if (C > 2001 && comboBox1.Text == "Euro 5")
                    {
                        textBoxD.Text = "0.39";
                        //D = Convert.ToDouble(textBoxD.Text);
                    }
                    if (C <= 2000 && comboBox1.Text == "Euro 4")
                    {
                        textBoxD.Text = "0.13";
                        //D = Convert.ToDouble(textBoxD.Text);
                    }
                    if (C >= 2001 && comboBox1.Text == "Euro 4")
                    {
                        textBoxD.Text = "3";
                       // D = Convert.ToDouble(textBoxD.Text);
                    }
                    if (C <= 2000 && (comboBox1.Text == "Euro 3" || comboBox1.Text == "Euro 2" || comboBox1.Text == "Euro 1" || comboBox1.Text == "Non-Euro"))
                    {
                        textBoxD.Text = "9";
                       // D = Convert.ToDouble(textBoxD.Text);
                    }
                    if (C >= 2001 && (comboBox1.Text == "Euro 3" || comboBox1.Text == "Euro 2" || comboBox1.Text == "Euro 1" || comboBox1.Text == "Non-Euro"))
                    {
                        textBoxD.Text = "16";
                        //D = Convert.ToDouble(textBoxD.Text);

                    }
                    D = Convert.ToDouble(textBoxD.Text);

                    try
                    {
                        if (Convert.ToDouble(textBox3.Text) == 0)
                        {
                            textBoxE.Text = "0";
                           // E = Convert.ToDouble(textBoxE.Text);
                        }
                        if (Convert.ToDouble(textBox3.Text) < 1 && Convert.ToDouble(textBox3.Text) > 0)
                        {
                            textBoxE.Text = "10";
                           // E = Convert.ToDouble(textBoxE.Text);
                        }
                        if (Convert.ToDouble(textBox3.Text) >= 1 && Convert.ToDouble(textBox3.Text) < 3)
                        {
                            textBoxE.Text = "30";
                           // E = Convert.ToDouble(textBoxE.Text);
                        }
                        if (Convert.ToDouble(textBox3.Text) >= 3 && Convert.ToDouble(textBox3.Text) < 5)
                        {
                            textBoxE.Text = "40";
                           // E = Convert.ToDouble(textBoxE.Text);
                        }
                        if (Convert.ToDouble(textBox3.Text) >= 5 && Convert.ToDouble(textBox3.Text) < 10)
                        {
                            textBoxE.Text = "60";
                            //E = Convert.ToDouble(textBoxE.Text);
                        }
                        if (Convert.ToDouble(textBox3.Text) >= 10)
                        {
                            textBoxE.Text = "80";
                           // E = Convert.ToDouble(textBoxE.Text);
                        }
                        E = Convert.ToDouble(textBoxE.Text);
                        String text = "Suma de plata: \r\n";
                        text += (((A*B*30/100)+(C*D*70/100))*(100-E)/100)/ 100;
                        textBoxRez.Text = text;
                    }






                    catch (Exception)
                    {
                        MessageBox.Show("Verificati valoarea introdusa pentru Vechimea autovehiculului", "Atentie!");
                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("Verificati valoarea introdusa pentru Cilindree", "Atentie!");
                }
              

            }
            catch (Exception)
            {
                MessageBox.Show("Verificati valoarea introdusa pentru Emisia de CO2", "Atentie!");
                }

        }

       
    }
}