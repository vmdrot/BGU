using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pdf2DataLib.Spares;

namespace ClippingPathVisualizer.ViewModels
{
    public class PathInfoEntryCollection : List<PathInfoEntry>
    {
        public static explicit operator PathInfoEntryCollection(List<PathInfo> src)
        {
            if (src == null)
                return null;
            PathInfoEntryCollection rslt = new PathInfoEntryCollection();
            for (int i = 0; i < src.Count; i++)
                rslt.Add(new PathInfoEntry() { DisplayText = i.ToString(), DataIndex = i });
            return rslt;
        }

    }
}
