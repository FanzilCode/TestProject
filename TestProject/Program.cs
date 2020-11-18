using System;
using System.IO;
namespace TestProject
{

    delegate void ChangeRotation(Disk disk, double NewRotation);

    delegate void ReverseDirection(Disk disk);

    delegate void ChangeResponse(Sensor sensor, int NewResponse);

    class Program
    {
        ReverseDirection reverseDirection = ReverseDirectionDisk;
        ChangeResponse changeResponse = EditResponse;
        ChangeRotation changeRotation = EditRotation;

        static bool processIn = true;
        public static void Start(Sensor sensor, Disk disk, DateTime time, ref string report)
        {
            DateTime time1 = time;
            TimeSpan s = new TimeSpan(0, 0, 0, 0, 10);

            while (processIn)
            {
                disk.Rotate();
                time += s;
                if ((time.Millisecond - time1.Millisecond) % sensor.Response == 0)
                {
                    sensor.Check(disk);
                    report += $"\n{time.ToLongTimeString()}:{time.Millisecond}  {sensor.Command()}";
                    Console.Write(report);
                    Console.ReadKey();
                }
            }
        }
        public static void Stop()
        {
            processIn = false;
        }
        static void Main(string[] args)
        {
            string report = "";
            Start(new Sensor(), new Disk(), DateTime.Now, ref report);
            Stop();
        }

        public static void ReverseDirectionDisk(Disk disk)
        {
            disk.change_x *= -1;
        }

        public static void EditResponse(Sensor sensor, int NewResponse)
        {
            sensor.Response = NewResponse;
        }


        public static void EditRotation(Disk disk, double NewRotation)
        {
            disk.Rotation = NewRotation;
        }
        public static void WriteInFile(string report, string file)
        {
            File.WriteAllText(report, file);
        }
    }
}