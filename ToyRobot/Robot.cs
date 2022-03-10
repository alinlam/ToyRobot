namespace ToyRobot
{
    public class Robot
    {
        public Robot()
        {
            this.Commands = new List<InputCommand>();
        }

        public Position? Posistion { get; private set; }

        // Having the commands list here is handy as history move, and potentialy can extend to make the robot undo the current commands
        public List<InputCommand> Commands { get; private set; }

        public InputCommand Action(string inputCommand, bool? outputCommand = false)
        {
            if (outputCommand.HasValue && outputCommand.Value && !string.IsNullOrEmpty(inputCommand))
            {
                Console.WriteLine($"> {inputCommand.ToUpper()}");
            }

            var command = new InputCommand(inputCommand);
            this.Commands.Add(command);

            // Set new position
            this.SetPosition(command);

            return command;
        }


        public bool SetPosition(InputCommand command)
        {
            if (command == null)
            {
                return false;
            }

            if (!command.IsValid)
            {
                return false;
            }

            switch (command.Action)
            {
                case ActionEnum.PLACE:
                    if (command.IsValid)
                    {
                        var direction = command.Direction.HasValue
                            ? command.Direction.Value
                            : DirectionEnum.UNKNOWN;

                        if (this.Posistion == null)
                        {
                            if (direction != DirectionEnum.UNKNOWN)
                            {
                                this.Posistion = new Position(command.X.Value, command.Y.Value, direction);
                                return true;
                            }
                        }
                        else
                        {
                            this.Posistion.X = command.X.Value;
                            this.Posistion.Y = command.Y.Value;

                            if (direction != DirectionEnum.UNKNOWN)
                            {
                                this.Posistion.Direction = direction;
                            }

                            return true;
                        }
                    }
                    return false;

                case ActionEnum.REPORT:
                    // No position moving is required
                    return true;

                case ActionEnum.EXAMPLE:
                    // No position moving is required
                    return true;

                case ActionEnum.MOVE:
                    if (this.Posistion != null)
                    {
                        return this.Posistion.Move();
                    }
                    return false;

                case ActionEnum.LEFT:
                    if (this.Posistion != null)
                    {
                        this.Posistion.Left();
                        return true;
                    }

                    return false;

                case ActionEnum.RIGHT:
                    if (this.Posistion != null)
                    {
                        this.Posistion.Right();
                        return true;
                    }

                    return false;

                default:
                    return false;
            }
        }
    }
}
