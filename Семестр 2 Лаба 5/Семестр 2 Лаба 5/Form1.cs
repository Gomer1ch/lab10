using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Семестр_2_Лаба_5
{
    public partial class Form1 : Form
    {
        public static string connectString  = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Лаба 5.mdb";
        public OleDbConnection connection;
        public Form1()
        {
            InitializeComponent();
            connection = new OleDbConnection(connectString);
            connection.Open();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "лаба_5DataSet.Товары". При необходимости она может быть перемещена или удалена.
            this.товарыTableAdapter.Fill(this.лаба_5DataSet.Товары);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "лаба_5DataSet.Заказы". При необходимости она может быть перемещена или удалена.
            this.заказыTableAdapter.Fill(this.лаба_5DataSet.Заказы);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string delete = "DELETE FROM Заказы WHERE [Номер заказа] = " + 114;
            //OleDbCommand command = new OleDbCommand(delete, connection);
            //command.ExecuteNonQuery();
            //MessageBox.Show("удален");
            //this.заказыTableAdapter.Fill(this.лаба_5DataSet.Заказы);
            FormZakazEdit f2 = new FormZakazEdit();
            f2.Owner = this;
            f2.Show();
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormTovarEdit f3 = new FormTovarEdit();
            f3.Owner = this;
            f3.Show();
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.товарыTableAdapter.Fill(this.лаба_5DataSet.Товары);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.заказыTableAdapter.Fill(this.лаба_5DataSet.Заказы);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int numberT;
                string query;
                numberT = Convert.ToInt32(textTDelete.Text);
                query = "DELETE FROM Товары WHERE [Номер товара] = " + numberT;
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Данные о товаре удалены");
            }
            catch { MessageBox.Show("Ошибка удаления"); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int numberZ;
                string query;
                numberZ = Convert.ToInt32(textZDelete.Text);
                query = "DELETE FROM Заказы WHERE [Номер заказа] = " + numberZ;
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Заказ удален");
            }
            catch { MessageBox.Show("Ошибка удаления"); }
        }

        private void buttonShow1_Click(object sender, EventArgs e)
        {
            string phone = textPhone.Text;
            string query = "SELECT Имя, Фамилия, [Номер товара], [Название товара] FROM Заказы WHERE Телефон = '" + phone + "'";
            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataReader reader = command.ExecuteReader();
            bool v = reader.Read();
            if (v == false) 
            { 
                MessageBox.Show("Такой номер не найден");
                labelName.Text = "Имя: ";
                labelSurname.Text = "Фамимлия: ";
                labelNumberT.Text = "Номер товара: ";
                labelNameT.Text = "Название товара: ";
            }
            reader.Close();
            if (v == true)
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    labelName.Text = "Имя: " + reader[0].ToString();
                    labelSurname.Text = "Фамимлия: " + reader[1].ToString();
                    labelNumberT.Text = "Номер товара: " + reader[2].ToString();
                    labelNameT.Text = "Название товара: " + reader[3].ToString();
                }
                reader.Close();
            }
        }

        private void buttonShow2_Click(object sender, EventArgs e)
        {
            try
            {
                double prise;
                prise = Convert.ToDouble(textPrise.Text);
                string query = "SELECT [Название товара], [Номер товара] FROM Товары WHERE Цена = " + prise + "";
                OleDbCommand command = new OleDbCommand(query, connection);
                OleDbDataReader reader = command.ExecuteReader();
                listBox1.Items.Clear();
                while (reader.Read())
                {
                    listBox1.Items.Add(reader[0].ToString() + " / " + reader[1].ToString() + " ");
                }
                reader.Close();
            }
            catch { MessageBox.Show("Ошибка ввода. Введите число"); }
        }

        private void buttonShow3_Click(object sender, EventArgs e)
        {
            try
            {
                int numberT, size;
                numberT = Convert.ToInt32(textNumberT.Text);
                size = Convert.ToInt32(textSize.Text);
                string query = "SELECT Цена, [Номер товара], [Название товара] FROM Товары WHERE [Номер товара] = " + numberT + " AND [Размер (Gb)] = " + size + "";
                OleDbCommand command = new OleDbCommand(query, connection);
                OleDbDataReader reader = command.ExecuteReader();
                bool v = reader.Read();
                if (v == false)
                {
                    MessageBox.Show("Товар с таким номером и размером не найден");
                    labelPrise.Text = "Цена: ";
                    labelNumberT2.Text = "Номер товара: ";
                    labelNameT2.Text = "Название товара: ";
                }
                reader.Close();
                if (v == true)
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        labelPrise.Text = "Цена: " + reader[0].ToString() + " ₴";
                        labelNumberT2.Text = "Номер товара: " + reader[1].ToString();
                        labelNameT2.Text = "Название товара: " + reader[2].ToString();
                    }
                    reader.Close();
                }
            }
            catch { MessageBox.Show("Товар с таким номером и размером не найден"); }
        }

        private void buttonShow4_Click(object sender, EventArgs e)
        {
            //DateTime date = new DateTime();
            string query = "SELECT [Номер товара], [Название товара], [Время действия (до)] FROM Товары";
            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataReader reader = command.ExecuteReader();
            listBox2.Items.Clear();
            while (reader.Read())
            {
                DateTime d1 = Convert.ToDateTime(reader[2].ToString());
                if (d1 < DateTime.Today)
                {
                    listBox2.Items.Add(reader[0].ToString() + " / " + reader[1].ToString() + " / " + reader[2].ToString() + " ");
                }
            }
            reader.Close();
        }

        private void buttonShow5_Click(object sender, EventArgs e)
        {
            string surname; //phone, TName;
            double prise = 0, sum;
            int quantity = 0, numberT = 0;
            surname = textSurnameB.Text;
            string query = "SELECT Фамилия, Телефон, [Название товара], Количество, [Номер товара] FROM Заказы WHERE Фамилия = '" + surname + "'";
            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataReader reader = command.ExecuteReader();
            bool v = reader.Read();
            if (v == false)
            {
                MessageBox.Show("Клиенты с данной фамилией не найдены");
                labelSurnameB.Text = "Фамилия: ";
                labelPhoneB.Text = "Телефон: ";
                labelNameTB.Text = "Название товара: ";
                labelPriseB.Text = "Цена: ";
                labelSumB.Text = "Итого: ";
            }
            reader.Close();
            if (v == true)
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    labelSurnameB.Text = "Фамилия: " + reader[0].ToString();
                    labelPhoneB.Text = "Телефон: " + reader[1].ToString();
                    labelNameTB.Text = "Название товара: " + reader[2].ToString();
                    quantity = Convert.ToInt32(reader[3].ToString());
                    numberT = Convert.ToInt32(reader[4].ToString());
                }
                reader.Close();
                string query2 = "SELECT Цена FROM Товары WHERE [Номер товара] = " + numberT + "";
                OleDbCommand command2 = new OleDbCommand(query2, connection);
                prise = Convert.ToDouble(command2.ExecuteScalar().ToString());
                sum = prise * quantity;
                labelPriseB.Text = "Цена: " + prise + " ₴";
                labelSumB.Text = "Итого: " + sum + " ₴";
                //string query2 = "SELECT Цена FROM Товары WHERE [Номер товара] = " + numberT + "";
                //OleDbCommand command2 = new OleDbCommand(query2, connection);
                //OleDbDataReader reader2 = command2.ExecuteReader();
                //while (reader2.Read())
                //{
                //    prise += Convert.ToDouble(reader2[0].ToString());
                //}
                //reader.Close();
                //sum = prise * quantity;
                //labelPriseB.Text = "Цена: " + prise + " ₴";
                //labelSumB.Text = "Итого: " + sum + " ₴";
            }
        }
    }
}
