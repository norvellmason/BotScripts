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
    }
}
