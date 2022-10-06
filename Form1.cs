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


namespace Food_
{
    public partial class Form1 : Form
    {
        public string FP = null;
        
        public Form1()
        {
            
            StartItems();
            if (File.Exists(Application.StartupPath + "\\config.txt"))
            {
                FP = File.ReadAllLines(Application.StartupPath + "\\config.txt").Last();
                filepathoutput.Text = FP;
            }                        
        }
        private void StartItems()
        {
            InitializeComponent();

            SearchPanel.BringToFront();
            AddItemPanel.SendToBack();
            AddItemLBL.Visible = false;
            //panel4.SendToBack();
            AddNewItemsVisibleFalse();
            bar.Height = searchBTN.Height;
            bar.Top = searchBTN.Top;
            // AddItemsPanel.Visible = false;
        }
        private void itemNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBox1.Items.Clear();
                string filePath = FP;
                FileStream inFile = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);
                string record;
                string search = itemNameBox.Text.Trim();
                itemNameBox.Clear();
                itemNameBox.Text = search;
                //MessageBox.Show(search);
                record = reader.ReadLine();
                while (record != null)
                {
                    if (record.Contains(search))
                    {
                        string[] output = record.Split(',');

                        listBox1.Items.Add(("Item Name: " + output[0].ToString() + "|   Isle: " + output[1].ToString() + "|   Side: " + output[2].ToString() + "\n"));
                        listBox1.Items.Add("----------------------------------------------------------------------------------------------------------------------");
                    }

                    if (!record.Contains(search))
                    {
                        listBox1.Text = "Item Not Found";
                    }
                    record = reader.ReadLine();

                }
                reader.Close();
                inFile.Close();
            }
        }
        private void saveBTN_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Application.StartupPath + "\\config.txt"))
            {
                StreamWriter newfile = new StreamWriter(Application.StartupPath + "\\config.txt");
                newfile.WriteLine(FP);
                newfile.Close();
            }
            else
            {
                List<string> lines = File.ReadAllLines(Application.StartupPath + "\\config.txt").ToList();
                lines.Add(FP);
                File.WriteAllLines(Application.StartupPath + "\\config.txt", lines);
            }
        }
       
        private void searchButton_Click_1(object sender, EventArgs e)
        {
            if (FP != null)
            {
                int a = 0;
                listBox1.Items.Clear();
                string filePath = FP;
                FileStream inFile = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);
                string record;
                string search = itemNameBox.Text;
                itemNameBox.Clear();
                itemNameBox.Text = search;
                
                //MessageBox.Show(search);

                record = reader.ReadLine();
                while (record != null)
                {
                    if (record.Contains(search))
                    { 
                        string[] output = record.Split(',');
                        listBox1.Items.Add((a + ": Item Name: " + output[0].ToString() + "   |   Isle: " + output[1].ToString() + "   |   Side: " + output[2].ToString() + "\n"));
                        listBox1.Items.Add("----------------------------------------------------------------------------------------------------------------------");
                        a++;
                    }
                    if (!record.Contains(search))
                    {
                        listBox1.Text = "Item Not Found";
                    }
                    record = reader.ReadLine();
                }
                reader.Close();
                inFile.Close();
            }
        }
        private void AddItemBTN_Click_1(object sender, EventArgs e)
        {
            AddNewItemsVisibleTrue();
            AddItemPanel.BringToFront();
            bar.Height = AddItemBTN.Height;
            bar.Top = AddItemBTN.Top;
            TitleSearch.Visible = false;
            AddItemLBL.Visible = true;
        }
        private void pictureBox1_Click_2(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FP = opf.FileName;

                filepathoutput.Text = FP;
            }
        }
        private void searchBTN_Click(object sender, EventArgs e)
        {
            
            SearchPanel.BringToFront();
            AddItemPanel.SendToBack();
            AddNewItemsVisibleFalse();
            bar.Height = searchBTN.Height;
            bar.Top = searchBTN.Top;
            TitleSearch.Visible = true;
            AddItemLBL.Visible = false;
        }
        private void newItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                string path = FP;
                List<string> lines = File.ReadAllLines(path).ToList();
                FileStream inFile = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);
                string record;

                string search = newItemName.Text;

                //---------------------------------------------------------------------------

                record = reader.ReadLine();
                if (search != null)
                {
                    if (record.Contains(search))
                    {
                        reader.Close();
                        inFile.Close();

                        ClearNewItemLines();
                        MessageBox.Show("Item Already Exists!");

                    }
                    if (!record.Contains(search))
                    {
                        reader.Close();
                        inFile.Close();
                        lines.Add(newItemName.Text + "," + NewIsleNumber.Text + "," + newIsleSide.Text);
                        File.WriteAllLines(path, lines);
                        if (multipleentriesCheckBox.Checked == true)
                        {
                            newItemName.Text = "";
                        }
                        else
                        {
                            ClearNewItemLines();
                        }

                    }
                }

            }
        }
        private void ClearNewItemLines()
        {
            newItemName.Text = "";
            NewIsleNumber.Text = "";
            newIsleSide.Text = "";
        }
        
        private void AddNewItem_Click(object sender, EventArgs e)
        {


            string path = FP;
            List<string> lines = File.ReadAllLines(path).ToList();
            FileStream inFile = new FileStream(path, FileMode.Open, FileAccess.Read);
            
            StreamReader reader = new StreamReader(inFile);
            string record;
            
            string search = newItemName.Text;

            //---------------------------------------------------------------------------

            record = reader.ReadLine();
            if (search != null)
            {
                if (record.Contains(search))
                {
                    ClearNewItemLines();
                    MessageBox.Show("Item Already Exists!");

                }
                if (!record.Contains(search))
                {
                    reader.Close();
                    inFile.Close();
                    if (newItemName.Text != "" || NewIsleNumber.Text != "" || newIsleSide.Text != "")
                    {
                        lines.Add(newItemName.Text + "," + NewIsleNumber.Text + "," + newIsleSide.Text);
                        File.WriteAllLines(path, lines);
                        if (multipleentriesCheckBox.Checked == true)
                        {
                            newItemName.Text = "";
                        }
                        else
                        {
                            ClearNewItemLines();
                        }
                    }
                }

            }
        }

        private void DoneBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region UIStuff
        private void label1_Click(object sender, EventArgs e)
        {

        }       
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void IsleLabel_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void itemNameBox_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void IsleNumberBox_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void IsleSideBox_TextChanged(object sender, EventArgs e)
        {
            
        }
        public void searchButton_Click(object sender, EventArgs e)
        {
            

        }
        private void result_TextChanged(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            
        }
        private void label1_Click_1(object sender, EventArgs e)
        {

        }       
        private void filepathoutput_TextChanged(object sender, EventArgs e)
        {

        }
        public void CloseTextFile()
        {
            
            
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void AddItemsPanelBTN_Click(object sender, EventArgs e)
        {
           
        }
        private void saveBTN_Click_1(object sender, EventArgs e)
        {

        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }              
        private void multipleentriesCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }       
        private void AddNewItemsVisibleFalse()
        {
            label5.Visible = false;
            newItemName.Visible = false;
            ItemNameLBL.Visible = false;
            NewIsleNumber.Visible = false;
            label4.Visible = false;
            newIsleSide.Visible = false;
            label3.Visible = false;
            DoneBTN.Visible = false;
            multipleentriesCheckBox.Visible = false;
            AddNewItem.Visible = false;
        }
        private void AddNewItemsVisibleTrue()
        {
            label5.Visible = true;
            newItemName.Visible = true;
            ItemNameLBL.Visible = true;
            NewIsleNumber.Visible = true;
            label4.Visible = true;
            newIsleSide.Visible = true;
            label3.Visible = true;
            DoneBTN.Visible = true;
            multipleentriesCheckBox.Visible = true;
            AddNewItem.Visible = true;
        }
        private void label5_Click(object sender, EventArgs e)
        {
            
        }
        private void newItemName_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void ItemNameLBL_Click(object sender, EventArgs e)
        {

        }
        private void NewIsleNumber_TextChanged(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void newIsleSide_TextChanged(object sender, EventArgs e)
        {

        }
        private void label3_Click_1(object sender, EventArgs e)
        {

        }
        private void DoneBTN_Click_1(object sender, EventArgs e)
        {

        }
        private void multipleentriesCheckBox_CheckedChanged_1(object sender, EventArgs e)
        {

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click_1(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }
        private void ItemNameLBL_ParentChanged(object sender, EventArgs e)
        {
            
        }
        #endregion

        private void AddItemPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
