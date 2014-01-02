using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CellPhoneShop
{
    public class RegisterState
    {
        public static int Success = 1;
        public static int UsernameExist = 2;
        public static int InfoInValid = 3;
        public static int Error = 4;
    }

    public class RatingState
    {
        public static int Success = 1;
        public static int NotLogin = 0;
        public static int Error = -1;
    }
}