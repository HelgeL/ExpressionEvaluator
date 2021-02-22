﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Shouldly;

namespace CodingSeb.ExpressionEvaluator.Tests
{
    [TestFixture]
    public class ExpressionEvaluatorScriptEvaluateTests
    {
        private static readonly Regex removeAllWhiteSpacesRegex = new Regex(@"\s+");

        #region Setup TearDown

        [SetUp]
        public static void BeforeTests()
        {
            ClassForTest1.StaticIntProperty = 67;
        }

        [TearDown]
        public static void AfterTests()
        {
            ClassForTest1.StaticIntProperty = 67;
        }

        #endregion

        #region Scripts that must succeed

        public static IEnumerable<TestCaseData> TestCasesForScriptEvaluateTests
        {
            get
            {
                #region Assignations

                #region Instance Property Assignation

                ClassForTest1 obj0001 = new ClassForTest1();

                yield return new TestCaseData("obj.IntProperty = 3;",
                        new ExpressionEvaluator()
                        {
                            Variables = new Dictionary<string, object>()
                            {
                                { "obj", obj0001 }
                            }
                        },
                        new Action(() => obj0001.IntProperty.ShouldBe(25)),
                        new Action(() => obj0001.IntProperty.ShouldBe(3)),
                        null)
                    .SetCategory("Script")
                    .SetCategory("Instance Property set assignation")
                    .SetCategory("=")
                    .Returns(3);

                ClassForTest1 obj0002 = new ClassForTest1();

                yield return new TestCaseData("obj.IntProperty += 2;",
                        new ExpressionEvaluator()
                        {
                            Variables = new Dictionary<string, object>()
                            {
                                { "obj", obj0002 }
                            }
                        },
                        new Action(() => obj0002.IntProperty.ShouldBe(25)),
                        new Action(() => obj0002.IntProperty.ShouldBe(27)),
                        null)
                    .SetCategory("Script")
                    .SetCategory("Instance Property set assignation")
                    .SetCategory("+=")
                    .Returns(27);

                ClassForTest1 obj0003 = new ClassForTest1();

                yield return new TestCaseData("obj.IntProperty -= 2;",
                        new ExpressionEvaluator()
                        {
                            Variables = new Dictionary<string, object>()
                            {
                                { "obj", obj0003 }
                            }
                        },
                        new Action(() => obj0003.IntProperty.ShouldBe(25)),
                        new Action(() => obj0003.IntProperty.ShouldBe(23)),
                        null)
                    .SetCategory("Script")
                    .SetCategory("Instance Property set assignation")
                    .SetCategory("-=")
                    .Returns(23);

                ClassForTest1 obj0004 = new ClassForTest1();

                yield return new TestCaseData("obj.IntProperty *= 2;",
                        new ExpressionEvaluator()
                        {
                            Variables = new Dictionary<string, object>()
                            {
                                { "obj", obj0004 }
                            }
                        },
                        new Action(() => obj0004.IntProperty.ShouldBe(25)),
                        new Action(() => obj0004.IntProperty.ShouldBe(50)),
                        null)
                    .SetCategory("Script")
                    .SetCategory("Instance Property set assignation")
                    .SetCategory("*=")
                    .Returns(50);

                ClassForTest1 obj0005 = new ClassForTest1();

                yield return new TestCaseData("obj.IntProperty /= 5;",
                        new ExpressionEvaluator()
                        {
                            Variables = new Dictionary<string, object>()
                            {
                                { "obj", obj0005 }
                            }
                        },
                        new Action(() => obj0005.IntProperty.ShouldBe(25)),
                        new Action(() => obj0005.IntProperty.ShouldBe(5)),
                        null)
                    .SetCategory("Script")
                    .SetCategory("Instance Property set assignation")
                    .SetCategory("/=")
                    .Returns(5);

                ClassForTest1 obj0006 = new ClassForTest1();

                yield return new TestCaseData("obj.IntProperty %= 5;",
                        new ExpressionEvaluator()
                        {
                            Variables = new Dictionary<string, object>()
                            {
                                { "obj", obj0006 }
                            }
                        },
                        new Action(() => obj0006.IntProperty.ShouldBe(25)),
                        new Action(() => obj0006.IntProperty.ShouldBe(0)),
                        null)
                    .SetCategory("Script")
                    .SetCategory("Instance Property set assignation")
                    .SetCategory("%=")
                    .Returns(0);

                ClassForTest1 obj0007 = new ClassForTest1()
                {
                    IntProperty = 10
                };

                yield return new TestCaseData("obj.IntProperty %= 3;",
                        new ExpressionEvaluator()
                        {
                            Variables = new Dictionary<string, object>()
                            {
                                { "obj", obj0007 }
                            }
                        },
                        new Action(() => obj0007.IntProperty.ShouldBe(10)),
                        new Action(() => obj0007.IntProperty.ShouldBe(1)),
                        null)
                    .SetCategory("Script")
                    .SetCategory("Instance Property set assignation")
                    .SetCategory("%=")
                    .Returns(1);

                ClassForTest1 obj0008 = new ClassForTest1()
                {
                    IntProperty = 15
                };

                yield return new TestCaseData("obj.IntProperty &= 19;",
                        new ExpressionEvaluator()
                        {
                            Variables = new Dictionary<string, object>()
                            {
                                { "obj", obj0008 }
                            }
                        },
                        new Action(() => obj0008.IntProperty.ShouldBe(15)),
                        new Action(() => obj0008.IntProperty.ShouldBe(3)),
                        null)
                    .SetCategory("Script")
                    .SetCategory("Instance Property set assignation")
                    .SetCategory("&=")
                    .Returns(3);

                ClassForTest1 obj0009 = new ClassForTest1()
                {
                    IntProperty = 5
                };

                yield return new TestCaseData("obj.IntProperty |= 9;",
                        new ExpressionEvaluator()
                        {
                            Variables = new Dictionary<string, object>()
                            {
                                { "obj", obj0009 }
                            }
                        },
                        new Action(() => obj0009.IntProperty.ShouldBe(5)),
                        new Action(() => obj0009.IntProperty.ShouldBe(13)),
                        null)
                    .SetCategory("Script")
                    .SetCategory("Instance Property set assignation")
                    .SetCategory("|=")
                    .Returns(13);

                ClassForTest1 obj0010 = new ClassForTest1()
                {
                    IntProperty = 5
                };

                yield return new TestCaseData("obj.IntProperty ^= 9;",
                        new ExpressionEvaluator()
                        {
                            Variables = new Dictionary<string, object>()
                            {
                                { "obj", obj0010 }
                            }
                        },
                        new Action(() => obj0010.IntProperty.ShouldBe(5)),
                        new Action(() => obj0010.IntProperty.ShouldBe(12)),
                        null)
                    .SetCategory("Script")
                    .SetCategory("Instance Property set assignation")
                    .SetCategory("^=")
                    .Returns(12);

                ClassForTest1 obj0011 = new ClassForTest1()
                {
                    IntProperty = 5
                };

                yield return new TestCaseData("obj.IntProperty <<= 2;",
                        new ExpressionEvaluator()
                        {
                            Variables = new Dictionary<string, object>()
                            {
                                { "obj", obj0011 }
                            }
                        },
                        new Action(() => obj0011.IntProperty.ShouldBe(5)),
                        new Action(() => obj0011.IntProperty.ShouldBe(20)),
                        null)
                    .SetCategory("Script")
                    .SetCategory("Instance Property set assignation")
                    .SetCategory("<<=")
                    .Returns(20);

                ClassForTest1 obj0012 = new ClassForTest1()
                {
                    IntProperty = 20
                };

                yield return new TestCaseData("obj.IntProperty >>= 2;",
                        new ExpressionEvaluator()
                        {
                            Variables = new Dictionary<string, object>()
                            {
                                { "obj", obj0012 }
                            }
                        },
                        new Action(() => obj0012.IntProperty.ShouldBe(20)),
                        new Action(() => obj0012.IntProperty.ShouldBe(5)),
                        null)
                    .SetCategory("Script")
                    .SetCategory("Instance Property set assignation")
                    .SetCategory(">>=")
                    .Returns(5);

                #endregion

                #region Static Property Assignation

                yield return new TestCaseData("ClassForTest1.StaticIntProperty = 18;",
                        null,
                        new Action(() => ClassForTest1.StaticIntProperty.ShouldBe(67)),
                        new Action(() => ClassForTest1.StaticIntProperty.ShouldBe(18)), null)
                    .SetCategory("Script")
                    .SetCategory("Static Property set assignation")
                    .SetCategory("=")
                    .Returns(18);

                yield return new TestCaseData("ClassForTest1.StaticIntProperty += 3;",
                        null,
                        new Action(() => ClassForTest1.StaticIntProperty.ShouldBe(67)),
                        new Action(() => ClassForTest1.StaticIntProperty.ShouldBe(70)), null)
                    .SetCategory("Script")
                    .SetCategory("Static Property set assignation")
                    .SetCategory("+=")
                    .Returns(70);

                yield return new TestCaseData("ClassForTest1.StaticIntProperty -= 7;",
                        null,
                        new Action(() => ClassForTest1.StaticIntProperty.ShouldBe(67)),
                        new Action(() => ClassForTest1.StaticIntProperty.ShouldBe(60)), null)
                    .SetCategory("Script")
                    .SetCategory("Static Property set assignation")
                    .SetCategory("-=")
                    .Returns(60);

                yield return new TestCaseData("ClassForTest1.StaticIntProperty *= 2;",
                        null,
                        new Action(() => ClassForTest1.StaticIntProperty.ShouldBe(67)),
                        new Action(() => ClassForTest1.StaticIntProperty.ShouldBe(134)), null)
                    .SetCategory("Script")
                    .SetCategory("Static Property set assignation")
                    .SetCategory("*=")
                    .Returns(134);

                yield return new TestCaseData("ClassForTest1.StaticIntProperty /= 2;",
                        null,
                        new Action(() => ClassForTest1.StaticIntProperty.ShouldBe(67)),
                        new Action(() => ClassForTest1.StaticIntProperty.ShouldBe(33)), null)
                    .SetCategory("Script")
                    .SetCategory("Static Property set assignation")
                    .SetCategory("/=")
                    .Returns(33);

                yield return new TestCaseData("ClassForTest1.StaticIntProperty %= 2;",
                        null,
                        new Action(() => ClassForTest1.StaticIntProperty.ShouldBe(67)),
                        new Action(() => ClassForTest1.StaticIntProperty.ShouldBe(1)), null)
                    .SetCategory("Script")
                    .SetCategory("Static Property set assignation")
                    .SetCategory("%=")
                    .Returns(1);

                yield return new TestCaseData("ClassForTest1.StaticIntProperty &= 70;",
                        null,
                        new Action(() => ClassForTest1.StaticIntProperty.ShouldBe(67)),
                        new Action(() => ClassForTest1.StaticIntProperty.ShouldBe(66)), null)
                    .SetCategory("Script")
                    .SetCategory("Static Property set assignation")
                    .SetCategory("&=")
                    .Returns(66);

                yield return new TestCaseData("ClassForTest1.StaticIntProperty |= 70;",
                        null,
                        new Action(() => ClassForTest1.StaticIntProperty.ShouldBe(67)),
                        new Action(() => ClassForTest1.StaticIntProperty.ShouldBe(71)), null)
                    .SetCategory("Script")
                    .SetCategory("Static Property set assignation")
                    .SetCategory("|=")
                    .Returns(71);

                yield return new TestCaseData("ClassForTest1.StaticIntProperty <<= 2;",
                         null,
                         new Action(() => ClassForTest1.StaticIntProperty.ShouldBe(67)),
                         new Action(() => ClassForTest1.StaticIntProperty.ShouldBe(268)), null)
                     .SetCategory("Script")
                     .SetCategory("Static Property set assignation")
                     .SetCategory("<<=")
                     .Returns(268);

                yield return new TestCaseData("ClassForTest1.StaticIntProperty >>= 2;",
                         null,
                         new Action(() => ClassForTest1.StaticIntProperty.ShouldBe(67)),
                         new Action(() => ClassForTest1.StaticIntProperty.ShouldBe(16)), null)
                     .SetCategory("Script")
                     .SetCategory("Static Property set assignation")
                     .SetCategory(">>=")
                     .Returns(16);

                #endregion

                #region Variable Assignation

                ExpressionEvaluator evaluator0001 = new ExpressionEvaluator()
                {
                    Variables = new Dictionary<string, object>()
                    {
                        { "x", 5 }
                    }
                };

                yield return new TestCaseData("x = 3;",
                    evaluator0001,
                    new Action(() => evaluator0001.Variables["x"].ShouldBe(5)),
                    new Action(() => evaluator0001.Variables["x"].ShouldBe(3)), null)
                .SetCategory("Script")
                .SetCategory("Variable assignation")
                .SetCategory("=")
                .Returns(3);

                yield return new TestCaseData("y = 20;",
                    evaluator0001,
                    new Action(() => evaluator0001.Variables.ContainsKey("y").ShouldBeFalse()),
                    new Action(() => evaluator0001.Variables["y"].ShouldBe(20)), null)
                .SetCategory("Script")
                .SetCategory("Variable assignation")
                .SetCategory("=")
                .Returns(20);

                ExpressionEvaluator evaluator0002 = new ExpressionEvaluator()
                {
                    Variables = new Dictionary<string, object>()
                    {
                        { "x", 5 },
                        { "text", "Test" }
                    }
                };

                yield return new TestCaseData("x += 4;",
                   evaluator0002,
                    new Action(() => evaluator0002.Variables["x"].ShouldBe(5)),
                    new Action(() => evaluator0002.Variables["x"].ShouldBe(9)), null)
                .SetCategory("Script")
                .SetCategory("Variable assignation")
                .SetCategory("+=")
                .Returns(9);

                yield return new TestCaseData("text += \" Try\";",
                    evaluator0002,
                    new Action(() => evaluator0002.Variables["text"].ShouldBe("Test")),
                    new Action(() => evaluator0002.Variables["text"].ShouldBe("Test Try")), null)
                .SetCategory("Script")
                .SetCategory("Variable assignation")
                .SetCategory("+=")
                .Returns("Test Try");

                ExpressionEvaluator evaluator0003 = new ExpressionEvaluator()
                {
                    Variables = new Dictionary<string, object>()
                    {
                        { "x", 5 },
                    }
                };

                yield return new TestCaseData("x -= 4;",
                   evaluator0003,
                    new Action(() => evaluator0003.Variables["x"].ShouldBe(5)),
                    new Action(() => evaluator0003.Variables["x"].ShouldBe(1)), null)
                .SetCategory("Script")
                .SetCategory("Variable assignation")
                .SetCategory("-=")
                .Returns(1);

                ExpressionEvaluator evaluator0004 = new ExpressionEvaluator()
                {
                    Variables = new Dictionary<string, object>()
                    {
                        { "x", 5 },
                    }
                };

                yield return new TestCaseData("x *= 2;",
                   evaluator0004,
                    new Action(() => evaluator0004.Variables["x"].ShouldBe(5)),
                    new Action(() => evaluator0004.Variables["x"].ShouldBe(10)), null)
                .SetCategory("Script")
                .SetCategory("Variable assignation")
                .SetCategory("*=")
                .Returns(10);

                ExpressionEvaluator evaluator0005 = new ExpressionEvaluator()
                {
                    Variables = new Dictionary<string, object>()
                    {
                        { "x", 5 },
                    }
                };

                yield return new TestCaseData("x /= 2;",
                   evaluator0005,
                    new Action(() => evaluator0005.Variables["x"].ShouldBe(5)),
                    new Action(() => evaluator0005.Variables["x"].ShouldBe(2)), null)
                .SetCategory("Script")
                .SetCategory("Variable assignation")
                .SetCategory("/=")
                .Returns(2);

                ExpressionEvaluator evaluator0006 = new ExpressionEvaluator()
                {
                    Variables = new Dictionary<string, object>()
                    {
                        { "x", 5 },
                    }
                };

                yield return new TestCaseData("x %= 2;",
                   evaluator0006,
                    new Action(() => evaluator0006.Variables["x"].ShouldBe(5)),
                    new Action(() => evaluator0006.Variables["x"].ShouldBe(1)), null)
                .SetCategory("Script")
                .SetCategory("Variable assignation")
                .SetCategory("%=")
                .Returns(1);

                ExpressionEvaluator evaluator0007 = new ExpressionEvaluator()
                {
                    Variables = new Dictionary<string, object>()
                    {
                        { "x", 5 },
                    }
                };

                yield return new TestCaseData("x ^= 3;",
                   evaluator0007,
                    new Action(() => evaluator0007.Variables["x"].ShouldBe(5)),
                    new Action(() => evaluator0007.Variables["x"].ShouldBe(6)), null)
                .SetCategory("Script")
                .SetCategory("Variable assignation")
                .SetCategory("^=")
                .Returns(6);

                ExpressionEvaluator evaluator0008 = new ExpressionEvaluator()
                {
                    Variables = new Dictionary<string, object>()
                    {
                        { "x", 5 },
                    }
                };

                yield return new TestCaseData("x &= 3;",
                   evaluator0008,
                    new Action(() => evaluator0008.Variables["x"].ShouldBe(5)),
                    new Action(() => evaluator0008.Variables["x"].ShouldBe(1)), null)
                .SetCategory("Script")
                .SetCategory("Variable assignation")
                .SetCategory("&=")
                .Returns(1);

                ExpressionEvaluator evaluator0009 = new ExpressionEvaluator()
                {
                    Variables = new Dictionary<string, object>()
                    {
                        { "x", 5 },
                    }
                };

                yield return new TestCaseData("x |= 3;",
                   evaluator0009,
                    new Action(() => evaluator0009.Variables["x"].ShouldBe(5)),
                    new Action(() => evaluator0009.Variables["x"].ShouldBe(7)), null)
                .SetCategory("Script")
                .SetCategory("Variable assignation")
                .SetCategory("|=")
                .Returns(7);

                ExpressionEvaluator evaluator0010 = new ExpressionEvaluator()
                {
                    Variables = new Dictionary<string, object>()
                    {
                        { "x", 5 },
                    }
                };

                yield return new TestCaseData("x <<= 2;",
                   evaluator0010,
                    new Action(() => evaluator0010.Variables["x"].ShouldBe(5)),
                    new Action(() => evaluator0010.Variables["x"].ShouldBe(20)), null)
                .SetCategory("Script")
                .SetCategory("Variable assignation")
                .SetCategory("<<=")
                .Returns(20);

                ExpressionEvaluator evaluator0011 = new ExpressionEvaluator()
                {
                    Variables = new Dictionary<string, object>()
                    {
                        { "x", 5 },
                    }
                };

                yield return new TestCaseData("x >>= 2;",
                   evaluator0011,
                    new Action(() => evaluator0011.Variables["x"].ShouldBe(5)),
                    new Action(() => evaluator0011.Variables["x"].ShouldBe(1)),
                    null)
                .SetCategory("Script")
                .SetCategory("Variable assignation")
                .SetCategory(">>=")
                .Returns(1);

                yield return new TestCaseData(Resources.Script0071,
                    null,
                    null,
                    null,
                    null)
                .SetCategory("Script")
                .SetCategory("Variable assignation")
                .SetCategory("??=")
                .Returns("First Null-coalescing assignation");

                #endregion

                #region Array content assignation

                yield return new TestCaseData(Resources.Script0033, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Array Assignation")
                    .SetCategory("=")
                    .Returns("[0,5,0]");

                yield return new TestCaseData(Resources.Script0034, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Array instanciation")
                    .SetCategory("new")
                    .SetCategory("Array Assignation")
                    .SetCategory("=")
                    .Returns("[0,5,0]");

                yield return new TestCaseData(Resources.Script0035, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Array instanciation")
                    .SetCategory("new")
                    .SetCategory("Array Assignation")
                    .SetCategory("=")
                    .Returns("[1,2,3]");

                yield return new TestCaseData(Resources.Script0036, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Array instanciation")
                    .SetCategory("new")
                    .SetCategory("Array Assignation")
                    .SetCategory("=")
                    .Returns("[1,2,3]");

                #endregion

                #region StringEscape

                yield return new TestCaseData(Resources.Script0037, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Variable Assignation")
                    .SetCategory("StringEscape")
                    .SetCategory("=")
                    .Returns("\"");

                yield return new TestCaseData(Resources.Script0038, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Variable Assignation")
                    .SetCategory("StringEscape")
                    .SetCategory("=")
                    .Returns("(?<begining>[<]tag\\s+id\\s*[=]\\s*\"A.Id.For.The_Tag[^\"]*\"\\s*version\\s*[=]\\s*\")(?<version>[^\"]*)");

                yield return new TestCaseData(Resources.Script0039, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Variable Assignation")
                    .SetCategory("StringEscape")
                    .SetCategory("StringInterpolate")
                    .SetCategory("=")
                    .Returns("(?<begining>[<]tag\\s+id\\s*[=]\\s*\"A.Id.For.The_Tag[^\"]*\"\\s*version\\s*[=]\\s*\")(?<version>[^\"]*)");

                yield return new TestCaseData(Resources.Script0040, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Variable Assignation")
                    .SetCategory("StringEscape")
                    .SetCategory("StringInterpolate")
                    .SetCategory("=")
                    .Returns("(?<begining>[<]tag\\s+id\\s*[=]\\s*\"A.Id.For.The_Tag[^\"]*\"\\s*version\\s*[=]\\s*\")(?<version>[^\"]*)");

                yield return new TestCaseData(Resources.Script0041, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Variable Assignation")
                    .SetCategory("StringEscape")
                    .SetCategory("StringInterpolate")
                    .SetCategory("=")
                    .Returns("(?<begining>[<]tag\\s+id\\s*[=]\\s*\"A.Id.For.The_Tag[^\"]*\"\\s*version\\s*[=]\\s*\")(?<version>[^\"]*)");

                yield return new TestCaseData(Resources.Script0042, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Variable Assignation")
                    .SetCategory("char")
                    .SetCategory("doubleQuote")
                    .SetCategory("=")
                    .Returns('"');

                yield return new TestCaseData(Resources.Script0043, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Variable Assignation")
                    .SetCategory("StringInterpolate")
                    .SetCategory("char")
                    .SetCategory("doubleQuote")
                    .SetCategory("=")
                    .Returns("\"");

                yield return new TestCaseData(Resources.Script0044, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Variable Assignation")
                    .SetCategory("char")
                    .SetCategory("StringInterpolate")
                    .SetCategory("=")
                    .Returns("\"");

                yield return new TestCaseData(Resources.Script0045, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Variable Assignation")
                    .SetCategory("StringEscape")
                    .SetCategory("StringInterpolate")
                    .SetCategory("=")
                    .Returns("(?<begining>[<]tag\\s+id\\s*[=]\\s*\"A.Id.For.The_Tag[^\"]*\"\\s*version\\s*[=]\\s*\")(?<version>[^\"]*)");

                yield return new TestCaseData(Resources.Script0046, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Variable Assignation")
                    .SetCategory("StringEscape")
                    .SetCategory("StringInterpolate")
                    .SetCategory("=")
                    .Returns("(?<begining>[<]tag\\s+id\\s*[=]\\s*\"A.Id.For.The_Tag[^\"]*\"\\s*version\\s*[=]\\s*\")(?<version>[^\"]*)");

                #endregion

                #region prefix operators
                yield return new TestCaseData(Resources.Script0047, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Variable Assignation")
                    .SetCategory("PrefixOperators")
                    .SetCategory("++")
                    .SetCategory("=")
                    .Returns("x:6 y:6");
                yield return new TestCaseData(Resources.Script0048, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Variable Assignation")
                    .SetCategory("PrefixOperators")
                    .SetCategory("--")
                    .SetCategory("=")
                    .Returns("x:4 y:4");

                #endregion

                #endregion

                #region while

                yield return new TestCaseData(Resources.Script0001, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("while")
                    .SetCategory("variable assignation")
                    .SetCategory("++")
                    .SetCategory("+=")
                    .Returns("0,1,2,3,4");
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0001, string.Empty), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("while")
                    .SetCategory("variable assignation")
                    .SetCategory("++")
                    .SetCategory("+=")
                    .Returns("0,1,2,3,4");
                yield return new TestCaseData(Resources.Script0015, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("do while")
                    .SetCategory("variable assignation")
                    .SetCategory("++")
                    .SetCategory("+=")
                    .Returns(string.Empty);
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0015, string.Empty), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("do while")
                    .SetCategory("variable assignation")
                    .SetCategory("++")
                    .SetCategory("+=")
                    .Returns(string.Empty);

                #endregion

                #region do while

                yield return new TestCaseData(Resources.Script0013, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("do while")
                    .SetCategory("variable assignation")
                    .SetCategory("++")
                    .SetCategory("+=")
                    .Returns("0,1,2,3,4");
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0013, string.Empty), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("do while")
                    .SetCategory("variable assignation")
                    .SetCategory("++")
                    .SetCategory("+=")
                    .Returns("0,1,2,3,4");
                yield return new TestCaseData(Resources.Script0014, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("do while")
                    .SetCategory("variable assignation")
                    .SetCategory("++")
                    .SetCategory("+=")
                    .Returns("0");
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0014, string.Empty), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("do while")
                    .SetCategory("variable assignation")
                    .SetCategory("++")
                    .SetCategory("+=")
                    .Returns("0");

                #endregion

                #region for

                yield return new TestCaseData(Resources.Script0002, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("for")
                    .SetCategory("variable assignation")
                    .SetCategory("++")
                    .SetCategory("+=")
                    .Returns("0,1,2,3,4");
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0002, string.Empty), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("for")
                    .SetCategory("variable assignation")
                    .SetCategory("++")
                    .SetCategory("+=")
                    .Returns("0,1,2,3,4");
                yield return new TestCaseData(Resources.Script0003, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("for")
                    .SetCategory("variable assignation")
                    .SetCategory("++")
                    .SetCategory("+=")
                    .Returns("0,1,2,3,4");
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0003, string.Empty), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("for")
                    .SetCategory("variable assignation")
                    .SetCategory("++")
                    .SetCategory("+=")
                    .Returns("0,1,2,3,4");

                #endregion

                #region foreach

                yield return new TestCaseData(Resources.Script0018, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("foreach")
                    .SetCategory("variable assignation")
                    .SetCategory("+=")
                    .Returns("This is a splitted text");

                #endregion

                #region List<>.ForEach
                yield return new TestCaseData(Resources.Script0068, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("List")
                    .SetCategory("variable assignation")
                    .SetCategory("ForEach")
                    .Returns(10);
                yield return new TestCaseData(Resources.Script0069, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("List")
                    .SetCategory("variable assignation")
                    .SetCategory("ForEach")
                    .Returns("1;2;3;4;");
                #endregion

                #region if, else if, else

                yield return new TestCaseData(Resources.Script0004.Replace("[valx]", "0").Replace("[valy]", "1"), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(1);
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0004.Replace("[valx]", "0").Replace("[valy]", "1"), string.Empty).Replace("else", "else "), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(1);
                yield return new TestCaseData(Resources.Script0004.Replace("[valx]", "-1").Replace("[valy]", "1"), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(1);
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0004.Replace("[valx]", "-1").Replace("[valy]", "1"), string.Empty).Replace("else", "else "), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(1);
                yield return new TestCaseData(Resources.Script0004.Replace("[valx]", "1").Replace("[valy]", "1"), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(1);
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0004.Replace("[valx]", "1").Replace("[valy]", "1"), string.Empty).Replace("else", "else "), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(1);

                yield return new TestCaseData(Resources.Script0004.Replace("[valx]", "0").Replace("[valy]", "0"), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(2);
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0004.Replace("[valx]", "0").Replace("[valy]", "0"), string.Empty).Replace("else", "else "), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(2);

                yield return new TestCaseData(Resources.Script0004.Replace("[valx]", "-1").Replace("[valy]", "0"), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(3);
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0004.Replace("[valx]", "-1").Replace("[valy]", "0"), string.Empty).Replace("else", "else "), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(3);

                yield return new TestCaseData(Resources.Script0004.Replace("[valx]", "1").Replace("[valy]", "0"), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(4);
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0004.Replace("[valx]", "1").Replace("[valy]", "0"), string.Empty).Replace("else", "else "), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(4);

                yield return new TestCaseData(Resources.Script0005.Replace("[valx]", "0").Replace("[valy]", "1"), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(1);
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0005.Replace("[valx]", "0").Replace("[valy]", "1"), string.Empty).Replace("else", "else "), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(1);

                yield return new TestCaseData(Resources.Script0005.Replace("[valx]", "-1").Replace("[valy]", "1"), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(1);
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0005.Replace("[valx]", "-1").Replace("[valy]", "1"), string.Empty).Replace("else", "else "), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(1);

                yield return new TestCaseData(Resources.Script0005.Replace("[valx]", "1").Replace("[valy]", "1"), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(1);
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0005.Replace("[valx]", "1").Replace("[valy]", "1"), string.Empty).Replace("else", "else "), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(1);

                yield return new TestCaseData(Resources.Script0005.Replace("[valx]", "0").Replace("[valy]", "0"), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(2);
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0005.Replace("[valx]", "0").Replace("[valy]", "0"), string.Empty).Replace("else", "else "), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(2);

                yield return new TestCaseData(Resources.Script0005.Replace("[valx]", "-1").Replace("[valy]", "0"), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(3);
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0005.Replace("[valx]", "-1").Replace("[valy]", "0"), string.Empty).Replace("else", "else "), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(3);

                yield return new TestCaseData(Resources.Script0005.Replace("[valx]", "1").Replace("[valy]", "0"), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(4);
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0005.Replace("[valx]", "1").Replace("[valy]", "0"), string.Empty).Replace("else", "else "), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(4);

                #endregion

                #region try, catch, finally

                yield return new TestCaseData(Resources.Script0028, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Try")
                    .SetCategory("Catch")
                    .SetCategory("Finally")
                    .SetCategory("Exception")
                    .Returns("catch : True, finally : True");

                yield return new TestCaseData(Resources.Script0030, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Try")
                    .SetCategory("Catch")
                    .SetCategory("Exception")
                    .Returns("catch : True, finally : False");

                yield return new TestCaseData(Resources.Script0031, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Try")
                    .SetCategory("Catch")
                    .SetCategory("Finally")
                    .SetCategory("Exception")
                    .Returns("catch : 1, finally : True");

                yield return new TestCaseData(Resources.Script0032, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Try")
                    .SetCategory("Catch")
                    .SetCategory("Finally")
                    .SetCategory("Exception")
                    .Returns("catch : 2, finally : True");

                #endregion

                #region block for lambda body

                yield return new TestCaseData(Resources.Script0006, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("lambda")
                    .SetCategory("variable assignation")
                    .SetCategory("block for lambda body")
                    .Returns(3);
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0006, string.Empty), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("lambda")
                    .SetCategory("variable assignation")
                    .SetCategory("block for lambda body")
                    .Returns(3);

                #endregion

                #region return keyword and OptionAutoReturnLastExpressionResultInScriptsActive tests 

                yield return new TestCaseData(Resources.Script0008.Replace("[valx]", "1"), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("return")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(1);
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0008.Replace("[valx]", "1"), string.Empty).Replace("return", "return "), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("return")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(1);
                yield return new TestCaseData(Resources.Script0008.Replace("[valx]", "2"), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("return")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(2);
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0008.Replace("[valx]", "2"), string.Empty).Replace("return", "return "), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("return")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(2);
                yield return new TestCaseData(Resources.Script0008.Replace("[valx]", "0"), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("return")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(2);
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0008.Replace("[valx]", "0"), string.Empty).Replace("return", "return "), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("return")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .Returns(2);

                yield return new TestCaseData(Resources.Script0072, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("return")
                    .SetCategory("parentheses")
                    .SetCategory("variable assignation")
                    .Returns(8);

                ExpressionEvaluator evaluator = new ExpressionEvaluator()
                {
                    OptionOnNoReturnKeywordFoundInScriptAction = OptionOnNoReturnKeywordFoundInScriptAction.ReturnNull
                };

                yield return new TestCaseData(Resources.Script0008.Replace("[valx]", "1"), evaluator, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("return")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .SetCategory("Options")
                    .SetCategory("OptionOnNoReturnKeywordFoundInScriptAction = ReturnNull")
                    .Returns(null);
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0008.Replace("[valx]", "1"), string.Empty).Replace("return", "return "), evaluator, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("return")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .SetCategory("Options")
                    .SetCategory("OptionOnNoReturnKeywordFoundInScriptAction = ReturnNull")
                    .Returns(null);
                yield return new TestCaseData(Resources.Script0008.Replace("[valx]", "2"), evaluator, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("return")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .SetCategory("Options")
                    .SetCategory("OptionOnNoReturnKeywordFoundInScriptAction = ReturnNull")
                    .Returns(null);
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0008.Replace("[valx]", "2"), string.Empty).Replace("return", "return "), evaluator, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("return")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .SetCategory("Options")
                    .SetCategory("OptionOnNoReturnKeywordFoundInScriptAction = ReturnNull")
                    .Returns(null);
                yield return new TestCaseData(Resources.Script0008.Replace("[valx]", "0"), evaluator, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("return")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .SetCategory("Options")
                    .SetCategory("OptionOnNoReturnKeywordFoundInScriptAction = ReturnNull")
                    .Returns(2);
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0008.Replace("[valx]", "0"), string.Empty).Replace("return", "return "), evaluator, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("return")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .SetCategory("Options")
                    .SetCategory("OptionOnNoReturnKeywordFoundInScriptAction = ReturnNull")
                    .Returns(2);

                evaluator = new ExpressionEvaluator()
                {
                    OptionOnNoReturnKeywordFoundInScriptAction = OptionOnNoReturnKeywordFoundInScriptAction.ThrowSyntaxException
                };

                yield return new TestCaseData(Resources.Script0008.Replace("[valx]", "0"), evaluator, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("return")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .SetCategory("Options")
                    .SetCategory("OptionOnNoReturnKeywordFoundInScriptAction = ReturnNull")
                    .Returns(2);
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0008.Replace("[valx]", "0"), string.Empty).Replace("return", "return "), evaluator, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("return")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .SetCategory("Options")
                    .SetCategory("OptionOnNoReturnKeywordFoundInScriptAction = ReturnNull")
                    .Returns(2);

                #endregion

                #region Option OptionScriptNeedSemicolonAtTheEndOfLastExpression set to false

                ExpressionEvaluator evaluatorForNoSemicolonAtTheEnd = new ExpressionEvaluator()
                {
                    OptionScriptNeedEndOfExpressionTokenAtTheEndOfLastExpression = false
                };

                yield return new TestCaseData(Resources.Script0061, evaluatorForNoSemicolonAtTheEnd, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("OptionScriptNeedSemicolonAtTheEndOfLastExpression")
                    .Returns("[1,2,3,4]");

                yield return new TestCaseData(Resources.Script0062, evaluatorForNoSemicolonAtTheEnd, null, null, new Func<object, object>(obj => JsonConvert.SerializeObject(obj)))
                    .SetCategory("Script")
                    .SetCategory("OptionScriptNeedSemicolonAtTheEndOfLastExpression")
                    .Returns("[1,2,3,4]");

                #endregion

                #region Lambda assignation and call

                yield return new TestCaseData(Resources.Script0016, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("lambda")
                    .SetCategory("lambda call")
                    .SetCategory("lambda assignation")
                    .SetCategory("return")
                    .SetCategory("variable assignation")
                    .Returns(7);

                yield return new TestCaseData(Resources.Script0017, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("lambda")
                    .SetCategory("lambda call")
                    .SetCategory("lambda call imbrication")
                    .SetCategory("lambda assignation")
                    .SetCategory("return")
                    .SetCategory("variable assignation")
                    .Returns(6);

                #endregion

                #region ExpandoObject

                yield return new TestCaseData(Resources.Script0019, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("ExpandoObject")
                    .SetCategory("return")
                    .Returns(58.3);
                yield return new TestCaseData(Resources.Script0020, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("ExpandoObject")
                    .SetCategory("Indexing")
                    .SetCategory("return")
                    .Returns(58.3);
                yield return new TestCaseData(Resources.Script0021, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("ExpandoObject")
                    .SetCategory("Indexing")
                    .SetCategory("return")
                    .Returns(58.3);
                yield return new TestCaseData(Resources.Script0022, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("ExpandoObject")
                    .SetCategory("Indexing")
                    .SetCategory("return")
                    .Returns(58.3);
                yield return new TestCaseData(Resources.Script0023, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("ExpandoObject")
                    .SetCategory("Indexing")
                    .SetCategory("Postfix operator")
                    .SetCategory("++")
                    .SetCategory("return")
                    .Returns(5);
                yield return new TestCaseData(Resources.Script0024, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("ExpandoObject")
                    .SetCategory("lambda")
                    .SetCategory("lambda call")
                    .SetCategory("lambda assignation")
                    .SetCategory("return")
                    .Returns("The result is : 7");

                yield return new TestCaseData(Resources.Script0051, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Init of ExpandoObject")
                    .Returns("{\"Hello\":3,\"No\":\"Yes\"}");

                yield return new TestCaseData(Resources.Script0052, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Using already define vars in inits")
                    .SetCategory("Init of ExpandoObject")
                    .SetCategory("conflict variable assignation vs on the fly in object with same name")
                    .Returns("{\"Hello\":3,\"No\":\"Yes\"}");

                yield return new TestCaseData(Resources.Script0053, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Using already define vars in inits")
                    .SetCategory("Anonymous type init as ExpandoObject")
                    .SetCategory("Init of ExpandoObject")
                    .SetCategory("conflict variable assignation vs on the fly in object with same name")
                    .Returns("{\"Hello\":3,\"No\":\"Yes\"}");

                #endregion

                #region Diactitics

                yield return new TestCaseData(Resources.Script0026, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Diactitics")
                    .SetCategory("=")
                    .Returns("A value in diactitic varçÿ && very complex var");

                yield return new TestCaseData(Resources.Script0027, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Diactitics")
                    .SetCategory("=")
                    .Returns("ç");

                #endregion

                #region var keyword

                yield return new TestCaseData(Resources.Script0060, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("var keyword")
                    .SetCategory("=")
                    .Returns("A text for 4 test");

                #endregion

                #region Typed and dynamic variables

                yield return new TestCaseData(Resources.Script0063, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("primaryTyped variable")
                    .SetCategory("int")
                    .SetCategory("=")
                    .Returns(5);

                yield return new TestCaseData(Resources.Script0064, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("primaryTyped variable")
                    .SetCategory("float")
                    .SetCategory("=")
                    .Returns(5.5);

                yield return new TestCaseData(Resources.Script0065, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Dynamic variable")
                    .SetCategory("dynamic")
                    .SetCategory("=")
                    .Returns(8);

                yield return new TestCaseData(Resources.Script0066, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("primaryTyped variable")
                    .SetCategory("string")
                    .SetCategory("int")
                    .SetCategory("for")
                    .SetCategory("++")
                    .SetCategory("=")
                    .Returns("0,1,2,3,4,");

                yield return new TestCaseData(Resources.Script0067, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("primaryTyped variable")
                    .SetCategory("List")
                    .SetCategory("int")
                    .SetCategory("=")
                    .Returns("[1,2,3,4]");

                yield return new TestCaseData("int? x = null; return x;", null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("primaryTyped variable")
                    .SetCategory("null")
                    .SetCategory("nullable")
                    .SetCategory("=")
                    .Returns(null);

                #endregion

                #region More complex script

                yield return new TestCaseData(Resources.Script0007, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("lambda")
                    .SetCategory("variable assignation")
                    .SetCategory("if")
                    .SetCategory("block for lambda body")
                    .Returns(13);
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0007, string.Empty), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("lambda")
                    .SetCategory("variable assignation")
                    .SetCategory("if")
                    .SetCategory("block for lambda body")
                    .Returns(13);
                yield return new TestCaseData(Resources.Script0009, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("variable assignation")
                    .SetCategory("if")
                    .SetCategory("continue in for")
                    .SetCategory("break in for")
                    .Returns("0,1,2,4,5,6,");
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0009, string.Empty), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("variable assignation")
                    .SetCategory("if")
                    .SetCategory("continue in for")
                    .SetCategory("break in for")
                    .Returns("0,1,2,4,5,6,");
                yield return new TestCaseData(Resources.Script0010, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("variable assignation")
                    .SetCategory("if")
                    .SetCategory("continue in while")
                    .SetCategory("break in while")
                    .Returns("0,1,2,4,5,6,");
                yield return new TestCaseData(removeAllWhiteSpacesRegex.Replace(Resources.Script0010, string.Empty), null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("variable assignation")
                    .SetCategory("if")
                    .SetCategory("continue in while")
                    .SetCategory("break in while")
                    .Returns("0,1,2,4,5,6,");

                yield return new TestCaseData(Resources.Script0011, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Indexing assignation")
                    .SetCategory("=")
                    .SetCategory("+=")
                    .SetCategory("-=")
                    .SetCategory("*=")
                    .SetCategory("/=")
                    .SetCategory("/=")
                    .SetCategory("%=")
                    .SetCategory("^=")
                    .SetCategory("&=")
                    .SetCategory("|=")
                    .SetCategory("<<=")
                    .SetCategory("<<=")
                    .SetCategory("List function")
                    .Returns("[8,11,3,15,2,1,6,1,7,20,1]");

                yield return new TestCaseData(Resources.Script0012, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Indexing postfix operators")
                    .SetCategory("=")
                    .SetCategory("+=")
                    .SetCategory("++")
                    .SetCategory("--")
                    .SetCategory("List function")
                    .Returns("[6,4,10,6,10,4]");

                yield return new TestCaseData(Resources.Script0100, new ExpressionEvaluator(), null, null, null)
                    .SetCategory("Script")
                    .SetCategory("OutKeywordMethod")
                    .Returns(5);

                yield return new TestCaseData(Resources.Script0101, new ExpressionEvaluator(), null, null, null)
                    .SetCategory("Script")
                    .SetCategory("OutKeywordMethod")
                    .Returns(5);

                #endregion

                #region Flexible script syntax

                ExpressionEvaluator flexibleScriptSyntaxEvaluator01 = new ExpressionEvaluator()
                {
                    OptionScriptEndOfExpression = new string[] { "\r\n", "\r", "\n" },
                    OptionScriptNeedEndOfExpressionTokenAtTheEndOfLastExpression = false
                };

                yield return new TestCaseData(Resources.Script0074, flexibleScriptSyntaxEvaluator01, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptEndOfExpression))
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptNeedEndOfExpressionTokenAtTheEndOfLastExpression))
                    .Returns(8);

                ExpressionEvaluator flexibleScriptSyntaxEvaluator02 = new ExpressionEvaluator()
                {
                    OptionScriptSyntaxForHeadStatementInBlocksKeywords = SyntaxForHeadStatementInBlocksKeywords.SeparatorBetweenHeadAndBlock
                };

                yield return new TestCaseData(Resources.Script0075.Replace("[infos]", nameof(SyntaxForHeadStatementInBlocksKeywords.SeparatorBetweenHeadAndBlock)), flexibleScriptSyntaxEvaluator02, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(SyntaxForHeadStatementInBlocksKeywords.SeparatorBetweenHeadAndBlock))
                    .Returns(20);

                yield return new TestCaseData(Resources.Script0076.Replace("[infos]", nameof(SyntaxForHeadStatementInBlocksKeywords.SeparatorBetweenHeadAndBlock)), flexibleScriptSyntaxEvaluator02, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(SyntaxForHeadStatementInBlocksKeywords.SeparatorBetweenHeadAndBlock))
                    .Returns(20);

                yield return new TestCaseData(Resources.Script0077.Replace("[infos]", nameof(SyntaxForHeadStatementInBlocksKeywords.SeparatorBetweenHeadAndBlock)), flexibleScriptSyntaxEvaluator02, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(SyntaxForHeadStatementInBlocksKeywords.SeparatorBetweenHeadAndBlock))
                    .Returns(20);

                yield return new TestCaseData(Resources.Script0078.Replace("[infos]", nameof(SyntaxForHeadStatementInBlocksKeywords.SeparatorBetweenHeadAndBlock)), flexibleScriptSyntaxEvaluator02, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(SyntaxForHeadStatementInBlocksKeywords.SeparatorBetweenHeadAndBlock))
                    .Returns(20);

                yield return new TestCaseData(Resources.Script0081.Replace("[infos]", nameof(SyntaxForHeadStatementInBlocksKeywords.SeparatorBetweenHeadAndBlock)), flexibleScriptSyntaxEvaluator02, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(SyntaxForHeadStatementInBlocksKeywords.SeparatorBetweenHeadAndBlock))
                    .Returns(20);

                ExpressionEvaluator flexibleScriptSyntaxEvaluator03 = new ExpressionEvaluator()
                {
                    OptionScriptSyntaxForHeadStatementInBlocksKeywords = SyntaxForHeadStatementInBlocksKeywords.Any
                };

                yield return new TestCaseData(Resources.Script0075.Replace("[infos]", nameof(SyntaxForHeadStatementInBlocksKeywords.Any)), flexibleScriptSyntaxEvaluator03, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(SyntaxForHeadStatementInBlocksKeywords.Any))
                    .Returns(20);

                yield return new TestCaseData(Resources.Script0076.Replace("[infos]", nameof(SyntaxForHeadStatementInBlocksKeywords.Any)), flexibleScriptSyntaxEvaluator03, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(SyntaxForHeadStatementInBlocksKeywords.Any))
                    .Returns(20);

                yield return new TestCaseData(Resources.Script0077.Replace("[infos]", nameof(SyntaxForHeadStatementInBlocksKeywords.Any)), flexibleScriptSyntaxEvaluator03, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(SyntaxForHeadStatementInBlocksKeywords.Any))
                    .Returns(20);

                yield return new TestCaseData(Resources.Script0078.Replace("[infos]", nameof(SyntaxForHeadStatementInBlocksKeywords.Any)), flexibleScriptSyntaxEvaluator03, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(SyntaxForHeadStatementInBlocksKeywords.Any))
                    .Returns(20);

                yield return new TestCaseData(Resources.Script0079.Replace("[infos]", nameof(SyntaxForHeadStatementInBlocksKeywords.Any)), flexibleScriptSyntaxEvaluator03, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(SyntaxForHeadStatementInBlocksKeywords.Any))
                    .Returns(20);

                yield return new TestCaseData(Resources.Script0080.Replace("[infos]", nameof(SyntaxForHeadStatementInBlocksKeywords.Any)), flexibleScriptSyntaxEvaluator03, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(SyntaxForHeadStatementInBlocksKeywords.Any))
                    .Returns(20);

                yield return new TestCaseData(Resources.Script0081.Replace("[infos]", nameof(SyntaxForHeadStatementInBlocksKeywords.Any)), flexibleScriptSyntaxEvaluator03, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(SyntaxForHeadStatementInBlocksKeywords.Any))
                    .Returns(20);

                ExpressionEvaluator flexibleScriptSyntaxEvaluator04 = new ExpressionEvaluator()
                {
                    OptionScriptSyntaxForHeadStatementInBlocksKeywords = SyntaxForHeadStatementInBlocksKeywords.Both
                };

                yield return new TestCaseData(Resources.Script0077.Replace("[infos]", nameof(SyntaxForHeadStatementInBlocksKeywords.Both)), flexibleScriptSyntaxEvaluator04, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory("SyntaxForHeadStatementInBlocksKeywords.Both")
                    .Returns(20);

                yield return new TestCaseData(Resources.Script0078.Replace("[infos]", nameof(SyntaxForHeadStatementInBlocksKeywords.Both)), flexibleScriptSyntaxEvaluator04, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory("SyntaxForHeadStatementInBlocksKeywords.Both")
                    .Returns(20);

                yield return new TestCaseData(Resources.Script0081.Replace("[infos]", nameof(SyntaxForHeadStatementInBlocksKeywords.Both)), flexibleScriptSyntaxEvaluator04, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(SyntaxForHeadStatementInBlocksKeywords.Both))
                    .Returns(20);

                ExpressionEvaluator flexibleScriptSyntaxEvaluator05 = new ExpressionEvaluator()
                {
                    OptionScriptBlocksKeywordsHeadStatementsStartBracket = "|",
                    OptionScriptBlocksKeywordsHeadExpressionEndBracket = "|"
                };

                yield return new TestCaseData(Resources.Script0082, flexibleScriptSyntaxEvaluator05, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlocksKeywordsHeadStatementsStartBracket))
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlocksKeywordsHeadExpressionEndBracket))
                    .Returns(20);

                yield return new TestCaseData(Resources.Script0083, flexibleScriptSyntaxEvaluator05, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlocksKeywordsHeadStatementsStartBracket))
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlocksKeywordsHeadExpressionEndBracket))
                    .Returns(20);

                ExpressionEvaluator flexibleScriptSyntaxEvaluator06 = new ExpressionEvaluator()
                {
                    OptionScriptBlocksKeywordsHeadStatementsStartBracket = "{",
                    OptionScriptBlocksKeywordsHeadExpressionEndBracket = "}"
                };

                yield return new TestCaseData(Resources.Script0084, flexibleScriptSyntaxEvaluator06, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlocksKeywordsHeadStatementsStartBracket))
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlocksKeywordsHeadExpressionEndBracket))
                    .Returns(20);

                yield return new TestCaseData(Resources.Script0085, flexibleScriptSyntaxEvaluator06, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlocksKeywordsHeadStatementsStartBracket))
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlocksKeywordsHeadExpressionEndBracket))
                    .Returns(20);

                ExpressionEvaluator flexibleScriptSyntaxEvaluator07 = new ExpressionEvaluator()
                {
                    OptionScriptBlocksKeywordsHeadStatementsStartBracket = "<[",
                    OptionScriptBlocksKeywordsHeadExpressionEndBracket = "]>"
                };

                yield return new TestCaseData(Resources.Script0086, flexibleScriptSyntaxEvaluator07, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlocksKeywordsHeadStatementsStartBracket))
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlocksKeywordsHeadExpressionEndBracket))
                    .Returns(20);

                yield return new TestCaseData(Resources.Script0087, flexibleScriptSyntaxEvaluator07, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlocksKeywordsHeadStatementsStartBracket))
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlocksKeywordsHeadExpressionEndBracket))
                    .Returns(20);

                ExpressionEvaluator flexibleScriptSyntaxEvaluator08 = new ExpressionEvaluator()
                {
                    OptionScriptBlockKeywordsHeadExpressionAndBlockSeparator = "=>",
                    OptionScriptSyntaxForHeadStatementInBlocksKeywords = SyntaxForHeadStatementInBlocksKeywords.SeparatorBetweenHeadAndBlock
                };

                yield return new TestCaseData(Resources.Script0088, flexibleScriptSyntaxEvaluator08, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(SyntaxForHeadStatementInBlocksKeywords.SeparatorBetweenHeadAndBlock))
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlockKeywordsHeadExpressionAndBlockSeparator))
                    .Returns(20);

                yield return new TestCaseData(Resources.Script0089, flexibleScriptSyntaxEvaluator08, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(SyntaxForHeadStatementInBlocksKeywords.SeparatorBetweenHeadAndBlock))
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlockKeywordsHeadExpressionAndBlockSeparator))
                    .Returns(20);

                ExpressionEvaluator flexibleScriptSyntaxEvaluator09 = new ExpressionEvaluator()
                {
                    OptionScriptBlockStartBracket = "(",
                    OptionScriptBlockEndBracket = ")"
                };

                yield return new TestCaseData(Resources.Script0090, flexibleScriptSyntaxEvaluator09, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlockStartBracket))
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlockEndBracket))
                    .Returns(20);

                ExpressionEvaluator flexibleScriptSyntaxEvaluator10 = new ExpressionEvaluator()
                {
                    OptionScriptSyntaxForHeadStatementInBlocksKeywords = SyntaxForHeadStatementInBlocksKeywords.SeparatorBetweenHeadAndBlock,
                    OptionScriptBlockKeywordsHeadExpressionAndBlockSeparator = "then",
                    OptionScriptBlockStartBracket = "begin",
                    OptionScriptBlockEndBracket = "end"
                };

                flexibleScriptSyntaxEvaluator10.ImbricableBracketsPairing["begin"] = "end";

                yield return new TestCaseData(Resources.Script0091, flexibleScriptSyntaxEvaluator10, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlockStartBracket))
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlockEndBracket))
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlockKeywordsHeadExpressionAndBlockSeparator))
                    .SetCategory(nameof(SyntaxForHeadStatementInBlocksKeywords.SeparatorBetweenHeadAndBlock))
                    .SetCategory("PascalSyntax")
                    .Returns(20);

                yield return new TestCaseData(Resources.Script0092, flexibleScriptSyntaxEvaluator10, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlockStartBracket))
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlockEndBracket))
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlockKeywordsHeadExpressionAndBlockSeparator))
                    .SetCategory(nameof(SyntaxForHeadStatementInBlocksKeywords.SeparatorBetweenHeadAndBlock))
                    .SetCategory("PascalSyntax")
                    .Returns(20);

                yield return new TestCaseData(Resources.Script0093, flexibleScriptSyntaxEvaluator10, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlockStartBracket))
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlockEndBracket))
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlockKeywordsHeadExpressionAndBlockSeparator))
                    .SetCategory(nameof(SyntaxForHeadStatementInBlocksKeywords.SeparatorBetweenHeadAndBlock))
                    .SetCategory("PascalSyntax")
                    .Returns(20);

                yield return new TestCaseData(Resources.Script0094, new ExpressionEvaluator() {OptionNewKeywordAliases = new[] { "->" } }, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(ExpressionEvaluator.OptionNewKeywordAliases))
                    .Returns(2);

                yield return new TestCaseData(Resources.Script0095, new ExpressionEvaluator() {OptionNewKeywordAliases = new[] { "new", "create" } }, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(ExpressionEvaluator.OptionNewKeywordAliases))
                    .Returns(12);

                ExpressionEvaluator flexibleScriptSyntaxEvaluator11 = new ExpressionEvaluator()
                {
                    OptionScriptSyntaxForBlocksIdentifier = SyntaxForScriptBlocksIdentifier.Indentation
                };

                yield return new TestCaseData(Resources.Script0096, flexibleScriptSyntaxEvaluator11, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(SyntaxForScriptBlocksIdentifier.Indentation))
                    .SetCategory("Indentation : " + nameof(ScriptBlocksIndentation.Spaces))
                    .Returns(24);

                ExpressionEvaluator flexibleScriptSyntaxEvaluator12 = new ExpressionEvaluator()
                {
                    OptionScriptSyntaxForBlocksIdentifier = SyntaxForScriptBlocksIdentifier.Indentation,
                    OptionScriptBlocksIndentation = ScriptBlocksIndentation.Tabulation
                };

                yield return new TestCaseData(Resources.Script0097, flexibleScriptSyntaxEvaluator12, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(SyntaxForScriptBlocksIdentifier.Indentation))
                    .SetCategory("Indentation : " + nameof(ScriptBlocksIndentation.Tabulation))
                    .Returns(24);

                ExpressionEvaluator flexibleScriptSyntaxEvaluator13 = new ExpressionEvaluator()
                {
                    OptionScriptSyntaxForBlocksIdentifier = SyntaxForScriptBlocksIdentifier.Indentation,
                    OptionScriptBlocksIndentationNumberOfSpaces = 2
                };

                yield return new TestCaseData(Resources.Script0098, flexibleScriptSyntaxEvaluator13, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(SyntaxForScriptBlocksIdentifier.Indentation))
                    .SetCategory("Indentation : " + nameof(ScriptBlocksIndentation.Spaces))
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptBlocksIndentationNumberOfSpaces))
                    .Returns(24);

                ExpressionEvaluator flexibleScriptSyntaxEvaluator14 = new ExpressionEvaluator()
                {
                    OptionScriptSyntaxForBlocksIdentifier = SyntaxForScriptBlocksIdentifier.Indentation,
                    OptionScriptSyntaxForHeadStatementInBlocksKeywords = SyntaxForHeadStatementInBlocksKeywords.SeparatorBetweenHeadAndBlock,
                    OptionScriptEndOfExpression = new string[] { "\r\n", "\r", "\n" },
                    OptionScriptNeedEndOfExpressionTokenAtTheEndOfLastExpression = false,
                };

                yield return new TestCaseData(Resources.Script0099, flexibleScriptSyntaxEvaluator14, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory(nameof(SyntaxForScriptBlocksIdentifier.Indentation))
                    .SetCategory("Indentation : " + nameof(ScriptBlocksIndentation.Spaces))
                    .SetCategory(nameof(SyntaxForHeadStatementInBlocksKeywords.SeparatorBetweenHeadAndBlock))
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptEndOfExpression))
                    .SetCategory(nameof(ExpressionEvaluator.OptionScriptNeedEndOfExpressionTokenAtTheEndOfLastExpression))
                    .SetCategory("PythonSyntax")
                    .Returns(24);

                #endregion

                #region For Bug correction (no regression)

                yield return new TestCaseData(Resources.Script0049, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("Conflict between generics and <> operators")
                    .SetCategory("variable assignation")
                    .SetCategory("Bug")
                    .SetCategory("#26")
                    .Returns(false);

                yield return new TestCaseData(Resources.Script0050, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("conflict variable assignation vs on the fly in object with same name")
                    .SetCategory("Bug")
                    .Returns("{\"Hello\":3,\"No\":\"Yes\"}");

                StructForTest1 structForTest1 = new StructForTest1();
                ExpressionEvaluator evaluatorForStructs = new ExpressionEvaluator(
                    new Dictionary<string, object>
                    {
                        { "myStruct", structForTest1 }
                    });

                yield return new TestCaseData("return myStruct.myIntvalue;", evaluatorForStructs, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("struct tests")
                    .SetCategory("Bug")
                    .Returns(0);

                yield return new TestCaseData(Resources.Script0054, evaluatorForStructs, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("struct tests")
                    .SetCategory("Bug")
                    .Returns("Result Test 3");

                evaluatorForStructs.Variables["otherStruct"] = new StructForTest2();

                yield return new TestCaseData(Resources.Script0055, evaluatorForStructs, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("struct tests")
                    .SetCategory("Bug")
                    .Returns("Result Hey 9, 5");

                yield return new TestCaseData(Resources.Script0056, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("struct tests")
                    .SetCategory("Bug")
                    .Returns("Result Hey 9");

                yield return new TestCaseData(Resources.Script0057, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("struct tests")
                    .SetCategory("Bug")
                    .Returns("Result Hey 9");

                yield return new TestCaseData(Resources.Script0058, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("struct tests")
                    .SetCategory("Bug")
                    .SetCategory("Better Than C#")
                    .Returns("Result Hey 9");

                yield return new TestCaseData(Resources.Script0059, null, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("struct tests")
                    .SetCategory("Bug")
                    .SetCategory("Better Than C#")
                    .Returns("Result Hey 9, 5");

                yield return new TestCaseData(Resources.Script0066, new ExpressionEvaluator { OptionScriptNeedEndOfExpressionTokenAtTheEndOfLastExpression = false }, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("primaryTyped variable")
                    .SetCategory("string")
                    .SetCategory("int")
                    .SetCategory("for")
                    .SetCategory("++")
                    .SetCategory("=")
                    .SetCategory("OptionScriptNeedSemicolonAtTheEndOfLastExpression")
                    .Returns("0,1,2,3,4,");

                yield return new TestCaseData(Resources.Script0070, new ExpressionEvaluator { OptionScriptNeedEndOfExpressionTokenAtTheEndOfLastExpression = false }, null, null, null)
                    .SetCategory("Script")
                    .SetCategory("new Exception must not throw the exception")
                    .Returns(3);

                #endregion
            }
        }

        [TestCaseSource(nameof(TestCasesForScriptEvaluateTests))]
        public object TestCasesForScriptEvaluate(string script, ExpressionEvaluator evaluator, Action PreExecuteAssertAction, Action PostExecuteAssertAction, Func<object,object> ModifyResultFunc)
        {
            evaluator = evaluator ?? new ExpressionEvaluator();

            evaluator.EvaluateVariable += Evaluator_EvaluateVariable;

            evaluator.Namespaces.Add("CodingSeb.ExpressionEvaluator.Tests");

            PreExecuteAssertAction?.Invoke();

            object result = evaluator.ScriptEvaluate(evaluator.RemoveComments(script));

            PostExecuteAssertAction?.Invoke();
            result = ModifyResultFunc?.Invoke(result) ?? result;

            evaluator.EvaluateVariable -= Evaluator_EvaluateVariable;

            return result;
        }

        private void Evaluator_EvaluateVariable(object sender, VariableEvaluationEventArg e)
        {
            if (e.This != null && e.Name.Equals("Json"))
            {
                e.Value = JsonConvert.SerializeObject(e.This);
            }
        }

        #endregion

        #region Exception Throwing Evaluation

        public static IEnumerable<TestCaseData> TestCasesForExceptionThrowingScriptEvaluation
        {
            get
            {
                #region Options

                #region OptionOnNoReturnKeywordFoundInScriptAction = OptionOnNoReturnKeywordFoundInScriptAction.ThrowSyntaxException

                ExpressionEvaluator evaluator = new ExpressionEvaluator()
                {
                    OptionOnNoReturnKeywordFoundInScriptAction = OptionOnNoReturnKeywordFoundInScriptAction.ThrowSyntaxException
                };

                yield return new TestCaseData(evaluator, Resources.Script0008.Replace("[valx]", "1"), typeof(ExpressionEvaluatorSyntaxErrorException), null,null)
                    .SetCategory("Script")
                    .SetCategory("return")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .SetCategory("Options")
                    .SetCategory("OptionOnNoReturnKeywordFoundInScriptAction = ThrowSyntaxException");
                yield return new TestCaseData(evaluator, Resources.Script0008.Replace("[valx]", "2"), typeof(ExpressionEvaluatorSyntaxErrorException), null,null)
                    .SetCategory("Script")
                    .SetCategory("return")
                    .SetCategory("if")
                    .SetCategory("variable assignation")
                    .SetCategory("Options")
                    .SetCategory("OptionOnNoReturnKeywordFoundInScriptAction = ThrowSyntaxException");

                #endregion

                #endregion

                #region Flexible script syntax that must throw Exception

                ExpressionEvaluator flexibleScriptSyntaxEvaluator01 = new ExpressionEvaluator()
                {
                    OptionScriptSyntaxForHeadStatementInBlocksKeywords = SyntaxForHeadStatementInBlocksKeywords.HeadBrackets
                };

                yield return new TestCaseData(flexibleScriptSyntaxEvaluator01, Resources.Script0075.Replace("[infos]", "HeadBrackets"), typeof(ExpressionEvaluatorSyntaxErrorException), null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory("SyntaxForHeadStatementInBlocksKeywords.HeadBrackets")
                    .SetCategory("Exception");

                yield return new TestCaseData(flexibleScriptSyntaxEvaluator01, Resources.Script0076.Replace("[infos]", "HeadBrackets"), typeof(ExpressionEvaluatorSyntaxErrorException), null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory("SyntaxForHeadStatementInBlocksKeywords.HeadBrackets")
                    .SetCategory("Exception");

                yield return new TestCaseData(flexibleScriptSyntaxEvaluator01, Resources.Script0077.Replace("[infos]", "HeadBrackets"), typeof(ExpressionEvaluatorSyntaxErrorException), null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory("SyntaxForHeadStatementInBlocksKeywords.HeadBrackets")
                    .SetCategory("Exception");

                yield return new TestCaseData(flexibleScriptSyntaxEvaluator01, Resources.Script0078.Replace("[infos]", "HeadBrackets"), typeof(ExpressionEvaluatorSyntaxErrorException), null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory("SyntaxForHeadStatementInBlocksKeywords.HeadBrackets")
                    .SetCategory("Exception");

                yield return new TestCaseData(flexibleScriptSyntaxEvaluator01, Resources.Script0081.Replace("[infos]", "HeadBrackets"), typeof(ExpressionEvaluatorSyntaxErrorException), null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory("SyntaxForHeadStatementInBlocksKeywords.HeadBrackets")
                    .SetCategory("Exception");

                ExpressionEvaluator flexibleScriptSyntaxEvaluator02 = new ExpressionEvaluator()
                {
                    OptionScriptSyntaxForHeadStatementInBlocksKeywords = SyntaxForHeadStatementInBlocksKeywords.SeparatorBetweenHeadAndBlock
                };

                yield return new TestCaseData(flexibleScriptSyntaxEvaluator02, Resources.Script0079.Replace("[infos]", "SeparatorBetweenHeadAndBlock"), typeof(ExpressionEvaluatorSyntaxErrorException), null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory("SyntaxForHeadStatementInBlocksKeywords.SeparatorBetweenHeadAndBlock")
                    .SetCategory("Exception");

                yield return new TestCaseData(flexibleScriptSyntaxEvaluator02, Resources.Script0080.Replace("[infos]", "SeparatorBetweenHeadAndBlock"), typeof(ExpressionEvaluatorSyntaxErrorException), null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory("SyntaxForHeadStatementInBlocksKeywords.SeparatorBetweenHeadAndBlock")
                    .SetCategory("Exception");

                ExpressionEvaluator flexibleScriptSyntaxEvaluator03 = new ExpressionEvaluator()
                {
                    OptionScriptSyntaxForHeadStatementInBlocksKeywords = SyntaxForHeadStatementInBlocksKeywords.Both
                };

                yield return new TestCaseData(flexibleScriptSyntaxEvaluator03, Resources.Script0075.Replace("[infos]", "Both"), typeof(ExpressionEvaluatorSyntaxErrorException), null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory("SyntaxForHeadStatementInBlocksKeywords.Both")
                    .SetCategory("Exception");

                yield return new TestCaseData(flexibleScriptSyntaxEvaluator03, Resources.Script0076.Replace("[infos]", "Both"), typeof(ExpressionEvaluatorSyntaxErrorException), null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory("SyntaxForHeadStatementInBlocksKeywords.Both")
                    .SetCategory("Exception");

                yield return new TestCaseData(flexibleScriptSyntaxEvaluator03, Resources.Script0079.Replace("[infos]", "Both"), typeof(ExpressionEvaluatorSyntaxErrorException), null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory("SyntaxForHeadStatementInBlocksKeywords.Both")
                    .SetCategory("Exception");

                yield return new TestCaseData(flexibleScriptSyntaxEvaluator03, Resources.Script0080.Replace("[infos]", "Both"), typeof(ExpressionEvaluatorSyntaxErrorException), null, null)
                    .SetCategory("Script")
                    .SetCategory("FlexibleScriptSyntax")
                    .SetCategory("SyntaxForHeadStatementInBlocksKeywords.Both")
                    .SetCategory("Exception");

                #endregion

                #region Throw Exception

                yield return new TestCaseData(new ExpressionEvaluator(), Resources.Script0025, typeof(Exception), "Exception for test",null)
                    .SetCategory("Script")
                    .SetCategory("Throw")
                    .SetCategory("Exception");

                yield return new TestCaseData(new ExpressionEvaluator(), Resources.Script0029, typeof(DivideByZeroException), null, new Action(() => ClassForTest1.StaticIntProperty.ShouldBe(20)))
                    .SetCategory("Script")
                    .SetCategory("Try")
                    .SetCategory("Finally")
                    .SetCategory("Exception");

                #endregion

                #region set bad content to TypedVariable 

                yield return new TestCaseData(new ExpressionEvaluator(), "int x = \"Test\";", typeof(InvalidCastException), null, null)
                    .SetCategory("Script")
                    .SetCategory("int")
                    .SetCategory("primaryTyped variable")
                    .SetCategory("Exception");

                yield return new TestCaseData(new ExpressionEvaluator(), "List<int> x = 3;", typeof(InvalidCastException), null, null)
                    .SetCategory("Script")
                    .SetCategory("int")
                    .SetCategory("List")
                    .SetCategory("primaryTyped variable")
                    .SetCategory("Exception");

                yield return new TestCaseData(new ExpressionEvaluator(), "int x = null;", typeof(ExpressionEvaluatorSyntaxErrorException), "Can not cast null to System.Int32 because it's not a nullable valueType", null)
                    .SetCategory("Script")
                    .SetCategory("int")
                    .SetCategory("null")
                    .SetCategory("primaryTyped variable")
                    .SetCategory("Exception");

                #endregion

                #region bad return

                yield return new TestCaseData(new ExpressionEvaluator(), Resources.Script0073, typeof(ExpressionEvaluatorSyntaxErrorException), null, null)
                    .SetCategory("Script")
                    .SetCategory("return")
                    .SetCategory("Exception");

                #endregion
            }
        }

        [TestCaseSource(nameof(TestCasesForExceptionThrowingScriptEvaluation))]
        public void ExceptionThrowingScriptEvaluation(ExpressionEvaluator evaluator, string script, Type exceptionType, string exceptionMessage, Action ToTestAfter)
        {
            evaluator.Namespaces.Add("CodingSeb.ExpressionEvaluator.Tests");

            bool exceptionThrown = false;

            try
            {
                evaluator.ScriptEvaluate(evaluator.RemoveComments(script));
            }
            catch(Exception exception)
            {
                exceptionThrown = true;
                exception.ShouldBeAssignableTo(exceptionType);
                if (exceptionMessage != null)
                {
                    exception.Message.ShouldBe(exceptionMessage);
                }
            }

            exceptionThrown.ShouldBeTrue();

            ToTestAfter?.Invoke();
        }

        #endregion

        #region Remove Comments

        public static IEnumerable<TestCaseData> TestCasesForRemoveCommentsTests
        {
            get
            {
                yield return new TestCaseData("// simple line comment").SetCategory("RemoveComments").Returns(" ");
                yield return new TestCaseData("/* simple block comment */").SetCategory("RemoveComments").Returns(" ");
                yield return new TestCaseData("/* multi line\r\nblock comment */").SetCategory("RemoveComments").Returns("\r\n");
                yield return new TestCaseData("/* multi line\rblock comment */").SetCategory("RemoveComments").Returns("\r");
                yield return new TestCaseData("/* multi line\nblock comment */").SetCategory("RemoveComments").Returns("\n");
                yield return new TestCaseData(@"a = ""apple""; // test").SetCategory("RemoveComments").Returns(@"a = ""apple"";  ");
                yield return new TestCaseData(@"a = ""apple""; /* test */").SetCategory("RemoveComments").Returns(@"a = ""apple"";  ");
                yield return new TestCaseData("// /*comment within comments */").SetCategory("RemoveComments").Returns(" ");
                yield return new TestCaseData("/* //comment within comments */").SetCategory("RemoveComments").Returns(" ");
                yield return new TestCaseData("// bla bla /*comment within comments */  bla bla").SetCategory("RemoveComments").Returns(" ");
                yield return new TestCaseData("/* bla bla //comment within comments */").SetCategory("RemoveComments").Returns(" ");
                yield return new TestCaseData(@"// ""bla bla"" ").SetCategory("RemoveComments").Returns(" ");
                yield return new TestCaseData(@"/* ""bla bla"" */").SetCategory("RemoveComments").Returns(" ");
                yield return new TestCaseData(@"""// test """).SetCategory("RemoveComments").SetCategory("Not a comments").Returns(@"""// test """);
                yield return new TestCaseData(@"""/* test */""").SetCategory("RemoveComments").SetCategory("Not a comments").Returns(@"""/* test */""");
                yield return new TestCaseData(@"""bla bla // test """).SetCategory("RemoveComments").SetCategory("Not a comments").Returns(@"""bla bla // test """);
                yield return new TestCaseData(@"""bla bla /* test */ bla bla""").SetCategory("RemoveComments").SetCategory("Not a comments").Returns(@"""bla bla /* test */ bla bla""");
            }
        }

        [TestCaseSource(nameof(TestCasesForRemoveCommentsTests))]
        public string RemoveCommentsTests(string script)
        {
            ExpressionEvaluator evaluator = new ExpressionEvaluator();

            return evaluator.RemoveComments(script);
        }

        #endregion
    }
}
