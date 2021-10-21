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

namespace MapGameForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            Button[] btnArray = { button1, button2, button3, button4 };
            int temp;
            int currentFlag,correctFlagLocation;
            int[] flag = new int[3];
            string[] imageCodeArray;
            string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Resources");
            imageCodeArray = Directory.GetFiles(filePath, "*");
                currentFlag = r.Next(0, 256);
                temp = r.Next(0, 256);
                while (temp == currentFlag)
                {
                    temp = r.Next(0, 256);
                }
                flag[0] = temp;
                temp = r.Next(0, 256);
                while (temp == currentFlag || temp == flag[0])
                {
                    temp = r.Next(0, 256);
                }
                flag[1] = temp;
                temp = r.Next(0, 256);
                while (temp == currentFlag || temp == flag[0] || temp == flag[1])
                {
                    temp = r.Next(0, 256);
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
        public void button1_Click(object sender, EventArgs e)
        {
           int buttonInt = Array.IndexOf(btnArray, sender as Button); //this is an error, cannot refer to btnArray as it doesnt exist in this context. not sure how to get around this
            
        }
    }

}
