using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Data;
using iText.Kernel.Pdf.Canvas.Parser.Listener;

public class CustomLocationTextExtractionStrategy : LocationTextExtractionStrategy
{
    private string wordToFind;

    public float LastFoundX { get; private set; }
    public float LastFoundY { get; private set; }

    public CustomLocationTextExtractionStrategy(string wordToFind)
    {
        this.wordToFind = wordToFind;
    }

    public override void EventOccurred(IEventData data, EventType type)
    {
        base.EventOccurred(data, type);
        if (type.Equals(EventType.RENDER_TEXT))
        {
            var renderInfo = (TextRenderInfo)data;
            string text = renderInfo.GetText();
            if (text.Contains(wordToFind))
            {
                Vector location = renderInfo.GetBaseline().GetStartPoint();
                
                LastFoundX = location.Get(Vector.I1);
                LastFoundY = location.Get(Vector.I2);
            }
        }
    }
}