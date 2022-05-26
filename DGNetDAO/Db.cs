using System;
using System.Data.SQLite;
using System.IO;

namespace DGNetDAO
{
  public class Db
  {
    private static string databasePath = string.Empty;
    private static string Constr = string.Empty;

    public static void Initialize()
    {
      try
      {
        if (databasePath.Equals(string.Empty))
        {
          databasePath = Directory.GetCurrentDirectory() + "\\AppData";
          if (!Directory.Exists(databasePath))
          {
            Directory.CreateDirectory(databasePath);
          }

          databasePath = Directory.GetCurrentDirectory() + "\\AppData\\DGNetV2.db3";
        }

        if (!File.Exists(databasePath))
        {
          //logger.Info("Creating database file");
          SQLiteConnection.CreateFile(databasePath);
          Constr = "Data Source =" + databasePath + "; Pooling = True; foreign_keys = true;";
          SQLiteConnection con = new SQLiteConnection(Constr);

          CreateDb();
        }
        else
        {
          //UpgradeDb();
        }
      }
      catch (Exception ex)
      {
        throw new Exception("Unable to Initialize Database. " + ex.Message);
      }
    }

    public static void CreateDb()
    {
      try
      {
        if (Constr == "") throw new Exception("Connection string not set");
        using (SQLiteConnection dbcon = GetConnection())
        {
          SQLiteCommand cmd = new SQLiteCommand(dbcon);
          cmd.CommandText = "CREATE TABLE IF NOT EXISTS [Product] (" +
          "Href TEXT," +
          "Code TEXT UNIQUE NOT NULL PRIMARY KEY," +
          "Title TEXT," +
          "Description TEXT," +
          "SellingPrice TEXT," +
          "OnHand TEXT," +
          "ProductLine TEXT," +
          "VendorCode TEXT," +
          "UpcBarcode TEXT," +
          "Eta TEXT," +
          "Status TEXT," +
          "DateCreated TEXT," +
          "DateModified TEXT); \n" +

          "CREATE TABLE IF NOT EXISTS [Image] (" +
          "Code TEXT REFERENCES Product (Code)," +
          "ImageUrl TEXT," +
          "ShortDescription TEXT," +
          "LongDescription TEXT); \n" +

          "CREATE TABLE IF NOT EXISTS [ErrorLog] (" +
          "Type TEXT NOT NULL," +
          "Code TEXT," +
          "Description TEXT NOT NULL," +
          "Location TEXT," +
          "DateCreated DATETIME NOT NULL); \n" +

          "CREATE UNIQUE INDEX idxProductCode ON Product (Code); \n" +
          "CREATE UNIQUE INDEX idxImageCode ON Image (Code); \n" +
          "CREATE INDEX idxProductLine ON Product (ProductLine);";

          cmd.ExecuteNonQuery();
        }
      }
      catch (Exception ex)
      {
        throw new Exception("Unable to Create Database. " + ex.Message);
      }
    }

    public static SQLiteConnection GetConnection()
    {
      Constr = "Data Source =" + Directory.GetCurrentDirectory() + "\\AppData\\DGNetV2.db3; Pooling = 1; foreign_keys = 1; automatic_index = 0";

      SQLiteConnection dbcon = new SQLiteConnection(Constr);

      dbcon.Open();
      return dbcon;
    }
  }
}
