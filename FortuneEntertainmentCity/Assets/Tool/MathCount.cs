using System;
using System.Security.Cryptography;

public static class MathCount {
    public static string GetDataSize(long size) {
        var num = 1024.00;
        if(size < num)
            return size + "B";
        if(size < Math.Pow(num, 2))
            return ( size / num ).ToString("f2") + "KB";
        if(size < Math.Pow(num, 3))
            return ( size / Math.Pow(num, 2) ).ToString("f2") + "MB";
        if(size < Math.Pow(num, 4))
            return ( size / Math.Pow(num, 3) ).ToString("f2") + "GB";
        return ( size / Math.Pow(num, 4) ).ToString("f2") + "TB";
    }
    public static string GetRandom(int length) {
        using(var crypto = new RNGCryptoServiceProvider()) {
            int bits = ( length * 6 );
            int byteSize =  ( bits + 7 ) / 8 ;
            byte[] bytesArray = new byte[byteSize];
            crypto.GetBytes(bytesArray);
            return Convert.ToBase64String(bytesArray);
        }
    }
}
