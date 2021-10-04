namespace HexBlock
{
    class Spot
    {
        private bool color;
        private bool empty;
        private int x;
        private int y;

        public bool GetColor()
        {
            return this.color;
        }
        public bool IsEmpty()
        {
            return this.empty;
        }


        public (int, int) GetCoo()
        {
            return (this.x,this.y);
        }
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }

        public void Color(bool player)
        {
            this.empty = false;
            this.color = player;
        }
        public Spot(int x, int y)
        {
            this.empty = true;
            this.color = true;
            this.x = x;
            this.y = y;
        }

    }
}
