using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// Provides the ability to parse an expression into a value.
    /// </summary>
    public class Parser
    {
        /// <summary>
        /// Performs an operation on a single operand. If the opertion cannot be
        /// applied to the operand, an OperationException should be thrown,
        /// describing the exception.
        /// </summary>
        /// 
        /// <param name="operand">the operand to process</param>
        /// 
        /// <returns>the result of the operation</returns>
        public delegate object UnaryOperator(object operand);

        /// <summary>
        /// Performs an operation on two operands. If the operation cannot be
        /// applied to the operands, an OperationException should be thrown,
        /// describing the exception.
        /// </summary>
        /// 
        /// <param name="leftOperand">the left side operand</param>
        /// <param name="rightOperand">the right side operand</param>
        /// 
        /// <returns>the result of the operation</returns>
        public delegate object InfixOperator(object leftOperand, object rightOperand);

        /// <summary>
        /// Retrieves the value of a variable using its name. If there is an
        /// error while getting the value of the variable, an ArgumentException
        /// should be thrown with a message describing the exception.
        /// </summary>
        /// 
        /// <param name="variableName">the name of the variable to retrive the
        /// value of</param>
        /// 
        /// <returns>the value of the requested variable</returns>
        public delegate object VariableLookup(String variableName);

        // the unary operators supported by this parser
        private Dictionary<String, UnaryOperator> unaryOperators;

        // the infix operators supported by this parser
        private Dictionary<String, InfixOperator> infixOperators;

        // the order that infix operator will be executed in
        private List<String> infixOrder;

        // the variables names supported by this parser
        private HashSet<String> variableNames;

        /// <summary>
        /// Construct a Parser with the given unary operators, infix operator,
        /// and variable names.
        /// </summary>
        /// 
        /// <param name="unaryOperators">the supported unary operators</param>
        /// <param name="infixOperators">the supported infix operators</param>
        /// <param name="variableNames">the supported variable names</param>
        public Parser(Dictionary<String, UnaryOperator> unaryOperators, Dictionary<String, InfixOperator> infixOperators, List<String> infixOrder, HashSet<String> variableNames)
        {
            this.unaryOperators = unaryOperators;
            this.infixOperators = infixOperators;
            this.infixOrder = infixOrder;
            this.variableNames = variableNames;
        }

        /// <summary>
        /// Parses an expression using the given variable lookup. If an error
        /// occurs while parsing the expression, a ParseException will be
        /// thrown.
        /// </summary>
        /// 
        /// <param name="expression">the expression to parse</param>
        /// <param name="lookup">the lookup to use</param>
        /// 
        /// <returns>the result of the expression</returns>
        public object Parse(String expression, VariableLookup lookup)
        {
            // remove whitespace from the expression
            expression = Regex.Replace(expression, "\\s+", "");

            // tokenize the string
            List<object> tokens = Tokenize(expression, lookup);

            for(int index = 0; index < tokens.Count; index++)
            {
                if(tokens[index] is String op)
                {
                    if(index - 1 < 0 || tokens[index - 1] is String)
                    {
                        // operator is unary!!!
                        if(index + 1 < tokens.Count && !(tokens[index + 1] is String))
                        {
                            object operand = tokens[index + 1];

                            tokens.RemoveRange(index, 2);
                            tokens.Insert(index, unaryOperators[op](operand));
                        }
                        else
                        {
                            throw new ParseException("Unary operator '" + op + "' is in invalid position");
                        }
                    }
                }
            }

            foreach(String globOp in infixOrder)
            {
                for(int index = 0; index < tokens.Count; index++)
                {
                    if(tokens[index] is String op)
                    {
                        if(op == globOp)
                        {
                            if(index - 1 < 0 || tokens[index - 1] is String || index + 1 >= tokens.Count || tokens[index + 1] is String)
                                throw new ParseException("Infix operator '" + op + "' is in invalid position");

                            object leftOperand = tokens[index - 1];
                            object rightOperand = tokens[index + 1];

                            tokens.RemoveRange(index - 1, 3);
                            tokens.Insert(--index, infixOperators[op](leftOperand, rightOperand));
                        }
                    }
                }
            }

            if(tokens.Count == 1)
                return tokens[0];

            throw new ParseException("Expression did not properly evaluate");
        }

        /// <summary>
        /// Tokenizes an expression into the relevant symbols.
        /// </summary>
        /// 
        /// <param name="expression">the expression to tokenize</param>
        /// <param name="lookup">the lookup to use for variables</param>
        /// 
        /// <returns>the tokens in the expression</returns>
        private List<object> Tokenize(String expression, VariableLookup lookup)
        {
            List<object> tokens = new List<object>();
            while(expression.Length > 0)
            {
                String match = "";
                String type = null;

                if(expression[0] == '(')
                {
                    match = expression.Substring(0, GetClosingParenthesisPosition(expression) + 1);
                    object result = match.Substring(1, match.Length - 1);

                    if(result is float || result is bool)
                        tokens.Add(result);
                    else
                        throw new ParseException("Subexpression did not return a float or bool");
                }
                else
                {
                    FindMatch(expression, unaryOperators.Keys, "operator", ref match, ref type);
                    FindMatch(expression, infixOperators.Keys, "operator", ref match, ref type);
                    FindMatch(expression, variableNames, "variable", ref match, ref type);

                    if(type == "operator")
                    {
                        tokens.Add(match);
                    }
                    else if(type == "variable")
                    {
                        try
                        {
                            tokens.Add(lookup(match));
                        }
                        catch(ArgumentException ae)
                        {
                            throw new ParseException("Failed to retieve value of variable '" + match + "':\n" + ae.Message);
                        }
                    }
                    else
                    {
                        Match matchResult = Regex.Match(expression, @"(?:^\d+(\.\d+)?)|(?:^\.\d+)");
                        if(matchResult.Success)
                        {
                            match = matchResult.Value;
                            tokens.Add(float.Parse(match));
                        }
                        else
                        {
                            throw new ParseException("Unknown token starting at '" + expression + "'");
                        }
                    }
                }

                expression = expression.Substring(match.Length);
            }

            return tokens;
        }

        /// <summary>
        /// Finds the position of the parentehsis that closes the first
        /// parenthesis found in the expression
        /// </summary>
        /// 
        /// <param name="expression">the expression to search</param>
        /// 
        /// <returns>the position of the closing parenthesis</returns>
        private int GetClosingParenthesisPosition(String expression)
        {
            int depth = 0;
            for(int index = 0; index < expression.Length; index++)
            {
                if(expression[index] == '(')
                {
                    depth += 1;
                }
                else if(expression[index] == ')')
                {
                    depth -= 1;

                    if(depth == 0)
                        return index;
                }
            }

            if(depth == 0)
                throw new ParseException("No parentheses found");

            throw new ParseException("No closing parenthesis found");
        }

        /// <summary>
        /// Search through the given values to see if any of them are the start
        /// of the given expression.
        /// </summary>
        /// 
        /// <param name="expression">the expression to check</param>
        /// <param name="values">the values to search for</param>
        /// <param name="valueType">the type of the given values</param>
        /// <param name="match">the current match</param>
        /// <param name="type">the current type</param>
        private void FindMatch(String expression, IEnumerable<String> values, String valueType, ref String match, ref String type)
        {
            foreach(String value in values)
            {
                if(value.Length > match.Length && expression.IndexOf(value) == 0)
                {
                    match = value;
                    type = valueType;
                }
            }
        }

        /// <summary>
        /// Describes an exception that occurs while executing an operation.
        /// </summary>
        public class OperationException : Exception
        {
            /// <summary>
            /// Construct a new OperationException with the given message.
            /// </summary>
            /// 
            /// <param name="message">the exception message</param>
            public OperationException(String message) : base(message)
            {
            }
        }

        /// <summary>
        /// Describes an exception that occurs while parsing an exception.
        /// </summary>
        public class ParseException : Exception
        {
            /// <summary>
            /// Construct a new ParseException with the given message.
            /// </summary>
            /// 
            /// <param name="message">the exception message</param>
            public ParseException(String message) : base(message)
            {
            }
        }
    }
}
