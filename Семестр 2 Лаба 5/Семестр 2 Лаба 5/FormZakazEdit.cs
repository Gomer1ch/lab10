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
    public partial class FormZakazEdit : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Лаба 5.mdb";
        public OleDbConnection connection;
        public FormZakazEdit()
        {
            InitializeComponent();
            connection = new OleDbConnection(connectString);
            connection.Open();
            AutoCompleteStringCollection source = new AutoCompleteStringCollection()
            {
                "Шутеры",
                "РПГ",
                "Гонки"
            };
            textTType.AutoCompleteCustomSource = source;
            textTType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textTType.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name, type, time, query;
                double prise, size;
                int number;
                name = textTName.Text;
                type = textTType.Text;
                time = monthCalendar1.SelectionRange.Start.ToShortDateString();
                prise = Convert.ToDouble(textTPrise.Text);
                size = Convert.ToDouble(textTSize.Text);
                number = Convert.ToInt32(textTNumber.Text);
                query = "INSERT INTO Товары VALUES ('" + name + "','" + type + "'," + prise + "," + number + "," + size + ",'" + time + "')";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Данные о товарах обновлены");
            }
            catch { MessageBox.Show("Ошибка ввода или добавления"); }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string name ="", type="", time="", query;
                double prise=0, size=0;
                int number;
                number = Convert.ToInt32(textTNumber.Text);
                string queryD = "SELECT [Название товара], Тип, Цена, [Номер товара], [Размер (Gb)], [Время действия (до)] FROM Товары WHERE [Номер товара] = " + number + "";
                OleDbCommand command = new OleDbCommand(queryD, connection);
                OleDbDataReader reader = command.ExecuteReader();
                bool v = reader.Read();
                if (v == false)
                {
                    MessageBox.Show("Товар с таким номером не найден");
                }
                reader.Close();
                if (v == true)
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        name = reader[0].ToString();
                        type = reader[1].ToString();
                        prise = Convert.ToDouble(reader[2].ToString());
                        number = Convert.ToInt32(reader[3].ToString());
                        size = Convert.ToDouble(reader[4].ToString());
                        time = reader[5].ToString();
                    }
                    reader.Close();
                    if (textTName.Text != "") name = textTName.Text;
                    if (textTType.Text != "") type = textTType.Text;
                    if (monthCalendar1.Focused == false) time = monthCalendar1.SelectionRange.Start.ToShortDateString();
                    if (textTPrise.Text != "") prise = Convert.ToDouble(textTPrise.Text);
                    if (textTSize.Text != "") size = Convert.ToDouble(textTSize.Text);
                    //if (textTNumber.Text != "") number = Convert.ToInt32(textTNumber.Text);
                    query = "UPDATE Товары SET [Название товара] = '" + name + "', Тип = '" + type + "', Цена = " + prise + ", [Размер (Gb)] = " + size + ", [Время действия (до)] = '" + time + "' WHERE [Номер товара] = " + number + "";
                    OleDbCommand command2 = new OleDbCommand(query, connection);
                    command2.ExecuteNonQuery();
                    MessageBox.Show("Данные о товарах обновлены");
                }
            }
            catch { MessageBox.Show("Ошибка ввода или добавления"); }
        }
    }
}
