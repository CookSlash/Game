using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GameServer
{
    public class Game
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int BlockSize { get; private set; }
        public List<Point> BlockEdges { get; private set; }
        public List<Point> Targets { get; private set; }


        private readonly int _size = 200;
        private readonly int _numberOfBlocks = 5;
        private readonly int _blocksSize = 10;
        private readonly int _numberOfTargets = 5;
        private readonly int _numberOfPlayer = 2;


        private readonly HashSet<Point> BlockSet;

        public Game()
        {
            Height = _size;
            Width = _size;
            BlockSize = _blocksSize;
            BlockEdges = GenerateBlockEdges();
            BlockSet = GenerateBlocks(BlockEdges);
            Targets = GenerateTargets();

        }

        private List<Point> GenerateBlockEdges()
        {
            BlockEdges = new List<Point>();
            for (int i = 0; i < _numberOfBlocks; i++)
            {
                var edge = GeneratePointInGame();
                BlockEdges.Add(edge);

            }
            return BlockEdges;
        }

        private HashSet<Point> GenerateBlocks(List<Point> edges)
        {
            var blocks = new HashSet<Point>();
            foreach (var edge in edges)
            {
                blocks.UnionWith(GetAllBlockCells(edge, _blocksSize));
            }

            return blocks;
        }

        private HashSet<Point> GetAllBlockCells(Point edge, int size)
        {
            var allCells = new HashSet<Point>();
            for (int i = 0; i < _blocksSize; i++)
            {
                for (int j = 0; j < _blocksSize; j++)
                {
                    allCells.Add(new Point(edge.X + i, edge.X + j));
                }
            }
            return allCells;
        }

        private Point GeneratePointInGame()
        {
            Random r = new Random();
            int rX, rY;
            rX = r.Next(0, _size - _blocksSize);
            rY = r.Next(0, _size - _blocksSize);
            return new Point(rX, rY);
        }

        private List<Point> GenerateTargets()
        {
            var targets = new List<Point>();
            while (targets.Count < _numberOfTargets)
            {
                var candidateTarget = GeneratePointInGame();
                if (IsPointOusideBlocks(candidateTarget))
                {
                    targets.Add(candidateTarget);
                }
            }

            return targets;

        }

        private bool IsPointOusideBlocks(Point candidateTarget)
        {
            return !BlockSet.Contains(candidateTarget);
        }
    }
}