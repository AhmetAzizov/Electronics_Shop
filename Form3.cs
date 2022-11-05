using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Exam_Project_2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Error!\nPlease, select a product to continue!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] item = Format();

            items(item);
        }

        // this method puts all the data into the labels.
        private void items(string[] item)
        {
            labelIDname.Text = item[3];
            label1name.Text = item[7];
            labelBrandname.Text = item[1];
            label2name.Text = item[5];
            labelModelname.Text = item[2];
            label3name.Text = item[6];
            labelPricename.Text = item[4];
            label4name.Text = item[8];
        }

        // in this method, we take the chosen value from the listbox and put it on correct format to be able to compare it with the date in our file
        private string[] Format()
        {
            string[] listbox = Convert.ToString(listBox1.SelectedItem).Split(':');

            string word = $"{listbox[0]}{listbox[1]}";

            string[] listbox2 = word.Split(' ');

            string list = $"{selectedItem}%{listbox2[0]}%{listbox2[1]}";

            string[] words = Read(list).Split('%');

            return words;
        }

        // in this method, we read the file and choose the row which matches the product type, brand name, and model.
        private string Read(string a)
        {
            string d, c, b = "";
            FileStream fs = new FileStream("listbox.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            while (!sr.EndOfStream)
            {
                d = sr.ReadLine();

                string[] words = d.Split('%');

                c = $"{words[0]}%{words[1]}%{words[2]}";

                if (a == c)
                {
                    b = d;
                }
            }

            sr.Close();
            fs.Close();
            return b;
        }

        // this method clears all the labels.
        private void labelClear()
        {
            labelIDname.Text = "";
            labelBrandname.Text = "";
            labelModelname.Text = "";
            labelPricename.Text = "";
            label1name.Text = "";
            label2name.Text = "";
            label3name.Text = "";
            label4name.Text = "";
        }

        string selectedItem;

        // this button takes the product type from the combobox and puts all the items with the same product type into our listbox.
        private void button1_Click(object sender, EventArgs e)
        {
            labelClear();

            selectedItem = Convert.ToString(comboBox1.SelectedItem);

            listBox1.Items.Clear();

            example(selectedItem);
        }

        private void example(string product) 
        {
            try
            {
                switch (product)
                {
                    case "Monitor":
                        label1.Text = "Panel Type:";
                        label2.Text = "Refresh Rate:";
                        label3.Text = "Response Time:";
                        label4.Text = "HDR:";

                        FileStream fs = new FileStream("listbox.txt", FileMode.Open, FileAccess.Read);
                        StreamReader sr = new StreamReader(fs);

                        while (!sr.EndOfStream)
                        {
                            string[] words = sr.ReadLine().Split('%');

                            if (words[0] == "Monitor")
                            {
                                listBox1.Items.Add($"{words[1]}: {words[2]}");
                            }
                        }

                        sr.Close();
                        fs.Close();

                        break;
                    case "Smartphone":
                        label1.Text = "Dual Sim:";
                        label2.Text = "OS:";
                        label3.Text = "RAM:";
                        label4.Text = "5G:";

                        FileStream fs1 = new FileStream("listbox.txt", FileMode.Open, FileAccess.Read);
                        StreamReader sr1 = new StreamReader(fs1);

                        while (!sr1.EndOfStream)
                        {
                            string[] words = sr1.ReadLine().Split('%');

                            if (words[0] == "Smartphone")
                            {
                                listBox1.Items.Add($"{words[1]}: {words[2]}");
                            }
                        }

                        sr1.Close();
                        fs1.Close();

                        break;
                    case "Headphone":
                        label1.Text = "Wireless:";
                        label2.Text = "Frequency:";
                        label3.Text = "Impedance:";
                        label4.Text = "Noise Cancelling:";

                        FileStream fs2 = new FileStream("listbox.txt", FileMode.Open, FileAccess.Read);
                        StreamReader sr2 = new StreamReader(fs2);

                        while (!sr2.EndOfStream)
                        {
                            string[] words = sr2.ReadLine().Split('%');

                            if (words[0] == "Headphone")
                            {
                                listBox1.Items.Add($"{words[1]}: {words[2]}");
                            }
                        }

                        sr2.Close();
                        fs2.Close();

                        break;
                    default:
                        break;
                }
            }
            catch (FileNotFoundException)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();

            this.Hide();
            f1.ShowDialog();
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Error!\nPlease, select a product to continue!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] listbox = Convert.ToString(listBox1.SelectedItem).Split(':');

            string word = $"{listbox[0]}{listbox[1]}";

            string[] listbox2 = word.Split(' ');

            string list = $"{selectedItem}%{listbox2[0]}%{listbox2[1]}";

            string data = "";

            FileStream fo = new FileStream("listbox.txt", FileMode.Open, FileAccess.Read);
            FileStream fc = new FileStream("temporary.txt", FileMode.Create, FileAccess.Write);
            StreamReader sr = new StreamReader(fo);
            StreamWriter sw = new StreamWriter(fc);

            while(!sr.EndOfStream)
            {
                 data = sr.ReadLine();

                string[] Row = data.Split('%');

                string listboxItem = $"{Row[0]}%{Row[1]}%{Row[2]}";

                if (list == listboxItem) { }
                else
                {
                    sw.WriteLine(data);
                }

            }

            sw.Close();
            sr.Close();
            fc.Close();
            fo.Close();

            File.Replace("temporary.txt", "listbox.txt", "Backup.txt");
            File.Delete("temporary.txt");

            listBox1.Items.Clear();
            example(selectedItem);
            labelClear();
        }
    }
}
