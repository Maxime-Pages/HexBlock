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

        public bool isBlue()
        {
            return this.blue;
        }


        public bool isEmpty()
        {
            return this.empty;
        }


        public (int, int) getCoo()
        {
            return this.coo;
        }

        public void Color(bool player)
        {
            if (player)
            {

            }
        }

        public Spot()
        {
            this.empty = true;
            this.red = false;
            this.blue = false;
        }

    }
}