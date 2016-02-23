//Author : Gayathri Kaki 
//http://GayathriKaki.wordpress.com

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//In this example, data will be serialized and deserialized to and from a file.
namespace SerializeToFileDeserialize
{
    public partial class UserForm : Form
    {
        
        string filename = Path.GetTempPath() + "BinaryDataFile.dat";
        BinaryFormatter bFormatter = new BinaryFormatter();
        public UserForm()
        {
            InitializeComponent();
        }

        private void btnSerialize_Click(object sender, EventArgs e)
        {
            SerializeForm formobj = new SerializeForm(txtName.Text, txtPassword.Text);     
           
           //write form data to file as binary
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            bFormatter.Serialize(fs, formobj);
            fs.Close();

            btnDeserialize.Enabled = true;

            lblmsg.Text = "Data written to file" + filename;

            txtName.Text = "";
            txtPassword.Text = "";

        }

        private void btnDeserialize_Click(object sender, EventArgs e)
        {
            //deserilize binary data and load back to form
            SerializeForm formfileObj = new SerializeForm();
            FileStream fsRead = new FileStream(filename, FileMode.Open);
            formfileObj = bFormatter.Deserialize(fsRead) as SerializeForm;

            txtName.Text = formfileObj.username;
            txtPassword.Text  = formfileObj.password;
            fsRead.Close();
            lblmsg.Text = "Deserialization is completed.Populated Binary data from file to controls.";

           

           
        }
    }

}
