﻿using System.Collections.Generic;

namespace Tetris_Game
{
    abstract class Block
    {
        protected abstract Position[][] Tiles { get; }
        protected abstract Position StartOffset { get; }
        public abstract int id { get; }

        private int rotationState;
        private Position offset;

        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        public IEnumerable<Position> TilesPositions()
        {
            foreach (Position p in Tiles[rotationState])
            {
                yield return new Position(p.Row, p.Column + offset.Column);
            }
        }

        public void RotateCw()
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        public void RotateCCw()
        {
            if (rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }

        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        public void Reset()
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}