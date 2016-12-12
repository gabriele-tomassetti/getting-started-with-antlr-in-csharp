using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Tree;
using AntlrCSharp;
using static AntlrCSharp.SpeakParser;

namespace AntlrCSharp
{    
    public class SpeakVisitor : SpeakBaseVisitor<object>
    {
        public List<SpeakLine> Lines = new List<SpeakLine>();

        public override object VisitLine(SpeakParser.LineContext context)
        {            
            NameContext name = context.name();
            WordContext word = context.word();

            SpeakLine line = new SpeakLine() { Person = name.GetText(), Text = word.GetText() };
            Lines.Add(line);

            return line;
        }
    }
}
