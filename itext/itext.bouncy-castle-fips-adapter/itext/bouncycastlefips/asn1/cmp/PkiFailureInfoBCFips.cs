/*
This file is part of the iText (R) project.
Copyright (c) 1998-2023 Apryse Group NV
Authors: Apryse Software.

This program is offered under a commercial and under the AGPL license.
For commercial licensing, contact us at https://itextpdf.com/sales.  For AGPL licensing, see below.

AGPL licensing:
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
using Org.BouncyCastle.Asn1.Cmp;
using iText.Bouncycastlefips.Asn1;
using iText.Commons.Bouncycastle.Asn1.Cmp;

namespace iText.Bouncycastlefips.Asn1.Cmp {
    /// <summary>
    /// Wrapper class for
    /// <see cref="Org.BouncyCastle.Asn1.Cmp.PkiFailureInfo"/>.
    /// </summary>
    public class PkiFailureInfoBCFips : Asn1ObjectBCFips, IPkiFailureInfo {
        /// <summary>
        /// Creates new wrapper instance for
        /// <see cref="Org.BouncyCastle.Asn1.Cmp.PkiFailureInfo"/>.
        /// </summary>
        /// <param name="pkiFailureInfo">
        /// 
        /// <see cref="Org.BouncyCastle.Asn1.Cmp.PkiFailureInfo"/>
        /// to be wrapped
        /// </param>
        public PkiFailureInfoBCFips(PkiFailureInfo pkiFailureInfo)
            : base(pkiFailureInfo) {
        }

        /// <summary>Gets actual org.bouncycastle object being wrapped.</summary>
        /// <returns>
        /// wrapped
        /// <see cref="Org.BouncyCastle.Asn1.Cmp.PkiFailureInfo"/>.
        /// </returns>
        public virtual PkiFailureInfo GetPkiFailureInfo() {
            return (PkiFailureInfo)GetEncodable();
        }

        /// <summary><inheritDoc/></summary>
        public virtual int IntValue() {
            return GetPkiFailureInfo().IntValue;
        }
    }
}