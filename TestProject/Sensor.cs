using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TestProject
{
    class Sensor
    {
        static double x0 = 360, x1 = 300, x2 = 240, x3 = 120;

        int response;

        public bool IsBlack { get; set; }
        public Sensor()
        {
            response = 50;
        }
        public Sensor(int response)
        {
            Response = response;
        }
        public int Response
        {
            get
            {
                return response;
            }
            set
            {
                if(value >= 10 && value <= 100)
                {
                    response = value;
                }
                else
                {
                    throw new Exception("Некорректный ввод значения частоты реакции датчика");
                }
            }
        }
        
        public void Check(Disk disk)
        {
            if ((disk.x_current <= x0 && disk.x_current >= x1) || (disk.x_current <= x2 && disk.x_current >= x3) || (disk.x_current == 0))
            {
                IsBlack = true;
            }
            else IsBlack = false;
        }
        public string Command()
        {
            if (IsBlack) return "Черный";
            return "Белый";
        }
    }
}
