using System;
using iTextSharp.Kernel.Geom;
using iTextSharp.Kernel.Pdf;
using iTextSharp.Kernel.Pdf.Canvas.Parser.Filter;
using iTextSharp.Kernel.Pdf.Canvas.Parser.Listener;
using iTextSharp.Test;

namespace iTextSharp.Kernel.Pdf.Canvas.Parser {
    public class GlyphTextEventListenerTest : ExtendedITextTest {
        private static readonly String sourceFolder = NUnit.Framework.TestContext.CurrentContext.TestDirectory + "/../../resources/itextsharp/kernel/parser/GlyphTextEventListenerTest/";

        /// <exception cref="System.IO.IOException"/>
        [NUnit.Framework.Test]
        public virtual void Test01() {
            PdfDocument pdfDocument = new PdfDocument(new PdfReader(sourceFolder + "test.pdf"));
            float x1;
            float y1;
            float x2;
            float y2;
            x1 = 203;
            x2 = 21;
            y1 = 749;
            y2 = 49;
            String extractedText = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(1), new GlyphTextEventListener
                (new FilteredTextEventListener(new LocationTextExtractionStrategy(), new TextRegionEventFilter(new Rectangle
                (x1, y1, x2, y2)))));
            NUnit.Framework.Assert.AreEqual("1234\nt5678", extractedText);
        }

        /// <exception cref="System.IO.IOException"/>
        [NUnit.Framework.Test]
        public virtual void Test02() {
            PdfDocument pdfDocument = new PdfDocument(new PdfReader(sourceFolder + "Sample.pdf"));
            String extractedText = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(1), new GlyphTextEventListener
                (new FilteredTextEventListener(new LocationTextExtractionStrategy(), new TextRegionEventFilter(new Rectangle
                (111, 855, 25, 12)))));
            NUnit.Framework.Assert.AreEqual("Your ", extractedText);
        }

        /// <exception cref="System.IO.IOException"/>
        [NUnit.Framework.Test]
        public virtual void TestWithMultiFilteredRenderListener() {
            PdfDocument pdfDocument = new PdfDocument(new PdfReader(sourceFolder + "test.pdf"));
            float x1;
            float y1;
            float x2;
            float y2;
            FilteredEventListener listener = new FilteredEventListener();
            x1 = 122;
            x2 = 22;
            y1 = 678.9f;
            y2 = 12;
            ITextExtractionStrategy region1Listener = listener.AttachEventListener(new LocationTextExtractionStrategy(
                ), new TextRegionEventFilter(new Rectangle(x1, y1, x2, y2)));
            x1 = 156;
            x2 = 13;
            y1 = 678.9f;
            y2 = 12;
            ITextExtractionStrategy region2Listener = listener.AttachEventListener(new LocationTextExtractionStrategy(
                ), new TextRegionEventFilter(new Rectangle(x1, y1, x2, y2)));
            PdfCanvasProcessor parser = new PdfCanvasProcessor(new GlyphEventListener(listener));
            parser.ProcessPageContent(pdfDocument.GetPage(1));
            NUnit.Framework.Assert.AreEqual("Your", region1Listener.GetResultantText());
            NUnit.Framework.Assert.AreEqual("dju", region2Listener.GetResultantText());
        }
    }
}
