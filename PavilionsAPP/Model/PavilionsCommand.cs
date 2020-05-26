using System;
using PavilionsDAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.ComponentModel;
using System.Data.SqlClient;

namespace PavilionsAPP.Model
{
    public static class PavilionsCommand
    {
        private static string connectionString = "data source=DESKTOP-5D0552Q;initial catalog=Pavilions;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

        public static object TryAutorize(string login = "", string password = "")
        {
            object res = "Неверный логин или пароль";
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                try
                {
                    using (var context = new PavilionsEntities())
                    {
                        var user = context.Planctons.FirstOrDefault(x => x.Login.ToLower() == login);

                        if (user != null && user.Password == password)
                            res = user;
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else res = "Ничего не введено";

            return res;
        }



        public static object GetAllSC()
        {
            object res = null;
            DataTable dt = new DataTable();
            using (var context = new PavilionsEntities())
            {
                SqlConnection connection = new SqlConnection(connectionString);
                string query = $"SELECT SC.SCName, SC.Status, SC.PavilNum, SC.City, SC.Price, SC.FlorNum, SC.CoeOffAddedValue FROM SC";
                try
                {
                    using (connection)
                    {
                        if (connection.State != ConnectionState.Open) connection.Open();

                        dt = GetDataTable(query, connection);
                    }
                }
                catch (Exception ex)
                {
                    // error handling
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            res = dt;
            return res;
        }


        public static DataTable ListToDataTable<T>(IList<T> data)
        {
            DataTable table = new DataTable();

            //special handling for value types and string
            if (typeof(T).IsValueType || typeof(T).Equals(typeof(string)))
            {

                DataColumn dc = new DataColumn("Value");
                table.Columns.Add(dc);
                foreach (T item in data)
                {
                    DataRow dr = table.NewRow();
                    dr[0] = item;
                    table.Rows.Add(dr);
                }
            }
            else
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
                foreach (PropertyDescriptor prop in properties)
                {
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                    {
                        try
                        {
                            row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                        }
                        catch (Exception ex)
                        {
                            row[prop.Name] = DBNull.Value;
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            return table;
        }



        static DataTable GetDataTable(string query, SqlConnection connection)
        {
            DataTable resultDT = new DataTable(); // Результирующая таблица
            SqlCommand command; // Команда выборки
                                // SqlTransaction transaction = null; // Транзакция
            query = query.ToLower(); // Перевод запроса в нижний регистр

            command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader(); // Выполнение выборки
            resultDT.Load(reader); // Загрузка результатов в таблицу
            reader.Close();

            //transaction?.Rollback(); // Откат транзакции

            return resultDT;
        }


    }
}
