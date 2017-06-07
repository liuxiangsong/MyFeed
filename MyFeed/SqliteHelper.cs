using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Dapper;
using MyFeed.Entity;

namespace MyFeed
{

    public class SqliteHelper
    {
        //  private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["MyFeed"].ToString();
        private static Dictionary<string, string> _cacheDict = new Dictionary<string, string>();

        public static SQLiteConnection GetConnection()
        {
            string dbFilePath = Environment.CurrentDirectory + "\\MyFeedSqlite.db";
            string _connectionString = string.Format("Data Source={0}", dbFilePath);
            SQLiteConnection conn = new SQLiteConnection(_connectionString);
            conn.Open();
            return conn;
        }

        public static Article GetAArticle()
        {
            Article entity = new Article();
            SQLiteConnection conn = GetConnection();
            using (var tran = conn.BeginTransaction())
            {
                try
                {
                    string commandText = "select * from Article where Flag=0 limit 1";
                    entity = conn.Query<Article>(commandText).FirstOrDefault();
                    commandText = string.Format("update Article set Flag=1 where id={0}", entity.Id);
                    conn.Execute(commandText);
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                }
            }
            return entity;
        }

        public static bool Exists(string sql)
        {
            using (SQLiteConnection conn = GetConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    return cmd.ExecuteReader().HasRows; 
                }
            }
        }

        public static int ExecuteNonQuery(string sql)
        {
            using (SQLiteConnection conn = GetConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataSet ExcuteDataSet(string sql)
        {
            using (SQLiteConnection conn = GetConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    DataSet dataSet=new DataSet();
                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(dataSet);
                    }
                    return dataSet;
                }
            }
        }

        public static List<T> Select<T>()
        {
            string commandText = string.Format("select * from {0}", typeof(T).Name);
            using (SQLiteConnection conn = GetConnection())
            {
                return conn.Query<T>(commandText).ToList();
            }
        }

        public static int Insert<T>(T entity, bool cache = true)
        {
            string commandText = GetInsertCommandText(entity, cache);
            SQLiteConnection conn = GetConnection(); 
            return conn.Execute(commandText, entity);
        }

        private static string GetInsertCommandText<T>(T entity, bool cache = true)
        {
            string dictKey = string.Format("Insert:{0}", typeof(T).Name);
            if (cache && _cacheDict.ContainsKey(dictKey))
            {
                return _cacheDict[dictKey];
            }

            List<string> columns = new List<string>();
            foreach (var prop in entity.GetType().GetProperties())
            {
                if (prop.Name != "Id" && prop.GetValue(entity) != null)
                {
                    columns.Add(prop.Name);
                }
            }
            string commandText = string.Format("INSERT INTO [{0}]([{1}]) VALUES(@{2})",
              typeof(T).Name, string.Join("],[", columns), string.Join(",@", columns));

            if (cache && !_cacheDict.ContainsKey(dictKey))
            {
                _cacheDict[dictKey] = commandText;
            }
            return commandText;
        }
    }
}
