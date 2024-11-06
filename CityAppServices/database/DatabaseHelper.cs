using CityAppServices.Objects.Entities;
using Dapper;
using Microsoft.Data.Sqlite;
using Windows.Storage;

namespace CityAppServices.Objects.database
{
    internal class DatabaseHelper
    {
        internal string dbname = "cityscapedb.db";
        List<string> databasesTables = new List<string>();
        internal DatabaseHelper()
        {
        }
        internal void CheckOrCreateDB()
        {
            try
            {
                SettingEntity droptablesetting = GlobalServices.GettingSetting("dbname");
                droptablesetting.IntSetting = 1;
                if (DBExists() == false)
                {
                    CreateDB();
                }
                CreateTableListAsync();
                if (droptablesetting.IntSetting == 1)
                {
                    DropAllTables();
                }
                CreateTables();
                SettingsRepository settingsRepository = new SettingsRepository();
                GlobalServices.Settings = settingsRepository.GetSetting();
                if (GlobalServices.Settings.Count == 0)
                {
                    GlobalServices.InsertSetting("droptables", "true", 1);
                    GlobalServices.InsertSetting("emaillog", "true", 1);
                    GlobalServices.InsertSetting("aninationTime", "15000", 1);
                }
                SettingEntity thisSetting = GlobalServices.GetSettingByName("travelspeed");
                if (thisSetting == null || thisSetting.Name == "")
                    GlobalServices.InsertSetting("travelspeed", "", 10);
                 thisSetting = GlobalServices.GetSettingByName("campfire");
                if (thisSetting == null || thisSetting.Name == "")
                    GlobalServices.InsertSetting("campfire", "", 5);
                thisSetting = GlobalServices.GetSettingByName("badguycount");
                if (thisSetting == null || thisSetting.Name == "")
                    GlobalServices.InsertSetting("badguycount", "", 1);
                thisSetting = GlobalServices.GetSettingByName("policecarspeed");
                if (thisSetting == null || thisSetting.Name == "")
                    GlobalServices.InsertSetting("policecarspeed", "", 15);
                thisSetting = GlobalServices.GetSettingByName("policecarspeed");
                if (thisSetting == null || thisSetting.Name == "")
                    GlobalServices.InsertSetting("campfiresleeptime", "", 10);

                
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        private void DropAllTables()
        {
            var connection = GetConnection();
            var command = new SqliteCommand();
            command.Connection = connection;

  
                try
                {
                      command.CommandText = @"drop TABLE Person";
                      if (DoesTableExist("Person"))
                        command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw;
                }
            try
            {
                command.CommandText = @"drop TABLE PersonImage";

                if (DoesTableExist("PersonImage"))
                    command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw;
            }
            try
            {
                command.CommandText = @"drop TABLE Image";

                if (DoesTableExist("Image"))
                    command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw;
            }
            try
            {
                     command.CommandText = @"drop TABLE House";

                if (DoesTableExist("House"))
                    command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw;
            }
            try
            {
                    command.CommandText = @"drop TABLE Business";

                if (DoesTableExist("Business"))
                    command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private async Task CreateTableListAsync()
        {
            var connection = GetConnection();
            string checksql = "SELECT name FROM sqlite_master WHERE type='table';";
            List<string> tables = new List<string>();
            var tablese =await connection.QueryAsync<string>(checksql);
            foreach (var row in tablese) 
            {
                databasesTables.Add(row);
            }
    
        }
        private bool DoesTableExist(string tableName)
        {
            bool result = false;
            try
            {
               var found = from t in databasesTables where t == tableName select t;
               if (found != null && found.Count() > 0) 
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }
        internal SqliteConnection GetConnection()
        {
            string connectionString = $"Data Source={dbname};Version=3";
            SqliteConnection connection;
            try
            {
                connection = new SqliteConnection(connectionString);
                connection.Open();
            }
            catch (Exception ex)
            {

                throw;
            }
           return connection;
        }
        private bool DBExists()
        {
            bool exists = false;
            if (File.Exists(dbname))
                exists = true;
            return exists;
        }
        private void CreateDB()
        {
            try
            {
                ApplicationData.Current.LocalFolder
           .CreateFileAsync(dbname, CreationCollisionOption.OpenIfExists);
                string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path,
                                             dbname);
                //SqliteConnection.CreateFile(dbname);
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void CreateTables()
        {
            var connection =GetConnection();
            var command = new SqliteCommand();
            command.Connection = connection;

            try
            {

                try
                {
                    command.CommandText = @"
                CREATE TABLE if not exists  Person (
                    PersonID INTEGER PRIMARY KEY,
                    Name TEXT, 
                    CurrentImageKey integer,
                    PersonRole TEXT, 
                    IsUser INTEGER,
                    Funds REAL,
                    CurrentImage TEXT,
                    Active bit
                )";
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw;
                }

                command.CommandText = @"
                CREATE TABLE if not exists   PersonImage (
                    PersonImageID INTEGER PRIMARY KEY,
                    FKImageID INTEGER ,   
                    Name TEXT, 
                    PersonImageType TEXT, 
                    FilePath TEXT, 
                    ImageType TEXT, 
                    FKPersonID INTEGER,
                    PersonImageStatus TEXT
                )";
                command.CommandText = @"
                CREATE TABLE if not exists Image (
                    ImageID INTEGER PRIMARY KEY,
                    Name TEXT, 
                    Filename TEXT,
                    FilePath TEXT, 
                    NamePart TEXT,
                    NumberPart TEXT,
                    SequenceNumber TEXT,
                    TrailingPart TEXT,
                    ImageRole TEXT
        
                )";
                command.ExecuteNonQuery();
                command.CommandText = @"
                CREATE TABLE  if not exists House (
                    HouseID INTEGER PRIMARY KEY,
                    Name TEXT, 
                    OwnerName TEXT, 
                    imageFileName TEXT, 
                    ImageLivingRoomFileName TEXT, 
                    ImageKitchenFileName TEXT, 
                    ImageGarageFileName TEXT, 
                    IsUserHouse INTEGER
                )";
                command.ExecuteNonQuery();
               
                command.CommandText = @"
                CREATE TABLE  if not exists Business (
                   BusinessID INTEGER PRIMARY KEY,
                   Name TEXT, 
                   BusinessType TEXT, 
                   ImageName TEXT,
                   EmployeePayHour NUMERIC 
                )";
                command.ExecuteNonQuery();

                if (DoesTableExist("Settings") == false)
                {
                    command.CommandText = @"
                        CREATE TABLE  if not exists Settings (
                           SettingID INTEGER PRIMARY KEY,
                           Name TEXT, 
                           StringSetting TEXT, 
                           IntSetting INT
                        )";
                    command.ExecuteNonQuery();

                }
                command.CommandText = @"
                        CREATE TABLE  if not exists Logging (
                           LoggingID INTEGER PRIMARY KEY,
                           ClassName TEXT, 
                           MethodName TEXT, 
                           Message TEXT,
                           RunTime NUMERIC
                        )";
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
