namespace ExcapeRoom
{
    public class Player
    {
        private ushort PlayerPositionX;
        private ushort PlayerPositionY;

        Player(ushort _xPos, ushort _yPos)
        {
            this.PlayerPositionX = _xPos;
            this.PlayerPositionY = _yPos;
        }
    }
}