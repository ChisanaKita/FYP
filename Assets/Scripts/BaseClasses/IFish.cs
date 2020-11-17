public interface IFish
{
    bool IsBaiting { get; set; }
    bool IsCatched { get; set; }
    int CatchThreshold { get; set; }
    string Name { get; set; }
}
