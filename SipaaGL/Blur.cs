using Cosmos.Core;
using Cosmos.Core.Memory;
using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SipaaGL
{
    /// <summary>
    /// RaphMar2019's blur implementation
    /// 
    /// Made by nifanfa, Ported to SipaaGL by me
    /// </summary>
    public unsafe class Blur
    {
        public static void BlurGraphics(Graphics gr, uint intensity)
        {
            uint* _raw = gr.Internal;

            for (uint w = 0; w < gr.Width; w++)
            {
                for (uint h = 0; h < gr.Height; h++)
                {
                    long r = 0, g = 0, b = 0, a = 0;
                    int counter = 0;

                    for (uint ww = w - intensity; ww < w + intensity; ww++)
                    {
                        for (uint hh = h - intensity; hh < h + intensity; hh++)
                        {
                            if (ww >= 0 && hh >= 0 && ww < gr.Width && hh < gr.Height)
                            {
                                Color color = Color.FromARGB(_raw[gr.Width * hh + ww]);

                                r += color.R;
                                g += color.G;
                                b += color.B;
                                a += color.A;

                                counter++;
                            }
                        }
                    }

                    r /= counter;
                    g /= counter;
                    b /= counter;
                    a /= counter;

                    gr[(int)w, (int)h] = Color.FromARGB((byte)a, (byte)r, (byte)g, (byte)b).ARGB;
                }
            }
        }

        public static void BlurGraphicsRegion(Graphics gr, int x, int y, int width, int height, uint intensity)
        {
            uint* _raw = gr.Internal;

            for (uint w = (uint)x; w < width; w++)
            {
                for (uint h = (uint)y; h < height; h++)
                {
                    long r = 0, g = 0, b = 0, a = 0;
                    int counter = 0;

                    for (uint ww = w - intensity; ww < w + intensity; ww++)
                    {
                        for (uint hh = h - intensity; hh < h + intensity; hh++)
                        {
                            if (ww >= 0 && hh >= 0 && ww < gr.Width && hh < gr.Height)
                            {
                                Color color = Color.FromARGB(_raw[gr.Width * hh + ww]);

                                r += color.R;
                                g += color.G;
                                b += color.B;
                                a += color.A;

                                counter++;
                            }
                        }
                    }

                    r /= counter;
                    g /= counter;
                    b /= counter;
                    a /= counter;

                    gr[(int)w, (int)h] = Color.FromARGB((byte)a, (byte)r, (byte)g, (byte)b).ARGB;
                }
            }
        }
    }
}