using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web09052024
{
    public class GlobFunc
    {
        public static string getRundStr(int length)
        {
            string str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string retStr = "";
            int index;
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
               index= rnd.Next(str.Length);
                retStr += str[index];
            }

            return retStr;
        }
    }
}