using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mini1
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
            Console.ReadLine();
        }

        private static async void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Loading...");
            var watch = Stopwatch.StartNew();
            var students = DataSource();
            var tasks = new List<Task<Students>>();
            foreach (var student in students)
            {
                tasks.Add(Task.Run(() => ExcuteData(student)));
            }
            var infos = await Task.WhenAll(tasks);
            Console.Clear();
            foreach (var info in infos)
            {
                DisPlayInfo(info);
            }
            watch.Stop();

            Console.WriteLine($"Tổng thời gian thực thi: {watch.ElapsedMilliseconds}ms");
        }

        private static void DisPlayInfo(Students studenInfo)
        {
            Console.WriteLine($"Sinh viên '{studenInfo.Name}' hiện tại {studenInfo.Age} tủi");
        }

        private static Students ExcuteData(Students student)
        {
            Thread.Sleep(1000);
            return student;
        }

        static List<Students> DataSource()
        {
            return new List<Students>
            {
                new Students(){ Name = "Studen 1", Age = 20},
                new Students(){ Name = "Studen 2", Age = 20},
                new Students(){ Name = "Studen 3", Age = 20},
                new Students(){ Name = "Studen 4", Age = 20},
                new Students(){ Name = "Studen 5", Age = 20},
                new Students(){ Name = "Studen 6", Age = 20},
                new Students(){ Name = "Studen 7", Age = 20},
                new Students(){ Name = "Studen 8", Age = 20},
                new Students(){ Name = "Studen 9", Age = 20},
                new Students(){ Name = "Studen 10", Age = 20},
            };
        }
    }
}
