using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Data;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using Pdf2DataLib.Spares;

namespace Pdf2DataLib.Spares
{
    public class TablesEventListener : IEventListener
    {
        private List<string> _texts = new List<string>();
        private List<PathInfo> _clippingPaths = new List<PathInfo>();
        private StringBuilder _currText;
        private int _currTextSegmentIndex = -1;

        public void EventOccurred(IEventData data, EventType type)
        {
            
            switch (type)
            {
                case EventType.BEGIN_TEXT:
                    _currTextSegmentIndex++;
                    _currText = new StringBuilder();
                    break;
                case EventType.END_TEXT:
                    _texts.Add(_currText.ToString());
                    break;
                case EventType.RENDER_TEXT:
                    {
                        TextRenderInfo tri = data as TextRenderInfo;
                        if (tri != null)
                        {
                            _currText.Append(tri.GetText());
                        }
                    }
                    break;
                case EventType.CLIP_PATH_CHANGED:
                    {
                        ClippingPathInfo cpi = data as ClippingPathInfo;
                        if (cpi != null)
                        {
                            var cpii = (PathInfo)cpi.GetClippingPath();
                            cpii.RelatedTextIndex = _currTextSegmentIndex;
                            _clippingPaths.Add(cpii);
                        }
                    }
                    break;
                case EventType.RENDER_IMAGE:
                case EventType.RENDER_PATH:
                default:
                    break;
            }
        }

        public List<string> GetTexts()
        {
            return _texts;
        }
        public List<PathInfo> GetClippingPaths()
        {
            return _clippingPaths;
        }

        public ICollection<EventType> GetSupportedEvents()
        {
            List<EventType> rslt = new List<EventType>();
            rslt.Add(EventType.BEGIN_TEXT);
            rslt.Add(EventType.CLIP_PATH_CHANGED);
            rslt.Add(EventType.END_TEXT);
            rslt.Add(EventType.RENDER_IMAGE);
            rslt.Add(EventType.RENDER_PATH);
            rslt.Add(EventType.RENDER_TEXT);
            return rslt;
        }
    }
}
