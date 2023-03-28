using System;
using System.Collections.Generic;
using System.Text;

namespace HousekeeperApp.Common
{
    public static class SeederConstants
    {
        public static List<string> firstNames = new List<string>() { "Alex", "Jack", "Jane", "John", "Ivan" };
        public static List<string> lastNames = new List<string>() { "Alexandrov", "Johnson", "Ivanov", "Petrov" };
        public static List<string> mails = new List<string>() { "mail.bg", "abv.bg", "live.com", "gmail.com", "mail.ru", "outlook.com" };

        public const string Password = "123456";

        public const string AdminEmail = "admin@abv.bg";
        public const string AdminFirstName = "Admin";
        public const string AdminLastName = "Admin";
        public static string username = "{0}{1}{2}@{3}";
    }
}
