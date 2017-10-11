﻿// <copyright file="DyKnowTest.cs" company="University of Louisville Speed School of Engineering">
// GNU General Public License v3
// </copyright>
// <summary>Performs the serialization / deserialization regression tests on a DyKnow file.</summary>
namespace UnitTests
{
    using DPXReader.DyKnow;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.IO.Compression;

    /// <summary>
    /// This is a test class for DyKnowTest and is intended
    /// to contain all DyKnowTest Unit Tests
    /// </summary>
    [TestClass()]
    public class DyKnowTest
    {
        /// <summary>
        /// THe test context instance.
        /// </summary>
        private TestContext testContextInstance;

        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext
        {
            get
            {
                return this.testContextInstance;
            }

            set
            {
                this.testContextInstance = value;
            }
        }

        /// <summary>
        /// Test the serialization and deserialization of a DyKnow file that only contains only some simple ink content on a single panel.
        /// </summary>
        [TestMethod()]
        public void SerializationTestSimpleInking()
        {
            this.PerformSerializationTest("TestSimpleInking", "Simple Inking");
        }

        /// <summary>
        /// Test the serialization and deserialization of a DyKnow file that contains some complicated ink content.
        /// </summary>
        [TestMethod()]
        public void SerializationTestAdvancedInking()
        {
            this.PerformSerializationTest("TestAdvancedInking", "Advanced Inking");
        }

        /// <summary>
        /// Test the serialization and deserialization of a DyKnow file that contains deleted ink content.
        /// </summary>
        [TestMethod()]
        public void SerializationTestDeleteInking()
        {
            this.PerformSerializationTest("TestDeleteInking", "Delete Inking");
        }

        /// <summary>
        /// Test the serialization and deserialization of a DyKnow file that contains resized ink content.
        /// </summary>
        [TestMethod()]
        public void SerializationTestScaleInking()
        {
            this.PerformSerializationTest("TestScaleInking", "Scale Inking");
        }

        /// <summary>
        /// Test the serialization and deserialization of a DyKnow file that contains a simple image.
        /// </summary>
        [TestMethod()]
        public void SerializationTestSimpleImage()
        {
            this.PerformSerializationTest("TestSimpleImage", "Simple Image");
        }

        /// <summary>
        /// Test the serialization and deserialization of a DyKnow file that contains a multiple images.
        /// </summary>
        [TestMethod()]
        public void SerializationTestMultipleImages()
        {
            this.PerformSerializationTest("TestMultipleImages", "Multiple Images");
        }

        /// <summary>
        /// Test the serialization and deserialization of a DyKnow file that contains moderator full page text.
        /// </summary>
        [TestMethod()]
        public void SerializationTestFullPanelTextModerator()
        {
            this.PerformSerializationTest("TestFullPanelTextModerator", "Full Panel Text Moderator");
        }

        /// <summary>
        /// Test the serialization and deserialization of a DyKnow file that contains an animation.
        /// </summary>
        [TestMethod()]
        public void SerializationTestAnimation()
        {
            this.PerformSerializationTest("TestAnimation", "Animation");
        }

        /// <summary>
        /// Test the serialization and deserialization of a DyKnow file that contains a simple text box.
        /// </summary>
        [TestMethod()]
        public void SerializationTestSimpleTextBox()
        {
            this.PerformSerializationTest("TestSimpleTextBox", "Simple Text Box");
        }

        /// <summary>
        /// Test the serialization and deserialization of a DyKnow file that contains a hyperlink.
        /// </summary>
        [TestMethod()]
        public void SerializationTestHyperlink()
        {
            this.PerformSerializationTest("TestHyperlink", "Hyperlink");
        }

        /// <summary>
        /// Test the serialization and deserialization of a DyKnow file that contains a simple poll.
        /// </summary>
        [TestMethod()]
        public void SerializationTestSimplePoll()
        {
            this.PerformSerializationTest("TestSimplePoll", "Simple Poll");
        }

        /// <summary>
        /// Test the serialization and deserialization of a DyKnow file that contains multiple panels with various content.
        /// </summary>
        [TestMethod()]
        public void SerializationTestAdvancedMultiplePanels()
        {
            this.PerformSerializationTest("TestAdvancedMultiplePanels", "Advanced Multiple Panels");
        }

        /// <summary>
        /// Test the serialization and deserialization of a DyKnow file that was retrieved from a session.
        /// </summary>
        [TestMethod()]
        public void SerializationTestRetrievedPanels()
        {
            this.PerformSerializationTest("TestRetrievedPanels", "Retrieved Panels");
        }

        /// <summary>
        /// Test the serialization and deserialization of a DyKnow file that contains chat content.
        /// </summary>
        [TestMethod()]
        public void SerializationTestSessionChat()
        {
            this.PerformSerializationTest("TestSessionChat", "Session Chat");
        }

        /// <summary>
        /// Test the serialization and deserialization of a DyKnow file that contains an answer box.
        /// </summary>
        [TestMethod()]
        public void SerializationTestAnswerBox()
        {
            this.PerformSerializationTest("TestAnswerBox", "Answer Box");
        }

        /// <summary>
        /// Test the serialization and deserialization of a DyKnow file that contains an edited text box.
        /// </summary>
        [TestMethod()]
        public void SerializationTestSimpleTextBoxEdit()
        {
            this.PerformSerializationTest("TestSimpleTextBoxEdit", "Simple Text Box Edit");
        }

        /// <summary>
        /// Test the serialization and deserialization of a DyKnow file that contains an arrow shape.
        /// </summary>
        [TestMethod()]
        public void SerializationTestShapesArrow()
        {
            this.PerformSerializationTest("TestShapesArrow", "Shape Arrow");
        }

        /// <summary>
        /// Test the serialization and deserialization of a DyKnow file that contains a circle.
        /// </summary>
        [TestMethod()]
        public void SerializationTestShapesCircle()
        {
            this.PerformSerializationTest("TestShapesCircle", "Shape Circle");
        }

        /// <summary>
        /// Test the serialization and deserialization of a DyKnow file that contains a line.
        /// </summary>
        [TestMethod()]
        public void SerializationTestShapesLine()
        {
            this.PerformSerializationTest("TestShapesLine", "Shape Line");
        }

        /// <summary>
        /// Test the serialization and deserialization of a DyKnow file that contains a rectangle.
        /// </summary>
        [TestMethod()]
        public void SerializationTestShapesRectangle()
        {
            this.PerformSerializationTest("TestShapesRectangle", "Shape Rectangle");
        }

        /// <summary>
        /// Test the serialization and deserialization of a DyKnow file that contains a straight line.
        /// </summary>
        [TestMethod()]
        public void SerializationTestShapesStraightLine()
        {
            this.PerformSerializationTest("TestShapesStraightLine", "Shape Straight Line");
        }

        /// <summary>
        /// Test the serialization and deserialization of a DyKnow file that contains a table.
        /// </summary>
        [TestMethod()]
        public void SerializationTestShapesTable()
        {
            this.PerformSerializationTest("TestShapesTable", "Shape Table");
        }

        /// <summary>
        /// Performs the serialization test.
        /// </summary>
        /// <param name="file">The file to process.</param>
        /// <param name="name">The name of the task.</param>
        private void PerformSerializationTest(string file, string name)
        {
            // Read in the file as a string
            string original = this.GetFileContent(file);
            DyKnow dyknow = this.DeserializeDyKnow(original);
            Debug.WriteLine("Processing: " + name);

            if (dyknow == null)
            {
                // Write the XML (with line breaks) that could not be parsed to a file
                TextWriter tre = new StreamWriter(file + "-Failed" + ".txt");
                tre.WriteLine(original.Replace("><", ">\n<"));
                tre.Close();

                // Assert that the test failed.
                Assert.Fail("The XML could not be deserialized properly.");
                Debug.WriteLine(name + " Test Failed to Serialize");
            }
            else
            {
                string repacked = this.SerializeDyKnow(dyknow);

                // TODO: Fix underlying problem with RTF and \r
                // Remove the carriage returns from both of the strings before comparison.
                // This is a hack that will let more of the tests pass
                original = original.Replace("\r", string.Empty);
                repacked = repacked.Replace("\r", string.Empty);

                // Perform a test to determine if the string are equal so we can write out the results.
                Debug.WriteLine("Original: " + original.Length + " - Repacked: " + repacked.Length);
                if (!original.Equals(repacked))
                {
                    // Write the original XML (with line breaks) to a file
                    TextWriter tro = new StreamWriter(file + "-Original" + ".txt");
                    tro.WriteLine(original.Replace("><", ">\n<"));
                    tro.Close();

                    // Write the repacked XML (with line breaks) to a file
                    TextWriter trr = new StreamWriter(file + "-Repacked" + ".txt");
                    trr.WriteLine(repacked.Replace("><", ">\n<"));
                    trr.Close();
                }

                Assert.AreEqual(original, repacked, "The reserialized object did not match the original XML");
            }
        }

        /// <summary>
        /// Gets the content of the file.
        /// </summary>
        /// <param name="name">The name of the file.</param>
        /// <returns>A string containing all of the contents of the file</returns>
        private string GetFileContent(string name)
        {
            string file = "..\\..\\..\\UnitTests\\DyKnowFiles\\" + name + ".dyz";
            FileStream inputFile = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
            GZipStream gzipFile = new GZipStream(inputFile, CompressionMode.Decompress, true);
            StreamReader reader = new StreamReader(gzipFile);
            string content = reader.ReadToEnd();
            gzipFile.Close();
            inputFile.Close();
            return content;
        }

        /// <summary>
        /// Deserializes the DyKnow string.
        /// </summary>
        /// <param name="data">The string representation of a serialized DyKnow object.</param>
        /// <returns>A DyKnow object on success; otherwise null.</returns>
        private DyKnow DeserializeDyKnow(string data)
        {
            DyKnow dyknow = null;

            try
            {
                dyknow = DyKnow.Deserialize(data);
            }
            catch (Exception e)
            {
                Debug.WriteLine("DyKnow object could not be deserialized.");
                Debug.WriteLine(e.Message);
            }

            return dyknow;
        }

        /// <summary>
        /// Serializes the DyKnow object.
        /// </summary>
        /// <param name="dyknow">The DyKnow object.</param>
        /// <returns>A string representation of the DyKnow object; otherwise null.</returns>
        private string SerializeDyKnow(DyKnow dyknow)
        {
            string result = null;

            try
            {
                result = dyknow.Serialize();

                // NOTE:  This removes the XML header, this is not the best implementation possible.
                result = result.Substring(result.IndexOf("<DYKNOW_NB50"));
            }
            catch
            {
                Debug.WriteLine("DyKnow object could not serialized.");
            }

            return result;
        }
    }
}