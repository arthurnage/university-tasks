﻿using System;
using System.IO;
using System.Collections.Generic;

namespace MyWorks
{
    /// <summary>
    /// Class that reads data from the txt file and makes all the calculation of the programm
    /// </summary>
    public class RobotMaker
    {
        public int RobotsNumber { get; }
        public Robot[] Robots { get; }
        public int[,] Matrix { get; }
        public bool SequenceExists { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileName">File name.</param>
        public RobotMaker(string fileName)
        {
            try
            {
                using (StreamReader file = new StreamReader(fileName))
                {
                    int nodeNumber = 0;
                    String line = file.ReadToEnd();
                    String[] substrings = line.Split(' ', '\n');
                    int stringIndex = 0;
                    nodeNumber = int.Parse(substrings[stringIndex++]);
                    RobotsNumber = int.Parse(substrings[stringIndex++]);
                    Matrix = new int[nodeNumber, nodeNumber];
                    Robots = new Robot[RobotsNumber];
                    for (int i = 0; i < RobotsNumber; ++i)
                    {
                        Robots[i] = new Robot(int.Parse(substrings[stringIndex++]), Matrix);
                    }
                    for (int i = 0; i < nodeNumber; ++i)
                    {
                        for (int j = 0; j < nodeNumber; ++j)
                        {
                            Matrix[i, j] = int.Parse(substrings[stringIndex++]);
                        }
                    }
                    file.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read: ");
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Returns true if all the robots can be destroyed on matrix
        /// </summary>
        public void CheckMatrix()
        {
            // subgraph of way creates for each robot
            foreach (Robot robot in Robots)
            {
                robot.setGraph();
            }
            // compare number of robots and their subgraphs of ways
            var usedRobots = new List<int>();
            int index = 0;
            if (RobotsNumber == 1)
            {
                SequenceExists = false;
            }
            else
            {
                for (int i = 0; i < RobotsNumber; ++i)
                {
                    index = 0;
                    if (usedRobots.Contains(i))
                    {
                        continue;
                    }
                    for (int j = i + 1; j < RobotsNumber; ++j)
                    {
                        if (!usedRobots.Contains(j))
                        {
                            if (new HashSet<int>(Robots[i].graph).SetEquals(Robots[j].graph))
                            {
                                index++;
                                usedRobots.Add(j);
                                continue;
                            }
                        }
                    }
                    if (index == 0)
                    {
                        SequenceExists = false;
                        return;
                    }
                }
                SequenceExists = true;
            }
        }
    }
}