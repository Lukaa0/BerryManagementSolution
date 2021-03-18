using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Configuration;
using System.IO;
using System.Data;
using BerryPackagingApplication.BM_Operarion_ServiceRefernce;

namespace BerryPackagingApplication.DbServices
{
    public class LocalDatabase
    {
        private string _DatabaseFileName = "Containers.sdf";
        private string _TableName = "ContainerWeight";
        private string _ConnectionString;
        private SqlCeConnection _Connection;

        public LocalDatabase(ref string errorMessage)
        {
            CreateDatabase(ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return;
            }
            CreateTables(ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return;
            }
        }

        private void CreateDatabase(ref string errorMessage)
        {
            this._ConnectionString = string.Format("DataSource =\"{0}\"; Password = '{1}'", this._DatabaseFileName, "");
            this._Connection = new SqlCeConnection(this._ConnectionString);
            if (File.Exists(this._DatabaseFileName))
            {
                return; // File.Delete(this._DatabaseFileName);
            }
            SqlCeEngine engine = new SqlCeEngine(this._ConnectionString);
            try
            {
                engine.CreateDatabase();
            }
            catch (SqlCeException sqlexception)
            {
                errorMessage = "error " + sqlexception;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CreateTables(ref string errorMessage)
        {
            try
            {
                string sql;
                SqlCeCommand command;
                sql = "SELECT count(*) FROM Information_Schema.Tables WHERE Table_Name = '" + this._TableName + "'";
                if (this._Connection.State == ConnectionState.Closed)
                {
                    this._Connection.Open();
                }
                command = new SqlCeCommand(sql, this._Connection);
                var count = command.ExecuteScalar();
                if (count != null && (int)count == 1)
                {
                    return;
                }
                sql = "CREATE TABLE [" + this._TableName + "] ( " +
                             "[BreedName] nvarchar(150) NULL" +//
                             ",[BoxIdNew] nvarchar(50) NULL" +//
                             ",[Net] float NULL" +//
                             ",[Gross] float NULL" +//
                             ",[Time] datetime NULL" +//
                             ",[BoxIdOld] nvarchar(50) NULL" +//
                             ",[HarvestDate] datetime NULL" +//
                             ",[UserPostId] bigint NULL" +//
                             ",[ProductId] [uniqueidentifier] NULL " +//
                             ",[Id] [uniqueidentifier] NOT NULL " +//
                             ",[IsComplite] [bit] NOT NULL " +//
                             ",CONSTRAINT [PK_ContainerWeight] PRIMARY KEY ([Id])" +
                             ")";
                command = new SqlCeCommand(sql, this._Connection);
                command.ExecuteNonQuery();
            }
            catch (SqlCeException sqlexception)
            {
                errorMessage = "error " + sqlexception;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this._Connection.Close();
            }
        }

        public DataTable LoadContainerWeightTable(ref string errorMessage)
        {
            DataTable result = new DataTable();
            try
            {
                SqlCeCommand command;
                string sql = "SELECT * FROM " + this._TableName + " ORDER BY Time DESC";
                if (this._Connection.State == ConnectionState.Closed)
                {
                    this._Connection.Open();
                }
                command = new SqlCeCommand(sql, this._Connection);
                SqlCeDataAdapter adapter = new SqlCeDataAdapter(command);
                adapter.SelectCommand = command;
                adapter.Fill(result);
            }
            catch (SqlCeException sqlexception)
            {
                errorMessage = "error " + sqlexception;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this._Connection.Close();
            }
            return result;
        }

        public ProductRepackAndWeight GetContainerWeight(Guid id, ref string errorMessage)
        {
            ProductRepackAndWeight result = null;
            try
            {
                SqlCeCommand command;
                string sql = "SELECT * FROM " + this._TableName + " WHERE Id = @Id";
                if (this._Connection.State == ConnectionState.Closed)
                {
                    this._Connection.Open();
                }
                command = new SqlCeCommand(sql, this._Connection);
                command.Parameters.AddWithValue("@Id", id);
                SqlCeDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = new ProductRepackAndWeight();
                    result.BreedName = reader["BreedName"].ToString();
                    result.ContainerBarCode = reader["BoxIdNew"].ToString();
                    result.Net = decimal.Parse(reader["Net"].ToString());
                    result.Gross = decimal.Parse(reader["Gross"].ToString());
                    result.Time = DateTime.Parse(reader["Time"].ToString());
                    result.OldContainerBarCode = reader["BoxIdOld"].ToString();
                    result.HarvestDate = DateTime.Parse(reader["HarvestDate"].ToString());
                    result.UserPersonPostId = long.Parse(reader["UserPostId"].ToString());
                    result.ProductId = new Guid(reader["ProductId"].ToString());
                    result.Id = new Guid(reader["Id"].ToString());
                    result.IsComplite = bool.Parse(reader["IsComplite"].ToString());

                }
            }
            catch (SqlCeException sqlexception)
            {
                errorMessage = "error " + sqlexception;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this._Connection.Close();
            }
            return result;
        }

        public bool ChackBadRow(ref string errorMessage)
        {
            bool result = false;
            try
            {
                SqlCeCommand command;
                string sql = "SELECT count(*) FROM " + this._TableName + " WHERE IsComplite = 0";
                if (this._Connection.State == ConnectionState.Closed)
                {
                    this._Connection.Open();
                }
                command = new SqlCeCommand(sql, this._Connection);
                var count = command.ExecuteScalar();
                if (count != null && (int)count > 0)
                {
                    result = true;
                }
            }
            catch (SqlCeException sqlexception)
            {
                errorMessage = "error " + sqlexception;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this._Connection.Close();
            }
            return result;
        }

        public void InsertContainerWeightTable(ProductRepackAndWeight productRepackAndWeight, ref string errorMessage)
        {
            try
            {
                   SqlCeCommand command;
                string sql = "INSERT INTO " + this._TableName +
                    " (" +
                    "BreedName" +
                    ",BoxIdNew" +
                    ",Net" +
                    ",Gross" +
                    ",Time" +
                    ",BoxIdOld" +
                    ",HarvestDate" +
                    ",UserPostId" +
                    ",ProductId" +
                    ",Id" +
                    ",IsComplite" +
                    ") " +
                    "VALUES " +
                    "(" +
                    "@BreedName" +
                    ",@BoxIdNew" +
                    ",@Net" +
                    ",@Gross" +
                    ",@Time" +
                    ",@BoxIdOld" +
                    ",@HarvestDate" +
                    ",@UserPostId" +
                    ",@ProductId" +
                    ",@Id" +
                    ",@IsComplite" +
                    ")";
                command = new SqlCeCommand(sql, this._Connection);
                command.Parameters.AddWithValue("@BreedName", productRepackAndWeight.BreedName);
                command.Parameters.AddWithValue("@BoxIdNew", productRepackAndWeight.ContainerBarCode);
                command.Parameters.AddWithValue("@Net", productRepackAndWeight.Net);
                command.Parameters.AddWithValue("@Gross", productRepackAndWeight.Gross);
                command.Parameters.AddWithValue("@Time", productRepackAndWeight.Time);
                command.Parameters.AddWithValue("@BoxIdOld", productRepackAndWeight.OldContainerBarCode);
                command.Parameters.AddWithValue("@HarvestDate", productRepackAndWeight.HarvestDate);
                command.Parameters.AddWithValue("@UserPostId", productRepackAndWeight.UserPersonPostId);
                command.Parameters.AddWithValue("@ProductId", productRepackAndWeight.ProductId);
                command.Parameters.AddWithValue("@Id", productRepackAndWeight.Id);
                command.Parameters.AddWithValue("@IsComplite", productRepackAndWeight.IsComplite);
                if (this._Connection.State == ConnectionState.Closed)
                {
                    this._Connection.Open();
                }
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch (SqlCeException sqlexception)
            {
                errorMessage = "error " + sqlexception;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this._Connection.Close();
            }
        }

        public void UpdateContainerWeightTable(ProductRepackAndWeight productRepackAndWeight, ref string errorMessage)
        {
            try
            {      
        SqlCeCommand command;
                //string sql = "INSERT INTO ContainerWeight (BreedName,Id, IsComplite) values ('df', 'aesda', '0')";
                string sql = "UPDATE [" + this._TableName + "]" +
                    " SET BreedName = @BreedName, " +
                    " BoxIdNew = @BoxIdNew, " +
                    " Net = @Net, " +
                    " Gross = @Gross, " +
                    " Time = @Time, " +
                    " BoxIdOld = @BoxIdOld, " +
                    " HarvestDate = @HarvestDate, " +
                    " UserPostId = @UserPostId, " +
                    " ProductId = @ProductId, " +
                    " IsComplite = @IsComplite " +
                    " WHERE Id = @Id";
                command = new SqlCeCommand(sql, this._Connection);
                command.Parameters.AddWithValue("@BreedName", productRepackAndWeight.BreedName);
                command.Parameters.AddWithValue("@BoxIdNew", productRepackAndWeight.ContainerBarCode);
                command.Parameters.AddWithValue("@Net", productRepackAndWeight.Net);
                command.Parameters.AddWithValue("@Gross", productRepackAndWeight.Gross);
                command.Parameters.AddWithValue("@Time", productRepackAndWeight.Time);
                command.Parameters.AddWithValue("@BoxIdOld", productRepackAndWeight.OldContainerBarCode);
                command.Parameters.AddWithValue("@HarvestDate", productRepackAndWeight.HarvestDate);
                command.Parameters.AddWithValue("@UserPostId", productRepackAndWeight.UserPersonPostId);
                command.Parameters.AddWithValue("@ProductId", productRepackAndWeight.ProductId);
                command.Parameters.AddWithValue("@IsComplite", productRepackAndWeight.IsComplite);
                command.Parameters.AddWithValue("@Id", productRepackAndWeight.Id);
                if (this._Connection.State == ConnectionState.Closed)
                {
                    this._Connection.Open();
                }
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch (SqlCeException sqlexception)
            {
                errorMessage = "error " + sqlexception;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this._Connection.Close();
            }
        }
    }
}
