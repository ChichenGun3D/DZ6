using System;
using System.Collections.Generic;

namespace TransportApp
{
    // 1. АБСТРАКТНЫЙ КЛАСС
    public abstract class Vehicle
    {
        // Свойства (4 свойства, чтение и запись)
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelConsumption { get; set; } // Расход топлива на 100 км

        // Конструктор базового класса
        public Vehicle(string brand, string model, int year, double fuelConsumption)
        {
            Brand = brand;
            Model = model;
            Year = year;
            FuelConsumption = fuelConsumption;
        }

        // Абстрактный метод (обязателен для наследников)
        public abstract string GetVehicleType();

        // Обычные методы (минимум 5 с учетом наследников)
        public virtual void PrintInfo()
        {
            Console.WriteLine($"[{Brand} {Model}] Год: {Year} | Расход: {FuelConsumption} л/100км");
        }

        public double CalculateFuelForDistance(double distanceKm)
        {
            return (FuelConsumption / 100) * distanceKm;
        }

        public void ApplyEcoMode()
        {
            FuelConsumption -= 0.5;
            if (FuelConsumption < 0) FuelConsumption = 0;
            Console.WriteLine($"Включен эко-режим для {Brand} {Model}. Новый расход: {FuelConsumption} л/100км.");
        }

        public string GenerateRegistrationPlate()
        {
            return $"{Brand.Substring(0, 1).ToUpper()}{Model.Substring(0, 1).ToUpper()}-{Year % 100}";
        }

        public void ChangeYear(int newYear)
        {
            Year = newYear;
            Console.WriteLine($"Год выпуска изменен на {newYear}.");
        }
    }

    // 2. НАСЛЕДНИК 1 - ЛЕГКОВОЙ АВТОМОБИЛЬ
    public class Car : Vehicle
    {
        public int DoorsCount { get; set; }
        public bool IsAutomatic { get; set; }

        // Конструктор 1
        public Car(string brand, string model, int year, double fuelConsumption, int doorsCount, bool isAutomatic)
            : base(brand, model, year, fuelConsumption)
        {
            DoorsCount = doorsCount;
            IsAutomatic = isAutomatic;
        }

        // Конструктор 2
        public Car(string brand, string model, int year)
            : this(brand, model, year, 7.5, 4, true)
        {
        }

        public override string GetVehicleType()
        {
            return "Легковой автомобиль";
        }

        public void OpenTrunk()
        {
            Console.WriteLine($"Багажник автомобиля {Brand} {Model} открыт.");
        }

        public void EnableCruiseControl()
        {
            Console.WriteLine("Круиз-контроль активирован.");
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"  -> Тип: {GetVehicleType()}, Дверей: {DoorsCount}, Коробка: {(IsAutomatic ? "Автомат" : "Механика")}");
        }
    }

    // 3. НАСЛЕДНИК 2 - ГРУЗОВИК
    public class Truck : Vehicle
    {
        public double MaxLoadTons { get; set; }
        public int AxlesCount { get; set; }

        // Конструктор 1
        public Truck(string brand, string model, int year, double fuelConsumption, double maxLoadTons, int axlesCount)
            : base(brand, model, year, fuelConsumption)
        {
            MaxLoadTons = maxLoadTons;
            AxlesCount = axlesCount;
        }

        // Конструктор 2
        public Truck(string brand, string model, int year)
            : this(brand, model, year, 25.0, 10.0, 3)
        {
        }

        public override string GetVehicleType()
        {
            return "Грузовой автомобиль";
        }

        public void LoadCargo(double weight)
        {
            if (weight <= MaxLoadTons)
                Console.WriteLine($"Загружено {weight} тонн. Машина готова к выезду.");
            else
                Console.WriteLine($"Ошибка: перегруз! Максимум {MaxLoadTons} тонн.");
        }

        public void UnloadCargo()
        {
            Console.WriteLine("Груз полностью выгружен.");
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"  -> Тип: {GetVehicleType()}, Грузоподъемность: {MaxLoadTons} т, Осей: {AxlesCount}");
        }
    }

    // 4. НАСЛЕДНИК 3 - МОТОЦИКЛ
    public class Motorcycle : Vehicle
    {
        public bool HasSidecar { get; set; }
        public int EngineVolume { get; set; }

        // Конструктор 1
        public Motorcycle(string brand, string model, int year, double fuelConsumption, bool hasSidecar, int engineVolume)
            : base(brand, model, year, fuelConsumption)
        {
            HasSidecar = hasSidecar;
            EngineVolume = engineVolume;
        }

        // Конструктор 2
        public Motorcycle(string brand, string model, int year)
            : this(brand, model, year, 3.5, false, 600)
        {
        }

        public override string GetVehicleType()
        {
            return "Мотоцикл";
        }

        public void DoWheelie()
        {
            Console.WriteLine("Мотоцикл встал на заднее колесо! (Вилли)");
        }

        public void RemoveSidecar()
        {
            if (HasSidecar)
            {
                HasSidecar = false;
                Console.WriteLine("Коляска отцеплена.");
            }
            else
            {
                Console.WriteLine("Коляски и так нет.");
            }
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"  -> Тип: {GetVehicleType()}, Объем двигателя: {EngineVolume} куб.см, Коляска: {(HasSidecar ? "Есть" : "Нет")}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ДЕМОНСТРАЦИЯ РАБОТЫ ПРОГРАММЫ ===\n");

            // Создаем объекты
            Car myCar = new Car("Toyota", "Camry", 2022, 8.2, 4, true);
            Truck myTruck = new Truck("Volvo", "FH16", 2020); // Использует 2-й конструктор
            Motorcycle myMoto = new Motorcycle("Yamaha", "MT-07", 2023, 4.0, false, 689);

            // 1. Легковой автомобиль
            Console.WriteLine("--- Автомобиль ---");
            myCar.PrintInfo();
            myCar.OpenTrunk();
            myCar.ApplyEcoMode();
            Console.WriteLine($"Топливо на 150 км: {myCar.CalculateFuelForDistance(150):F2} л.");
            Console.WriteLine($"Госномер: {myCar.GenerateRegistrationPlate()}\n");

            // 2. Грузовик
            Console.WriteLine("--- Грузовик ---");
            myTruck.PrintInfo();
            myTruck.LoadCargo(12);
            myTruck.LoadCargo(8);
            myTruck.UnloadCargo();
            myTruck.ChangeYear(2021); // Использование метода базового класса
            Console.WriteLine();

            // 3. Мотоцикл
            Console.WriteLine("--- Мотоцикл ---");
            myMoto.PrintInfo();
            myMoto.DoWheelie();
            myMoto.HasSidecar = true; // Использование свойства на запись
            myMoto.RemoveSidecar();
            Console.WriteLine($"Расход топлива (свойство): {myMoto.FuelConsumption} л.\n");

            Console.ReadKey();
        }
    }
}