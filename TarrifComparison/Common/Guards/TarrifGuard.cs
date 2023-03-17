using System;

namespace TarrifComparison.Common.Guards
{
    public static class TarrifGuard
    {
        public static decimal GuardAgainstZeroOrNegative(this decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return value;
        }
        public static int GuardAgainstZeroOrNegative(this int value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return value;
        }
    }
}
