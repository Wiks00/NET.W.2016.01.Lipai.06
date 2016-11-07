using System;

namespace Task1
{
    public sealed class Customer : IFormattable
    {
        public string Name { get; set; }
        public decimal Revenue { get; set; }
        public string ContactPhone { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="name">Name of customer</param>
        /// <param name="contactPhone">ContactPhone of customer</param>
        /// <param name="revenue">Revenue of customer</param>
        public Customer(string name = "Anonim", string contactPhone = "+1(425)555-0100", decimal revenue = 100000)
        {
            Name = name;
            Revenue = revenue;
            ContactPhone = contactPhone;
        }

        /// <summary>
        /// Convert customer into string representation
        /// </summary>
        /// <returns>String representation of customer</returns>
        public override string ToString()
        {
            return $"Customer record: {Name}, {Revenue}, {ContactPhone}";
        }

        /// <summary>
        /// Convert customer into string representation
        /// </summary>
        /// <param name="format">format of string representation</param>
        /// <param name="formatProvider">Provider of the format</param>
        /// <returns>String representation of customer</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format(formatProvider, format, this);
        }

        /// <summary>
        /// Convert customer into string representation
        /// </summary>
        /// <param name="format">format of string representation</param>
        /// <returns>String representation of customer</returns>
        public string ToString(string format)
        {
            var formatProvider = new BestFormatProvider();
            return string.Format(formatProvider, format, this);
        }
    }
}
