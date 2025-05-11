using System;
using System.IO;
using System.Runtime.InteropServices;

namespace IntelOrca.OpenLauncher.Core
{
    public class Game
    {
        public static Game OpenRCT2 => new Game("OpenRCT2", "openrct2", new RepositoryName("OpenRCT2", "OpenRCT2"), new RepositoryName("OpenRCT2", "OpenRCT2-binaries"));
        public static Game OpenLoco => new Game("OpenLoco", "openloco", new RepositoryName("OpenLoco", "OpenLoco"));

        public string Name { get; }
        public string BinaryName { get; }
        public string BinPath { get; }
        public RepositoryName ReleaseRepository { get; set; }
        public RepositoryName? DevelopRepository { get; set; }

        private Game(string name, string binaryName, RepositoryName releaseRepo, RepositoryName? developRepo = null)
        {
            Name = name;
            BinaryName = binaryName;

            var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            BinPath = Path.Combine(localAppData, name, "bin");
            ReleaseRepository = releaseRepo;
            DevelopRepository = developRepo;
        }
    }

    public struct RepositoryName
    {
        public string Owner { get; }
        public string Name { get; }

        public RepositoryName(string owner, string name)
        {
            Owner = owner;
            Name = name;
        }

        public override string ToString() => $"{Owner}/{Name}";
    }
}
