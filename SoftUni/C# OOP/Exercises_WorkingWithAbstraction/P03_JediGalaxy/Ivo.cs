namespace P03_JediGalaxy
{
    public class Ivo
    {
        public Ivo(int xCoord, int yCoord)
        {
            XCoord = xCoord;
            YCoord = yCoord;
        }

        public int XCoord { get; set; }
        public int YCoord { get; set; }
    
        public long Move(int[,] matrix)
        {
            var sum = 0;
            while (this.XCoord >= 0 && this.YCoord < matrix.GetLength(1))
            {
                if (this.XCoord >= 0 && this.XCoord < matrix.GetLength(0) && this.YCoord >= 0 && this.YCoord < matrix.GetLength(1))
                {
                    sum += matrix[this.XCoord, this.YCoord];
                }

                this.YCoord++;
                this.XCoord--;
            }

            return sum;
        }
    }
}