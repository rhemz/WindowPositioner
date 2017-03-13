using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WindowPositioner
{
    [Serializable()]
    class WindowCollectionContainer : ISerializable
    {
        private List<WindowCollection> collections = new List<WindowCollection>();

        public List<WindowCollection> Collections
        {
            get { return this.collections; }
            set { this.collections = value; }
        }

        public WindowCollectionContainer()
        {

        }

        public WindowCollectionContainer(SerializationInfo info, StreamingContext context)
        {
            this.collections = (List<WindowCollection>)info.GetValue("Collections", typeof(List<WindowCollection>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Collections", this.collections);
        }
    }
}
