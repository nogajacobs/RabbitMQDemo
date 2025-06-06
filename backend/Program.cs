using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;

namespace RabbitMQConsumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var targets = CreateRandomTargets(5);

            string json = JsonSerializer.Serialize(targets, new JsonSerializerOptions
            {
                WriteIndented = true // Optional: for pretty printing
            });

            File.WriteAllText("targets.json", json);

            foreach (var target in targets)
            {
                Console.WriteLine("---------- Target ----------");
                PrintObject(target);
                Console.WriteLine();
            }

            Console.WriteLine("Finished creating 5 random targets.");
        }

        static List<structTarget.Target> CreateRandomTargets(int count)
        {
            var random = new Random();
            var list = new List<structTarget.Target>();

            for (int i = 0; i < count; i++)
            {
                var target = new structTarget.Target
                {
                    Id = i + 1,
                    AisData = new structTarget.AisData
                    {
                        Channel = $"Channel-{random.Next(1, 5)}",
                        Message = $"Message-{random.Next(100, 999)}",
                        MessageNumber_1 = new structTarget.Message1 { UserId = random.Next(1000) },
                        MessageNumber_2 = new structTarget.Message2 { UserId = random.Next(1000) },
                        MessageNumber_3 = new structTarget.Message3 { UserId = random.Next(1000) },
                        MessageNumber_5 = new structTarget.Message5
                        {
                            UserId = random.Next(1000),
                            Name = $"Ship-{random.Next(1, 100)}",
                            TypeOfShipOrCargo = "Cargo",
                            DimensionA = random.Next(10, 50),
                            DimensionB = random.Next(10, 50),
                            DimensionC = random.Next(10, 50),
                            DimensionD = random.Next(10, 50),
                            CallSing = "CALL123",
                            Destination = "PortX",
                            ImoNumber = random.Next(1000000, 9999999)
                        },
                        MessageNumber_18 = new structTarget.Message18 { UserId = random.Next(1000) },
                        MessageNumber_19 = new structTarget.Message19
                        {
                            UserId = random.Next(1000),
                            Name = $"Ship19-{random.Next(1, 100)}",
                            TypeOfShipOrCargo = "Type19",
                            DimensionA = random.Next(10, 50),
                            DimensionB = random.Next(10, 50),
                            DimensionC = random.Next(10, 50),
                            DimensionD = random.Next(10, 50)
                        }
                    },
                    Position = new structTarget.Position
                    {
                        Lat = random.NextDouble() * 180 - 90,
                        Lon = random.NextDouble() * 360 - 180,
                        Alt = random.NextDouble() * 10000
                    },
                    AirVelocity = new structTarget.Velocity
                    {
                        East = random.NextDouble() * 100,
                        North = random.NextDouble() * 100,
                        Up = random.NextDouble() * 100
                    },
                    Acceleration = new structTarget.Velocity
                    {
                        East = random.NextDouble() * 10,
                        North = random.NextDouble() * 10,
                        Up = random.NextDouble() * 10
                    },
                    Angles = new structTarget.Angles
                    {
                        Yaw = random.NextDouble() * 360,
                        Pitch = random.NextDouble() * 360,
                        Roll = random.NextDouble() * 360
                    },
                    AngleRate = new structTarget.Angles
                    {
                        Yaw = random.NextDouble() * 10,
                        Pitch = random.NextDouble() * 10,
                        Roll = random.NextDouble() * 10
                    },
                    PolyLine = new structTarget.Shape
                    {
                        Id = random.Next(1000),
                        TargetId = i + 1,
                        Points = new List<structTarget.Position>
                        {
                            new structTarget.Position { Lat = random.NextDouble() * 180 - 90, Lon = random.NextDouble() * 360 - 180, Alt = random.NextDouble() * 10000 },
                            new structTarget.Position { Lat = random.NextDouble() * 180 - 90, Lon = random.NextDouble() * 360 - 180, Alt = random.NextDouble() * 10000 }
                        }
                    },
                    PolyLineId = random.Next(1000),
                    Polygon = new structTarget.Shape
                    {
                        Id = random.Next(1000),
                        TargetId = i + 1,
                        Points = new List<structTarget.Position>
                        {
                            new structTarget.Position { Lat = random.NextDouble() * 180 - 90, Lon = random.NextDouble() * 360 - 180, Alt = random.NextDouble() * 10000 },
                            new structTarget.Position { Lat = random.NextDouble() * 180 - 90, Lon = random.NextDouble() * 360 - 180, Alt = random.NextDouble() * 10000 }
                        }
                    },
                    PolygonId = random.Next(1000),
                    Noise = new structTarget.Noise
                    {
                        X = random.NextDouble(),
                        Y = random.NextDouble(),
                        Z = random.NextDouble()
                    },
                    Misc = new structTarget.Misc
                    {
                        WindAngle = random.NextDouble() * 360,
                        WindVelocity = random.NextDouble() * 50,
                        RCS = random.NextDouble() * 100,
                        Swerling = random.Next(1, 6)
                    },
                    Display = new structTarget.Display
                    {
                        Size = random.Next(1, 10),
                        Color = "Red",
                        ShowLabel = true,
                        ShowRing = false,
                        RingCount = 3,
                        StartRadius = 10,
                        DeltaRadius = 5,
                        RingColor = "Blue"
                    },
                    TargetType = new structTarget.TargetType
                    {
                        IsRadar = true,
                        IsIFF = false,
                        IsAIS = true,
                        IsADSB = false
                    },
                    Radar = new structTarget.Radar
                    {
                        GroupType = "GroupA",
                        ECMType = "ECM1",
                        Type = "TypeX",
                        Class = "Class1"
                    },
                    Adsb = new structTarget.Adsb
                    {
                        Id = random.Next(1000),
                        Name = $"ADSB-{i + 1}"
                    },
                    IffFlags = new List<structTarget.IffFlag>
                    {
                        new structTarget.IffFlag { Name = "Flag1", Flag = true },
                        new structTarget.IffFlag { Name = "Flag2", Flag = false }
                    },
                    IffModws = new structTarget.IffModws
                    {
                        Mode_1 = new structTarget.IffMode1 { Active = true, Valid = true, CodeMatch = false, Octal = random.Next(8) },
                        Mode_2 = new structTarget.IffMode2 { Active = false, Valid = true, CodeMatch = true, Octal = random.Next(8) },
                        Mode_3A = new structTarget.IffMode3A { Active = true, Valid = false, CodeMatch = false, Octal = random.Next(8) },
                        Mode_4 = new structTarget.IffMode4 { Active = true, GroupType = "Group4" },
                        Mode_C = new structTarget.IffModeC { Active = true, Altitude = random.NextDouble() * 10000, ValidAltitude = true },
                        Mode_5 = new structTarget.IffMode5 { Active = false, NationalOrigin = random.Next(100), Pin = random.Next(100), Attributes = random.Next(1000) },
                        Mode_S = new structTarget.IffModeS { Active = true }
                    }
                };

                list.Add(target);
            }

            return list;
        }

        static void PrintObject(object obj, int indent = 0)
        {
            if (obj == null)
            {
                Console.WriteLine($"{new string(' ', indent)}null");
                return;
            }

            Type type = obj.GetType();

            // If it's a simple type or string, print directly
            if (type.IsPrimitive || obj is string || obj is decimal)
            {
                Console.WriteLine($"{new string(' ', indent)}{obj}");
                return;
            }

            // If it's a collection, iterate
            if (obj is System.Collections.IEnumerable enumerable && !(obj is string))
            {
                foreach (var item in enumerable)
                {
                    PrintObject(item, indent + 2);
                }
                return;
            }

            // Otherwise, print properties and fields recursively
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                var val = prop.GetValue(obj);
                if (val == null)
                {
                    Console.WriteLine($"{new string(' ', indent)}{prop.Name}: null");
                }
                else if (prop.PropertyType.IsPrimitive || val is string || val is decimal)
                {
                    Console.WriteLine($"{new string(' ', indent)}{prop.Name}: {val}");
                }
                else if (val is System.Collections.IEnumerable enumerableProp && !(val is string))
                {
                    Console.WriteLine($"{new string(' ', indent)}{prop.Name}:");
                    foreach (var item in enumerableProp)
                    {
                        PrintObject(item, indent + 4);
                    }
                }
                else
                {
                    Console.WriteLine($"{new string(' ', indent)}{prop.Name}:");
                    PrintObject(val, indent + 4);
                }
            }

            foreach (var field in fields)
            {
                var val = field.GetValue(obj);
                if (val == null)
                {
                    Console.WriteLine($"{new string(' ', indent)}{field.Name}: null");
                }
                else if (field.FieldType.IsPrimitive || val is string || val is decimal)
                {
                    Console.WriteLine($"{new string(' ', indent)}{field.Name}: {val}");
                }
                else if (val is System.Collections.IEnumerable enumerableField && !(val is string))
                {
                    Console.WriteLine($"{new string(' ', indent)}{field.Name}:");
                    foreach (var item in enumerableField)
                    {
                        PrintObject(item, indent + 4);
                    }
                }
                else
                {
                    Console.WriteLine($"{new string(' ', indent)}{field.Name}:");
                    PrintObject(val, indent + 4);
                }
            }
        }
    }
}
