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
    public partial class FormTovarEdit : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Лаба 5.mdb";
        public OleDbConnection connection;
        public FormTovarEdit()
        {
            InitializeComponent();
            connection = new OleDbConnection(connectString);
            connection.Open();
            AutoCompleteStringCollection source = new AutoCompleteStringCollection()
            {
                "+380",
                "+7",
                "+375"
            };
            textZPhone.AutoCompleteCustomSource = source;
            textZPhone.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textZPhone.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string Name, Surname, phone, TName, query;
                int numberZ, numberT, quantity;
                Name = textZName.Text;
                Surname = textZSurname.Text;
                phone = textZPhone.Text;
                numberT = Convert.ToInt32(textZnumberT.Text);
                numberZ = Convert.ToInt32(textZnumberZ.Text);
                quantity = Convert.ToInt32(textZQuantity.Text);
                string query2 = "SELECT [Название товара] FROM Товары WHERE [Номер товара] = " + numberT;
                OleDbCommand command2 = new OleDbCommand(query2, connection);
                TName = command2.ExecuteScalar().ToString();
                label6.Text = TName;
                query = "INSERT INTO Заказы VALUES (" + numberZ + ",'" + Surname + "','" + Name + "','" + phone + "'," + numberT + ",'" + TName + "'," + quantity + ")";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Добавлен новый заказ");
            }
            catch { MessageBox.Show("Ошибка ввода или добавления"); }
        }

        private void buttonUpdate2_Click(object sender, EventArgs e)
        {
            try
            {
                string Name = "", Surname = "", phone = "", TName = "", query;
                int numberZ=0, numberT=0, quantity=0;
                numberZ = Convert.ToInt32(textZnumberZ.Text);
                string queryD = "SELECT [Номер заказа], Фамилия, Имя, Телефон, [Номер товара], [Название товара], Количество FROM Заказы WHERE [Номер заказа] = " + numberZ + "";
                OleDbCommand command = new OleDbCommand(queryD, connection);
                OleDbDataReader reader = command.ExecuteReader();
                bool v = reader.Read();
                if (v == false)
                {
                    MessageBox.Show("Заказ с таким номером не найден");
                }
                reader.Close();
                if (v == true)
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        numberZ = Convert.ToInt32(reader[0].ToString());
                        Surname = reader[1].ToString();
                        Name = reader[2].ToString();
                        phone = reader[3].ToString();
                        numberT = Convert.ToInt32(reader[4].ToString());
                        TName = reader[5].ToString();
                        quantity = Convert.ToInt32(reader[6].ToString());
                    }
                    reader.Close();
                    if(textZName.Text != "") Name = textZName.Text;
                    if(textZSurname.Text != "") Surname = textZSurname.Text;
                    if(textZPhone.Text != "") phone = textZPhone.Text;
                    if(textZnumberT.Text != "") numberT = Convert.ToInt32(textZnumberT.Text);
                    if(textZnumberZ.Text != "") numberZ = Convert.ToInt32(textZnumberZ.Text);
                    if(textZQuantity.Text != "") quantity = Convert.ToInt32(textZQuantity.Text);
                    if (textZnumberT.Text != "")
                    {
                        string query2 = "SELECT [Название товара] FROM Товары WHERE [Номер товара] = " + numberT;
                        OleDbCommand command3 = new OleDbCommand(query2, connection);
                        TName = command3.ExecuteScalar().ToString();
                    }
                    query = "UPDATE Заказы SET Фамилия = '" + Surname + "', Имя = '" + Name + "', Телефон = '" + phone + "', [Номер товара] = " + numberT + ", [Название товара] = '" + TName + "', Количество = " + quantity + " WHERE [Номер заказа] = " + numberZ + "";
                    OleDbCommand commandF = new OleDbCommand(query, connection);
                    commandF.ExecuteNonQuery();
                    MessageBox.Show("Данные о товарах обновлены");
                }
            }
            catch { MessageBox.Show("Ошибка ввода или добавления"); }
        }
    }
}
