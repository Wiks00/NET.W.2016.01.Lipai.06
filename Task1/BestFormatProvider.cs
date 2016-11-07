using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    public class BestFormatProvider : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : Thread.CurrentThread.CurrentCulture.GetFormat(formatType);
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if(ReferenceEquals(arg,null))
                throw new ArgumentNullException();

            IFormattable formattable = arg as IFormattable;

            string s = formattable?.ToString(format, formatProvider) ?? arg.ToString();

            if (!(arg is Customer)) return s;

            var customer = (Customer)arg;
            string name = customer.Name, revenue = customer.Revenue.ToString("C", CultureInfo.CurrentCulture), contactPhone = customer.ContactPhone;

            switch (format)
            {
                case "nnRRcc":
                    return customer.ToString();
                case "nnccRR":
                    return $"Customer record: {name}, {contactPhone}, {revenue}";
                case "RRnncc":
                    return $"Customer record: {revenue}, {name},  {contactPhone}";
                case "RRccnn":
                    return $"Customer record: {revenue}, {contactPhone}, {name}";
                case "ccnnRR":
                    return $"Customer record: {contactPhone}, {name}, {revenue}";
                case "ccRRnn":
                    return $"Customer record: {contactPhone}, {revenue}, {name}";
                case "nnRR":
                    return $"Customer record: {name}, {revenue}";
                case "nncc":
                    return $"Customer record: {name}, {contactPhone}";
                case "RRnn":
                    return $"Customer record: {revenue}, {contactPhone}";
                case "RRcc":
                    return $"Customer record: {revenue}, {name}";
                case "ccnn":
                    return $"Customer record: {contactPhone}, {name}";
                case "ccRR":
                    return $"Customer record: {contactPhone}, {revenue}";
                case "nn":
                    return $"Customer record: {name}";
                case "RR":
                    return $"Customer record: {revenue}";
                case "cc":
                    return $"Customer record: {contactPhone}";
                default:
                    throw new FormatException($"Unknown format: {format}");
            }
        }
    }
}
