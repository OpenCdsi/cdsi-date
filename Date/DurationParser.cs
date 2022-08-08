﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCdsi.Date
{
    public readonly partial struct Duration
    {
        public static Duration Parse(string text)
        {
            text = text.Replace(" ", "");
            var values = new List<Interval>();
            do
            {
                values.Add(Interval.Parse(text));
                text = Interval.re.Replace(text, "");

            } while (!string.IsNullOrEmpty(text));

            values.Sort(new IntervalUnitComparer());

            return new Duration()
            {
                Values = values.ToArray()
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="result"></param>
        /// <returns>If the method returns false then the result variable is set to MinValue. </returns>
        public static bool TryParse(string text, out Duration result)
        {
            try
            {
                result = Parse(text);
                return true;
            }
            catch (ArgumentException)
            {
                result = MinValue;
                return false;
            }
        }
    }
}