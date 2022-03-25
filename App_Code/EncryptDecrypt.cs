using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EncryptDecrypt
/// </summary>
public static class EncryptDecrypt
{
	
         //public static string Base64Encode(string plainText)
         //   {
         //       var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
         //       return System.Convert.ToBase64String(plainTextBytes);
         //   }
         //public static string Base64Decode(string base64EncodedData)
         //   {
         //       var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
         //       return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
         //   }

         //public static System.Data.SqlTypes.SqlInt32 Base64Decode(System.Data.SqlTypes.SqlInt32 CityID)
         //{
         //    throw new NotImplementedException();
         //}

    public static string Base64Encode(String PlainText)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(PlainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }

    public static string Base64Decode(String Base64EncodeData)
    {
        var Base64EncodedBytes = System.Convert.FromBase64String(Base64EncodeData);
        return System.Text.Encoding.UTF8.GetString(Base64EncodedBytes);
    }



}
