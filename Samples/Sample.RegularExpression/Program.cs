using System;
using System.Text.RegularExpressions;

namespace Sample.RegularExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            string href;
            string exp;

            //// Get drives available on local computer and form into a single character expression.
            //string[] drives = Environment.GetLogicalDrives();
            //string driveNames = "[";

            //foreach (string drive in drives)
            //    driveNames += drive.Substring(0, 1);

            //driveNames += "]";

            //// Create regular expression pattern dynamically based on local machine information.
            //string pattern = @"\\\\(?i:" + Environment.MachineName + @")(?:\.\w+)*\\((?i:" + driveNames + @"))\$";

            //string replacement = "$1:";

            //string[] uncPaths = {@"\\MyMachine.domain1.mycompany.com\C$\ThingsToDo.txt", 
            //                     @"\\MyMachine\c$\ThingsToDo.txt", 
            //                     @"\\MyMachine\d$\documents\mydocument.docx" };

            //foreach (string uncPath in uncPaths)
            //{
            //    Console.WriteLine("Input string: " + uncPath);
            //    Console.WriteLine("Returned string: " + Regex.Replace(uncPath, pattern, replacement));
            //    Console.WriteLine();
            //}

            //Console.ReadKey();


            //Regex regex = new Regex(@"@\b([a-zA-Z]*)");
            //string mm = "update cliente set id = @id, nome = @nome, endereco = @endereco where idcliente = @idcliente";

            //foreach (Match my in regex.Matches(mm))
            //{
            //    Console.WriteLine(my.ToString());
            //}

            //Console.ReadKey();

            //href = @"[url=http://SERVIDOR.com]http://SERVIDOR.com[/url]";
            //exp = @"/\[url=(.*?)\](.*?)\[\/url]/g";

            //Console.WriteLine("Returned string: " + Regex.Replace(href, exp, "<a href=\"$1\" target=\"_blank\">$2</a>"));
            //Console.ReadKey();


            href = @"<a href=""http://any.url.here/%7BlocalLink:1369%7D%7C%7CThank%20you%20for%20registering"">broken link</a>";
            exp = @"(<a\s+[^>]*href="")[^""%]*%7B(localLink:\d+)%7D%7C%7C([^""]*)(""[^>]*>[^<]*</a>)";

            Console.WriteLine("Input string: " + href);
            Console.WriteLine("Returned string: " + Regex.Replace(href, exp, @"$1/{$2}"" title=""$3$4"));

            Console.WriteLine("\n\n");

            href = @"<a  href='http://www.com/%7Blocalhost:1369%7D%7C%7CThank%20you%20for%20registering'>link</a>";
            exp = @"(<a\s+[^>]*href=')[^'%]*%7B(localhost:\d+)%7D%7C%7C([^']*)('[^>]*>[^<]*</a>)";

            Console.WriteLine("Input string: " + href);
            Console.WriteLine("Returned string: " + Regex.Replace(href, exp, @"$1/{$2}' title='$3$4"));

            Console.WriteLine("\n\n");

            href = @"<a href='http://www.com/%7Blocalhost:122%7D%7C%7C?teste'>clique aqui</a>";
            exp = @"(<a\s+[^>]*href=')[^'%]*%7B(localhost:\d+)%7D%7C%7C([^']*)('[^>]*>[^<]*</a>)";

            Console.WriteLine("Input string: " + href);
            Console.WriteLine("Returned string: " + Regex.Replace(href, exp, @"$1/{$2}' title='$3$4"));
            Console.ReadKey();


            // Change e-mail addresses to mailto: links. 
            const RegexOptions o = RegexOptions.Multiline | RegexOptions.IgnoreCase;

            href = @"firstname.secondname@one.two.three.co.uk";

            const string pat3 = @"([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,6})";
            const string rep3 = @"<a href=""mailto:$1@$2.$3"">$1@$2.$3</a>";

            Console.WriteLine(Regex.Replace(href, pat3, rep3, o));
            Console.ReadKey();

        }

        //function Linkify(inputText) { 
        //    //URLs starting with http://, https://, or ftp:// 
        //    var replacePattern1 = /(\b(https?|ftp):\/\/[-A-Z0-9+&@#\/%?=~_|!:,.;]*[-A-Z0-9+&@#\/%=~_|])/gim; 
        //    var replacedText = inputText.replace(replacePattern1, '<a href="$1" target="_blank">$1</a>'); 

        //    //URLs starting with www. (without // before it, or it'd re-link the ones done above) 
        //    var replacePattern2 = /(^|[^\/])(www\.[\S]+(\b|$))/gim; 
        //    var replacedText = replacedText.replace(replacePattern2, '$1<a href="http://$2" target="_blank">$2</a>'); 

        //    //Change email addresses to mailto:: links 
        //    var replacePattern3 = /(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})/gim; 
        //    var replacedText = replacedText.replace(replacePattern3, '<a href="mailto:$1">$1</a>'); 

        //    return replacedText 
        //} 


        //        function replaceURLWithHTMLLinks(text) { 
        //  var exp = /(\b(https?|ftp|file):\/\/[-A-Z0-9+&@#\/%?=~_|!:,.;]*[-A-Z0-9+&@#\/%=~_|])/ig; 
        //  return text.replace(exp,"<a href='$1'>$1</a>");  
        //} 

    }
}
