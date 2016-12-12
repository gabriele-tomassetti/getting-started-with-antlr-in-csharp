using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AntlrCSharp;
using Antlr4.Runtime;

namespace AntlrCSharpTests
{
    [TestClass]
    public class ParserTest
    {
        private SpeakParser Setup(string text)
        {
            AntlrInputStream inputStream = new AntlrInputStream(text);
            SpeakLexer speakLexer = new SpeakLexer(inputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(speakLexer);
            SpeakParser speakParser = new SpeakParser(commonTokenStream);

            return speakParser;   
        }

        [TestMethod]
        public void TestChat()
        {
            SpeakParser parser = Setup("john says hello \n michael says world \n");

            SpeakParser.ChatContext context = parser.chat();
            SpeakVisitor visitor = new SpeakVisitor();
            visitor.Visit(context);

            Assert.AreEqual(visitor.Lines.Count, 2);
        }

        [TestMethod]
        public void TestLine()
        {
            SpeakParser parser = Setup("john says hello \n");

            SpeakParser.LineContext context = parser.line();
            SpeakVisitor visitor = new SpeakVisitor();
            SpeakLine line = (SpeakLine) visitor.VisitLine(context);            
            
            Assert.AreEqual(line.Person, "john");
            Assert.AreEqual(line.Text, "hello");
        }

        [TestMethod]
        public void TestWrongLine()
        {
            SpeakParser parser = Setup("john sayan hello \n");

            var context = parser.line();
            
            Assert.IsInstanceOfType(context, typeof(SpeakParser.LineContext));            
            Assert.AreEqual(context.name().GetText(), "john");
            Assert.AreEqual(context.word().GetText(), "sayan");
            Assert.AreEqual(context.GetText(), "john<missing SAYS>sayanhello\n");
        }
    }
}
