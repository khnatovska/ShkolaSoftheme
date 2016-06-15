using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDescriptor
{
    public class ShapeDescriptor
    {
        public string ShapeType { get; set; }

        public ShapeDescriptor(Point first, Point second)
        {
            ShapeType = "Line";
        }

        public ShapeDescriptor(Point first, Point second, Point third)
        {
            ShapeType = "Triangle";
        }

        public ShapeDescriptor(Point first, Point second, Point third, Point fourth)
        {
            ShapeType = "Square";
        }

        public string GetShapeType()
        {
            return ShapeType;
        }
    }
}
