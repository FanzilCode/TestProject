using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    class Disk
    {
        double rotation;

        public double x_current { get; set; }
        public double change_x { get; set; }

        public Disk()
        {
            Rotation = 1; x_current = 0; change_x = 10 * 360 / 1000 / Rotation;
        }
        public Disk(double rotation)
        {
            Rotation = rotation;
        }
        public double Rotation
        {
            get
            {
                return rotation;
            }
            set
            {
                rotation = value;
            }
        }
        public void Rotate()
        {
            x_current = (x_current + change_x + 360) % 360;
        }
        
    }
}
