using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Engine;

namespace CodeParserInteractive
{
    public partial class CodeParserInteractive : Form
    {
        public static List<String> OPERATORS = new List<String>() { "*", "/", "+", "-", ">", "<", ">=", "<=", "==", "!=", "||", "&&" };

        public CodeParserInteractive()
        {
            InitializeComponent();
        }

        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String[] lines = codeInput.Text.Split('\n');
            Dictionary<String, object> state = ParseInputs(variableInput.Text);

            try
            {
                CodeParser parser = new CodeParser(lines, new HashSet<String>(), new HashSet<String>(state.Keys));

                Dictionary<String, object> result = parser.Execute(state);
                DisplayOutputs(result);
            }
            catch(Exception ex)
            {
                variableOutput.Text = ex.Message;
            }
        }

        private Dictionary<String, object> ParseInputs(String text)
        {
            Dictionary<String, object> input = new Dictionary<String, object>();

            foreach(String line in text.Split('\n'))
            {
                Match match = Regex.Match(line, @"^\s*([a-zA-Z\.]+)\s*=\s*([a-zA-Z0-9-\.]+)\s*$");
                if(match.Success)
                {
                    if(float.TryParse(match.Groups[2].Value, out float value))
                        input[match.Groups[1].Value] = value;
                    else if(match.Groups[2].Value == "true" || match.Groups[2].Value == "false")
                        input[match.Groups[1].Value] = bool.Parse(match.Groups[2].Value);
                }
            }

            return input;
        }

        private void DisplayOutputs(Dictionary<String, object> values)
        {
            String output = "";

            foreach(KeyValuePair<String, object> pair in values)
                output += pair.Key + " = " + pair.Value + Environment.NewLine;

            variableOutput.Text = output;
        }

        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<String, object> inputs = ParseInputs(variableInput.Text);

            codeInput.Text = GenerateAssignment(new List<String>(inputs.Keys));
        }

        private String GenerateAssignment(List<String> vars)
        {
            Random random = new Random();

            return vars[random.Next(vars.Count)] + " = " + GenerateExpression(vars, OPERATORS);
        }

        private String GenerateExpression(List<String> vars, List<String> ops)
        {
            Random random = new Random();
            int length = random.Next(10);

            String expression = "";
            while(--length > 0)
            {
                if(random.NextDouble() < 0.5)
                    expression += vars[random.Next(vars.Count)];
                else
                    expression += ((float)random.NextDouble() - 0.5) * 10;

                expression += " " + ops[random.Next(ops.Count)] + " ";
            }
            
            if(random.NextDouble() < 0.5)
                expression += vars[random.Next(vars.Count)];
            else
                expression += ((float)random.NextDouble() - 0.5) * 10;

            return expression;
        }

        private void botGenerateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<String, object> inputs = ParseInputs(variableInput.Text);

            BotScript computerScript = new BotScript(inputs.Keys, inputs.Keys, OPERATORS, 1000);

            codeInput.Text = "";
            foreach(String line in computerScript.getLines())
            {
                codeInput.Text += line + Environment.NewLine;
            }
        }
    }
}
