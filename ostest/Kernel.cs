using Cosmos.System;
using SipaaGL;
using SipaaGL.Animation;
using SipaaGL.Extentions;
using SipaaGL.FontRendering;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace ostest
{
    public class Kernel : Sys.Kernel
    {
        [IL2CPU.API.Attribs.ManifestResourceStream(ResourceName = "ostest.sklogo.bmp")]
        public static byte[] sklogo;

        Graphics img;

        SVGAIICanvas C;
        AnimationController A = new(25f, 270f, new(0, 0, 0, 0, 750), AnimationMode.Ease);
        AnimationController P = new(0f, 360f, new(0, 0, 0, 0, 500), AnimationMode.Linear);

        int X;
        int Y;

        protected override void BeforeRun()
        {
            C = new(1280, 720);

            MouseManager.ScreenWidth = 1280;
            MouseManager.ScreenHeight = 720;

            X = C.Width / 2;
            Y = C.Height / 2 + 100;

            img = Image.FromBitmap(sklogo);
        }

        protected override void Run()
        {
            if (A.Current == A.Target)
            {
                (A.Source, A.Target) = (A.Target, A.Source);
                A.Reset();
            }
            if (P.Current == P.Target)
            {
                P.Reset();
            }

            int LengthOffset = (int)(P.Current + A.Current);
            int Offset = (int)P.Current;

            C.Clear();
            C.DrawImage(X - 128 / 2, Y - 200, img, true);
            C.DrawArc(X, Y, 20, Color.White, Offset, LengthOffset);
            C.DrawString(10, 10, $"{C.GetFPS()} FPS", BitFont.Fallback, Color.White);
            C.DrawFilledRectangle((int)MouseManager.X, (int)MouseManager.Y, 10, 10, 0, Color.White);
            C.Update();
        }
    }
}
