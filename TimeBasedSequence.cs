namespace TimeBasedSequence;

/// <inheritdoc />
public class TimeBasedSequence : ITimeBasedSequence
{
    private static long _ticks = DateTime.UtcNow.Ticks;

    /// <inheritdoc />
    public long Next()
    {
        return Next(1)[0];
    }

    /// <inheritdoc />
    public long[] Next(int count)
    {
        var currentTick = DateTime.UtcNow.Ticks;
        var startTick = Math.Max(currentTick, Interlocked.Read(ref _ticks) + 1);

        Interlocked.Exchange(ref _ticks, startTick + count - 1);

        var arr = new long[count];
        for (var i = 0; i < count; i++)
        {
            arr[i] = startTick + i;
        }

        return arr;
    }
}