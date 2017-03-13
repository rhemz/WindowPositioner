using System;
using System.Timers;
using System.ComponentModel;

namespace WindowPositioner
{
    class HwndRefreshTimer
    {
        private const int hwndRefreshRate = 8000; // 8sec

        public delegate void hwndRefreshHandler();
        public event hwndRefreshHandler hwndRefresh;

        protected Timer refreshTimer = new Timer();
        protected ISynchronizeInvoke syncObj;


        public HwndRefreshTimer(ISynchronizeInvoke iso)
        {
            this.syncObj = iso;
            refreshTimer.Elapsed += new ElapsedEventHandler(Tick);
            refreshTimer.Interval = hwndRefreshRate;
        }

        protected delegate void tickDelegate(object source, ElapsedEventArgs e);
        private void Tick(object source, ElapsedEventArgs e)
        {
            if (syncObj.InvokeRequired)
                syncObj.BeginInvoke(new tickDelegate(Tick), new object[] { source, e });
            else
                hwndRefresh();
        }


        public void Go()
        {
            refreshTimer.Enabled = true;
        }

    }
}
