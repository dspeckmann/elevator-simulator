using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ElevatorSimulator
{
    [Serializable]
    public class GameProgress
    {
        private const string savegamePath = "savegames";

        public string Name { get; set; }
        public string Path { get; set; }
        public int Day { get; set; } = 0;

        public GameProgress(string name)
        {
            Name = name;
        }

        public static IEnumerable<GameProgress> GetAvailableSavegames()
        {
            if(!Directory.Exists(savegamePath)) // TODO: Improve. Somehow.
            {
                Directory.CreateDirectory(savegamePath);
            }
            string[] files = Directory.GetFiles(savegamePath);
            BinaryFormatter formatter = new BinaryFormatter();
            List<GameProgress> savegames = new List<GameProgress>();
            foreach(string file in files)
            {
                try
                {
                    using (Stream stream = new FileStream(file, FileMode.Open))
                    {
                        Console.WriteLine("Full path: {0}", System.IO.Path.GetFullPath(file));
                        savegames.Add(formatter.Deserialize(stream) as GameProgress);
                    }

                    Console.WriteLine("Successfully loaded savegame {0}!", file);
                }
                catch(Exception ex) // TODO: Better exception handling
                {
                    Console.WriteLine("Could not open savegame {0}!", file);
                }
            }

            return savegames;
        }

        public void Save()
        {
            if(string.IsNullOrEmpty(Path))
            {
                // TODO: Better savegame naming, check for illegal symbols and if filename already exists
                Path = string.Format("{0}/{1}-{2}.elvtr", savegamePath, Name, new Random().Next(1000, 9999));
            }

            try
            {
                using (Stream stream = new FileStream(Path, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, this);
                }

                Console.WriteLine("Successfully wrote savegame {0}!", Path);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Could not write savegame {0}!", Path);
            }
        }
    }
}
