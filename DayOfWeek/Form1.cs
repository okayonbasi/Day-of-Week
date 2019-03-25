using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayOfWeek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /* Disparate Variation */

        public int takeMount(int mount) 
        {
            if (mount == 1)
            {
                return 11;
            }
            else if (mount == 2)
            {
                return 12;
            }
            else return mount -2;
        }

        public int takeYear(int year, int mount) 
        {
            int y = 0;
            year = newYear(year, mount);
            if (year % 100 == 0)
            {
                y = 100;
                return y;
            }
            else 
            {
                y = year % 100;
                return y;
            }
        }

        public int takeCentury(int year, int mount)
        {
            year = newYear(year,mount);
            int century = year / 100;
            return century;
        }

        public int newYear(int year, int mount) 
        {
            if (mount == 1 || mount == 2)
            {
                year = year - 1;
                return year;
            }
            else
            {
                return year;
            }
            
        }


        public int findDayWithDisparate(int day, int mount, int year) 
        {
            int century = takeCentury(year,mount);
            int d;
            d = Convert.ToInt32((day + Math.Floor((2.6 * takeMount(mount)) - 0.2) + takeYear(year,mount) + (takeYear(year,mount) / 4 )+ (century / 4 - (2 * century))) % 7);
            return d;
        }

        public string TakeDay(int x) 
        {
            string day;
            switch(x)
            {
                case 0: day = "Pazar"; break;
                case 1: day = "Pazartesi"; break;
                case 2: day = "Salı"; break;
                case 3: day = "Çarşamba"; break;
                case 4: day = "Perşembe"; break;
                case 5: day = "Cuma"; break;
                case 6: day = "Cumartesi"; break;
                default: day = "wrong"; break;
            }
            return day;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int day = Convert.ToInt32(textBox1.Text);
            int mount = Convert.ToInt32(textBox2.Text);
            int year = Convert.ToInt32(textBox3.Text);

            int findOfWeek = findDayWithDisparate(day,mount,year);
            label5.Text = TakeDay(findOfWeek);
            label5.Visible = true;
                
        }

        /* Kraitchik's Variation */

        /****************************************************************************************************************/
        public int tMount(int m) 
        {
            int[] mount = { 1, 4, 3, 6, 1, 4, 6, 2, 5, 0, 3, 5 };
            return mount[m - 1];
        }

        public int tCentury(int c)
        {
            int[] century = { 0, 5, 3, 1 };
            return century[c];        }


        public string tDay(int x) 
        {
            string day;
            switch (x)
            {
                case 1: day = "Pazar"; break;
                case 2: day = "Pazartesi"; break;
                case 3: day = "Salı"; break;
                case 4: day = "Çarşamba"; break;
                case 5: day = "Perşembe"; break;
                case 6: day = "Cuma"; break;
                case 0: day = "Cumartesi"; break;
                default: day = "wrong"; break;
            }
            return day;

        }

        public Boolean isLeapYear(int year) 
        {
            if((year % 400 == 0 || year % 100 != 0) && (year % 4 == 0))
            {
                return true;
            }
            return false;

        }

        public int tFirst2Digit(int year) 
        {
            int x = year / 100;
            return x;
        }

        public int tLast2Digit(int year)
        {
            int x = year % 100;
            return x;
        }


        public int findDayWithKraitchiks(int day, int mount, int year)
        {
            int calculate = mod(Convert.ToInt32(Math.Floor(tLast2Digit(year) / 4.0) + tLast2Digit(year)), 7);
            int dayOfWeek = mod((day + tMount(mount) + tCentury((year / 100) % 4) + calculate),7);
                if (isLeapYear(year))
                {
                    if (mount == 1 || mount == 2)
                    {
                        if (dayOfWeek == 1)
                        {
                            dayOfWeek = 6;
                        }
                        else
                        {
                            dayOfWeek = dayOfWeek - 2;
                        }
                    }
                    else
                    {
                        if (mount == 1 || mount == 2)
                        {
                            dayOfWeek = dayOfWeek - 1;
                        }
                    }
                }
                return dayOfWeek;
            }

        static int mod(int a, int b)
        {
            return Math.Abs(a % b + b) % b;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            int day = Convert.ToInt32(textBox1.Text);
            int mount = Convert.ToInt32(textBox2.Text);
            int year = Convert.ToInt32(textBox3.Text);

            label10.Text = tDay(findDayWithKraitchiks(day, mount, year));
            label10.Visible = true;

        

        }

    }
}





