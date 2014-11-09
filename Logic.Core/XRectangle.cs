﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Core
{
    public class XRectangle : IShape
    {
        public IStyle Style { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public bool IsFilled { get; set; }

        public void Render(object dc, IRenderer renderer, IStyle style)
        {
            renderer.DrawRectangle(dc, style, this);
        }
    }
}