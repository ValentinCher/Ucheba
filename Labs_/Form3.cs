using System;
using System.IO;
using System.Windows.Forms;

namespace Labs_
{
    public partial class Form3 : Form
    {
        public static string[] massline1;

        public static string usernamecopy;
        public static string logintxt = @"D:\test\logpass.txt";
        public static string user;

        public Form3(string username)
        {
            InitializeComponent();

            this.Text = "Ролевой доступ";
            label1.Text = "Здравствуйте, " + username;
            usernamecopy = username;
            try
            {
                if (username == "admin")
                {
                    using (StreamReader sr = new StreamReader(logintxt))
                    {

                        while (!sr.EndOfStream)
                        {
                            while (!sr.EndOfStream)
                                richTextBox1.Text += sr.ReadLine() + "\n";
                        }
                    }
                    //label2.Text = "D:\\test\\login.txt";
                }
                else
                {
                    button2.Hide();
                    button3.Hide();
                    textBox1.Hide();
                    label3.Hide();
                    using (StreamReader reader = new StreamReader(logintxt))
                    {
                        string line;
                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();
                            massline1 = line.Split(';');
                            if (username == massline1[0])
                            {
                                using (StreamReader reader2 = new StreamReader(@"D:\\test\\users\\" + usernamecopy + ".txt"))
                                {
                                    line = "";
                                    while (!reader2.EndOfStream)
                                        richTextBox1.Text += reader2.ReadLine() + "\n";
                                }
                                break;
                            }

                        }
                        label2.Text = "Рабочая область " + usernamecopy;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!: " + ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (usernamecopy != "admin")
                {
                    using (StreamWriter writer = new StreamWriter(@"D:\\test\\users\\" + usernamecopy + ".txt"))
                        writer.WriteLine(richTextBox1.Text);
                    MessageBox.Show("Пользователь отработал");
                }
                else
                {
                    if (textBox1.Text == "")
                    {
                        using (StreamWriter wL = new StreamWriter(@"D:\\test\\logpass.txt"))
                            wL.WriteLine(richTextBox1.Text);
                    }
                    else
                    {
                        using (StreamWriter wU = new StreamWriter(@"D:\\test\\users\\" + user + ".txt"))
                            wU.WriteLine(richTextBox1.Text);
                    }
                    MessageBox.Show("Сохранено!");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!: " + ex);
            }
        
    }

        private void button2_Click(object sender, EventArgs e)
        {
            user = textBox1.Text;
            richTextBox1.Text = "";
            try
            {
                using (StreamReader sr = new StreamReader(@"D:\\test\\users\\" + user + ".txt"))
                {
                    while (!sr.EndOfStream)
                        richTextBox1.Text += sr.ReadLine() + "\n";
                }
                label2.Text = "D:\\test\\users\\" + user + ".txt";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!: " + ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            try
            {
                if (usernamecopy == "admin")
                {
                    using (StreamReader sr = new StreamReader(logintxt))
                    {
                        while (!sr.EndOfStream)
                            richTextBox1.Text += sr.ReadLine() + "\n";
                    }
                    //label2.Text = "D:\\test\\login.txt";
                }
                else
                {
                    button2.Hide();
                    textBox1.Hide();
                    label3.Hide();
                    using (StreamReader reader = new StreamReader(logintxt))
                    {
                        string line;
                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();
                            massline1 = line.Split(';');
                            if (usernamecopy == massline1[0])
                            {
                                using (StreamReader reader2 = new StreamReader(@"D:\\test\\users\\" + usernamecopy + ".txt"))
                                {
                                    line = "";
                                    while (!reader2.EndOfStream)
                                        richTextBox1.Text += reader2.ReadLine() + "\n";
                                }
                                break;
                            }

                        }
                        label2.Text = "D:\\test\\users\\" + usernamecopy + ".txt";
                    }
                    if (massline1[1] == "INTERN") button1.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!: " + ex);
            }
        }
    }
}

