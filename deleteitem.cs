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
    public partial class deleteitem : Form
    {
        public deleteitem()
        {
            InitializeComponent(); //C# included line to make sure everything is updated
        }
        private void refreshBTN_Click(object sender, EventArgs e) //refreshes the items in case something was added
        {
            using (Form1 f1 = new Form1())
            {
                TextReader reader = new StreamReader(f1.FP); //reads the file and updates the list with any new changes
                itemListTEXTBOX.Text = reader.ReadToEnd();
                reader.Close();
            }
        }
        private void deleteBTN_Click(object sender, EventArgs e) //function to delete specific items
        {
            using (Form1 f1 = new Form1())
            {
                string path = f1.FP;
                List<string> lines = File.ReadAllLines(path).ToList();
                FileStream inFile = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);
                string record;
                string search = itemNameDelete.Text; //opens the file
                //---------------------------------------------------------------------------
                record = reader.ReadLine();
                if (search != null)
                {
                    if (record.Contains(search))
                    {
                        string[] output = record.Split(',');  //parses the found item
                    }
                    if (!record.Contains(search))
                    {
                        reader.Close();
                        inFile.Close();
                    }
                }
            }
        }
        private void deleteitem_Load(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
