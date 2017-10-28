using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class BotScript
    {
        private List<String> variables;
        private List<String> outputs;
        private List<String> operators;

        private List<Line> lines;

        public BotScript(IEnumerable<String> variables, IEnumerable<String> outputs, IEnumerable<String> operators, int lineCount)
        {
            this.variables = new List<String>(variables);
            this.outputs = new List<String>(outputs);
            this.operators = new List<String>(operators);

            lines = new List<Line>();
            while(lineCount-- > 0)
                lines.Add(new Line(this.variables, this.outputs, this.operators));
        }

        public String[] getLines()
        {
            List<String> lines = new List<String>();

            foreach(Line line in this.lines)
                lines.Add(line.ToString());

            return lines.ToArray();
        }
    }

    class Line
    {
        int depth;
        String head;
        List<String> operands = new List<String>();
        List<String> operators = new List<String>();

        private static Random random = new Random();

        public Line(List<String> variables, List<String> outputs, List<String> operators)
        {
            depth = random.Next(10);
            head = GenerateHeader(outputs);

            int opCount = random.Next(8);

            while(opCount-- > 0)
            {
                operands.Add(GetOperand(variables));
                operators.Add(operators[random.Next(operators.Count)]);
            }

            operands.Add(GetOperand(variables));
        }

        public override string ToString()
        {
            String line = "";
            while(line.Length < depth)
                line += " ";

            line += head;

            for(int index = 0; index < operators.Count; index++)
            {
                line += operands[index] + operators[index];
            }

            line += operands[operands.Count - 1];

            return line;
        }

        private String GetOperand(List<String> variables)
        {
            if(random.NextDouble() < 0.5)
                return variables[random.Next(variables.Count)];

            return ((random.NextDouble() - 0.5) * 20).ToString();
        }

        private String GenerateHeader(List<String> outputs)
        {
            if(random.NextDouble() < 0.3)
            {
                if(random.NextDouble() < 0.6)
                    return "if ";

                if(random.NextDouble() < 0.5)
                    return "elseif ";

                return "else";
            }

            return outputs[random.Next(outputs.Count)] + " = ";
        }
    }
}
