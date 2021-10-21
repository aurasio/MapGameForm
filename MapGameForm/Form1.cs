using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Resources;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MapGameForm
{
    public partial class Form1 : Form
    {
        public int currentFlag, correctFlagLocation;
        public static string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Resources");
        public int incrementorCor = 0;
        public int incrementorTotal = 0;
        public string[] imageCodeArray = Directory.GetFiles(filePath, "*");
        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            initiallize();
        }
        public void initiallize()
        {
            Button[] btnArray = { button1, button2, button3, button4 };
            for (int i = 0; i < 4; i++)
            {
                btnArray[i].BackColor = Color.White;
            }
            createQuestion();

        }
        public void createQuestion()
        {
            Button[] btnArray = { button1, button2, button3, button4 };
            Random r = new Random();
            int temp;
            int[] flag = new int[3];
            currentFlag = r.Next(0, imageCodeArray.Length - 1);
            temp = r.Next(0, imageCodeArray.Length - 1);
            while (temp == currentFlag)
            {
                temp = r.Next(0, imageCodeArray.Length - 1);
            }
            flag[0] = temp;
            temp = r.Next(0, imageCodeArray.Length - 1);
            while (temp == currentFlag || temp == flag[0])
            {
                temp = r.Next(0, imageCodeArray.Length - 1);
            }
            flag[1] = temp;
            temp = r.Next(0, imageCodeArray.Length - 1);
            while (temp == currentFlag || temp == flag[0] || temp == flag[1])
            {
                temp = r.Next(0, imageCodeArray.Length - 1);
            }
            flag[2] = temp;
            pictureBox1.ImageLocation = imageCodeArray[currentFlag];
            temp = 0;
            correctFlagLocation = r.Next(0, 4);
            for (int i = 0; i < 4; i++)
            {
                if (correctFlagLocation == i)
                {
                    btnArray[i].Text = imageCodeArray[currentFlag].Replace(filePath, "").Replace("\\", "").Replace(".png", "");
                }
                else
                {
                    btnArray[i].Text = imageCodeArray[flag[temp]].Replace(filePath, "").Replace("\\", "").Replace(".png", "");
                    temp++;
                }
            }
        }

        public void questionResult(int buttonNum,bool correct)
        {
            Button[] btnArray = { button1, button2, button3, button4 };

            if(correct==true)
            {
                btnArray[buttonNum].BackColor = Color.Green;
                incrementorCor++;
                incrementorTotal++;
                increment();
            }
            else
            {
                btnArray[buttonNum].BackColor = Color.Red;
                btnArray[correctFlagLocation].BackColor = Color.Green;
                incrementorTotal++;
                increment();
            }
            Refresh();
            Thread.Sleep(1000);
        }
        public void button1_Click(object sender, EventArgs e)
        {
            button_click(sender as Button);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button_click(sender as Button);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button_click(sender as Button);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button_click(sender as Button);
        }
        public void button_click(object sender)
        {
            Button[] btnArray = { button1, button2, button3, button4 };
            int buttonInt = Array.IndexOf(btnArray, sender as Button);
            bool correct;
            if (buttonInt == correctFlagLocation)
            {
                correct = true;
            }
            else
            {
                correct = false;
            }
            questionResult(buttonInt, correct);
            initiallize();
        }
        public void increment()
        {
            label1.Text = incrementorCor + "/" + incrementorTotal;
        }

    }

}
