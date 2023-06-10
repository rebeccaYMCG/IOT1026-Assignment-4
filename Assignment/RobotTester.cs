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
                Console.Write($"Assign command #{i + 1}: ");
                string input = Console.ReadLine();

                RobotCommand newCommand;
                switch (input.Trim().ToLower())
                {
                    case "on":
                        newCommand = new OnCommand();
                        break;
                    case "off":
                        newCommand = new OffCommand();
                        break;
                    case "north":
                        newCommand = new NorthCommand();
                        break;
                    case "south":
                        newCommand = new SouthCommand();
                        break;
                    case "east":
                        newCommand = new EastCommand();
                        break;
                    case "west":
                        newCommand = new WestCommand();
                        break;
                    case "jump":
                        newCommand = new JumpCommand();
                        break;
                    default:
                        Console.WriteLine("Invalid command - Please try again.");
                        i--; // Decrement i to repeat the current iteration
                        continue;
                }

                commands.Add(newCommand);
                robot.LoadCommand(newCommand);
                robot.Run();
            }
            
            Console.WriteLine("Input Commands:");
            for (int i = 0; i < commands.Count; i++)
            {
                Console.WriteLine($"Assign command {i + 1}: {commands[i].GetType().Name}");
            }

            Console.WriteLine(robot);
        }
    }
}