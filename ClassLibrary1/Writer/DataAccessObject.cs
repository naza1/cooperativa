using FileSystem.tablas;
using FileSystem.Tables;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace Cooperativa.FileSystem
{
    public class DataAccessObject
    {
        private SQLiteConnection _dbConnection;
        private SQLiteCommand command;

        public DataAccessObject()
        {
            if (!File.Exists("dataBase\\cooperativa.db3"))
            {
                Directory.CreateDirectory("dataBase");

                SQLiteConnection.CreateFile("dataBase\\cooperativa.db3");

                _dbConnection = new SQLiteConnection("Data Source=dataBase\\cooperativa.db3");

                CreateProjectTable();

                CreateExpenseTable();
            }
            else
            {
                _dbConnection = new SQLiteConnection("Data Source=dataBase\\cooperativa.db3");
            }
        }

        private void CreateProjectTable()
        {
            _dbConnection.Open();

            string sql = $@"CREATE TABLE [Project] ([Id] INTEGER primary key, [Name] TEXT, [StartBudget] REAL, [CreationDate] TEXT, [StartDate] TEXT, [EndDate] TEXT, [Status] TEXT, [Observations] TEXT, [Deleted] TEXT)";

            command = new SQLiteCommand(sql, _dbConnection);

            command.ExecuteNonQuery();

            _dbConnection.Close();
        }

        public void InsertProject(Project project)
        {
            _dbConnection.Open();

            var sql = $@"INSERT INTO[Project] VALUES(null, '{project.Name}', @projectStartBudget, '{project.CreationDate}', '{project.StartDate}', '{project.EndDate}', '{project.Status}', '{project.Observations}', '0')";

            command = new SQLiteCommand(sql, _dbConnection);

            command.Parameters.AddWithValue("@projectStartBudget", project.StartBudget);

            command.ExecuteNonQuery();

            //sql = @"select last_insert_rowid()";
            //command = new SQLiteCommand(sql, _dbConnection);

            //var id = command.ExecuteScalar();

            _dbConnection.Close();

            //return int.Parse(id.ToString());
        }

        public List<Project> GetProjects()
        {
            _dbConnection.Open();

            var sql = "SELECT * FROM [Project] WHERE [Deleted] <> '1'";

            var projectList = new List<Project>();

            using (var cmd = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var project = new Project
                        {
                            Id = rdr.GetInt32(0),
                            Name = rdr.GetString(1),
                            StartBudget = rdr.GetDecimal(2),
                            CreationDate = rdr.GetString(3),
                            StartDate = rdr.GetString(4),
                            EndDate = rdr.GetString(5),
                            Status = rdr.GetString(6),
                            Observations = rdr.GetString(7),
                            Deleted = rdr.GetString(8)
                        };

                        project.CurrentBudget = CalculateCurrentBudget(project.Id, project.StartBudget);
                        project.RemainingDays = CalculateRemainingDays(project.StartDate, project.EndDate);

                        projectList.Add(project);
                    }
                }
            }

            _dbConnection.Close();

            return projectList;
        }

        public decimal CalculateCurrentBudget(int id, decimal startBudget)
        {
            var sql = $"SELECT SUM([TotalPrice]) FROM [Expense] WHERE [Deleted] <> '1' AND [ProjectId] = {id}";

            var total = 0m;

            using (var cmd = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        if (!rdr.IsDBNull(0))
                        {
                            total = rdr.GetDecimal(0);
                        }
                    }
                    
                }
            }

            return startBudget - total;
        }

        public decimal CalculateTotalExpenses(int id)
        {
            _dbConnection.Open();

            var sql = $"SELECT SUM([TotalPrice]) FROM [Expense] WHERE [Deleted] <> '1' AND [ProjectId] = {id}";

            var total = 0m;

            using (var cmd = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        if (!rdr.IsDBNull(0))
                        {
                            total = rdr.GetDecimal(0);
                        }
                    }

                }
            }

            _dbConnection.Close();

            return total;
        }

        private double CalculateRemainingDays(string startDate, string endDate)
        {
            var startDateProject = DateTime.Parse(startDate);

            var endDateProject = DateTime.Parse(endDate);

            if (endDateProject < DateTime.Now)
            {
                return 0;
            }

            if (startDateProject <= DateTime.Now)
            {
                return (endDateProject - DateTime.Now.Date).TotalDays;
            }
            
            return (endDateProject - startDateProject).TotalDays;
        }

        public Project GetProject(int id)
        {
            _dbConnection.Open();

            var sql = $"SELECT * FROM [Project] WHERE Id = {id}";

            command = new SQLiteCommand(sql, _dbConnection);

            var proj = new Project();

            using (var cmd = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {

                        var project = new Project
                        {
                            Id = rdr.GetInt32(0),
                            Name = rdr.GetString(1),
                            StartBudget = rdr.GetDecimal(2),
                            CreationDate = rdr.GetString(3),
                            StartDate = rdr.GetString(4),
                            EndDate = rdr.GetString(5),
                            Status = rdr.GetString(6),
                            Observations = rdr.GetString(7),
                            Deleted = rdr.GetString(8)
                        };

                        proj = project;
                    }
                }
            }

            _dbConnection.Close();

            return proj;
        }

        public void UpdateProject(Project project)
        {
            _dbConnection.Open();

            var sql = $"UPDATE [Project] SET [Name] = '{project.Name}', [StartBudget] = @projectStartBudget, [StartDate] = '{project.StartDate}', [EndDate] = '{project.EndDate}', [Status] = '{project.Status}', [Observations] = '{project.Observations}' WHERE [Id] = {project.Id}";

            command = new SQLiteCommand(sql, _dbConnection);

            command.Parameters.AddWithValue("@projectStartBudget", project.StartBudget);

            command.ExecuteNonQuery();

            _dbConnection.Close();
        }

        public void DeleteProject(int id)
        {
            _dbConnection.Open();

            var sql = $"UPDATE [Project] SET [Deleted] = '1' WHERE [Id] = {id}";

            command = new SQLiteCommand(sql, _dbConnection);

            command.ExecuteNonQuery();


            var sql2 = $"UPDATE [Expense] SET [Deleted] = '1' WHERE [ProjectId] = {id}";

            command = new SQLiteCommand(sql2, _dbConnection);

            command.ExecuteNonQuery();

            _dbConnection.Close();

        }

        private void CreateExpenseTable()
        {
            _dbConnection.Open();

            string sql = $"CREATE TABLE [Expense] ([Id] INTEGER PRIMARY KEY, [ProjectId] INTEGER, [Name] TEXT, [Type] TEXT, [Amount] REAL, [UnitPrice] REAL, [TotalPrice] REAL, [VoucherNumber] TEXT, [Date] TEXT, [Description] TEXT, [Deleted] TEXT, FOREIGN KEY(ProjectId) REFERENCES Poject(Id))";

            command = new SQLiteCommand(sql, _dbConnection);

            command.ExecuteNonQuery();

            _dbConnection.Close();
        }

        public void InsertExpense(Expense expense)
        {
            _dbConnection.Open();

            var sql = $"INSERT INTO[Expense] VALUES(null, {expense.ProjectId}, '{expense.Name}', '{expense.Type}', @expenseAmount, @expenseUnitPrice, @expenseTotalPrice, '{expense.VoucherNumber}', '{expense.Date}', '{expense.Description}', '0')";

            command = new SQLiteCommand(sql, _dbConnection);

            command.Parameters.AddWithValue("@expenseAmount", expense.Amount);

            command.Parameters.AddWithValue("@expenseUnitPrice", expense.UnitPrice);

            command.Parameters.AddWithValue("@expenseTotalPrice", expense.TotalPrice);

            command.ExecuteNonQuery();

            _dbConnection.Close();
        }

        public List<Expense> GetExpenses(int projectId)
        {
            _dbConnection.Open();

            var sql = $"SELECT * FROM [Expense] WHERE [Deleted] <> '1' AND [ProjectId] = {projectId}";

            var expenseList = new List<Expense>();

            using (var cmd = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var expense = new Expense
                        {
                            Id = rdr.GetInt32(0),
                            ProjectId = rdr.GetInt32(1),
                            Name = rdr.GetString(2),
                            Type = rdr.GetString(3),
                            Amount = rdr.GetDecimal(4),
                            UnitPrice = rdr.GetDecimal(5),
                            TotalPrice = rdr.GetDecimal(6),
                            VoucherNumber = rdr.GetString(7),
                            Date = rdr.GetString(8),
                            Description = rdr.GetString(9),
                            Deleted = rdr.GetString(10)
                        };

                        expenseList.Add(expense);
                    }
                }
            }

            _dbConnection.Close();

            return expenseList;
        }

        public Expense GetExpense(int id)
        {
            _dbConnection.Open();

            var sql = $"SELECT * FROM [Expense] WHERE Id = {id}";

            command = new SQLiteCommand(sql, _dbConnection);

            var exp = new Expense();

            using (var cmd = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var expense = new Expense
                        {
                            Id = rdr.GetInt32(0),
                            ProjectId = rdr.GetInt32(1),
                            Name = rdr.GetString(2),
                            Type = rdr.GetString(3),
                            Amount = rdr.GetDecimal(4),
                            UnitPrice = rdr.GetDecimal(5),
                            TotalPrice = rdr.GetDecimal(6),
                            VoucherNumber = rdr.GetString(7),
                            Date = rdr.GetString(8),
                            Description = rdr.GetString(9),
                            Deleted = rdr.GetString(10)
                        };

                        exp = expense;
                    }
                }
            }

            _dbConnection.Close();

            return exp;
        }

        public void UpdateExpense(Expense expense)
        {
            _dbConnection.Open();

            var sql = $"UPDATE [Expense] SET [Name] = '{expense.Name}', [Type] = '{expense.Type}', [Amount] = @expenseAmount, [UnitPrice] = @expenseUnitPrice, [TotalPrice] = @expenseTotalPrice, [VoucherNumber] = '{expense.VoucherNumber}', [Description] = '{expense.Description}' WHERE [Id] = {expense.Id}";

            command = new SQLiteCommand(sql, _dbConnection);

            command.Parameters.AddWithValue("@expenseAmount", expense.Amount);

            command.Parameters.AddWithValue("@expenseUnitPrice", expense.UnitPrice);

            command.Parameters.AddWithValue("@expenseTotalPrice", expense.TotalPrice);

            command.ExecuteNonQuery();

            _dbConnection.Close();
        }

        public void DeleteExpense(int id)
        {
            _dbConnection.Open();

            var sql = $"UPDATE [Expense] SET [Deleted] = '1' WHERE [Id] = {id}";

            command = new SQLiteCommand(sql, _dbConnection);

            command.ExecuteNonQuery();

            _dbConnection.Close();
        }
    }
}