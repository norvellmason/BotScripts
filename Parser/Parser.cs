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
