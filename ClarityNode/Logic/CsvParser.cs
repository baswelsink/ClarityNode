using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarityNode.Logic
{
    public static class CsvParser
    {
        public static List<string> Parse(string line, char textQualifier, char separator)
        {
            List<string> tokens = new List<string>();
            string token = string.Empty;
            bool isTextQualified = false;
            using (StringReader reader = new StringReader(line))
            {
                while(reader.Read() is int nextChar)
                {
                    if(nextChar == -1)
                    {
                        break;
                    }

                    if (nextChar == textQualifier)
                    {
                        isTextQualified = !isTextQualified;
                    }
                    else
                    {
                        if(nextChar == separator)
                        {
                            if (!isTextQualified) 
                            {
                                tokens.Add(token);
                                token = string.Empty;
                            }
                        }
                        else
                        {
                            token += (char)nextChar;
                        }
                    }
                }
            }

            return tokens;
        }
    }
}
