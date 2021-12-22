using System.Threading.Tasks;

public static class TimeCount {
    public static bool IsTimeUp { get; private set; }
    public static int Seconds { get; private set; }
    public static void Timer(int time, int state = 0) {
        ResetTimeUp();
        Task task = TimerAsync(time, state);
        if(task.IsCompleted)
            task.Dispose();
    }
    public static void ResetTimeUp() {
        IsTimeUp = false;
        Seconds = 0;
    }
    private static async Task TimerAsync(int time, int state) {
        time = SecondsConversion(time, state);
        while(time > 0) {
            await Task.Delay(1000);
            time--;
            Seconds = time;
        }
        IsTimeUp = true;
    }
    private static int SecondsConversion(int second, int state = 0) {
        switch(state) {
            case 0:
                return second;
            case 1:
                return second * 60;
            case 2:
                return second * 3600;
            default:
                return second;
        }
    }
}