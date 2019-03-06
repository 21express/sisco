using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Devenlab.Common.Helpers
{
    public class InWordsHelper
    {
        private static readonly string[] Dasar = { "", "satu", "dua", "tiga", "empat", "lima", "enam", "tujuh", "delapan", "sembilan" };
        private static readonly long[] Angka = {
                1000000000,
                1000000,
                1000,
                100,
                10,
                1
            };
        private static readonly string[] Satuan = { "milyar", "juta", "ribu", "ratus", "puluh", "" };

        public static string Spell(decimal n)
        {
            var str = "";
            var i = 0;
            while (n != 0)
            {
                var count = (int)(n / Angka[i]);
                if (count >= 10)
                    str += Spell(count) + " " + Satuan[i] + " ";
                else if (count > 0 && count < 10)
                    str += Dasar[count] + " " + Satuan[i] + " ";

                n -= Angka[i] * count;
                i++;
            }

            str = Regex.Replace(str, @"satu puluh (\w+)", "$1 belas");
            str = Regex.Replace(str, "satu (ribu|ratus|puluh|belas)", "se$1");

            return str.Replace("  ", " ");
        }
    }
}
