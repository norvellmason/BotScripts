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
                "if eyes.right && eyes.left",
                " out.value = 5.4",
                "else",
                " out.value = -10"
            };

            HashSet<String> input = new HashSet<String>() {
                "eyes.right",
                "eyes.left"
            };

            HashSet<String> output = new HashSet<String>() {
                "out.value"
            };

            Dictionary<String, object> state = new Dictionary<String, object>() {
                ["eyes.right"] = false,
                ["eyes.left"] = true,
                ["out.value"] = 0f
            };

            CodeParser parser = new CodeParser(lines, input, output);
            Dictionary<String, object> result = parser.Execute(state);
        }
    }
}
