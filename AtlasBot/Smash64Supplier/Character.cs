using System;

namespace Smash64Supplier
{
    public class Character
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public double WalkingSpeed { get; set; }
        public double BrakingForce { get; set; }
        public double InitialDashSpeed { get; set; }
        public double DashDeceleration { get; set; }
        public double RunningSpeed { get; set; }
        public int JumpAnimationFrames { get; set; }
        public double XAirAcceleration { get;set; }
        public double XAirMaxSpeed { get; set; }
        public double XAirResistance { get; set; }
        public double YFallAcceleration { get; set; }
        public double YMaxSpeedFall { get; set; }
        public double YMaxFastFallSpeed { get; set; }
        public int MaxNumberOfJumps { get; set; }
        public double Weight { get; set; }
        public int InitialDashFrames { get; set; }
    }
}
