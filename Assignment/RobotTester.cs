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

            Console.WriteLine("Give 6 commands to the robot. Possible commands are: ");
            Console.WriteLine("on");
            Console.WriteLine("off");
            Console.WriteLine("north");
            Console.WriteLine("south");
            Console.WriteLine("east");
            Console.WriteLine("west");
            Console.WriteLine("jump");

            for (int i = 0; i < 6; i++)
            {
                Console.Write($"Assign command #{i + 1}: ");
                string input = Console.ReadLine() ?? string.Empty;

                RobotCommand command;
                switch (input)
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
                        i--;
                        continue;
                }

                 commands.Add(command);
            }

            Console.WriteLine();

            foreach (RobotCommand command in commands)
            {
                robot.LoadCommand(command);
            }

            robot.Run();
        }
    }
}