using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Engine;

namespace ParserTests
{
    [TestClass]
    public class ParseTester
    {
        [TestMethod]
        public void GenericTest()
        {
            Dictionary<String, Parser.UnaryOperator> unaryOperators = new Dictionary<String, Parser.UnaryOperator>();
            unaryOperators.Add("-", (operand) => {
                if(operand is float)
                    return -((float)operand);

                throw new ArgumentException("Cannot negate a boolean");
            });

            Dictionary<String, Parser.InfixOperator> infixOperators = new Dictionary<String, Parser.InfixOperator>();
            infixOperators.Add("+", (left, right) => {
                if(left is float && right is float)
                    return ((float)left) + ((float)right);

                throw new ArgumentException("Can only add two floats");
            });

            List<String> infixOrder = new List<String>() {
                "+"
            };

            HashSet<String> variableNames = new HashSet<String>() { "PI" };

            Parser.VariableLookup lookup = (name) => {
                switch(name)
                {
                    case "PI":
                        return 3.14159265358;
                }

                throw new ArgumentException("'" + name + "' is not a recognized variable");
            };

            Parser parser = new Parser(unaryOperators, infixOperators, infixOrder, variableNames);

            object result = parser.Parse("PI", lookup);
        }
    }
}
