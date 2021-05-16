using System;

namespace VRF
{
    internal enum EntityType
    {
        Player,
        Fish
    };

    internal enum ActionType
    {
        Test,
        Catch
    }

    public enum FishSize
    {
        Small = 1,
        Medium,
        Large
    }

    public enum FishType
    {
        TestFish
    }

    public enum BaitType
    {
        TestBait,
        SmallBait,
        MediumBait,
        LargeBait
    }
}