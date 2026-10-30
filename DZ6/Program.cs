using System;

namespace BuildingApp
{
    public class Building
    {
        private static int lastBuildingNumber = 0;

        private string buildingNumber;
        private double height;
        private int floors;
        private int apartments;
        private int entrances;

        public Building(double height, int floors, int apartments, int entrances)
        {
            buildingNumber = GenerateBuildingNumber();
            this.height = height;
            this.floors = floors;
            this.apartments = apartments;
            this.entrances = entrances;
        }

        private static string GenerateBuildingNumber()
        {
            lastBuildingNumber++;
            return lastBuildingNumber.ToString();
        }

        public void SetData(double height, int floors, int apartments, int entrances)
        {
            this.height = height;
            this.floors = floors;
            this.apartments = apartments;
            this.entrances = entrances;
        }

        public string GetBuildingNumber()
        {
            return buildingNumber;
        }

        public double GetHeight()
        {
            return height;
        }

        public int GetFloors()
        {
            return floors;
        }

        public int GetApartments()
        {
            return apartments;
        }

        public int GetEntrances()
        {
            return entrances;
        }

        public double GetFloorHeight()
        {
            if (floors == 0) return 0;
            return height / floors;
        }

        public double GetApartmentsPerEntrance()
        {
            if (entrances == 0) return 0;
            return (double)apartments / entrances;
        }

        public double GetApartmentsPerFloor()
        {
            if (floors == 0) return 0;
            return (double)apartments / floors;
        }

        public void PrintInfo()
        {
            Console.WriteLine("--- Информация о здании ---");
            Console.WriteLine($"Уникальный номер здания: {buildingNumber}");
            Console.WriteLine($"Высота: {height} м");
            Console.WriteLine($"Этажность: {floors}");
            Console.WriteLine($"Количество квартир: {apartments}");
            Console.WriteLine($"Количество подъездов: {entrances}");
            Console.WriteLine($"Высота этажа: {GetFloorHeight():F2} м");
            Console.WriteLine($"Квартир в подъезде: {GetApartmentsPerEntrance():F2}");
            Console.WriteLine($"Квартир на этаже: {GetApartmentsPerFloor():F2}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите высоту здания (м): ");
            double height1 = double.Parse(Console.ReadLine());

            Console.Write("Введите количество этажей: ");
            int floors1 = int.Parse(Console.ReadLine());

            Console.Write("Введите количество квартир: ");
            int apartments1 = int.Parse(Console.ReadLine());

            Console.Write("Введите количество подъездов: ");
            int entrances1 = int.Parse(Console.ReadLine());

            Building building1 = new Building(height1, floors1, apartments1, entrances1);
            Console.WriteLine();
            building1.PrintInfo();

            Console.WriteLine();

            Console.Write("Введите высоту здания (м): ");
            double height2 = double.Parse(Console.ReadLine());

            Console.Write("Введите количество этажей: ");
            int floors2 = int.Parse(Console.ReadLine());

            Console.Write("Введите количество квартир: ");
            int apartments2 = int.Parse(Console.ReadLine());

            Console.Write("Введите количество подъездов: ");
            int entrances2 = int.Parse(Console.ReadLine());

            Building building2 = new Building(height2, floors2, apartments2, entrances2);
            Console.WriteLine();
            building2.PrintInfo();

            Console.ReadKey();
        }
    }
}