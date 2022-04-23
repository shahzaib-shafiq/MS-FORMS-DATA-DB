using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace _20f_0317_DB_LAB
{
    
public partial class FirstName : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

       
        public FirstName()
        {
            InitializeComponent();
        }
      void GetIncrementID()
        {
            string IDtextBox;
            SqlConnection con = new SqlConnection(cs);
            string query = "Select id from E_Table";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            if (data.Rows.Count < 1)
            {
                textBox1.Text = "1";

            }
            else
            {
                SqlConnection con1 = new SqlConnection(cs);
                string query1 = "select max (id) from E_Table)";
                SqlCommand cmd = new SqlCommand(query1, con1);
                con1.Open();
                int a = Convert.ToInt32(cmd.ExecuteScalar());

                con1.Close();
                a = a + 1;
                textBox1.Text = a.ToString(); 
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        


        //add
        private void button1_Click(object sender, EventArgs e)
        {
          
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-HG6LLLN;Initial Catalog=OFFICE;Integrated Security=True");
            con.Open();
            string ID = textBox1.Text;
            int nid = Convert.ToInt32(ID);
            string FNAME = textBox2.Text;
            string LNAME = textBox3.Text;
            string EMAIL = textBox4.Text;
            string PASSWORD = textBox5.Text;
     
            string ADRES = textBox6.Text;
            string GENDER = textBox7.Text;
       
 
            string DESCCRIPTION = textBox9.Text;

          
            string query = "insert into E_Table(ID,FNAME,LNAME,EMAIL,PASSWORD,ADRES,GENDER,DOB,DESCRIPTION) Values ('" + ID + "','" + FNAME + "','" + LNAME + "','" + EMAIL + "','" + PASSWORD + "','" + ADRES + "','" + GENDER + "','" + this.dateTimePicker1.Text+ "','" + DESCCRIPTION + "')";
            SqlCommand cm = new SqlCommand(query,con);
           
           int a = cm.ExecuteNonQuery();
            if(a>0)
            {
                MessageBox.Show("Saved Sucessfully");
                //GetIncrementID();
            }
          else
            {
                MessageBox.Show("Not Saved");
            }
            cm.Dispose();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox9.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FirstName_Load(object sender, EventArgs e)
        {
            //button2_Click();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }
        //searching
        private void button2_Click(object sender, EventArgs e)
        {
           
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-HG6LLLN;Initial Catalog=OFFICE;Integrated Security=True");
            con.Open();
            SqlCommand command = new SqlCommand("select FNAME,LNAME,EMAIL,PASSWORD,ADRES,GENDER,DOB,DESCRIPTION from E_Table  where ID ='"+int.Parse(textBox1.Text)+"'",con);
            SqlDataReader srd = command.ExecuteReader();

            while (srd.Read())
            {

                textBox2.Text = srd.GetValue(0).ToString();
                textBox3.Text = srd.GetValue(1).ToString();
                textBox4.Text = srd.GetValue(2).ToString();
                textBox5.Text = srd.GetValue(3).ToString();
                textBox6.Text = srd.GetValue(4).ToString();
                textBox7.Text = srd.GetValue(5).ToString();
                textBox9.Text = srd.GetValue(6).ToString();


            }
            con.Close();
           
        }
        //updating
        private void button3_Click(object sender, EventArgs e)
        {

           string connectionstring = "Data Source=DESKTOP-HG6LLLN;Initial Catalog=OFFICE;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();      
            string ID = textBox1.Text;
            int nid = Convert.ToInt32(ID);
            string FNAME = textBox2.Text;
            string LNAME = textBox3.Text;
            string EMAIL = textBox4.Text;
            string PASSWORD = textBox5.Text;
            // String DOB = dateTimePicker1.Text; 
            string ADRES = textBox6.Text;
            string GENDER = textBox7.Text;
            //string DOB = this.dateTimePicker1.Text;
            string DESCCRIPTION = textBox9.Text;


            string query = "update E_Table SET FNAME = '" + FNAME + "' , LNAME='" + LNAME + "' , EMAIL='" + EMAIL + "' , PASSWORD='" + PASSWORD + "' , ADRES='" + ADRES + "' , GENDER='" + GENDER + "',DOB='" + this.dateTimePicker1.Text + "', DESCRIPTION='" + DESCCRIPTION + "' WHERE ID = " + ID;  
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

            
            //cm.Dispose();
            con.Close();
            MessageBox.Show("UPDATED Sucessfully");
        }
        //delete button
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-HG6LLLN;Initial Catalog=OFFICE;Integrated Security=True");
            con.Open();
            string ID = textBox1.Text;
            int nid = Convert.ToInt32(ID);
 
            string query = "delete from E_Table where ID ='" + ID +"'";
            SqlCommand cm = new SqlCommand(query, con);

            cm.ExecuteNonQuery();

            MessageBox.Show("deleted Sucessfully");
            cm.Dispose();
            con.Close(); 
        }

    
        private void textBox5_Enter(object sender, EventArgs e)
        {
         
            textBox5.Text = "";
            textBox5.ForeColor = Color.Black;
            textBox5.UseSystemPasswordChar = true;
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            
            if (textBox5.Text.Length == 0)
            {
                textBox5.ForeColor = Color.Gray;

                textBox5.Text = "Enter password";

                textBox5.UseSystemPasswordChar = false;

                SelectNextControl(textBox5, true, true, false, true);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text=="EMPLOYEE ID")
            {
                textBox1.Text = "";
                    
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "FIRST NAME")
            {
                textBox2.Text = "";

            }
        }

        private void textBox5_Enter_1(object sender, EventArgs e)
        {
            if (textBox5.Text == "MIN 8 CHARS")
            {
                textBox5.Text = "";

            }
            textBox5.Text = "";

            textBox5.ForeColor = Color.Black;

            textBox5.UseSystemPasswordChar = true;
        }

        private void textBox5_Leave_1(object sender, EventArgs e)
        {
            if (textBox5.Text == "MIN 8 CHARS")
            {
                textBox5.Text = "";

            }
            if (textBox5.Text.Length == 0)
            {
                textBox5.ForeColor = Color.Gray;

                textBox5.Text = "Enter password";

                textBox5.UseSystemPasswordChar = false;

                SelectNextControl(textBox5, true, true, false, true);
            }
        }

        private void textBox1_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "EMPLOYEE ID")
            {
                textBox1.Text = "";

            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "FIRST NAME")
            {
                textBox2.Text = "";

            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "LAST NAME")
            {
                textBox3.Text = "";

            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "LAST NAME")
            {
                textBox3.Text = "";

            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "ABC@EXP.COM")
            {
                textBox4.Text = "";

            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "ABC@EXP.COM")
            {
                textBox4.Text = "";

            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "ADRESS")
            {
                textBox6.Text = "";

            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "ADRESS")
            {
                textBox6.Text = "";

            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (textBox7.Text == "M / F")
            {
                textBox7.Text = "";

            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "M / F")
            {
                textBox7.Text = "";

            }
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            if (textBox9.Text == "EMPLOYEE DESCRIPTION")
            {
                textBox9.Text = "";

            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (textBox9.Text == "EMPLOYEE DESCRIPTION")
            {
                textBox9.Text = "";

            }
        }
    }
}
