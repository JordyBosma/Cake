using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// Checks if the user input is equal to the SHA-Encrypted password.
/// </summary>
public class Auth  
{
    private Database db;

    /// <summary>
    /// User login
    /// </summary>
    public int Login(string username, string password)
    {
        password = SHAGenerate.GenerateSHAString(password);
        using (db = Database.Open("Db_Fondanti"))
        {
            int login = db.QueryValue("SELECT COUNT(*) FROM Accounts WHERE Username = @0 AND Password = @1", username, password);
            return login;
        }
    }
}
