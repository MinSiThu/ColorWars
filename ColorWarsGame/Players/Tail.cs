﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

using ColorWars.Services;
using ColorWars.Boards;

namespace ColorWars.Players
{
    internal class Tail : ISquareDrawable
    {
        public List<BoardField> Positions {get; set;}
        private readonly PlayerModel owner;

        public Tail(PlayerModel owner)
        {
            this.owner = owner;
            this.Positions = new List<BoardField>();
        }

        public void AddField(BoardField field)
        {
            this.Positions.Add(field);
            field.PlayerEntered += this.PlayerEnteredHandler;
        }

        private void PlayerEnteredHandler(object sender, EventArgs e)
        {
            owner.Kill((PlayerModel)sender);
        }

        public void Delete()
        {
            foreach (BoardField position in this.Positions)
            {
                position.PlayerEntered -= this.PlayerEnteredHandler;
            }
            this.Positions.Clear();
        }

        public Color GetColor()
        {
            return ColorTools.HalfTransparent(this.owner.GetColor());
        }

        public Point[] GetPoints()
        {
            return this.Positions.Select(f => f.GetPoints()[0]).ToArray();
        }
    }
}
