using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        //bool ListExist = false;
        bool issorted = false, listcreated = false;
        List<Student> students = new List<Student>();
        public Form1()
        {
            InitializeComponent();
            InitializeMyControl();
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void InitializeMyControl()
        {
            textBox1.Text = "Open file.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = null;
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.InitialDirectory = "c:\\users";
                openFileDialog1.Filter = "txt files| *.txt";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFileDialog1.FileName;
                }
            }

            if (fileName != null)
            {
                string[] text = File.ReadAllLines(fileName);
                if (text.Length == 0)
                {
                    MessageBox.Show("file is empty");
                }
                else
                {
                    textBox1.Clear();
                    if (listcreated)
                    {
                        int cnt = students.Count;
                        for (int i = 0; i < cnt; i++)
                        {
                            students.Remove(students[students.Count - 1]);
                        }
                    }
                    try
                    {
                        for (int i = 0; i < text.Length; i++)
                        {
                            string[] str = text[i].Split(new Char[] { ' ' });
                            students.Add(new Student(str[1], Convert.ToInt32(str[0])));
                            textBox1.AppendText(students[i].printinfo());
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        MessageBox.Show("uncorrect file");
                    }
                    button2.Visible = true;
                    button13.Visible = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button6.Enabled = true;
                    button7.Enabled = true;
                    button8.Enabled = true;
                    button9.Enabled = true;
                    button10.Enabled = true;
                    button11.Enabled = true;
                    button12.Enabled = true;
                    button13.Enabled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                Student temp = Serchclass.Liniersearch(students, Convert.ToInt32(textBox2.Text));
                bool flag = false;
                if (temp != null)
                {
                    for (int i = 0; i < students.Count; i++)
                    {
                        if (temp.Name == students[i].Name || temp.Number == students[i].Number)
                        {
                            MessageBox.Show("this element already exist");
                            flag = true;
                            break;
                        }
                    }
                }
                if (!flag)
                {
                    try
                    {
                        students.Add(new Student(textBox3.Text, Convert.ToInt32(textBox2.Text)));
                        textBox1.AppendText(students[students.Count - 1].printinfo());
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("uncorrect data");
                    }
                }
            }

            else
            {
                MessageBox.Show("wrong data");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            textBox4.Clear();
            int swaps, equal;
            Sortclass.gnomsort(students,out equal,out swaps);
            
            for(int k =0;k<students.Count;k++)
            {
                textBox4.AppendText(students[k].printinfo());
            }
            MessageBox.Show("number of iterations: " + swaps + "\n" + "number of comparisons: " + equal);
            issorted = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int swaps=0, equal=0;
            textBox4.Clear();
            Student[] studarr = new Student[students.Count];
            for(int i=0; i<studarr.Length;i++)
            {
                studarr[i] = students[i];
            }
            Sortclass.quicksort(studarr, 0, studarr.Length-1,ref equal,ref swaps);
            for (int k = 0; k < studarr.Length; k++)
            {
                textBox4.AppendText(studarr[k].printinfo());
            }
            MessageBox.Show("number of iterations: " + swaps + "\n" + "number of comparisons: " + equal);
            issorted = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            int swaps = 0, equal = 0;
            Student[] studarr = new Student[students.Count];
            for (int i = 0; i < studarr.Length; i++)
            {
                studarr[i] = students[i];
            }
            Sortclass.Pyramid_Sort(studarr, studarr.Length,ref equal,ref swaps);
            for (int k = 0; k < studarr.Length; k++)
            {
                textBox4.AppendText(studarr[k].printinfo());
            }
            MessageBox.Show("number of iterations: " + swaps + "\n" + "number of comparisons: " + equal);
            issorted = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            int swaps = 0, equal = 0;
            Student[] studarr = new Student[students.Count];
            for (int i = 0; i < studarr.Length; i++)
            {
                studarr[i] = students[i];
            }
            Sortclass.Cocktailsort(studarr,ref equal,ref swaps);
            for (int k = 0; k < studarr.Length; k++)
            {
                textBox4.AppendText(studarr[k].printinfo());
            }
            MessageBox.Show("number of iterations: " + swaps + "\n" + "number of comparisons: " + equal);
            issorted = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            int swaps = 0, equal = 0;
            Student[] studarr = new Student[students.Count];
            for (int i = 0; i < studarr.Length; i++)
            {
                studarr[i] = students[i];
            }
            Sortclass.BubbleSort(studarr,ref equal,ref swaps);
            for (int k = 0; k < studarr.Length; k++)
            {
                textBox4.AppendText(studarr[k].printinfo());
            }
            MessageBox.Show("number of iterations: " + swaps + "\n" + "number of comparisons: " + equal);
            issorted = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                //bool excep = true;
                int serchkey = 0;
                try
                {
                    serchkey = Convert.ToInt32(textBox5.Text);
                    int equal = 0;
                    Student flag = Serchclass.Liniersearch(students, serchkey, ref equal);
                    if (flag != null)
                        MessageBox.Show(flag.printinfo() + "number of comparisons: " + equal);
                    else
                        MessageBox.Show("elemnt not exist");
                }
                catch(FormatException)
                {
                    MessageBox.Show("uncorrect data");
                }
                //int equal = 0;
                //Student flag = Serchclass.Liniersearch(students, serchkey, ref equal);
                //if (flag != null)
                //    MessageBox.Show(flag.printinfo() + "number of comparisons: " + equal);
                //else
                //    MessageBox.Show("elemnt not exist");
            }
            else
                MessageBox.Show("no key inputed");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (issorted && textBox5.Text != "")
            {
                try
                {
                    int equal = 0;
                    int serchkey = Convert.ToInt32(textBox5.Text);
                    Student[] studarr = new Student[students.Count];
                    for (int i = 0; i < studarr.Length; i++)
                    {
                        studarr[i] = students[i];
                    }
                    Student flag = Serchclass.BinarySearch(studarr, serchkey, ref equal);
                    if (flag != null)
                        MessageBox.Show(flag.printinfo() + "number of comparisons: " + equal);
                    else
                        MessageBox.Show("elemnt not exist");
                }
                catch(FormatException)
                {
                    MessageBox.Show("uncorrect data");
                }
            }
            else
                MessageBox.Show("List must be sorted, or you don't enter the key");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (issorted && textBox5.Text != "")
            {
                try
                {
                    int equal = 0;
                    int serchkey = Convert.ToInt32(textBox5.Text);
                    Student[] studarr = new Student[students.Count];
                    for (int i = 0; i < studarr.Length; i++)
                    {
                        studarr[i] = students[i];
                    }
                    Student flag = Serchclass.Interpolserch(studarr, serchkey, ref equal);
                    if (flag != null)
                        MessageBox.Show(flag.printinfo() + "number of comparisons: " + equal);
                    else
                        MessageBox.Show("elemnt not exist");
                }
                catch (FormatException)
                {
                    MessageBox.Show("uncorrect data");
                }
            }
            else
                MessageBox.Show("List must be sorted, or you don't enter the key");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (issorted && textBox5.Text != "")
            {
                try
                {
                    int equal = 0;
                    int serchkey = Convert.ToInt32(textBox5.Text);
                    Student[] studarr = new Student[students.Count];
                    for (int i = 0; i < studarr.Length; i++)
                    {
                        studarr[i] = students[i];
                    }
                    Student flag = Serchclass.fibMonaccianSearch(studarr, serchkey, studarr.Length - 1, ref equal);
                    if (flag != null)
                        MessageBox.Show(flag.printinfo() + "number of comparisons: " + equal);
                    else
                        MessageBox.Show("elemnt not exist");
                }
                catch (FormatException)
                {
                    MessageBox.Show("uncorrect data");
                }
            }
            else
                MessageBox.Show("List must be sorted, or you don't enter the key");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (issorted && textBox5.Text!="")
            {
                try
                {
                    int equal = 0;
                    int serchkey = Convert.ToInt32(textBox5.Text);
                    Student[] studarr = new Student[students.Count];
                    for (int i = 0; i < studarr.Length; i++)
                    {
                        studarr[i] = students[i];
                    }
                    Student flag = Serchclass.exponentialSearch(studarr, studarr.Length - 1, serchkey, ref equal);
                    if (flag != null)
                        MessageBox.Show(flag.printinfo() + "number of comparisons: " + equal);
                    else
                        MessageBox.Show("elemnt not exist");
                }
                catch (FormatException)
                {
                    MessageBox.Show("uncorrect data");
                }
            }
            else
                MessageBox.Show("List must be sorted, or you don't enter the key");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                try
                {
                    int serchkey = Convert.ToInt32(textBox2.Text);
                    Student todel = Serchclass.Liniersearch(students, serchkey);
                    if (todel == null)
                        MessageBox.Show("that element not exist");
                    students.Remove(todel);
                    textBox1.Clear();
                    for (int i = 0; i < students.Count; i++)
                    {
                        textBox1.AppendText(students[i].printinfo());
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("uncorrect data");
                }
            }
            else
            {
                MessageBox.Show("wrong data");
            }
        }
    }
}
