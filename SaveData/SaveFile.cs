namespace MHWLoadoutEdit.SaveData
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using Structure;

    partial class SaveFile
    {
        public List<EquipmentLoadout> loadouts = new List<EquipmentLoadout>();

        public SaveFile(string path)
        {
            data = File.ReadAllBytes(path);
            Decrypt();

            for (int i = 0; i < EquipmentLoadout.EquipmentSetCount; ++i)
            {
                var loadout = new EquipmentLoadout();
                var start = EquipmentLoadout.EquipmentSetOffset + EquipmentLoadout.EquipmentSetLength * i;
                var end = start + EquipmentLoadout.EquipmentSetLength;
                loadout.Load(Data.Slice(start, end));
                loadouts.Add(loadout);
            }
        }
    }
}
