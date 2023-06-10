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

            while (true)
            {
                Console.WriteLine("Give 6 commands to the robot. Possible commands are: ");

                Console.WriteLine("On");
                Console.WriteLine("Off");
                Console.WriteLine("North");
                Console.WriteLine("South");
                Console.WriteLine("East");
                Console.WriteLine("West");
                Console.WriteLine("Jump");

                string input = Console.ReadLine().Trim().ToUpper();

                if (input == "EXIT")
                    break;

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
                    default:
                        Console.WriteLine("Invalid command - Please try again.");
                        continue;
                }

                commands.Add(command);
                robot.LoadCommand(command);
                robot.Run();
                Console.WriteLine($"Robot State: Power: {robot.IsPowered}, Position: ({robot.X}, {robot.Y})");
                Console.WriteLine();
            }

            Console.WriteLine("Input Commands:");
            for (int i = 0; i < commands.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {commands[i].GetType().Name}");
            }
        }
    }
}