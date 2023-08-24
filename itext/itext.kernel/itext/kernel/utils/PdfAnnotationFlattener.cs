using System.Collections.Generic;
using iText.Commons.Utils;
using iText.Kernel.Exceptions;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Annot;
using iText.Kernel.Utils.Annotationsflattening;

namespace iText.Kernel.Utils {
    /// <summary>Utility class for flattening annotations.</summary>
    /// <remarks>
    /// Utility class for flattening annotations.
    /// <para />
    /// This class can be used to remove interactive elements from a PDF document.
    /// </remarks>
    public class PdfAnnotationFlattener {
        private readonly PdfAnnotationFlattenFactory pdfAnnotationFlattenFactory;

        /// <summary>
        /// Creates a new instance of
        /// <see cref="PdfAnnotationFlattener"/>.
        /// </summary>
        /// <param name="pdfAnnotationFlattenFactory">the factory for creating annotation flatten workers</param>
        public PdfAnnotationFlattener(PdfAnnotationFlattenFactory pdfAnnotationFlattenFactory) {
            this.pdfAnnotationFlattenFactory = pdfAnnotationFlattenFactory;
        }

        /// <summary>
        /// Creates a new instance of
        /// <see cref="PdfAnnotationFlattener"/>.
        /// </summary>
        /// <remarks>
        /// Creates a new instance of
        /// <see cref="PdfAnnotationFlattener"/>.
        /// The default factory will be used for creating annotation flatten workers.
        /// </remarks>
        public PdfAnnotationFlattener() {
            this.pdfAnnotationFlattenFactory = new PdfAnnotationFlattenFactory();
        }

        /// <summary>
        /// Flattens the annotations on the page according to the defined implementation of
        /// <see cref="iText.Kernel.Utils.Annotationsflattening.IAnnotationFlattener"/>.
        /// </summary>
        /// <param name="annotationsToFlatten">the annotations that should be flattened.</param>
        /// <param name="page">the page where the annotations are located.</param>
        public virtual void Flatten(IList<PdfAnnotation> annotationsToFlatten, PdfPage page) {
            if (page == null) {
                throw new PdfException(MessageFormatUtil.Format(KernelExceptionMessageConstant.ARG_SHOULD_NOT_BE_NULL, "page"
                    ));
            }
            if (annotationsToFlatten == null) {
                throw new PdfException(MessageFormatUtil.Format(KernelExceptionMessageConstant.ARG_SHOULD_NOT_BE_NULL, "annotationsToFlatten"
                    ));
            }
            foreach (PdfAnnotation pdfAnnotation in annotationsToFlatten) {
                IAnnotationFlattener worker = pdfAnnotationFlattenFactory.GetAnnotationFlattenWorker(pdfAnnotation.GetSubtype
                    ());
                worker.Flatten(pdfAnnotation, page);
            }
        }

        /// <summary>
        /// Flattens all annotations on the page according to the defined implementation of
        /// <see cref="iText.Kernel.Utils.Annotationsflattening.IAnnotationFlattener"/>.
        /// </summary>
        /// <param name="page">the page where the annotations are located.</param>
        public virtual void Flatten(PdfPage page) {
            if (page == null) {
                throw new PdfException(MessageFormatUtil.Format(KernelExceptionMessageConstant.ARG_SHOULD_NOT_BE_NULL, "page"
                    ));
            }
            Flatten(page.GetAnnotations(), page);
        }
    }
}