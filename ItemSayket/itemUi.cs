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
    public partial class itemUi : Form
    {
        public itemUi()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            insert();

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            show();
        }


        


        private void deleteButton_Click(object sender, EventArgs e)
        {

            delete();

        }


        private void updateButton_Click(object sender, EventArgs e)
        {
            update();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            search();
        }




        private void insert()
        {

            try
            {
                string connectionString = @"Server=DESKTOP-LQ035EB; Database=CoffeeShop;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);



                String commandString = @"INSERT INTO Item (name, price) values ('" + nameTextBox.Text + "'," + priceTextBox.Text + ") ";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                int isExecuted = sqlCommand.ExecuteNonQuery();

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
                MessageBox.Show(exception.Message);
            }


        }





        private void show()
        {

            try
            {
                string connectionString = @"Server=DESKTOP-LQ035EB; Database=CoffeeShop;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);



                String commandString = @"SELECT *  FROM Item";
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



        private void delete()
        {

            try
            {
                if (String.IsNullOrEmpty(idTextBox.Text))
                {
                    MessageBox.Show("Please ennter id.");
                }

                else
                {
                    string connectionString = @"Server=DESKTOP-LQ035EB; Database=CoffeeShop;Integrated Security=True";
                    SqlConnection sqlConnection = new SqlConnection(connectionString);



                    String commandString = @"DELETE FROM Item WHERE ID =" + idTextBox.Text + " ";
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

        private void update()
        {

            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Please ennter id   .\n");
            }

            else
            {
                string connectionString = @"Server=DESKTOP-LQ035EB; Database=CoffeeShop;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);



                String commandString = @"UPDATE Item SET  name =  '" + nameTextBox.Text + "' , price = " + priceTextBox.Text + " WHERE ID = " + idTextBox.Text + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

            }

        }



        private void search()
        {

            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Please ennter Name  .\n");
            }

            else
            {


                string connectionString = @"Server=DESKTOP-LQ035EB; Database=CoffeeShop;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);



                String commandString = @"SELECT *  FROM Item  WHERE name ='" + nameTextBox.Text+ "' ";
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
