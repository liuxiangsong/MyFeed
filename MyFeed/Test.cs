using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Dapper;
using MyFeed.Entity;

namespace MyFeed
{
   public class Test
    {
        public static void SelectTest()
        {
            string sql = "select * from testentity where id=1";
            SQLiteConnection conn = SqliteHelper.GetConnection();
            var v = conn.Query<TestEntity>(sql);
        }

        public static void InsertTest()
        {
            string sql = "INSERT INTO [TestEntity]([Title],[Content],[CreateDate]) VALUES('title1','content2' ,'1999.1.1')";
            SQLiteConnection conn = SqliteHelper.GetConnection();
            var v = conn.Execute(sql);
        }

       public static void UpdateTest()
        {
            SQLiteConnection conn = SqliteHelper.GetConnection();
          
            using (var tran = conn.BeginTransaction())
           {
               try
               {
                   string sql = "update  TestEntity set title='we' where id=10";
                   var v = conn.Execute(sql);
                   sql = "delete from   TestEntity where id=12";
                   var asa = conn.Execute(sql);
                   tran.Commit();
               }
               catch  
               {
                   tran.Rollback();
               }
               
           }
       }

       public static void DeleteTest2()
        {
            string sql = "delete from TestEntity where id=12";
            SQLiteConnection conn =SqliteHelper.GetConnection();
            var v = conn.Execute(sql);
        }

       public static void InsertTest2()
       {
           TestEntity entity = new TestEntity();
           entity.Title = "title";
           entity.Content = "content";

           List<string> columns = new List<string>();
           foreach (var prop in entity.GetType().GetProperties())
           {
               if (prop.Name != "Id" && prop.GetValue(entity) != null)
               {
                   columns.Add(prop.Name);
               }
           }
           string commandText = string.Format("INSERT INTO [TestEntity]([{0}]) VALUES(@{1})",
               string.Join("],[", columns), string.Join(",@", columns));
           SQLiteConnection conn = SqliteHelper.GetConnection();
           var v = conn.Execute(commandText, entity);
       }


       //private static object GetValue(TestEntity entity, string propertyName)
       //{ 
       //    return entity.GetType().GetProperty(propertyName).GetValue(entity, null);
       //}
    }

    public class EntityA
    {
        public  EntityA()
        {
            
        }

        public string SayHello()
        {
            return "Hello";
        }
    }

    public abstract class absB : EntityA
    {
        public abstract void Calc();
          string Test()
        {
            return "test";
        }
    }

    public interface IT
    {
        string a();
    }
}
