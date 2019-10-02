using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FrameApplication.ViewModels
{
    public partial class MianWindowViewModel : ViewModelBase
    {
        public string AppTitle { get; set; } = "FrameApplication";

        public delegate void currentCountDel(int count);
        currentCountDel currentCount;

        private int count;

        public int CurrentCountText
        {
            get { return count; }
            set
            {
                count = value;
                OnPropertyChanged();
            }
        }

        private int repeat = 1000;

        public int Repeat
        {
            get { return repeat; }
            set { repeat = value; }
        }

        private int delay = 220;

        public int Delay
        {
            get { return delay; }
            set
            {
                delay = value;
                OnPropertyChanged();

            }
        }

        bool canExecute = true;
        public bool CanExecute
        {
            get
            {
                return canExecute;
            }
            internal set
            {
                canExecute = value;
            }
        }

        public MianWindowViewModel()
        {
            currentCount = new currentCountDel(CurrentCount);
        }

        public void Execute()
        {
            Thread loadingThread = new Thread(delegate ()
            {
                DoMouseClick(repeat, delay);
            });
            loadingThread.Start();
        }

        public void CurrentCount(int count)
        {
            CurrentCountText = count;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point lpPoint);


        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public void DoMouseClick(int count, int delay)
        {
            CanExecute = false;
            //Call the imported function with the cursor's current position
            Point mouse;
            GetCursorPos(out mouse);
            uint X = (uint)mouse.X;
            uint Y = (uint)mouse.Y;

            //currentCount.Text = "0";

            for (int i = 1; i <= count; i++)
            {
                Thread.Sleep(delay);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
                CurrentCount(i);
            }

            CanExecute = true;
        }
    }
}