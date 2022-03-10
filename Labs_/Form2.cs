using System;
using System.IO;
using System.Windows.Forms;

namespace Labs_
{
    public partial class Form2 : Form
    {
        public static string[] massline;

        public static string usernamecopy;
        public static string logintxt = @"D:\test\login.txt";
        public static string user;
        Form main;

        public Form2(Form mainu,  string username)
        {
            InitializeComponent();

            main = mainu;

            richTextBox1.Text = "";
             this.Text = "Второе окно";
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

                    label4.Text += "Главный админ";
                    //label2.Text = "D:\\test\\login.txt";
                }
                else
                {
                    button2.Hide();
                    textBox1.Hide();
                    label3.Hide();
                    button4.Hide();
                    using (StreamReader reader = new StreamReader(logintxt))
                    {
                        string line;
                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();
                            massline = line.Split(';');
                            if (username == massline[0])
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

                    label4.Text += massline[1];

                    switch (massline[1])
                    {
                        case "usually":
                            richTextBox1.MaxLength = 200;
                            break;
                        case "moderator":
                            label3.Show();
                            textBox1.Show();
                            button2.Show();
                            richTextBox1.Enabled = false;
                            break;
                        case "administrators":
                            button4.Show();
                            label3.Show();
                            textBox1.Show();
                            button2.Show();
                            break;
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
                        using (StreamWriter wL = new StreamWriter(@"D:\\test\\login.txt"))
                            wL.WriteLine(richTextBox1.Text);
                    }
                    else
                    {
                        using (StreamWriter wU = new StreamWriter(@"D:\\test\\users\\" + textBox1.Text + ".txt"))
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
                    label2.Text = usernamecopy;
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
                            massline = line.Split(';');
                            if (usernamecopy == massline[0])
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
                        label2.Text =  usernamecopy;
                    }
                    if (massline[1] == "R") button1.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!: " + ex);
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form ols = new Form4();
            ols.Show();
        }
    }
}
