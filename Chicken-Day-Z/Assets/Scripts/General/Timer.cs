namespace ChickenDayZ.General
{
    public class Timer
    {
        private float _time;

        private float _countDown;

        public float Time
        {
            set
            {
                _time = value;

                ResetTimer();
            }
            get
            {
                return _time;
            }
        }

        public float CountDown
        {
            set
            {
                _countDown = value;
            }
            get
            {
                return _countDown;
            }
        }

        public bool TimerFinished
        {
            get
            {
                return _countDown <= 0f;
            }
        }

        public Timer(float time) 
        {
            _time = time;

            ResetTimer();
        }

        public void ResetTimer()
        {
            _countDown = _time;
        }

        public void DecreaseTimer()
        {
            if (_countDown > 0f)
            {
                _countDown -= UnityEngine.Time.deltaTime;

                if (_countDown <= 0f)
                {
                    _countDown = 0f;
                }
            }
        }
    }
}