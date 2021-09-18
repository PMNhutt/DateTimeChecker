using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateTimeChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
  
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure to exit?", "Confirm", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }      

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        } 

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //set
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte x,y; short z; 
            //check textbox có null hay có phải là số hay không?
            Boolean isCorrectFormat()
            {
            
            if (string.IsNullOrEmpty(textBox2.Text) || !byte.TryParse(textBox2.Text, out x))
            {
                DialogResult dialog = MessageBox.Show("Input data for Day is incorrect format!", 
                    "Error", MessageBoxButtons.OK);
                    return false;
            }
            else if (string.IsNullOrEmpty(textBox3.Text) || !byte.TryParse(textBox3.Text, out y))
                {
                    DialogResult dialog = MessageBox.Show("Input data for Month is incorrect format!",
                    "Error", MessageBoxButtons.OK);
                    return false;
                }
            else if (string.IsNullOrEmpty(textBox4.Text) || !short.TryParse(textBox4.Text, out z))
                {
                    DialogResult dialog = MessageBox.Show("Input data for Year is incorrect format!",
                    "Error", MessageBoxButtons.OK);
                    return false;
                }                                                      

                return true;
            }


            byte.TryParse(textBox2.Text, out x);
            byte.TryParse(textBox3.Text, out y);
            short.TryParse(textBox4.Text, out z);
            //check textbox out of range
            Boolean isValidRange()
            {

            if (x < 1 || x > 31)
            {
                DialogResult dialog = MessageBox.Show("Input data for Day is out of range!",
                    "Error", MessageBoxButtons.OK);
                    return false;
            }
            else if (y < 1 || y > 12)
                {
                    DialogResult dialog = MessageBox.Show("Input data for Month is out of range!",
                        "Error", MessageBoxButtons.OK);
                    return false;
                }
            else if (z < 1000 || z > 3000)
                {
                    DialogResult dialog = MessageBox.Show("Input data for Year is out of range!",
                        "Error", MessageBoxButtons.OK);
                    return false;
                }
               return true;
                
            }

            while ((isCorrectFormat() == true) && (isValidRange() == true))
            {
                //check Day in Month

                byte DayInMonth(short Year, byte Month)
                {
                    byte Day = 0;
                    if (Month == 1 || Month == 3 || Month == 5 || Month == 8 || Month == 7 || Month == 10
                        || Month == 12)
                    {
                        Day = 31;
                    }
                    else if (Month == 4 || Month == 6 || Month == 9 || Month == 11)
                    {
                        Day = 30;
                    }
                    else if (Month == 2)
                    {
                        if ((Year % 400) == 0)
                        {
                            Day = 29;
                        }
                        else if ((Year % 100) == 0)
                        {
                            Day = 28;
                        }
                        else if ((Year % 4) == 0)
                        {
                            Day = 29;
                        }
                        else
                        {
                            Day = 28;
                        }
                    }
                    return Day;
                }

                //check valid date
                Boolean IsValidDate(byte Day, byte Month, short Year)
                {
                    if (Month >= 1 && Month <= 12)
                    {
                        if (Day >= 1)
                        {
                            if (Day <= DayInMonth(Year, Month))
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }

                if (IsValidDate(x, y, z) == true)
                {
                    DialogResult dialog = MessageBox.Show($"{x}/{y}/{z} is correct date time!", "Message",
                        MessageBoxButtons.OK);
                    break;
                }
                else
                {
                    DialogResult dialog = MessageBox.Show($"{x}/{y}/{z} is NOT correct date time!", "Message",
                        MessageBoxButtons.OK);
                    break;
                }
            }
                        
            
        }

    }
}
