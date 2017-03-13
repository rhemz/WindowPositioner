using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WindowPositioner
{
    [Serializable()]
    class WindowCollection : ISerializable
    {
        public string title;
        private List<Window> windows = new List<Window>();

        public List<Window> Windows
        {
            get { return this.windows; }
            set { this.windows = value; }
        }

        public WindowCollection()
        {

        }

        public WindowCollection(string name)
        {
            this.title = name;
        }


        public WindowCollection(SerializationInfo info, StreamingContext context)
        {
            this.windows = (List<Window>)info.GetValue("Windows", typeof(List<Window>));
            this.title = (string)info.GetValue("Title", typeof(string));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Windows", this.windows);
            info.AddValue("Title", this.title);
        }
    }
}
