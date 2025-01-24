using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    internal class player
    {
        public Vector2 pos;
        public Vector2 ball_pos;
        public float player_speed = 300f;
        public float size = 1f;
        public Texture2D player_Texture2D;
    }
}
