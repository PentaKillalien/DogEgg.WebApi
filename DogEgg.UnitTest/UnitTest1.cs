using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DogEgg.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LeetCode()
        {
            int a = -423423;
            string b = a.ToString();
            char[] c = b.ToCharArray();
            Array.Reverse(c);
            var d = Int32.Parse(c);
            
            System.Console.WriteLine(d);
        }
    }
}
