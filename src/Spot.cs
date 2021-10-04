namespace HexBlock
{
    class Spot
    {
        private bool red;
        private bool blue;
        private bool empty;
        private int x;
        private int y;

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
            return (this.x,this.y);
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }

        public void Color(bool player)
        {
            this.empty = false;
            this.blue = player;
            this.red = !player;
        }
        public Spot(int x, int y)
        {
            this.empty = true;
            this.red = false;
            this.blue = false;
            this.x = x;
            this.y = y;
        }

    }
}