using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Engine;

namespace CodeParserTests
{
    [TestClass]
    public class CodeParserTests
    {
        [TestMethod]
        public void GenericTest()
        {
            String[] lines = {
                "out.value = 5.4"
            };

            HashSet<String> input = new HashSet<String>() {
                "eyes.right",
                "eyes.left"
            };

            HashSet<String> output = new HashSet<String>() {
                "out.value"
            };

            Dictionary<String, object> state = new Dictionary<String, object>() {
                ["eyes.right"] = true,
                ["eyes.left"] = false,
                ["out.value"] = false
            };

            CodeParser parser = new CodeParser(lines, input, output);
            Dictionary<String, object> result = parser.Execute(state);
        }
    }
}
