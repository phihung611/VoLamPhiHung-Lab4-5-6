using System;

namespace BigSchool.Models
{
    internal class StringLengthAttribute : Attribute
    {
        private int v;

        public StringLengthAttribute(int v)
        {
            this.v = v;
        }

        public string ErrorMessage { get; set; }
        public int MinimumLength { get; set; }
    }
}