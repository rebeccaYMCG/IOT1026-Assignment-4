using Assignment;
using Assignment.InterfaceCommand;

namespace AssignmentTest
{
    [TestClass]
    public class AssignmentTests
    {
        [TestMethod]
        public void PropertiesTest()
        {
            Robot robot1 = new();
            Assert.AreEqual(robot1.NumCommands, 6);
            const int ExpectedCommands = 10;
            Robot robot2 = new(ExpectedCommands);
            Assert.AreEqual(robot2.NumCommands, ExpectedCommands);

            Assert.AreEqual(robot1.IsPowered, false);
            robot1.IsPowered = true;
            Assert.AreEqual(robot1.IsPowered, true);

            Assert.AreEqual(robot1.X, 0);
            robot1.X = -5;
            Assert.AreEqual(robot1.X, -5);

            Assert.AreEqual(robot1.Y, 0);
            robot1.Y = -5;
            Assert.AreEqual(robot1.Y, -5);
        }

        [TestMethod]
        public void OnCommandTest()
        {
            Robot testRobot = new();
            Assert.AreEqual(testRobot.IsPowered, false);
            testRobot.LoadCommand(new OnCommand());
            testRobot.Run();
            Assert.AreEqual(testRobot.IsPowered, true);
            testRobot.Run();
            Assert.AreEqual(testRobot.IsPowered, true);
        }

        [TestMethod]
        public void OffCommandTest()
        {
            Robot testRobot = new();
            Assert.AreEqual(testRobot.IsPowered, false);
            testRobot.IsPowered = true;
            testRobot.LoadCommand(new OffCommand());
            testRobot.Run();
            Assert.AreEqual(testRobot.IsPowered, false);
            testRobot.Run();
            Assert.AreEqual(testRobot.IsPowered, false);
        }

        [TestMethod]
        public void MoveNorthTestCommand()
        {
            Robot testRobot = new();
            Assert.AreEqual(testRobot.Y, 0);
            testRobot.LoadCommand(new NorthCommand());
            testRobot.Run();
            Assert.AreEqual(testRobot.Y, 0);
            testRobot.IsPowered = true;
            testRobot.Run();
            Assert.AreEqual(testRobot.Y, 1);
            testRobot.Run();
            Assert.AreEqual(testRobot.Y, 2);
        }

        [TestMethod]
        public void MoveSouthTestCommand()
        {
            Robot testRobot = new();
            Assert.AreEqual(testRobot.Y, 0);
            testRobot.LoadCommand(new SouthCommand());
            testRobot.Run();
            Assert.AreEqual(testRobot.Y, 0);
            testRobot.IsPowered = true;
            testRobot.Run();
            Assert.AreEqual(testRobot.Y, -1);
            testRobot.Run();
            Assert.AreEqual(testRobot.Y, -2);
        }

        [TestMethod]
        public void MoveEastTestCommand()
        {
            Robot testRobot = new();
            Assert.AreEqual(testRobot.X, 0);
            testRobot.LoadCommand(new EastCommand());
            testRobot.Run();
            Assert.AreEqual(testRobot.X, 0);
            testRobot.IsPowered = true;
            testRobot.Run();
            Assert.AreEqual(testRobot.X, 1);
            testRobot.Run();
            Assert.AreEqual(testRobot.X, 2);
        }

        [TestMethod]
        public void MoveWestTestCommand()
        {
            Robot testRobot = new();
            Assert.AreEqual(testRobot.X, 0);
            testRobot.LoadCommand(new WestCommand());
            testRobot.Run();
            Assert.AreEqual(testRobot.X, 0);
            testRobot.IsPowered = true;
            testRobot.Run();
            Assert.AreEqual(testRobot.X, -1);
            testRobot.Run();
            Assert.AreEqual(testRobot.X, -2);
        }

        [TestMethod]
        public void JumpCommandTest()
        {
            Robot testRobot = new();
            Assert.AreEqual(testRobot.Y, 0);
            testRobot.LoadCommand(new JumpCommand());
            testRobot.Run();
            Assert.AreEqual(testRobot.Y, 0);
            testRobot.IsPowered = true;
            testRobot.Run();
            Assert.AreEqual(testRobot.Y, 2);
            testRobot.Run();
            Assert.AreEqual(testRobot.Y, 4);
        }
    }
}
