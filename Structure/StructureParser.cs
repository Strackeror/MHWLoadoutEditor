using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHWLoadoutEdit.Structure
{
    using System.Runtime.InteropServices;

    public static class StructureParser
    {
        public static T Parse<T>(byte[] data)
        {
            if (data.Length != Marshal.SizeOf(typeof(T)))
                return default(T);

            T ret;
            var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ret = (T) Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            }
            finally
            {
                handle.Free();
            }
            return ret;
        }
        public static byte[] Export<T>(T structure)
        {
            byte[] target = new byte[Marshal.SizeOf(structure)];
            var ptr = Marshal.AllocHGlobal(target.Length);
            try
            {
                Marshal.StructureToPtr(structure, ptr, true);
                Marshal.Copy(ptr, target, 0, target.Length);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return target;
        }
    }
}
