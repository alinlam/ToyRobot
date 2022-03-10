namespace ToyRobot
{
    public class Position
    {
        public int X { get; set; }

        public int Y { get; set; }

        public DirectionEnum Direction { get; set; }

        public string Output => $"Output: {this.X},{this.Y},{this.Direction.ToString().ToUpper()}";

        public Position(int x, int y, DirectionEnum direction)
        {
            this.X = x;
            this.Y = y;
            this.Direction = direction;
        }

        // Requirement only move 1 unit.
        // Anyway, this move function can be extend to take the number of units as parameter
        public bool Move()
        {
            var newX = this.X;
            var newY = this.Y;

            switch (this.Direction)
            {
                case DirectionEnum.WEST:
                    newX = newX - 1;
                    break;

                case DirectionEnum.EAST:
                    newX = newX + 1;
                    break;

                case DirectionEnum.SOUTH:
                    newY = newY - 1;
                    break;

                case DirectionEnum.NORTH:
                    newY = newY + 1;
                    break;
            }

            if (0 <= newX && newX <= 5
                && 0 <= newY && newY <= 5)
            {
                this.X = newX;
                this.Y = newY;
            }

            return false;
        }

        // Turn the direct 90 degree
        public void Left()
        {
            var newDirection = this.Direction;

            switch (this.Direction)
            {
                case DirectionEnum.WEST:
                    newDirection = DirectionEnum.SOUTH;
                    break;

                case DirectionEnum.SOUTH:
                    newDirection = DirectionEnum.EAST;
                    break;

                case DirectionEnum.EAST:
                    newDirection = DirectionEnum.NORTH;
                    break;

                case DirectionEnum.NORTH:
                    newDirection = DirectionEnum.WEST;
                    break;
            }

            this.Direction = newDirection;
        }

        // Turn the direct 90 degree
        public void Right()
        {
            var newDirection = this.Direction;

            switch (this.Direction)
            {
                case DirectionEnum.WEST:
                    newDirection = DirectionEnum.NORTH;
                    break;

                case DirectionEnum.NORTH:
                    newDirection = DirectionEnum.EAST;
                    break;

                case DirectionEnum.EAST:
                    newDirection = DirectionEnum.SOUTH;
                    break;

                case DirectionEnum.SOUTH:
                    newDirection = DirectionEnum.WEST;
                    break;
            }

            this.Direction = newDirection;
        }
    }
}
