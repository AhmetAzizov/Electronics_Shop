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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        string type, model, brand;
        int id, price;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxType.SelectedIndex < 0)
                {
                    MessageBox.Show("Error!\nProduct Type has not been selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    type = comboBoxType.SelectedItem.ToString();
                }
                id = Int32.Parse(txtID.Text);
                model = textBoxModel.Text;
                brand = textBoxBrand.Text;
                price = Int32.Parse(textBoxPrice.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Error!\nOne of the field is not in corect format or empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (type == "" | model == "" | brand == "")
            {
                MessageBox.Show("Error!\nAt least one box isn't filled", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (model.Contains(' ') | brand.Contains(' '))
            {
                MessageBox.Show("Error!\nYour values should not contains any space character!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string a = Convert.ToString(comboBoxType.SelectedItem);

            switch (a)
            {
                case "Monitor": groupBox1.Enabled = true; groupBox1.BackColor = Color.FromArgb(192,255,192); break;
                case "Smartphone": groupBox2.Enabled = true; groupBox2.BackColor = Color.FromArgb(192, 255, 192); break;
                case "Headphone": groupBox3.Enabled = true; groupBox3.BackColor = Color.FromArgb(192, 255, 192); break;
            }
            clear();

            button1.Enabled = false;
        }

        private void clear()
        {
            txtID.Clear();
            textBoxModel.Clear();
            textBoxBrand.Clear();
            textBoxPrice.Clear();
        }

        private void buttonMonitor_Click(object sender, EventArgs e)
        {
            try
            {
                int refreshRate = Int32.Parse(textBoxRefreshRate.Text);
                string panelType = textBoxPanelType.Text;
                int responseTime = Int32.Parse(textBoxResponseTime.Text);
                bool hdr = checkBoxHDR.Checked;
                Monitor newMonitor;

                if (panelType == "")
                {
                    MessageBox.Show("Error!\nAt least one box isn't filled!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                newMonitor = new Monitor(type, model, brand, id, price, refreshRate, responseTime, panelType, hdr);

                FileStream fs = new FileStream("listbox.txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(newMonitor.Data());

                sw.Close();
                fs.Close();
            }
            catch(FormatException)
            {
                MessageBox.Show("Error!\nOne of the field is not in correct format or empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            textBoxRefreshRate.Clear();
            textBoxPanelType.Clear();
            textBoxResponseTime.Clear();
            checkBoxHDR.Checked = false;
            MessageBox.Show("Item Added Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            groupBox1.BackColor = Color.FromArgb(255,192,192);
            groupBox1.Enabled = false;
            button1.Enabled = true;
        }

        private void buttonSmartphone_Click(object sender, EventArgs e)
        {
            try
            {
                string os = textBoxOS.Text;
                int ram = Int32.Parse(textBoxRAM.Text);
                bool dualSim = checkBoxDualSim.Checked;
                bool have5G = checkBox5G.Checked;
                Smartphone newSmarthone;

                if (os == "")
                {
                    MessageBox.Show("Error!\nAt least one box isn't filled!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                newSmarthone = new Smartphone(type, model, brand, id, price, os, ram, dualSim, have5G);

                FileStream fs = new FileStream("listbox.txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(newSmarthone.Data());

                sw.Close();
                fs.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Error!\nOne of the field is not in correct format or empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            textBoxOS.Clear();
            textBoxRAM.Clear();
            checkBoxDualSim.Checked = false;
            checkBox5G.Checked = false;
            MessageBox.Show("Item Added Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            groupBox2.BackColor = Color.FromArgb(255, 192, 192);
            groupBox2.Enabled = false;
            button1.Enabled = true;
        }



        private void buttonHeadphone_Click(object sender, EventArgs e)
        {
            try
            {
                int frequency = Int32.Parse(textBoxFrequency.Text);
                int impedance = Int32.Parse(textBoxImpedance.Text);
                bool wireless = checkBoxWirleless.Checked;
                bool noiseCancelling = checkBoxNoiseCancelling.Checked;
                Headphone newHeadphone;

                newHeadphone = new Headphone(type, model, brand, id, price, frequency, impedance, wireless, noiseCancelling);

                FileStream fs = new FileStream("listbox.txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(newHeadphone.Data());

                sw.Close();
                fs.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Error!\nOne of the field is not in correct format or empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            textBoxFrequency.Clear();
            textBoxImpedance.Clear();
            checkBoxWirleless.Checked = false;
            checkBoxNoiseCancelling.Checked = false;
            MessageBox.Show("Item Added Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            groupBox3.BackColor = Color.FromArgb(255, 192, 192);
            groupBox3.Enabled = false;
            button1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();

            this.Hide();
            f1.ShowDialog();
            this.Close();
        }
    }
}
