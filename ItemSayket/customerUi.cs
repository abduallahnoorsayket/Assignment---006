using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItemSayket
{
    public partial class customerUi : Form
    {
        public customerUi()
        {
            InitializeComponent();
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            Connection();


            String chkName = @"SELECT *FORM Customer WHERE name='"+nameTextBox.Text+"'";
            
            if (chkName == "nameTextBox.Text")
            {
                MessageBox.Show("name exits !!");

            }
            else

            {

                Insert();

            }   





        }

        private void showButton_Click(object sender, EventArgs e)
        {
            ShowAll();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateInfo();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Search();
        }




        private void Connection()
        {

            string connectionString = @"Server=DESKTOP-LQ035EB; Database=CoffeeShop;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
        }





        private void Insert()
        {

            try
            {
                // Connection();
                string connectionString = @"Server=DESKTOP-LQ035EB; Database=CoffeeShop;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                String commandString = @"INSERT INTO Customer (name,contact,addreess,orderr, quantity) values
  ('" + nameTextBox.Text + "','" + contactTextBox.Text + "','" + addressTextBox.Text + "','" + orderTextBox.Text + "'," + quantityTextBox.Text + ") ";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


                sqlConnection.Open();

                int isExecuted = sqlCommand.ExecuteNonQuery();

                //  

                if (isExecuted > 0)
                {

                    MessageBox.Show("Saved");

                }

                else
                {
                    MessageBox.Show("Not saved");
                }

                sqlConnection.Close();

            }

            catch(Exception exception)
            {
                MessageBox.Show(exception.Message );
            }



        }





        private void ShowAll()
        {
            try
            {
                string connectionString = @"Server=DESKTOP-LQ035EB; Database=CoffeeShop;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);



                String commandString = @"SELECT * FROM Customer";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)

                {
                    showDataGridView.DataSource = dataTable;

                }

                else
                {
                    MessageBox.Show("No data Found !");

                }
                //sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);

            }

        }




        private void Delete()
        {

            try
            {
                if (String.IsNullOrEmpty(nameTextBox.Text))
                {
                    MessageBox.Show("Please ennter Name.");
                }

                else
                {
                    string connectionString = @"Server=DESKTOP-LQ035EB; Database=CoffeeShop;Integrated Security=True";
                    SqlConnection sqlConnection = new SqlConnection(connectionString);



                    String commandString = @"DELETE FROM Customer WHERE name ='" + nameTextBox.Text + "'";
                    SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                    sqlConnection.Open();

                    sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();

                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void UpdateInfo()
        {



            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Please ennter Name   .\n");
            }

            else
            {
                string connectionString = @"Server=DESKTOP-LQ035EB; Database=CoffeeShop;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);



 String commandString = @"UPDATE Customer SET  contact =  '"+contactTextBox.Text+"' , addreess ='"+addressTextBox.Text+"', orderr='"+orderTextBox.Text+"' WHERE name = '"+nameTextBox.Text+"'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

            }

        }



        private void Search()
        {

            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Please ennter Name  .\n");
            }

            else
            {


                string connectionString = @"Server=DESKTOP-LQ035EB; Database=CoffeeShop;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);



                String commandString = @"SELECT *  FROM Customer WHERE name ='" + nameTextBox.Text +"'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();

                //showDataGridView.DataSource = dataTable;


                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)

                {
                    showDataGridView.DataSource = dataTable;

                }

                else
                {
                    MessageBox.Show("No data Found !");

                }

                //sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

            }
        }









    }
}
