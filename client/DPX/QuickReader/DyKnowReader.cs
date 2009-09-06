﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO.Compression;
using System.IO;

namespace QuickReader
{
    public class DyKnowReader
    {
        private FileStream inputFile;
        private GZipStream gzipFile;
        private XmlTextReader xmlFile;
        private String fileName;
        private List<DyKnowPage> dyKnowPages;

        private double meanStrokes;
        private double stdDevStrokes;

        public DyKnowReader(string name)
        {
            //The name of the DyKnow file used
            fileName = name;
            //Open the file
            inputFile = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            //Uncompress the file
            gzipFile = new GZipStream(inputFile, CompressionMode.Decompress, true);
            //Read the uncompressed file as XML
            xmlFile = new XmlTextReader(gzipFile);
            //The collection of pages
            dyKnowPages = new List<DyKnowPage>();
            //Some more default values
            meanStrokes = 0;
            stdDevStrokes = 0;

            int myRow = 1;
            //Loop through the XML information
            while (xmlFile.Read())
            {
                if (xmlFile.NodeType == XmlNodeType.Element)
                {
                    //We only care about the PAGE nodes
                    if (xmlFile.Name.ToString() == "PAGE")
                    {

                        //Process the PAGE sub-tree and store the inforation
                        DyKnowPage panel = new DyKnowPage(xmlFile.ReadSubtree(), myRow++);
                        
                        //Add the page information to the list of pages
                        dyKnowPages.Add(panel);
                    }
                }
            }

            meanStrokes = CalcMeanStrokes();
            stdDevStrokes = CalcStdDevStrokes(meanStrokes);
            fillInFinished();
        }

        private void fillInFinished()
        {
            for (int i = 0; i < NumOfPages(); i++)
            {
                if (dyKnowPages[i].getStrokeCount() == 0)
                {
                    dyKnowPages[i].setFinished("No");
                }
                else if (dyKnowPages[i].getStrokeCount() < (meanStrokes - (2 * stdDevStrokes)))
                {
                    dyKnowPages[i].setFinished("Maybe");
                }
                else
                {
                    dyKnowPages[i].setFinished("Yes");
                }
            }
        }

        private double CalcMeanStrokes()
        {
            long total = 0;
            for (int i = 0; i < NumOfPages(); i++)
            {
                total += dyKnowPages[i].getStrokeCount();
            }
            return (double)total / (double)NumOfPages();
        }

        private double CalcStdDevStrokes(double mean)
        {
            double total = 0;
            for (int i = 0; i < NumOfPages(); i++)
            {
                total += Math.Pow((dyKnowPages[i].getStrokeCount() - mean), 2);
            }
            return Math.Sqrt((double)total / (double)(NumOfPages() - 1));
        }

        public double GetMeanStrokes()
        {
            return meanStrokes;
        }

        public double GetStdDevStrokes()
        {
            return stdDevStrokes;
        }

        public void Close()
        {
            inputFile.Close();
            gzipFile.Close();
            xmlFile.Close();
        }

        public DyKnowPage getDyKnowPage(int i)
        {
            return dyKnowPages[i];
        }

        //Used in testing
        public String GetPageString(int i)
        {
            return dyKnowPages[i].ToString();
        }


        public object[] GetRowData(int i)
        {
            return dyKnowPages[i].getRowData();
        }


        public int NumOfPages()
        {
            return dyKnowPages.Count;
        }



    }
}