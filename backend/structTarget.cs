using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQConsumer
{
    internal class structTarget
    {
        public struct AisData
        {
            public string Channel { get; set; }
            public string Message { get; set; }
            public Message1 MessageNumber_1 { get; set; }
            public Message2 MessageNumber_2 { get; set; }
            public Message3 MessageNumber_3 { get; set; }
            public Message5 MessageNumber_5 { get; set; }
            public Message18 MessageNumber_18 { get; set; }
            public Message19 MessageNumber_19 { get; set; }
        }

        public struct Target
        {
            public AisData AisData { get; set; }
            public Position Position { get; set; }
            public Velocity AirVelocity { get; set; }
            public Velocity Acceleration { get; set; }
            public Angles Angles { get; set; }
            public Angles AngleRate { get; set; }
            public Shape PolyLine { get; set; }
            public int PolyLineId { get; set; }
            public Shape Polygon { get; set; }
            public int PolygonId { get; set; }
            public Noise Noise { get; set; }
            public Misc Misc { get; set; }
            public Display Display { get; set; }
            public TargetType TargetType { get; set; }
            public Radar Radar { get; set; }
            public Adsb Adsb { get; set; }
            public List<IffFlag> IffFlags { get; set; }
            public IffModws IffModws { get; set; }
            public int Id { get; set; }
        }

        public struct Position { public double Lat { get; set; } public double Lon { get; set; } public double Alt { get; set; } }
        public struct Velocity { public double East { get; set; } public double North { get; set; } public double Up { get; set; } }
        public struct Angles { public double Yaw { get; set; } public double Pitch { get; set; } public double Roll { get; set; } }
        public struct Shape
        {
            public List<Position>? Points { get; set; }
            public int TargetId { get; set; }
            public int Id { get; set; }
            public List<Velocity>? AltAndAirVelocitys { get; set; }
            public List<int>? TargetsIdInPolyLine { get; set; }
        }

        public struct Noise { public double X { get; set; } public double Y { get; set; } public double Z { get; set; } }
        public struct Misc { public double WindAngle { get; set; } public double WindVelocity { get; set; } public double RCS { get; set; } public int Swerling { get; set; } }
        public struct Display
        {
            public int Size { get; set; }
            public string Color { get; set; }
            public bool ShowLabel { get; set; }
            public bool ShowRing { get; set; }
            public int RingCount { get; set; }
            public int StartRadius { get; set; }
            public int DeltaRadius { get; set; }
            public string RingColor { get; set; }
        }
        public struct TargetType { public bool IsRadar { get; set; } public bool IsIFF { get; set; } public bool IsAIS { get; set; } public bool IsADSB { get; set; } }
        public struct Radar { public string GroupType { get; set; } public string ECMType { get; set; } public string Type { get; set; } public string Class { get; set; } }
        public struct Adsb { public int Id { get; set; } public string Name { get; set; } }
        public struct IffFlag { public string Name { get; set; } public bool Flag { get; set; } }

        public struct IffModws
        {
            public IffMode1 Mode_1 { get; set; }
            public IffMode2 Mode_2 { get; set; }
            public IffMode3A Mode_3A { get; set; }
            public IffMode4 Mode_4 { get; set; }
            public IffModeC Mode_C { get; set; }
            public IffMode5 Mode_5 { get; set; }
            public IffModeS Mode_S { get; set; }
        }

        public struct IffMode1 { public bool Active { get; set; } public bool Valid { get; set; } public bool CodeMatch { get; set; } public int Octal { get; set; } }
        public struct IffMode2 { public bool Active { get; set; } public bool Valid { get; set; } public bool CodeMatch { get; set; } public int Octal { get; set; } }
        public struct IffMode3A { public bool Active { get; set; } public bool Valid { get; set; } public bool CodeMatch { get; set; } public int Octal { get; set; } }
        public struct IffMode4 { public bool Active { get; set; } public string GroupType { get; set; } }
        public struct IffModeC { public bool Active { get; set; } public double Altitude { get; set; } public bool ValidAltitude { get; set; } }
        public struct IffMode5 { public bool Active { get; set; } public int NationalOrigin { get; set; } public int Pin { get; set; } public int Attributes { get; set; } }
        public struct IffModeS { public bool Active { get; set; } }

        // AIS Messages
        public struct Message1 { public int UserId { get; set; } }
        public struct Message2 { public int UserId { get; set; } }
        public struct Message3 { public int UserId { get; set; } }
        public struct Message5
        {
            public int UserId { get; set; }
            public string Name { get; set; }
            public string TypeOfShipOrCargo { get; set; }
            public int DimensionA { get; set; }
            public int DimensionB { get; set; }
            public int DimensionC { get; set; }
            public int DimensionD { get; set; }
            public string CallSing { get; set; }
            public string Destination { get; set; }
            public int ImoNumber { get; set; }
        }
        public struct Message18 { public int UserId { get; set; } }
        public struct Message19
        {
            public int UserId { get; set; }
            public string Name { get; set; }
            public string TypeOfShipOrCargo { get; set; }
            public int DimensionA { get; set; }
            public int DimensionB { get; set; }
            public int DimensionC { get; set; }
            public int DimensionD { get; set; }
        }

    }
}