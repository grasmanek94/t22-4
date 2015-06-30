namespace Communication
{
    public class MMessage
    {
        public byte[] Begin;
        public byte[] End;

        public byte Action { get; set; }

        public byte DataLen { get; set; }

        public bool PossiblyCorrupt { get; set; }

        public byte[] Data { get; set; }

        public byte[] Corruptioncheck;
        public byte[] Header;

        public MMessage()
        {
            Begin = new byte[2];
            End = new byte[2];
            Data = new byte[58];
            Corruptioncheck = new byte[2];
            Header = new byte[2];

            Begin[0] = (byte)'{';
            Begin[1] = (byte)'{';
            End[0] = (byte)'}';
            End[1] = (byte)'}';

            Action = 0;
            DataLen = 0;
            PossiblyCorrupt = false;
        }

        public MMessage(byte action)
            : this()
        {
            Action = action;
        }

        public override string ToString()
        {
            return "Message - " + ((int)Action).ToString() + " - " + ((int)DataLen).ToString() + " - " + PossiblyCorrupt.ToString();
        }
    }
}
