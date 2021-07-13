namespace P03_JediGalaxy
{
    public class Evil
    {
        public Evil(int xCoord, int yCoord)
        {
            XCoord = xCoord;
            YCoord = yCoord;
        }

        public int XCoord { get; set; }
        public int YCoord { get; set; }
   
        public void Move(int[,] matrix)
        {
            while (this.XCoord >= 0 && this.YCoord >= 0)
            {
                if (this.XCoord >= 0 && this.XCoord < matrix.GetLength(0) && this.YCoord >= 0 && this.YCoord < matrix.GetLength(1))
                {
                    matrix[this.XCoord, this.YCoord] = 0;
                }
                this.XCoord--;
                this.YCoord--;
            }
        }
    }

}
