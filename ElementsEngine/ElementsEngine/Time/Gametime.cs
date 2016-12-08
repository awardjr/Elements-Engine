using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ElementsEngine.Time
{
    public class Gametime
    {
     
        private int _startTime;
        public float ElapsedTime;
        public float DeltaTime;
        private int _previousTime;
        
        public Gametime()
        {
            _startTime = Environment.TickCount;
            _previousTime = _startTime;
        }

        public void Update()
        {
            ElapsedTime = (Environment.TickCount - _startTime) / 1000f;
            DeltaTime = (Environment.TickCount - _previousTime) / 1000f;
            _previousTime = Environment.TickCount;
        }

        public void Clear()
        {
            _startTime = Environment.TickCount;
            _previousTime = _startTime;
            DeltaTime = 0;
            
        }

    }
}
