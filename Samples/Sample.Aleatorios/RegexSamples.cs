using System;

using System.Text.RegularExpressions;

namespace Sample.Aleatorios
{
    public class RegexSamples
    {
        public static void Run()
        {
            string str = "INSERT INTO People \r\n" +
                "VALUES (3, 'Gandalf', 'The Gray'); \r\n GO\r\n" +
             "INSERT INTO People \r\n" +
                "VALUES (4, 'Legolas', 'Camus'); \r\nGO";

            //Regex regGo = new Regex(@"(?<=\b)(?i)GO(?!\w+)");
            Regex regGo = new Regex(@"\b(?i)GO\b");

            MatchCollection matches = regGo.Matches(str);
            foreach (Match m in matches)
            {
                Console.WriteLine(m.ToString());
            }

            _Escape();

            Console.Read();
        }

        static void _Escape()
        {
            ConsoleKeyInfo keyEntered;
            char beginComment, endComment;
            Console.Write("Enter begin comment symbol: ");
            keyEntered = Console.ReadKey();
            beginComment = keyEntered.KeyChar;
            Console.WriteLine();

            Console.Write("Enter end comment symbol: ");
            keyEntered = Console.ReadKey();
            endComment = keyEntered.KeyChar;
            Console.WriteLine();

            string input = "Text [Heliomar P Marques] more text [dos Santos]";
            string pattern = Regex.Escape(beginComment.ToString()) + @"(.*?)";
            string endPattern = Regex.Escape(endComment.ToString());

            if (endComment == ']' || endComment == '}')
                endPattern = @"\" + endPattern;

            pattern += endPattern;

            MatchCollection matches = Regex.Matches(input, pattern);

            Console.WriteLine();
            Console.WriteLine("Regular Expression: " + pattern);

            int commentNumber = 0;
            foreach (Match match in matches)
                Console.WriteLine("{0}: {1}", ++commentNumber, match.Groups[1].Value);


            // The example shows possible output from the example:
            //       Enter begin comment symbol: [
            //       Enter end comment symbol: ]
            //       \[(.*?)\]
            //       1: comment comment comment
            //       2: comment
        }
    }
}
