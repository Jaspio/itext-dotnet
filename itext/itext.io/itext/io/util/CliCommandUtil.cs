/*
This file is part of the iText (R) project.
Copyright (c) 1998-2024 Apryse Group NV
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
using System;
using iText.Commons.Utils;

namespace iText.IO.Util {
    public sealed class CliCommandUtil {
        private CliCommandUtil() {
        }

        /// <summary>
        /// Checks if the command, passed as parameter, is executable and the output version text contains
        /// expected text
        /// </summary>
        /// <param name="command">a string command to execute</param>
        /// <param name="versionText">an expected version text line</param>
        /// <returns>
        /// boolean result of checking: true - the required command is executable and the output version
        /// text is correct
        /// </returns>
        public static bool IsVersionCommandExecutable(String command, String versionText) {
            if ((command == null) || (versionText == null)) {
                return false;
            }
            try {
                String result = SystemUtil.RunProcessAndGetOutput(command, "-version");
                return result.Contains(versionText);
            }
            catch (Exception) {
                return false;
            }
        }
    }
}
