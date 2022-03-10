using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labs_
{
    public partial class Form4 : Form
    {
        private const string path_to_list_users = @"D:\test\login.txt";
        private ArrayList list_of_role = new ArrayList() { "usually", "moderator", "administrators" };
        private List<users> list_of_users = new List<users>();
        private bool remote;

        public Form4()
        {
            InitializeComponent();

            get_data();

            comboBox1.DataSource = list_of_users;
            comboBox1.DisplayMember = "log";

            comboBox2.DataSource = list_of_role;
            comboBox1.SelectedIndex = list_of_role.IndexOf(list_of_users[comboBox1.SelectedIndex].role);
        }

        private void get_data()
        {
            using (StreamReader reader = new StreamReader(path_to_list_users))
            {
                string line;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();

                    string[] temp_data_users = line.Split(';');

                    list_of_users.Add(new users() { log = temp_data_users[0], role = temp_data_users[1], paths = temp_data_users[2] });

                }
            }
        }

        public class users
        {
            public string log { get; set; }
            public string role { get; set; }
            public string paths { get; set; }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (remote)
            {
                comboBox2.SelectedIndex = list_of_role.IndexOf(list_of_users[comboBox1.SelectedIndex].role);
                remote = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (remote)
            {
                list_of_users[comboBox1.SelectedIndex].role = list_of_role[comboBox2.SelectedIndex].ToString();
                remote = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter file_with_data_of_users = new StreamWriter(path_to_list_users, false, Encoding.Default))
            {
                foreach ( users u in list_of_users)
                {
                    file_with_data_of_users.WriteLine(u.log + ";" + u.role + ";" + u.paths + ";");
                }
            }
        }

        private void comboBoxs(object sender, EventArgs e)
        {
            remote = true;
        }
    }
}
