﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dart2CSharpTranspiler.Parser
{
    public static class DartLibrary
    {
        public static bool identical(string first, string second)
        {
            return first == second;
        }

        public static bool identical(Expression first, Expression second)
        {
            return first == second;
        }

        public static bool identical(Token first, Token second)
        {
            return first == second;
        }

        public class StringBuffer
        {
            string value = "";

            public void writeCharCode(int @char)
            {
                value += Convert.ToChar(@char);
            }

            public void write(string text)
            {
                value += text;
            }

            public String toString()
            {
                return value;
            }
        }
    }
}