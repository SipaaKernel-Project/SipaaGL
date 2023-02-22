using SipaaGL.TDNumerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaGL.TDObjects
{
    public class Light
    {
        public Light(Vector3 Position, Vector3 Rotation, Color Color, Types Type)
        {
            this.Position = Position;
            this.Rotation = Rotation;
            this.Color = Color;
            this.Type = Type;
        }

        public enum Types
        {
            Fixed,
            Ambient,
            Directional,
        }

        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Color Color { get; set; }
        public Types Type { get; set; }
    }
}
