using System;
using System.Drawing;
using System.Runtime.Serialization;
using WindowScrape.Types;
using System.Runtime.InteropServices;


namespace WindowPositioner
{
    [Serializable()]
    class Window : ISerializable
    {
        /*
        [DllImport("user32", EntryPoint = "GetWindowLongA")]
        public static extern long GetWindowLong(long hwnd, long nIndex);

        [DllImport("user32", EntryPoint = "SetWindowLongA")]
        public static extern long SetWindowLong(long hwnd, long nIndex, long dwNewLong);

        [DllImport("user32")]
        public static extern long SetWindowPos(long hwnd, long hWndInsertAfter, long x, long y, long cx, long cy,
                                               long wFlags);
        */


        public int x;
        public int y;
        public int width;
        public int height;
        public string title;
        public bool translate;

        public Window()
        {
            x = 0;
            y = 0;
            width = 0;
            height = 0;
            title = "";
            translate = false;
        }

        public Window(int x, int y, int width, int height, string title, bool translate)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.title = title;
            this.translate = translate;
        }


        public Window(SerializationInfo info, StreamingContext context)
        {
            this.x = (int)info.GetValue("X", typeof(int));
            this.y = (int)info.GetValue("Y", typeof(int));
            this.width = (int)info.GetValue("Width", typeof(int));
            this.height = (int)info.GetValue("Height", typeof(int));
            this.title = (string)info.GetValue("Title", typeof(string));
            this.translate = (bool)info.GetValue("Translate", typeof(bool));
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("X", this.x);
            info.AddValue("Y", this.y);
            info.AddValue("Width", this.width);
            info.AddValue("Height", this.height);
            info.AddValue("Title", this.title);
            info.AddValue("Translate", this.translate);
        }


        public void Move(HwndObject o)
        {
            o.Location = new Point(this.x, this.y);
        }


        public void Resize(HwndObject o)
        {
            o.Size = new Size(this.width, this.height);
        }


        public void MoveAndResize(HwndObject o)
        {
            /*
            long style = GetWindowLong(Marshal.ReadInt64(o.Hwnd), -16L);
            style &= -12582913L;
            SetWindowLong((long)o.Hwnd, -16L, style);
            SetWindowPos((long)o.Hwnd, 0L, 0L, 0L, 0L, 0L, 0x27L);
            */

            o.Location = translate
                ? TranslatePositionForDecoration(new Point(this.x, this.y))
                : new Point(this.x, this.y);
            o.Size = translate
                ? TranslateSizeForDecoration(new Size(this.width, this.height))
                : new Size(this.width, this.height);

        }


        // handle window decoration size and position translations
        private Point TranslatePositionForDecoration(Point p)
        {
            int xMod = System.Windows.Forms.SystemInformation.FrameBorderSize.Width;
            int yMod = System.Windows.Forms.SystemInformation.CaptionHeight;
            return new Point(p.X - xMod, p.Y - yMod);
        }


        private Size TranslateSizeForDecoration(Size s)
        {
            int wMod = System.Windows.Forms.SystemInformation.FrameBorderSize.Width;
            int hMod = System.Windows.Forms.SystemInformation.CaptionHeight;

            //System.Windows.Forms.MessageBox.Show(hMod.ToString());
            // for window interior width we want width + frameborder*2
            // for height we want height + height of the title bar + height of the bottom frameborder
            return new Size(s.Width + (wMod*2), s.Height + hMod + wMod);
        }

    }
}
