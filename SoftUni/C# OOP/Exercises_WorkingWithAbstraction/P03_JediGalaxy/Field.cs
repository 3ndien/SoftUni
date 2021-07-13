using System;
using System.Linq;

namespace P03_JediGalaxy
{
    public class Field
    {
        private int[,] matrix;

        public Field(int rowSize, int colSize)
        {
            this.Initialize(rowSize, colSize);
        }

        public Ivo Ivo { get; set; }

        public Evil Evil { get; set; }

        public long Sum { get; private set; }

        private void Initialize(int rowSize, int colSize)
        {
            this.matrix = new int[rowSize, colSize];

            int value = 0;

            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < colSize; col++)
                {
                    matrix[row, col] = value++;
                }
            }
        }

        public void Start(string command)
        {
            int[] ivoCoords = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] evilCoords = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int xEvil = evilCoords[0];
            int yEvil = evilCoords[1];
            
            int xIvo = ivoCoords[0];
            int yIvo = ivoCoords[1];

            this.Evil = new Evil(xEvil, yEvil);
            this.Evil.Move(this.matrix);

            this.Ivo = new Ivo(xIvo, yIvo);
            this.Sum += this.Ivo.Move(this.matrix);
        }

    }
}
