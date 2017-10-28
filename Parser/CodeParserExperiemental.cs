using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Engine
{
    public class CodeParserExperimental
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
        public CodeParserExperimental(String[] lines, HashSet<String> inputVariables, HashSet<String> outputVariables)
        {
            this.lines = lines;

            variables = new HashSet<String>();
            variables.UnionWith(inputVariables);
            variables.UnionWith(outputVariables);

            this.outputVariables = outputVariables;

            expressionParser = ExpressionParser.GetDefaultParser(variables);
        }

        /// <summary>
        /// Executes the code given to this parser, using a given set of inputs.
        /// </summary>
        /// 
        /// <param name="state">the inputs to the program</param>
        /// 
        /// <returns>the inputs after the code has executed</returns>
        public Dictionary<String, object> Execute(Dictionary<String, object> state)
        {
            Stack<ControlBlock> blocks = new Stack<ControlBlock>();
            ControlBlock lastBlock = null;

            blocks.Push(new ControlBlock(-1, true, false));

            foreach (String line in lines)
            {
                int depth = GetLineDepth(line);
                String statement = line.Substring(depth);

                // reduce to the most relevant control structure
                while (depth <= blocks.Peek().Depth)
                    lastBlock = blocks.Pop();

                if (blocks.Peek().Execute)
                {
                    if (statement.IndexOf("if ") == 0)
                    {
                        object expression = expressionParser.Parse(statement.Substring(2), state);
                        if (expression is bool execute)
                            blocks.Push(new ControlBlock(depth, execute, execute));
                        else
                            throw new ArgumentException("If statment expression evaluated to number, needs to be boolean");
                    }
                    else if (statement.IndexOf("elseif ") == 0)
                    {
                        if (lastBlock != null && !lastBlock.ChainExecute && lastBlock.Depth == depth)
                        {
                            object expression = expressionParser.Parse(statement.Substring(7), state);
                            if (expression is bool execute)
                                blocks.Push(new ControlBlock(depth, execute, execute | lastBlock.ChainExecute));
                            else
                                throw new ArgumentException("If statment expression evaluated to number, needs to be boolean");
                        }
                        else
                        {
                            blocks.Push(new ControlBlock(depth, false, lastBlock.ChainExecute));
                        }
                    }
                    else if (statement.IndexOf("else") == 0)
                    {
                        if (lastBlock != null && !lastBlock.ChainExecute && lastBlock.Depth == depth)
                            blocks.Push(new ControlBlock(depth, !lastBlock.Execute, false));
                        else
                            blocks.Push(new ControlBlock(depth, false, lastBlock.ChainExecute));
                    }
                    else
                    {
                        foreach (String name in variables)
                        {
                            if (statement.IndexOf(name) == 0)
                            {
                                if (outputVariables.Contains(name))
                                {
                                    String expression = Regex.Replace(statement.Substring(name.Length), @"\s*=\s*", "");
                                    object result = expressionParser.Parse(expression, state);

                                    if (result is float || result is bool)
                                        state[name] = result;
                                    else
                                        throw new ArgumentException("Assigment did not evaluate to a number or a boolean");

                                    break;
                                }
                                else
                                {
                                    throw new ArgumentException("Cannot write to the variable '" + name + "'");
                                }
                            }
                        }
                    }
                }
            }

            return state;
        }

        public void SetCode(String[] lines)
        {
            this.lines = lines;
        }

        private int GetLineDepth(String line)
        {
            return Regex.Match(line, @"^\s*").Value.Length;
        }
    }

    class ControlBlockE
    {
        public int Depth { get; private set; }

        public bool Execute { get; private set; }

        public bool ChainExecute { get; private set; }

        /// <summary>
        /// Constructa new ControlBlock with the given 
        /// </summary>
        /// <param name="depth"></param>
        /// <param name="execute"></param>
        public ControlBlockE(int depth, bool execute, bool chainExecute)
        {
            Depth = depth;
            Execute = execute;
            ChainExecute = chainExecute;
        }
    }
}
