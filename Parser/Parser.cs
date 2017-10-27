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
        public Parser(Dictionary<String, UnaryOperator> unaryOperators, Dictionary<String, InfixOperator> infixOperators, HashSet<String> variableNames)
        {
            this.unaryOperators = unaryOperators;
            this.infixOperators = infixOperators;
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

            List<Token> tokens = new List<Token> ();
            while(expression.Length > 0)
            {
                String match = "";
                Token.TokenType type = Token.TokenType.CONSTANT;

                FindMatch(expression, unaryOperators.Keys, Token.TokenType.UNARY, ref match, ref type);
                FindMatch(expression, infixOperators.Keys, Token.TokenType.INFIX, ref match, ref type);
                FindMatch(expression, variableNames, Token.TokenType.VARIABLE, ref match, ref type);

                if(type == Token.TokenType.CONSTANT)
                {
                    Match matchResult = Regex.Match(expression, @"(?:^\d+(\.\d+)?)|(?:^\.\d+)");
                    if(matchResult.Success)
                        match = matchResult.Value;
                    else
                        throw new ParseException("Unknown token starting at '" + expression + "'");
                }

                tokens.Add(new Token(match, type));
            }

            return null;
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
        private void FindMatch(String expression, IEnumerable<String> values, Token.TokenType valueType, ref String match, ref Token.TokenType type)
        {
            foreach(String value in values)
            {
                if(value.Length > match.Length && expression.IndexOf(value) >= 0)
                {
                    match = value;
                    type = valueType;
                }
            }
        }

        private class Token
        {
            /// <summary>
            /// The value of this token.
            /// </summary>
            public String Value { get; private set; }

            /// <summary>
            /// The type of this token.
            /// </summary>
            public TokenType Type { get; private set; }

            /// <summary>
            /// Construct a new Token with the given value and type.
            /// </summary>
            /// 
            /// <param name="value">the value of this token</param>
            /// <param name="type">the type of this token</param>
            public Token(String value, TokenType type)
            {
                Value = value;
                Type = type;
            }

            /// <summary>
            /// The types of tokens that can exist.
            /// </summary>
            public enum TokenType
            {
                UNARY, INFIX, VARIABLE, CONSTANT
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
