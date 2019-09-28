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
    public partial class orderUi : Form
    {
        public orderUi()
        {
            InitializeComponent();
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            Insert();
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


        private void Insert()
        {

            try
            {
                string connectionString = @"Server=DESKTOP-LQ035EB; Database=CoffeeShop;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);



                String commandString = @"INSERT INTO orderr (name,item,quantity, unitprice) values
  ('" + nameTextBox.Text + "','" + itemTextBox.Text + "','" + quantityTextBox.Text + "','" + unitTextBox.Text + "') ";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                int isExecuted = sqlCommand.ExecuteNonQuery();

                // sqlCommand.ExecuteNonQuery();

                if (isExecuted >= 0)
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
                MessageBox.Show(exception.Message);
            }
        }





        private void ShowAll()
        {
            try
            {
                string connectionString = @"Server=DESKTOP-LQ035EB; Database=CoffeeShop;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);



                String commandString = @"SELECT * FROM orderr";
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
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Please ennter Name.");
            }

            else
            {
                string connectionString = @"Server=DESKTOP-LQ035EB; Database=CoffeeShop;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);



                String commandString = @"DELETE FROM orderr WHERE name ='" + nameTextBox.Text + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

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



                String commandString = @"UPDATE orderr SET  item ='" +itemTextBox.Text + "' , quantity =" +quantityTextBox.Text + ", unitprice=" + unitTextBox.Text +" WHERE name = '" + nameTextBox.Text + "'";
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



                String commandString = @"SELECT *  FROM orderr WHERE name ='" + nameTextBox.Text + "'";
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
