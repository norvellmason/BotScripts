using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class CodeParser
    {
        private String[] lines;

        private HashSet<String> variables;
        private HashSet<String> outputVariables;

        private ExpressionParser expressionParser;

        /// <summary>
        /// Construct a CodeParser with the given lines and variables.
        /// </summary>
        /// 
        /// <param name="lines">the lines to parse</param>
        /// <param name="inputVariables">the names of the input
        /// variables</param>
        /// <param name="outputVariables">the names of the output
        /// variables</param>
        public CodeParser(String[] lines, HashSet<String> inputVariables, HashSet<String> outputVariables)
        {
            this.lines = lines;

            variables = new HashSet<String>();
            variables.UnionWith(inputVariables);
            variables.UnionWith(outputVariables);

            this.outputVariables = outputVariables;

            expressionParser = ExpressionParser.GetDefaultParser(variables);
        }

        public Dictionary<String, object> Execute(Dictionary<String, object> state)
        {
            Stack<ControlBlock> blocks = new Stack<ControlBlock>();
            ControlBlock lastBlock = null;

            blocks.Push(new ControlBlock(-1, true));
            
            foreach(String line in lines)
            {
                int depth = GetLineDepth(line);
                String statement = line.Substring(depth);

                // reduce to the most relevant control structure
                while(depth <= blocks.Peek().Depth)
                    lastBlock = blocks.Pop();

                if(blocks.Peek().Execute)
                {
                    if(statement.IndexOf("if") == 0)
                    {
                        object expression = expressionParser.Parse(statement.Substring(2), state);
                        if(expression is bool execute)
                            blocks.Push(new ControlBlock(depth, execute));
                        else
                            throw new ArgumentException("If statment expression evaluated to number, needs to be boolean");
                    }
                    else
                    {
                        foreach(String name in outputVariables)
                        { 
                            if(statement.IndexOf(name) == 0)
                            {
                                String expression = Regex.Replace(statement.Substring(name.Length), @"\s*=\s*", "");
                                object result = expressionParser.Parse(expression, state);

                                if(result is float || result is bool)
                                    state[name] = result;
                                else
                                    throw new ArgumentException("Assigment did not evaluate to a number or a boolean");

                                break;
                            }
                        }
                    }
                }
            }

            return state;
        }

        private int GetLineDepth(String line)
        {
            return Regex.Match(line, @"^\s*").Value.Length;
        }
    }

    class ControlBlock
    {
        public int Depth { get; private set; }
        public bool Execute { get; private set; }

        /// <summary>
        /// Constructa new ControlBlock with the given 
        /// </summary>
        /// <param name="depth"></param>
        /// <param name="execute"></param>
        public ControlBlock(int depth, bool execute)
        {
            Depth = depth;
            Execute = execute;
        }
    }
}
