﻿using System;
using System.Collections.Generic;
using System.Text;

//https://github.com/dart-lang/sdk/blob/master/pkg/front_end/lib/src/scanner/errors.dart

namespace Dart2CSharpTranspiler.Parser
{
    // Copyright (c) 2016, the Dart project authors.  Please see the AUTHORS file
    // for details. All rights reserved. Use of this source code is governed by a
    // BSD-style license that can be found in the LICENSE file.

    //import '../base/errors.dart';
    //import '../fasta/fasta_codes.dart';
    //import '../fasta/scanner/error_token.dart';
    //import 'token.dart' show Token, TokenType;
    //    import '../fasta/scanner/token_constants.dart';

    /**
     * The error codes used for errors detected by the scanner.
     */
    public class ScannerErrorCode : ErrorCode
    {
        /**
         * Parameters:
         * 0: the token that was expected but not found
         */
        public static ScannerErrorCode EXPECTED_TOKEN =
          new ScannerErrorCode("EXPECTED_TOKEN", "Expected to find '{0}'.");

        /**
         * Parameters:
         * 0: the illegal character
         */
        public static ScannerErrorCode ILLEGAL_CHARACTER =
          new ScannerErrorCode("ILLEGAL_CHARACTER", "Illegal character '{0}'.");

        public static ScannerErrorCode MISSING_DIGIT =
          new ScannerErrorCode("MISSING_DIGIT", "Decimal digit expected.");

        public static ScannerErrorCode MISSING_HEX_DIGIT = new ScannerErrorCode(
      "MISSING_HEX_DIGIT", "Hexadecimal digit expected.");

        public static ScannerErrorCode MISSING_IDENTIFIER =
          new ScannerErrorCode("MISSING_IDENTIFIER", "Expected an identifier.");

        public static ScannerErrorCode MISSING_QUOTE =
          new ScannerErrorCode("MISSING_QUOTE", "Expected quote (' or \").");

        /**
         * Parameters:
         * 0: the path of the file that cannot be read
         */
        public static ScannerErrorCode UNABLE_GET_CONTENT = new ScannerErrorCode(
      "UNABLE_GET_CONTENT", "Unable to get content of '{0}'.");

        public static ScannerErrorCode UNEXPECTED_DOLLAR_IN_STRING =
          new ScannerErrorCode(
          "UNEXPECTED_DOLLAR_IN_STRING",
          "A '$' has special meaning inside a string, and must be followed by " +
          "an identifier or an expression in curly braces ({}).",
          correction: "Try adding a backslash (\\) to escape the '$'.");

        /**
         * Parameters:
         * 0: the unsupported operator
         */
        public static ScannerErrorCode UNSUPPORTED_OPERATOR = new ScannerErrorCode(
      "UNSUPPORTED_OPERATOR", "The '{0}' operator is not supported.");

        public static ScannerErrorCode UNTERMINATED_MULTI_LINE_COMMENT =
          new ScannerErrorCode(
          "UNTERMINATED_MULTI_LINE_COMMENT", "Unterminated multi-line comment.",
          correction: "Try terminating the comment with '*/', or " +
              "removing any unbalanced occurances of '/*'" +
              " (because comments nest in Dart).");

        public static ScannerErrorCode UNTERMINATED_STRING_LITERAL =
          new ScannerErrorCode(
          "UNTERMINATED_STRING_LITERAL", "Unterminated string literal.");

        /**
         * Initialize a newly created error code to have the given [name]. The message
         * associated with the error will be created from the given [message]
         * template. The correction associated with the error will be created from the
         * given [correction] template.
         */
        public ScannerErrorCode(String name, String message, String correction = "")
      : base(name, message, correction: correction) { }


        public ErrorSeverity errorSeverity => ErrorSeverity.ERROR;

        public ErrorType type => ErrorType.SYNTACTIC_ERROR;
    }

    /**
     * Used to report a scan error at the given offset.
     * The [errorCode] is the error code indicating the nature of the error.
     * The [arguments] are any arguments needed to complete the error message.
     */
    //public delegate ReportError(
    //    ScannerErrorCode errorCode, int offset, List<Object> arguments);

    ///**
    // *  Translates the given error [token] into an analyzer error and reports it
    // *  using [reportError].
    // */
    //void translateErrorToken(ErrorToken token, ReportError reportError)
    //{
    //    int charOffset = token.charOffset;
    //    // TODO(paulberry,ahe): why is endOffset sometimes null?
    //    int endOffset = token.endOffset ?? charOffset;
    //    void _makeError(ScannerErrorCode errorCode, List<Object> arguments)
    //    {
    //        if (_isAtEnd(token, charOffset))
    //        {
    //            // Analyzer never generates an error message past the end of the input,
    //            // since such an error would not be visible in an editor.
    //            // TODO(paulberry,ahe): would it make sense to replicate this behavior
    //            // in fasta, or move it elsewhere in analyzer?
    //            charOffset--;
    //        }
    //        reportError(errorCode, charOffset, arguments);
    //    }

    //    var errorCode = token.errorCode;
    //    switch (errorCode.analyzerCodes?.first)
    //    {
    //        case "UNTERMINATED_STRING_LITERAL":
    //            // TODO(paulberry,ahe): Fasta reports the error location as the entire
    //            // string; analyzer expects the end of the string.
    //            charOffset = endOffset - 1;
    //            return _makeError(ScannerErrorCode.UNTERMINATED_STRING_LITERAL, null);

    //        case "UNTERMINATED_MULTI_LINE_COMMENT":
    //            // TODO(paulberry,ahe): Fasta reports the error location as the entire
    //            // comment; analyzer expects the end of the comment.
    //            charOffset = endOffset;
    //            return _makeError(ScannerErrorCode.UNTERMINATED_MULTI_LINE_COMMENT, null);

    //        case "MISSING_DIGIT":
    //            // TODO(paulberry,ahe): Fasta reports the error location as the entire
    //            // number; analyzer expects the end of the number.
    //            charOffset = endOffset - 1;
    //            return _makeError(ScannerErrorCode.MISSING_DIGIT, null);

    //        case "MISSING_HEX_DIGIT":
    //            // TODO(paulberry,ahe): Fasta reports the error location as the entire
    //            // number; analyzer expects the end of the number.
    //            charOffset = endOffset - 1;
    //            return _makeError(ScannerErrorCode.MISSING_HEX_DIGIT, null);

    //        case "ILLEGAL_CHARACTER":
    //            return _makeError(ScannerErrorCode.ILLEGAL_CHARACTER, [token.character]);

    //        case "UNSUPPORTED_OPERATOR":
    //            return _makeError(ScannerErrorCode.UNSUPPORTED_OPERATOR,


    //                [(token as UnsupportedOperator).token.lexeme]);

    //        default:
    //            if (errorCode == codeUnmatchedToken)
    //            {
    //                charOffset = token.begin.endToken.charOffset;
    //                TokenType type = token.begin?.type;
    //                if (type == TokenType.OPEN_CURLY_BRACKET ||
    //                    type == TokenType.STRING_INTERPOLATION_EXPRESSION)
    //                {
    //                    return _makeError(ScannerErrorCode.EXPECTED_TOKEN, ['}']);
    //                }
    //                if (type == TokenType.OPEN_SQUARE_BRACKET)
    //                {
    //                    return _makeError(ScannerErrorCode.EXPECTED_TOKEN, [']']);
    //                }
    //                if (type == TokenType.OPEN_PAREN)
    //                {
    //                    return _makeError(ScannerErrorCode.EXPECTED_TOKEN, [')']);
    //                }
    //                if (type == TokenType.LT)
    //                {
    //                    return _makeError(ScannerErrorCode.EXPECTED_TOKEN, ['>']);
    //                }
    //            }
    //            else if (errorCode == codeUnexpectedDollarInString)
    //            {
    //                return _makeError(ScannerErrorCode.MISSING_IDENTIFIER, null);
    //            }
    //            throw new UnimplementedError(
    //                '$errorCode "${errorCode.analyzerCodes?.first}"');
    //    }
    //}

    /**
     * Determines whether the given [charOffset], which came from the non-EOF token
     * [token], represents the end of the input.
     */
    //bool _isAtEnd(Token token, int charOffset)
    //{
    //    while (true)
    //    {
    //        // Skip to the next token.
    //        token = token.next;
    //        // If we've found an EOF token, its charOffset indicates where the end of
    //        // the input is.
    //        if (token.isEof) return token.charOffset == charOffset;
    //        // If we've found a non-error token, then we know there is additional input
    //        // text after [charOffset].
    //        if (token.type.kind != BAD_INPUT_TOKEN) return false;
    //        // Otherwise keep looking.
    //    }
    //}
}