using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _04_Froggy
{
    public class Lake : IEnumerable<int>
    {
        private int[] stones;

        public Lake(int[] elements)
        {
            this.stones = elements;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 1; i <= this.stones.Length; i++)
            {
                if (i % 2 != 0)
                {
                    yield return this.stones[i - 1];
                }
            }

            for (int i = this.stones.Length; i >= 1 ; i--)
            {
                if (i % 2 == 0)
                {
                    yield return this.stones[i - 1];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

}
