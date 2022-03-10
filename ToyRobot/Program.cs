namespace ToyRobot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****** Welcome the Toy Robot application ******");
            Console.WriteLine("- The virtual simulator of a toy robot moving on a 6 x 6 square tabletop, and free to roam around the surface of the table");
            Console.WriteLine("- Following are the commands to move the robot");
            Console.WriteLine("- PLACE: will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST");
            Console.WriteLine("- (0,0) can be considered as the SOUTH WEST corner and (5,5) as the NORTH EAST corner.");
            Console.WriteLine("- The first valid command to the robot is a PLACE command. After that, any sequence of commands may be issued, in any order, including another PLACE command. The library should discard all commands in the sequence until a valid PLACE command has been executed");
            Console.WriteLine("- The PLACE command should be discarded if it places the robot outside of the table surface.");
            Console.WriteLine("- Once the robot is on the table, subsequent PLACE commands could leave out the direction and only provide the coordinates. When this happens, the robot moves to the new coordinates without changing the direction.");
            Console.WriteLine("- The MOVE will move the toy robot one unit forward in the direction it is currently facing.");
            Console.WriteLine("- The LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot.");
            Console.WriteLine("- The REPORT will announce the X,Y and orientation of the robot.");
            Console.WriteLine("- The EXAMPLE will show the examples");
            Console.WriteLine("- The EXIT will exit the application");
            Console.WriteLine("- A robot that is not on the table can choose to ignore the MOVE, LEFT, RIGHT and REPORT commands.");

            // Show example
            ShowExample();


            Console.WriteLine("========= Now, time to do some testing ^_^ ===========");

            var robot = new Robot();

            while (true)
            {
                var inputCommand = Console.ReadLine();
                if (!string.IsNullOrEmpty(inputCommand))
                {
                    var command = robot.Action(inputCommand);

                    if (command.IsValid)
                    {
                        if (command.IsReportOut)
                        {
                            var outputMessage = robot.Posistion != null
                                ? robot.Posistion.Output
                                : "Robot hasn't been placed in a position yet, please place the robot to a position as in the following example (PLACE 1,1,NORTH)";

                            Console.WriteLine(outputMessage);
                        }

                        if (command.Action == ActionEnum.EXAMPLE)
                        {
                            ShowExample();
                        }

                        if (command.Action == ActionEnum.EXIT)
                        {
                            break;
                        }
                    }
                }
            }

            Console.WriteLine("Thank you for testing the Toy Robot, have a nice day!");
            Console.WriteLine("Please press Enter to exit the application");
            Console.ReadKey();
        }

        private static void ShowExample()
        {
            var robot = new Robot();
            Console.WriteLine("1. Example 1 Input:");
            robot.Action("PLACE 0,0,NORTH", true);
            robot.Action("MOVE", true);
            robot.Action("REPORT", true);
            Console.WriteLine(robot.Posistion?.Output);

            Console.WriteLine("2. Example 2 Input");
            robot.Action("PLACE 0,0,NORTH", true);
            robot.Action("LEFT", true);
            robot.Action("REPORT", true);
            Console.WriteLine(robot.Posistion?.Output);

            Console.WriteLine("3. Example 3 Input");
            robot.Action("PLACE 1,2,EAST", true);
            robot.Action("MOVE", true);
            robot.Action("MOVE", true);
            robot.Action("LEFT", true);
            robot.Action("MOVE", true);
            robot.Action("REPORT", true);
            Console.WriteLine(robot.Posistion?.Output);

            Console.WriteLine("4. Example 4 Input");
            robot.Action("PLACE 1,2,EAST", true);
            robot.Action("MOVE", true);
            robot.Action("LEFT", true);
            robot.Action("MOVE", true);
            robot.Action("PLACE 3,1", true);
            robot.Action("MOVE", true);
            robot.Action("REPORT", true);
            Console.WriteLine(robot.Posistion?.Output);
        }
    }
}
