namespace MHWLoadoutEdit.Structure
{
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    
    public class EquipmentLoadout : INotifyPropertyChanged 
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct EquipmentLoadoutStruct
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public byte[] name;

            public uint weaponId, helmetId, chestId, glovesId, waistId, legsId, charmId, tool1Id, tool2Id;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public uint[] weaponDecos, helmetDecos, chestDecos, glovesDecos, waistDecos, legsDecos;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 36)]
            public uint[] _0;

            public uint bitMaskColored, bitMaskRainbow;
            public uint helmetRGBA, chestRGBA, glovesRGBA, waistRGBA, legsRGBA;
            public uint _1, _2;
        }

        public const int EquipmentSetOffset = 0x3de672;
        public const int EquipmentSetLength = 0x220;
        public const int EquipmentSetCount = 112;

        private EquipmentLoadoutStruct internalStruct;

        public int WeaponID => (int) internalStruct.weaponId;

        public EquipmentLoadout()
        {
        }

        public void Load(byte[] data)
        {
            internalStruct = StructureParser.Parse<EquipmentLoadoutStruct>(data);
            RaisePropertyChangedEvent("");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
