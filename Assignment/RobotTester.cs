using System;
using Assignment;
using Assignment.InterfaceCommand;

namespace RobotTester
{
    public static class RobotTester
    {
        public static void Run()
        {
            Robot robot = new();
            List<RobotCommand> commands = new();

            Console.WriteLine("Give 6 commands to the robot. Possible commands are:");

            Console.WriteLine("on");
            Console.WriteLine("off");
            Console.WriteLine("north");
            Console.WriteLine("south");
            Console.WriteLine("east");
            Console.WriteLine("west");
            Console.WriteLine("jump");

            int numCommands = 6;

            for (int i = 0; i < numCommands; i++)
            {
                Console.Write($"Assign Command #{i + 1}: ");
                string input = Console.ReadLine();

                RobotCommand command;
                switch (input.Trim().ToLower())
                {
                    case "on":
                        command = new OnCommand();
                        break;
                    case "off":
                        command = new OffCommand();
                        break;
                    case "north":
                        command = new NorthCommand();
                        break;
                    case "south":
                        command = new SouthCommand();
                        break;
                    case "east":
                        command = new EastCommand();
                        break;
                    case "west":
                        command = new WestCommand();
                        break;
                    case "jump":
                        command = new JumpCommand();
                        break;
                    default:
                        Console.WriteLine("Invalid command - Please try again.");
                        i--; // Decrement i to repeat the current iteration
                        continue;
                }

                commands.Add(command);

                // Execute the commands and display the results
                foreach (RobotCommand numcommand in commands)
                {
                    robot.LoadCommand(command);
                    robot.Run();
                    Console.WriteLine();
                }
            }
        }
    }
}