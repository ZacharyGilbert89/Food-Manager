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
    public partial class Form1 : Form {
        public string FP = null;
        public Form1() {
            StartItems();
            if (File.Exists(Application.StartupPath + "\\config.txt"))
            {
                FP = File.ReadAllLines(Application.StartupPath + "\\config.txt").Last();
                filepathoutput.Text = FP;
            }                        
        }
        private void StartItems() { //Starts the form with the visual components
            InitializeComponent();
            SearchPanel.BringToFront(); //makes sure the Search Panel is visible on startup
            AddItemPanel.SendToBack(); //makes sure the add item Panel is not visible on startup because the user would do this manually
            AddItemLBL.Visible = false;
            AddNewItemsVisibleFalse();
            bar.Height = searchBTN.Height;
            bar.Top = searchBTN.Top;
        }
        private void itemNameBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                listBox1.Items.Clear();
                // Opens the .txt file that stores all the saved items and their respected location
                string filePath = FP;
                FileStream inFile = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);
                string record;
                string search = itemNameBox.Text.Trim();
                itemNameBox.Clear();
                itemNameBox.Text = search;
                record = reader.ReadLine();
                while (record != null)
                {
                    if (record.Contains(search))
                    {
                        //This will display all saved items and their position
                        string[] output = record.Split(',');
                        listBox1.Items.Add(("Item Name: " + output[0].ToString() + "|   Isle: " + output[1].ToString() + "|   Side: " + output[2].ToString() + "\n"));
                        listBox1.Items.Add("----------------------------------------------------------------------------------------------------------------------");
                    }
                    if (!record.Contains(search)) { 
                        //if the user tries searching for an item, and it doesn't exist yet, the error will be displayed
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
            if (!File.Exists(Application.StartupPath + "\\config.txt")) //checks to see if the settings file exists, if it doesnt find it, it creates one, with the path of the saved items list
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
            if (FP != null) //makes sure a save file exists
            {
                int a = 0;
                listBox1.Items.Clear(); //clears the display of items for the search function
                string filePath = FP;
                FileStream inFile = new FileStream(filePath, FileMode.Open, FileAccess.Read); //opens the file to read from
                StreamReader reader = new StreamReader(inFile);
                string record;
                string search = itemNameBox.Text; //gets the search query
                itemNameBox.Clear();
                itemNameBox.Text = search;
                
                //MessageBox.Show(search);

                record = reader.ReadLine();
                while (record != null) //makes sure the file is able to be read
                {
                    if (record.Contains(search)) //search's the file for the specific item they are looking for
                    { 
                        string[] output = record.Split(','); // formats the output
                        listBox1.Items.Add((a + ": Item Name: " + output[0].ToString() + "   |   Isle: " + output[1].ToString() + "   |   Side: " + output[2].ToString() + "\n"));
                        listBox1.Items.Add("----------------------------------------------------------------------------------------------------------------------");
                        a++;
                    }
                    if (!record.Contains(search)) //if the item doesnt exist, it throws an error
                    {
                        listBox1.Text = "Item Not Found";
                    }
                    record = reader.ReadLine();
                }
                reader.Close();
                inFile.Close();
            }
        }
        private void AddItemBTN_Click_1(object sender, EventArgs e) //function to bring the add panel visible
        {
            AddNewItemsVisibleTrue(); //brings the add panel and its contents forwards and hides the previous panel
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
            SearchPanel.BringToFront();//brings the serach panel and its contents forwards and hides the previous panel
            AddItemPanel.SendToBack();
            AddNewItemsVisibleFalse();
            bar.Height = searchBTN.Height;
            bar.Top = searchBTN.Top;
            TitleSearch.Visible = true;
            AddItemLBL.Visible = false;
        }
        private void newItemName_KeyDown(object sender, KeyEventArgs e) //fucntion to add a new item
        {
            if (e.KeyCode == Keys.Enter)
            {
                string path = FP; 
                List<string> lines = File.ReadAllLines(path).ToList(); //opens the files to be read
                FileStream inFile = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);
                string record;
                string search = newItemName.Text;
                //---------------------------------------------------------------------------
                record = reader.ReadLine();
                if (search != null)
                {
                    if (record.Contains(search)) //checks to see if the item already exists
                    {
                        reader.Close();
                        inFile.Close();
                        ClearNewItemLines();
                        MessageBox.Show("Item Already Exists!");
                    }
                    if (!record.Contains(search)) //if the item doesnt exist it adds the item 
                    {
                        reader.Close();
                        inFile.Close();
                        lines.Add(newItemName.Text + "," + NewIsleNumber.Text + "," + newIsleSide.Text); //adds the new item with its properties
                        File.WriteAllLines(path, lines);
                        if (multipleentriesCheckBox.Checked == true) //this is used to see if the user wants to add multiple items
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
        private void ClearNewItemLines() //clears the fields for future use
        {
            newItemName.Text = "";
            NewIsleNumber.Text = "";
            newIsleSide.Text = "";
        }
        
        private void AddNewItem_Click(object sender, EventArgs e) //this is a different additem, inside the panel for looking for items, the user can add an item from within
        {
            string path = FP;
            List<string> lines = File.ReadAllLines(path).ToList();
            FileStream inFile = new FileStream(path, FileMode.Open, FileAccess.Read); //opens the file that contains all the items and their properties
            StreamReader reader = new StreamReader(inFile);
            string record;
            string search = newItemName.Text;
            //---------------------------------------------------------------------------
            record = reader.ReadLine();
            if (search != null)
            {
                if (record.Contains(search)) //checks to see if the item exists already
                {
                    ClearNewItemLines();
                    MessageBox.Show("Item Already Exists!");
                }
                if (!record.Contains(search)) //if the item doesnt exist it adds it to the .txt file that contains the rest of the items
                {
                    reader.Close();
                    inFile.Close();
                    if (newItemName.Text != "" || NewIsleNumber.Text != "" || newIsleSide.Text != "") //checks too see if any of the fields are missing
                    {
                        lines.Add(newItemName.Text + "," + NewIsleNumber.Text + "," + newIsleSide.Text); //adds the new item
                        File.WriteAllLines(path, lines); //writes the file
                        if (multipleentriesCheckBox.Checked == true)
                        {
                            newItemName.Text = ""; //Checks to see if the user wants to add more items at one time
                        }
                        else
                        {
                            ClearNewItemLines(); //clears the field for future use
                        }
                    }
                }

            }
        }

        private void DoneBTN_Click(object sender, EventArgs e)
        {
            this.Close(); //exits
        }
        private void AddNewItemsVisibleFalse() //add new items panel to be no longer visible 
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
        private void AddNewItemsVisibleTrue() //add new items panel to be visible 
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
        #region UIStuff //This is required by C# to initialize each element of the form, this does not serve any other purpose
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
