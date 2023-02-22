using psff = Cosmos.System.Graphics.Fonts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaGL
{
    /// <summary>
    /// PC Screen Font font renderer
    /// </summary>
    public static class PSFFont
    {
        /// <summary>
        /// Draw string with the PCScreenFont renderer.
        /// </summary>
        /// <param name="str">string to draw.</param>
        /// <param name="aFont">Font used to draw the string.</param>
        /// <param name="color">Color.</param>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        public static void DrawStringPSF(this Graphics g, int x, int y, string str, psff.Font aFont, Color color)
        {
            for (int i = 0; i < str.Length; i++)
            {
                g.DrawCharPSF(x, y, str[i], aFont, color);
                x += aFont.Width;
            }
        }


        /// <summary>
        /// Draw char with the PCScreenFont renderer.
        /// </summary>
        /// <param name="c">char to draw.</param>
        /// <param name="aFont">Font used.</param>
        /// <param name="color">Color.</param>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        public static void DrawCharPSF(this Graphics g, int x, int y, char c, psff.Font aFont, Color color)
        {
            int p = aFont.Height * (byte)c;

            for (int cy = 0; cy < aFont.Height; cy++)
            {
                for (byte cx = 0; cx < aFont.Width; cx++)
                {
                    if (aFont.ConvertByteToBitAddres(aFont.Data[p + cy], cx + 1))
                    {
                        g[(ushort)(x + (aFont.Width - cx)), (ushort)(y + cy)] = color;
                    }
                }
            }
        }
    }
}
