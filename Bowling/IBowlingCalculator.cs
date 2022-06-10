namespace Bowling
{
    public interface IBowlingCalculator
    {
        void RecordFrame(params int[] throws);
        int Score { get; }

    }
}
