using FileSystem.Tables;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System;

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

                CreateProjectTable();
            }
            else
            {
                _dbConnection = new SQLiteConnection("Data Source=cooperativa.db3");
            }

        }

        private void CreateProjectTable()
        {

            _dbConnection.Open();

            string sql = "create table Project (Id integer primary key, Name varchar(50), StartBudget decimal(8,2), CurrentBudget decimal(8,2), CreationDate text, StartDate text, EndDate text, Status text, Deleted numeric)";

            command = new SQLiteCommand(sql, _dbConnection);

            command.ExecuteNonQuery();

            _dbConnection.Close();
        }

        public void InsertProject(Project project)
        {
            _dbConnection.Open();

            var sql = $@"INSERT INTO[Project] VALUES(null, '{project.Name}', {project.StartBudget}, {project.CurrentBudget}, '{project.CreationDate}', '{project.StartDate}', '{project.EndDate}', '{project.Status}', '{project.Deleted}')";

            command = new SQLiteCommand(sql, _dbConnection);

            command.ExecuteNonQuery();

            _dbConnection.Close();
        }

        public List<Project> GetProjects()
        {
            _dbConnection.Open();

            var sql = $@"SELECT * FROM [Project] where [Deleted] <> 1;";

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
                            CurrentBudget = rdr.GetDecimal(3),
                            CreationDate = rdr.GetString(4),
                            StartDate = rdr.GetString(5),
                            EndDate = rdr.GetString(6),
                            Status = rdr.GetString(7),
                            Deleted = rdr.GetString(8)
                        };

                        projectList.Add(project);
                    }
                }
            }

            _dbConnection.Close();

            return projectList;
        }

        public void UpdateProject(Project project)
        {
            _dbConnection.Open();

            var sql = $@"UPDATE [Project] SET [Name] = '{project.Name}', [StartBugdet] = {project.StartBudget}, [CreationDate] = '{project.CreationDate}', [StartDate] = '{project.StartDate}', [EndDate] = '{project.EndDate}', [Status] = '{project.Status}', [Deleted] = {project.Deleted}";

            command = new SQLiteCommand(sql, _dbConnection);

            command.ExecuteNonQuery();

            _dbConnection.Close();
        }

        public Project GetProject(int id)
        {
            _dbConnection.Open();

            var sql = $@"SELECT * FROM [Project] WHERE Id = {id}";

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
                            CurrentBudget = rdr.GetDecimal(3),
                            CreationDate = rdr.GetString(4),
                            StartDate = rdr.GetString(5),
                            EndDate = rdr.GetString(6),
                            Status = rdr.GetString(7),
                            Deleted = rdr.GetString(8)
                        };

                        proj = project;
                    }
                }
            }

            _dbConnection.Close();

            return proj;
        }
    }
}