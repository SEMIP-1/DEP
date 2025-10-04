using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Class
{
    public class Duration
    {
        public int TotalSeconds { get; set; }
        public int Hours => TotalSeconds / 3600;
        public int Minutes => (TotalSeconds % 3600) / 60;
        public int Seconds => TotalSeconds % 60;
        public Duration(int hours, int minutes, int seconds)
        {
            TotalSeconds = (hours * 3600) + (minutes * 60) + seconds;
        }
        public Duration(int totalSeconds)
        {
            TotalSeconds = totalSeconds;
        }
        public override string ToString()
        {
            // Handle the case from the requirement where D3=666s -> Minutes: 11, Seconds: 6
            if (Hours == 0 && Minutes > 0)
            {
                return $"Minutes: {Minutes}, Seconds :{Seconds}";
            }
            return $"Hours: {Hours}, Minutes :{Minutes}, Seconds :{Seconds}";
        }
        public override bool Equals(object obj)
        {
            if (obj is Duration otherDuration)
            {
                return TotalSeconds == otherDuration.TotalSeconds;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return TotalSeconds.GetHashCode();
        }
        public static Duration operator +(Duration d1, Duration d2)
        {
            return new Duration(d1.TotalSeconds + d2.TotalSeconds);
        }
        public static Duration operator +(Duration d, int seconds)
        {
            return new Duration(d.TotalSeconds + seconds);
        }

        // Overload + (int (seconds) + Duration) -> D3 = 666 + D3
        public static Duration operator +(int seconds, Duration d)
        {
            return new Duration(seconds + d.TotalSeconds);
        }

        // Overload - (Duration - Duration) -> D1 = D1 - D2
        public static Duration operator -(Duration d1, Duration d2)
        {
            // Ensure the result is not negative, or allow it depending on requirements.
            // Assuming non-negative duration is preferred.
            int resultSeconds = d1.TotalSeconds - d2.TotalSeconds;
            return new Duration(Math.Max(0, resultSeconds));
        }

        // Overload ++ (Prefix/Postfix Increment) -> D3 = ++D1 (Increase One Minute)
        public static Duration operator ++(Duration d)
        {
            // Increase by 60 seconds (one minute)
            return new Duration(d.TotalSeconds + 60);
        }

        // Overload -- (Prefix/Postfix Decrement) -> D3 = --D2 (Decrease One Minute)
        public static Duration operator --(Duration d)
        {
            // Decrease by 60 seconds (one minute), ensuring non-negative result
            int resultSeconds = d.TotalSeconds - 60;
            return new Duration(Math.Max(0, resultSeconds));
        }

        // Overload > (Greater Than) -> If (D1 > D2)
        public static bool operator >(Duration d1, Duration d2)
        {
            return d1.TotalSeconds > d2.TotalSeconds;
        }

        // Overload < (Less Than) - Required counterpart for >
        public static bool operator <(Duration d1, Duration d2)
        {
            return d1.TotalSeconds < d2.TotalSeconds;
        }

        // Overload <= (Less Than or Equal To) -> If (D1 <= D2)
        public static bool operator <=(Duration d1, Duration d2)
        {
            return d1.TotalSeconds <= d2.TotalSeconds;
        }

        // Overload >= (Greater Than or Equal To) - Required counterpart for <=
        public static bool operator >=(Duration d1, Duration d2)
        {
            return d1.TotalSeconds >= d2.TotalSeconds;
        }

        // Implicit bool conversion -> If (D1)
        public static implicit operator bool(Duration d)
        {
            // A duration is considered "true" if it is greater than zero seconds
            return d.TotalSeconds > 0;
        }

        // Explicit conversion to DateTime -> DateTime Obj = (DateTime) D1
        public static explicit operator DateTime(Duration d)
        {
            // Convert the duration relative to the start of today (Midnight)
            DateTime today = DateTime.Today;
            return today.AddSeconds(d.TotalSeconds);
        }
    }
}
