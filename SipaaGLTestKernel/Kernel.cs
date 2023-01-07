using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using SipaaGL;
using SipaaGL.Extentions;

namespace SipaaGLTestKernel
{
    public class Kernel : Sys.Kernel
    {
        [ManifestResourceStream(ResourceName = "SipaaGLTestKernel.segoeuil.ttf")]
        public static byte[] RawSegoeUIL;

        public static string Font = "Segoe UI Light";

        public static VBECanvas vc;

        protected override void BeforeRun()
        {
            vc = new();
            TTFManager.RegisterFont(Font, RawSegoeUIL);
            Console.WriteLine("Cosmos booted successfully. Type a line of text to get it echoed back.");
        }

        protected override void Run()
        {
            vc.Clear(Color.Black);
            vc.DrawString(Color.White, "TTF fonts into SipaaGL VBE canvas!", Font, 48f, 20, 50);
            vc.Update();
        }
    }
}
