using System.Threading.Tasks;

public class TimeCount {
    public bool IsTimeUp { get; private set; }
    public int Seconds { get; private set; }
    public TimeCount() {
        IsTimeUp = false;
        Seconds = 0;
    }
    public void Timer(int time, int state = 0) {
        Task task = TimerAsync(time, state);
        if(task.IsCompleted)
            task.Dispose();
    }
    public void ResetTimeUp() {
        IsTimeUp = false;
    }
    private async Task TimerAsync(int time, int state) {
        time = SecondsConversion(time, state);
        while(time > 0) {
            await Task.Delay(1000);
            time--;
            Seconds = time;
        }
        IsTimeUp = true;
    }
    private int SecondsConversion(int second, int state = 0) {
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