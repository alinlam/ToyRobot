namespace ToyRobot
{
    public class InputCommand
    {
        public ActionEnum Action { get; private set; }

        public int? X { get; private set; }

        public int? Y { get; private set; }

        public DirectionEnum? Direction { get; private set; }

        public Position? Position { get; private set; }

        public bool IsValid
        {
            get
            {
                if (this.Action == ActionEnum.NOACTION)
                {
                    return false;
                }

                // Place command must have parameters X,Y (optional for Direction)
                if (this.Action == ActionEnum.PLACE
                    && (!this.X.HasValue || !this.Y.HasValue))
                {
                    return false;
                }

                return true;
            }
        }

        public bool IsReportOut => this.Action == ActionEnum.REPORT;

        public string InputString { get; private set; }

        // This seperator could be extend and make it configurable
        private const string INPUTSEPERATOR = " ";
        private const string PARAMETERSEPERATOR = ",";

        public InputCommand(string inputString)
        {
            this.InputString = inputString;

            // Cannot initialise the input command
            if (string.IsNullOrEmpty(inputString))
            {
                return;
            }

            var splitStrings = inputString.Split(INPUTSEPERATOR, StringSplitOptions.RemoveEmptyEntries);
            if (splitStrings != null && splitStrings.Any())
            {
                switch (splitStrings[0].ToLower())
                {
                    case "move":
                        this.Action = ActionEnum.MOVE;
                        break;

                    case "left":
                        this.Action = ActionEnum.LEFT;
                        break;

                    case "right":
                        this.Action = ActionEnum.RIGHT;
                        break;

                    case "report":
                        this.Action = ActionEnum.REPORT;
                        break;

                    case "place":
                        this.Action = ActionEnum.PLACE;
                        if (splitStrings.Length == 2)
                        {
                            this.ExtractPosition(splitStrings[1]);
                        }
                        break;

                    case "exit":
                        this.Action = ActionEnum.EXIT;
                        break;

                    case "example":
                        this.Action = ActionEnum.EXAMPLE;
                        break;

                    default:
                        this.Action = ActionEnum.NOACTION;
                        break;
                }
            }
        }

        private void ExtractPosition(string inputString)
        {
            // Cannot initialise the Position
            if (string.IsNullOrEmpty(inputString))
            {
                return;
            }

            // The position input string must in pattern of X,Y,Direction
            var splitPlaceStrings = inputString.Split(PARAMETERSEPERATOR, StringSplitOptions.RemoveEmptyEntries);
            if (splitPlaceStrings == null || splitPlaceStrings.Length < 2)
            {
                return;
            }

            if (int.TryParse(splitPlaceStrings[0], out var x)
                && int.TryParse(splitPlaceStrings[1], out var y))
            {
                if (0 <= x && x <= 5
                    && 0 <= y && y <= 5)
                {
                    this.X = x;
                    this.Y = y;

                    var strDirection = string.Empty;
                    if (splitPlaceStrings.Length == 3 && !string.IsNullOrEmpty(splitPlaceStrings[2]))
                    {
                        strDirection = splitPlaceStrings[2].ToLower();
                    }

                    switch (strDirection)
                    {
                        case "north":
                            this.Direction = DirectionEnum.NORTH;
                            return;

                        case "south":
                            this.Direction = DirectionEnum.SOUTH;
                            return;

                        case "west":
                            this.Direction = DirectionEnum.WEST;
                            return;

                        case "east":
                            this.Direction = DirectionEnum.EAST;
                            return;

                        default:
                            this.Direction = DirectionEnum.UNKNOWN;
                            return;
                    }
                }
            }
        }
    }
}
