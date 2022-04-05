
public sealed class TimerSystem 
{
    private int _frameSizeDelaySet =0;
    private int _delayTic = 0;
    internal const int FRAME = 30;
    private bool _isStartTimer = true;
    private bool _isloopTimer;

    //timeSwich==true секуны, timeSwich==false кадры.
    //loop зацикливание таймера.
    //time еденицы времени задержки.
    public TimerSystem(bool timerSwich, bool isloop, float time)
    {
        Timer(timerSwich,isloop,time);
    }
    public TimerSystem(bool isloop, float time)
    {
        Timer(true, isloop, time);
    }
    public TimerSystem(float time)
    {
        Timer(true, true, time);
    }
    private void Timer(bool timerSwich, bool isloop, float time)
    {
        _isloopTimer = isloop;
        if (timerSwich)
        {
            float temp = (time * FRAME);
            _frameSizeDelaySet = (int)temp;
        }
        else
        {
            _frameSizeDelaySet = (int)time;
        }
    }
    public bool CheckEvent()
    {
        if (_isStartTimer)
        {
            _delayTic = _frameSizeDelaySet;
            _isStartTimer = false;
        }
        else
        {
            bool eventT;
            TimeTic(ref _delayTic, out eventT);
            return eventT;
        }
        return false;
    }
    private void TimeTic(ref int getTime, out bool eventTimer)
    {
        if (getTime >0)
        {
            getTime--;
            eventTimer = false;
        }
        else
        {
            eventTimer = true;
            if (_isloopTimer)
            {
                _delayTic = _frameSizeDelaySet;
            }
        }
    }
}
