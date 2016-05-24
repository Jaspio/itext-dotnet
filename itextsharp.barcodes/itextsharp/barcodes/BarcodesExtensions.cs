﻿using System;
using System.Collections.Generic;
using System.Text;

namespace iTextSharp.Barcodes
{
    internal static class BarcodesExtensions {
        public static byte[] GetBytes(this String str, String encoding) {
            return Encoding.GetEncoding(encoding).GetBytes(str);
        }

        public static String JSubstring(this String str, int beginIndex, int endIndex)
        {
            return str.Substring(beginIndex, endIndex - beginIndex);
        }

        public static T JRemoveAt<T>(this IList<T> list, int index) {
            T value = list[index];
            list.RemoveAt(index);

            return value;
        }
    }
}