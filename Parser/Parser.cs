using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
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
    }
}
