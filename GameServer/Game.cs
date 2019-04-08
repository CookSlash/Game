using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameServer
{
    public class Game
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int BlocSize { get; private set; }
        public List<Point> Blocks { get; private set; }

        private readonly int _size =200;
        private readonly int _numberOfBlocks = 5;
        private readonly int _blocksSize = 10;
        public Game()
        {
            Height = _size;
            Width = _size;
            BlocSize = _blocksSize;
            Blocks = GetBlocks();

        }

        public  List<Point> GetBlocks()
        {
            var blocks = new List<Point>();
            for (int i =0; i< _numberOfBlocks; i++)
            {
                Random r = new Random();
                int rX = r.Next(0, _size- _blocksSize);
                int rY = r.Next(0, _size- _blocksSize);
                blocks.Add(new Point(rX,rY));
            }
            return blocks;
        }
    }
}
