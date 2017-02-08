//David Gipe    
//CIS237
//Assignment 2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        /// <summary>
        /// Class level memeber variable for the mazesolver class
        /// </summary>
        char[,] maze;
        int xStart;
        int yStart;
        bool fin;

        /// <summary>
        /// Default Constuctor to setup a new maze solver.
        /// </summary>
        public MazeSolver()
        {}


        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            //Assign passed in variables to the class level ones. It was not done in the constuctor so that
            //a new maze could be passed in to this solve method without having to create a new instance.
            //The variables are assigned so they can be used anywhere they are needed within this class. 
            this.maze = maze;
            this.xStart = xStart;
            this.yStart = yStart;

            //Maze not complete
            fin = false;
            //Start at
            this.maze[1, 1] = 'X';

            Console.WriteLine("Current state of the Maze:");
            Console.WriteLine();
            Print(this.maze);
            Console.WriteLine("Press any key to solve.");

            Console.ReadKey();

            mazeTraversal(this.maze, this.xStart, this.yStart);
            Console.WriteLine("Complete! Solved maze is below. Press any key to continue.");
            Console.WriteLine();
            Console.WriteLine("***************");
            Console.WriteLine();
            Print(maze);
            Console.WriteLine();
            Console.WriteLine("***************");
            Console.WriteLine();
            Console.ReadKey();

        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// </summary>
        private void mazeTraversal(char[,] maze, int xPos, int yPos)
        {
            
            //Set and check if it has reached any of the limits
            if (xPos == 0 | yPos == 0 | yPos == 11 | xPos == 11)
            {
                maze[xPos, yPos] = 'X';
                fin = true;
                return;
            }
            //Check left (-X)
            if (maze[xPos - 1, yPos] == '.' & !fin)
            {
                maze[xPos - 1, yPos] = 'X';
                Print(maze);
                mazeTraversal(maze, xPos - 1, yPos);
            }

            //Check Right (+X)
            if (maze[xPos + 1, yPos] == '.' & !fin)
            {
                maze[xPos + 1, yPos] = 'X';
                Print(maze);
                mazeTraversal(maze, xPos + 1, yPos);
            }

            //Check Up (-Y (Because Y goes up as you go down. This one threw me for a bit)
            if (maze[xPos, yPos - 1] == '.' & !fin)
            {
                maze[xPos, yPos - 1] = 'X';
                Print(maze);
                mazeTraversal(maze, xPos, yPos - 1);
            }
           
            //Check Down (+Y)
            if (maze[xPos, yPos + 1] == '.' & !fin)
            {
                maze[xPos, yPos + 1] = 'X';
                Print(maze);
                mazeTraversal(maze, xPos, yPos + 1);
            }
            //Reaches a deadend         
            if (!fin)
            {
                maze[xPos, yPos] = 'O';
                Print(maze);
            }
        }


        //Print the current state
        private void Print(char[,] maze)
        {
            for (int i = 0; i <= 11; i++)
            {
                for (int j = 0; j <= 11; j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
