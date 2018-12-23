using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paygate.Utility
{
   public class NumberUtilities
    {
       public static Int64 ConvertToLong(object number)
       {
           try
           {
               return number != null ? System.Convert.ToInt64(number) : 0;
           }catch
           {
               return 0;
           }
       }

       public static Int32 ConvertToInt32(object number)
       {
           try
           {
               return number != null ? System.Convert.ToInt32(number) : 0;
           }
           catch
           {
               return 0;
           }
       }
    }
}
