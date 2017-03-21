using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;


namespace WindowPositioner
{
    class KeyHook
    {
        #region Interop DLL Imports

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            KeyboardProcedure lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern short GetAsyncKeyState(int keyCode);

        #endregion

        #region Vars
        private delegate IntPtr KeyboardProcedure(int nCode, IntPtr wParam, IntPtr lParam);
        public event KeyEventHandler KeyPressDetected;
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_HIGH = 0x8000;

        private KeyboardProcedure keyboardProcedure;
        private IntPtr keyboardHookId = IntPtr.Zero;
        #endregion

        #region Functions
        private KeyboardProcedure CurrentKeyboardProcedure
        {
            get { return keyboardProcedure ?? (keyboardProcedure = HookCallback); }
            set { keyboardProcedure = value; }
        }

        public void KeyboardHook()
        {
            keyboardHookId = SetHook(CurrentKeyboardProcedure);
        }

        private IntPtr SetHook(KeyboardProcedure proc)
        {
            using (Process currentProcess = Process.GetCurrentProcess())
            using (ProcessModule currentModule = currentProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(currentModule.ModuleName), 0);
            }
        }

        private void OnKeyPressDetected(object sender, KeyEventArgs args)
        {
            if (KeyPressDetected != null)
            {
                KeyPressDetected(sender, args);
            }
        }

        public bool IsKeyDown(Keys key)
        {
            return (GetAsyncKeyState((int)key) & WM_HIGH) != 0;
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && (wParam ==
                (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN))
            {
                int vkCode = Marshal.ReadInt32(lParam);
                var key = ((Keys)vkCode);

                if (IsKeyDown(Keys.LControlKey) || IsKeyDown(Keys.RControlKey))
                {
                    key = key | Keys.Control;
                }

                if (IsKeyDown(Keys.LShiftKey) || IsKeyDown(Keys.RShiftKey))
                {
                    key = key | Keys.Shift;
                }

                if (IsKeyDown(Keys.LMenu) || IsKeyDown(Keys.RMenu))
                {
                    key = key | Keys.Alt;
                }

                OnKeyPressDetected(null, new KeyEventArgs(key));
            }
            return CallNextHookEx(keyboardHookId, nCode, wParam, lParam);
        }

        public void Dispose()
        {
            UnhookWindowsHookEx(keyboardHookId);
        }
        #endregion

    }
}
