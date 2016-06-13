/*

This file is part of the iText (R) project.
Copyright (c) 1998-2016 iText Group NV
Authors: Bruno Lowagie, Paulo Soares, et al.

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License version 3
as published by the Free Software Foundation with the addition of the
following permission added to Section 15 as permitted in Section 7(a):
FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY
ITEXT GROUP. ITEXT GROUP DISCLAIMS THE WARRANTY OF NON INFRINGEMENT
OF THIRD PARTY RIGHTS

This program is distributed in the hope that it will be useful, but
WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
or FITNESS FOR A PARTICULAR PURPOSE.
See the GNU Affero General Public License for more details.
You should have received a copy of the GNU Affero General Public License
along with this program; if not, see http://www.gnu.org/licenses or write to
the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
Boston, MA, 02110-1301 USA, or download the license from the following URL:
http://itextpdf.com/terms-of-use/

The interactive user interfaces in modified source and object code versions
of this program must display Appropriate Legal Notices, as required under
Section 5 of the GNU Affero General Public License.

In accordance with Section 7(b) of the GNU Affero General Public License,
a covered work must retain the producer line in every PDF that is created
or manipulated using iText.

You can be released from the requirements of the license by purchasing
a commercial license. Buying such a license is mandatory as soon as you
develop commercial activities involving the iText software without
disclosing the source code of your own applications.
These activities include: offering paid services to customers as an ASP,
serving PDFs on the fly in a web application, shipping iText with a closed
source product.

For more information, please contact iText Software Corp. at this
address: sales@itextpdf.com
*/
using iTextSharp.Kernel.Geom;
using iTextSharp.Kernel.Pdf;
using iTextSharp.Kernel.Pdf.Canvas;

namespace iTextSharp.Kernel.Pdf.Canvas.Parser.Data {
    /// <summary>Contains information relating to painting current path.</summary>
    public class PathRenderInfo : IEventData {
        /// <summary>End the path object without filling or stroking it.</summary>
        /// <remarks>
        /// End the path object without filling or stroking it. This operator shall be a path-painting no-op,
        /// used primarily for the side effect of changing the current clipping path
        /// </remarks>
        public const int NO_OP = 0;

        /// <summary>Value specifying stroke operation to perform on the current path.</summary>
        public const int STROKE = 1;

        /// <summary>Value specifying fill operation to perform on the current path.</summary>
        /// <remarks>
        /// Value specifying fill operation to perform on the current path. When the fill operation
        /// is performed it should use either nonzero winding or even-odd rule.
        /// </remarks>
        public const int FILL = 2;

        private Path path;

        private int operation;

        private int rule;

        private bool isClip;

        private int clippingRule;

        private CanvasGraphicsState gs;

        /// <param name="path">The path to be rendered.</param>
        /// <param name="operation">
        /// One of the possible combinations of
        /// <see cref="STROKE"/>
        /// and
        /// <see cref="FILL"/>
        /// values or
        /// <see cref="NO_OP"/>
        /// </param>
        /// <param name="rule">
        /// Either
        /// <see cref="iTextSharp.Kernel.Pdf.Canvas.PdfCanvasConstants.FillingRule.NONZERO_WINDING"/>
        /// or
        /// <see cref="iTextSharp.Kernel.Pdf.Canvas.PdfCanvasConstants.FillingRule.EVEN_ODD"/>
        /// .
        /// </param>
        /// <param name="isClip">True indicates that current path modifies the clipping path, false - if not.</param>
        /// <param name="clipRule">
        /// Either
        /// <see cref="iTextSharp.Kernel.Pdf.Canvas.PdfCanvasConstants.FillingRule.NONZERO_WINDING"/>
        /// or
        /// <see cref="iTextSharp.Kernel.Pdf.Canvas.PdfCanvasConstants.FillingRule.EVEN_ODD"/>
        /// .
        /// </param>
        /// <param name="gs">The graphics state.</param>
        public PathRenderInfo(Path path, int operation, int rule, bool isClip, int clipRule, CanvasGraphicsState gs
            ) {
            this.path = path;
            this.operation = operation;
            this.rule = rule;
            this.gs = gs;
            this.isClip = isClip;
            this.clippingRule = clipRule;
        }

        /// <summary>
        /// If the operation is
        /// <see cref="NO_OP"/>
        /// then the rule is ignored,
        /// otherwise
        /// <see cref="iTextSharp.Kernel.Pdf.Canvas.PdfCanvasConstants.FillingRule.NONZERO_WINDING"/>
        /// is used by default.
        /// With this constructor path is considered as not modifying clipping path.
        /// See
        /// <see cref="PathRenderInfo(iTextSharp.Kernel.Geom.Path, int, int, bool, int, iTextSharp.Kernel.Pdf.Canvas.CanvasGraphicsState)
        ///     "/>
        /// </summary>
        public PathRenderInfo(Path path, int operation, CanvasGraphicsState gs)
            : this(path, operation, PdfCanvasConstants.FillingRule.NONZERO_WINDING, false, PdfCanvasConstants.FillingRule
                .NONZERO_WINDING, gs) {
        }

        /// <returns>
        /// The
        /// <see cref="iTextSharp.Kernel.Geom.Path"/>
        /// to be rendered.
        /// </returns>
        public virtual Path GetPath() {
            return path;
        }

        /// <returns>
        /// <CODE>int</CODE> value which is either
        /// <see cref="NO_OP"/>
        /// or one of possible
        /// combinations of
        /// <see cref="STROKE"/>
        /// and
        /// <see cref="FILL"/>
        /// </returns>
        public virtual int GetOperation() {
            return operation;
        }

        /// <returns>
        /// Either
        /// <see cref="iTextSharp.Kernel.Pdf.Canvas.PdfCanvasConstants.FillingRule.NONZERO_WINDING"/>
        /// or
        /// <see cref="iTextSharp.Kernel.Pdf.Canvas.PdfCanvasConstants.FillingRule.EVEN_ODD"/>
        /// .
        /// </returns>
        public virtual int GetRule() {
            return rule;
        }

        /// <returns>true indicates that current path modifies the clipping path, false - if not.</returns>
        public virtual bool IsPathModifiesClippingPath() {
            return isClip;
        }

        /// <returns>
        /// Either
        /// <see cref="iTextSharp.Kernel.Pdf.Canvas.PdfCanvasConstants.FillingRule.NONZERO_WINDING"/>
        /// or
        /// <see cref="iTextSharp.Kernel.Pdf.Canvas.PdfCanvasConstants.FillingRule.EVEN_ODD"/>
        /// .
        /// </returns>
        public virtual int GetClippingRule() {
            return clippingRule;
        }

        /// <returns>Current transformation matrix.</returns>
        public virtual Matrix GetCtm() {
            return gs.GetCtm();
        }

        public virtual float GetLineWidth() {
            return gs.GetLineWidth();
        }

        public virtual int GetLineCapStyle() {
            return gs.GetLineCapStyle();
        }

        public virtual int GetLineJoinStyle() {
            return gs.GetLineJoinStyle();
        }

        public virtual float GetMiterLimit() {
            return gs.GetMiterLimit();
        }

        public virtual PdfArray GetLineDashPattern() {
            return gs.GetDashPattern();
        }

        public virtual iTextSharp.Kernel.Color.Color GetStrokeColor() {
            return gs.GetStrokeColor();
        }

        public virtual iTextSharp.Kernel.Color.Color GetFillColor() {
            return gs.GetFillColor();
        }
    }
}
