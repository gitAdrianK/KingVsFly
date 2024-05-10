using JumpKing;
using System;
using System.IO;
using System.Reflection;

namespace KingVsFly
{
    public class ModSaves
    {
        private static ModSaves instance;
        public static ModSaves Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ModSaves();
                }
                return instance;
            }
        }

        public void Reset()
        {
            instance = null;
        }

        private ModSaves()
        {
            Load();
        }

        public int mainBabeRecord;
        public int newBabeRecord;
        public int ghostBabeRecord;

        public void Save()
        {
            JKContentManager contentManager = Game1.instance.contentManager;
            char sep = Path.DirectorySeparatorChar;
            string path = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{sep}save";

            // Level being null means the vanilla map is being started/ended.
            if (contentManager.level != null)
            {
                return;
            }

            BinaryWriter binaryWriter = null;
            try
            {
                binaryWriter = new BinaryWriter(File.Open(path, FileMode.Create));

                binaryWriter.Write(mainBabeRecord);
                binaryWriter.Write(newBabeRecord);
                binaryWriter.Write(ghostBabeRecord);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                binaryWriter?.Flush();
                binaryWriter?.Close();
            }
        }

        public void Load()
        {
            char sep = Path.DirectorySeparatorChar;
            string path = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{sep}save";

            if (!File.Exists(path))
            {
                SetRecords();
                return;
            }

            BinaryReader binaryReader = null;
            try
            {
                binaryReader = new BinaryReader(File.Open(path, FileMode.Open));

                mainBabeRecord = binaryReader.ReadInt32();
                newBabeRecord = binaryReader.ReadInt32();
                ghostBabeRecord = binaryReader.ReadInt32();
            }
            catch
            {
                SetRecords();
            }
            finally
            {
                binaryReader?.Close();
            }
        }

        private void SetRecords()
        {
            SetRecords(-1, -1, -1);
        }

        private void SetRecords(int mainBabeRecord, int newBabeRecord, int ghostBabeRecord)
        {
            this.mainBabeRecord = mainBabeRecord;
            this.newBabeRecord = newBabeRecord;
            this.ghostBabeRecord = ghostBabeRecord;
        }
    }
}
