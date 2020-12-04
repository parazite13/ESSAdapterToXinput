using System;
using System.Collections.Generic;
using WpfApp.InputReader.Devices;

namespace WpfApp.InputReader
{
    public class InputSource
    {
        static public readonly InputSource NES = new InputSource("nes", "NES", true, false, port => new SerialControllerReader(port, SuperNESandNES.ReadFromPacket_NES));
        static public readonly InputSource SNES = new InputSource("snes", "Super NES", true, false, port => new SerialControllerReader(port, SuperNESandNES.ReadFromPacket_SNES));
        static public readonly InputSource N64 = new InputSource("n64", "Nintendo 64", true, false, port => new SerialControllerReader(port, Nintendo64.ReadFromPacket));
        static public readonly InputSource GAMECUBE = new InputSource("gamecube", "GameCube", true, false, port => new SerialControllerReader(port, GameCube.ReadFromPacket));

        static public readonly IReadOnlyList<InputSource> ALL = new List<InputSource> {
            NES, SNES, N64, GAMECUBE
        };

        static public readonly InputSource DEFAULT = NES;

        public string TypeTag { get; private set; }
        public string Name { get; private set; }
        public bool RequiresComPort { get; private set; }
        public bool RequiresId { get; private set; }

        public Func<string, IControllerReader> BuildReader { get; private set; }

        InputSource(string typeTag, string name, bool requiresComPort, bool requiresId, Func<string, IControllerReader> buildReader)
        {
            TypeTag = typeTag;
            Name = name;
            RequiresComPort = requiresComPort;
            RequiresId = requiresId;
            BuildReader = buildReader;
        }
    }
}
