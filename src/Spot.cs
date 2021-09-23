using System.Collections.Generic;

namespace HexBlock
{
    class Spot
    {
        private bool red;
        private bool blue;
        private bool empty;
        private (int, int) coo;

        public bool isRed()
        {
            return this.red;
        }

        public void setRed(bool red)
        {
            this.red = red;
        }

        public bool isBlue()
        {
            return this.blue;
        }

        public void setBlue(bool blue)
        {
            this.blue = blue;
        }

        public bool isEmpty()
        {
            return this.empty;
        }


        public (int, int) getCoo()
        {
            return this.coo;
        }

        public Spot()
        {
            
        }

    }
}