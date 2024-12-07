using System;
using System.Collections.Generic;
namespace A1{
    public class A1{
        public static void print(string a){
            Console.WriteLine(a);
        }
        public static bool isSpace(char ch) {
            return ch <= ' '; 
        }
        public static ParsedLine parseLine(string input) {
            ParsedLine parsedLine = new ParsedLine();
            Token token = new Token();
            if (!token.GetToken(input)) { return parsedLine; }
            if (token.tokenValue != " ") {
                parsedLine.label = token.tokenValue;
                if (!token.GetToken(input)) { return parsedLine; }
            }
            if (!token.GetToken(input)) { return parsedLine; }
            parsedLine.inst = token.tokenValue;
            if (!token.GetToken(input)) { return parsedLine; }
            if (!token.GetToken(input)) { return parsedLine; }
            parsedLine.operands.Add(token.tokenValue);
            while (true) {
                if (!token.GetToken(input)) { return parsedLine; }
                if (token.tokenValue == " ") { return parsedLine; }
                token.GetToken(input);
                parsedLine.operands.Add(token.tokenValue);
            }
        }
    }
    public class ParsedLine {
        public string label { get; set; }
        public string inst { get; set; }
        public List<string> operands { get; set; }
        public ParsedLine() {
            label = "";
            inst = "";
            operands = new List<string>();
        }
    }
    public class Token {
        public int indexNext { get; set; }
        public string tokenValue { get; set; }
        public Token() {
            indexNext = 0;
            tokenValue = "";
        }
        public bool GetToken(string input) {
            int n = indexNext;
            if (n >= input.Length) { return false; }
            char ch = input[n];
            if (ch == ';') { return false; }
            if (ch == ',') {
                tokenValue = ",";
                indexNext = n + 1;
                return true;
            }
            if (A1.isSpace(ch)) {
                n++;
                while (n < input.Length && A1.isSpace(input[n])) { n++; }
                tokenValue = " ";
                indexNext = n;
                return true;
            }
            bool inQuote = false;
            List<char> ar = new List<char>();
            while (n < input.Length) {
                ch = input[n];
                if (inQuote) {
                    if (ch == '\'') { inQuote = false; }
                    ar.Add(ch);
                }
                else {
                    if (ch == '\'') { inQuote = true; }
                    else if (A1.isSpace(ch) || ch == ';' || ch == ',') { break; }
                    ar.Add(char.ToUpper(ch));
                }
                n++;
            }
            tokenValue = new string(ar.ToArray());
            indexNext = n;
            return true;
        }
    }
}