﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Runtime.CompilerServices;
using System.IO.Enumeration;

namespace ConsoleGUI
{
    public static class TextfilesIO
    {
        public static string TextfilesPath { get; } = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Textfiles\\";

        public static void SaveListOfInt(List<int> ints, string fileName = "Save.csv")
        {
            File.AppendAllText(TextfilesPath + fileName, string.Join(',', ints));
        }
        public static void SaveListOfPoint(List<(int X, int Y)> points, string fileName)
            {
            int length = points.Count;
            string pair;
            var pairs = new List<string>();
            for (int i = 0; i < length; i++)
            {
                pair = $"{points[i].X}, {points[i].Y}";
                pairs.Add(pair);
                
            }
            File.AppendAllText(TextfilesPath + fileName, string.Join(' ', pairs.ToArray()));
        }
        public static void SaveString(string line, string fileName = "Save.csv")
        {
            var lines = new List<string> { line };
            File.AppendAllLines(TextfilesPath + fileName, lines);

        }
        public static void SaveString(List<string> lines, string fileName = "Save.csv")
        {
            File.AppendAllLines(TextfilesPath + fileName, lines);
        }
        public static List<int> ImportIntCSV(string fileName = "Data.csv")
        {
            string text = File.ReadAllText(TextfilesPath + fileName).Trim();
            var lines = text.Split(',', '\n');

            var ints = Array.ConvertAll(lines, int.Parse);
            var list = ints.ToList();
            return list;
        }
        public static void ExportStringList(string fileName, List<string> list)
        {
            File.WriteAllLines(TextfilesPath + fileName, list);
        }
        public static List<string> ImportStringList(string fileName)
        {
            return File.ReadAllLines(TextfilesPath + fileName).ToList();
        }

        public static void Clear(string fileName = "Data.csv")
        {
            File.WriteAllText(TextfilesPath + fileName, "");
        }

        public static List<List<string>> ImportBransches(string fileName)
        {
            var topList = new List<List<string>>();
            try
            {
                foreach (var inputLines in File.ReadAllLines(TextfilesPath + fileName).ToList())
                {
                    var newBransch = new List<string>(inputLines.Split(','));
                    topList.Add(newBransch);
                }
            }
            catch (Exception)
            {
                topList = null;
            }

            return topList;
        }
    }
}
