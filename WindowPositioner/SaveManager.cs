using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using WindowPositioner;


namespace WindowPositioner
{
    class SaveManager
    {

        private string saveFilePath;

        public SaveManager(string path)
        {
            this.saveFilePath = path;
        }


        public bool SaveExists()
        {
            return File.Exists(saveFilePath);
        }

        public void SaveContainer(WindowCollectionContainer container)
        {
            Stream stream = File.Open(saveFilePath, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, container);
            stream.Close();

        }

        public WindowCollectionContainer LoadContainer()
        {
            WindowCollectionContainer container;
            Stream stream = File.Open(saveFilePath, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            container = (WindowCollectionContainer)formatter.Deserialize(stream);
            stream.Close();
            
            return container;

        }

    }


}
