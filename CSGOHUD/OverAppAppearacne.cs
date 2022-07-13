using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace CSGOHUD
{
    public partial class MainWindow
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int W, int H, uint uFlags);
        private Thread? _threadOvershowing = null;

        /// <summary>
        /// Главное окно приложения становиться поверх всех окон.
        /// </summary>
        /// <param name="delay">Перерыв в миллисекундах</param>
        private void StartOvershowing(int milliseconds)
        {
            if (_threadOvershowing != null)
                return;

            if (milliseconds > 1000)
                milliseconds = 1000;

            if (milliseconds < 10)
                milliseconds = 10;

            _threadOvershowing = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(milliseconds);
                    SetWindowPos(Process.GetCurrentProcess().MainWindowHandle, IntPtr.Parse("-1"), 0, 0, 0, 0, 0x0001 | 0x0002 | 0x0200);
                }
            });
            _threadOvershowing.Start();
        }
    }
}
