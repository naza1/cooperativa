using FileSystem.Tables;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System;
using System.Globalization;
using FileSystem.tablas;

namespace Cooperativa.FileSystem
{
    public class DataAccessObject
    {
        private SQLiteConnection _dbConnection;
        private SQLiteCommand command;

        public DataAccessObject()
        {

            if (!File.Exists("cooperativa.db3"))
            {
                SQLiteConnection.CreateFile("cooperativa.db3");

                _dbConnection = new SQLiteConnection("Data Source=cooperativa.db3");

                CreateWorkTable();

                CreateProjectTable();

                CreateExpenseTable();
            }
            else
            {
                _dbConnection = new SQLiteConnection("Data Source=cooperativa.db3");
            }

        }

        private void CreateWorkTable()
        {
            _dbConnection.Open();

            string sql = $@"CREATE TABLE [Work] ([Id] INTEGER primary key, [Description] TEXT)";

            command = new SQLiteCommand(sql, _dbConnection);

            command.ExecuteNonQuery();

            _dbConnection.Close();
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

            var projectStartBudget = project.StartBudget;

            var sql = $@"INSERT INTO[Project] VALUES(null, '{project.Name}', @projectStartBudget, '{project.CreationDate}', '{project.StartDate}', '{project.EndDate}', '{project.Status}', '{project.Observations}', '0')";

            command = new SQLiteCommand(sql, _dbConnection);

            command.Parameters.AddWithValue("@projectStartBudget", projectStartBudget);

            command.ExecuteNonQuery();

            _dbConnection.Close();
        }

        public void InsertWork(Work work)
        {
            _dbConnection.Open();

            var sql = $@"INSERT INTO[Work] VALUES(null, '{work.Description}')";

            command = new SQLiteCommand(sql, _dbConnection);

            command.ExecuteNonQuery();

            _dbConnection.Close();
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

                        //project.CurrentBudget = "$ " + CalculateCurrentBudget(project.Id, project.StartBudget.Replace("$ ", "")).ToString().Replace(",", ".");
                        project.RemainingDays = CalculateRemainingDays(project.StartDate, project.EndDate);

                        projectList.Add(project);
                    }
                }
            }

            _dbConnection.Close();

            return projectList;
        }

        public decimal CalculateCurrentBudget(int id, string startBudget)
        {
            var sql = $@"SELECT SUM([TotalPrice]) FROM [Expense] WHERE [Deleted] <> '1' AND [ProjectId] = {id}";

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

            return decimal.Parse(startBudget, CultureInfo.CreateSpecificCulture("en-US")) - total;
        }

        public decimal CalculateTotalExpenses(int id)
        {
            _dbConnection.Open();

            var sql = $@"SELECT SUM([TotalPrice]) FROM [Expense] WHERE [Deleted] <> '1' AND [ProjectId] = {id}";

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

        private int CalculateRemainingDays(string startDate, string endDate)
        {
            var startDateProject = DateTime.Parse(startDate);
            var endDateProject = DateTime.Parse(endDate);

            if (endDateProject < DateTime.Now)
            {
                return 0;
            }

            if (startDateProject <= DateTime.Now)
            {
                return int.Parse((DateTime.Parse(endDate) - DateTime.Now.Date).TotalDays.ToString());
            }
            
            return int.Parse((DateTime.Parse(endDate) - startDateProject).TotalDays.ToString());
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

            var sql = $@"UPDATE [Project] SET [Name] = '{project.Name}', [StartBudget] = '{project.StartBudget}', [StartDate] = '{project.StartDate}', [EndDate] = '{project.EndDate}', [Status] = '{project.Status}', [Observations] = '{project.Observations}' WHERE [Id] = {project.Id}";

            command = new SQLiteCommand(sql, _dbConnection);

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

            string sql = $@"CREATE TABLE [Expense] ([Id] INTEGER PRIMARY KEY, [ProjectId] INTEGER, [Name] TEXT, [Type] TEXT, [Amount] TEXT, [UnitPrice] TEXT, [TotalPrice] TEXT, [VoucherNumber] TEXT, [Date] TEXT, [Description] TEXT, [Deleted] TEXT, FOREIGN KEY(ProjectId) REFERENCES Poject(Id))";

            command = new SQLiteCommand(sql, _dbConnection);

            command.ExecuteNonQuery();

            _dbConnection.Close();
        }

        public void InsertExpense(Expense expense)
        {
            _dbConnection.Open();

            var sql = $@"INSERT INTO[Expense] VALUES(null, {expense.ProjectId}, '{expense.Name}', '{expense.Type}', '{expense.Amount}', '{expense.UnitPrice}', '{expense.TotalPrice}', '{expense.VoucherNumber}', '{expense.Date}', '{expense.Description}', '0')";

            command = new SQLiteCommand(sql, _dbConnection);

            command.ExecuteNonQuery();

            _dbConnection.Close();
        }

        public List<Expense> GetExpenses(int projectId)
        {
            _dbConnection.Open();

            var sql = $@"SELECT * FROM [Expense] WHERE [Deleted] <> '1' AND [ProjectId] = {projectId}";

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
                            Amount = rdr.GetString(4),
                            UnitPrice = "$ " + rdr.GetString(5),
                            TotalPrice = "$ " + rdr.GetString(6),
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

            var sql = $@"SELECT * FROM [Expense] WHERE Id = {id}";

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
                            Amount = rdr.GetString(4),
                            UnitPrice = rdr.GetString(5),
                            TotalPrice = rdr.GetString(6),
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

            var sql = $@"UPDATE [Expense] SET [Name] = '{expense.Name}', [Type] = '{expense.Type}', [Amount] = '{expense.Amount}', [UnitPrice] = '{expense.UnitPrice}', [TotalPrice] = '{expense.TotalPrice}', [VoucherNumber] = '{expense.VoucherNumber}', [Description] = '{expense.Description}' WHERE [Id] = {expense.Id}";

            command = new SQLiteCommand(sql, _dbConnection);

            command.ExecuteNonQuery();

            _dbConnection.Close();
        }

        public void DeleteExpense(int id)
        {
            _dbConnection.Open();

            var sql = $@"UPDATE [Expense] SET [Deleted] = '1' WHERE [Id] = {id}";

            command = new SQLiteCommand(sql, _dbConnection);

            command.ExecuteNonQuery();

            _dbConnection.Close();
        }
    }
}