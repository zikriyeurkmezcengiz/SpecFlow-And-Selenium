using System;

namespace VCManager.Core
{
    public class VideoFilePart
    {
        public VideoFilePart(int number, string name)
        {
            Number = number;
            Name = name;

            var tmp = number.ToString("D2") + "-" + name;
            if (!VideoFileParser.BasicRegex.IsMatch(tmp)) throw new ArgumentException();
        }

        public int Number { get; }
        public string Name { get; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != GetType())
                return false;
            if (obj == this)
                return true;

            var that = (VideoFilePart) obj;

            return string.CompareOrdinal(this.Name, that.Name) == 0 &&
                   this.Number == that.Number;
        }

        protected bool Equals(VideoFilePart other)
        {
            return Number == other.Number && string.Equals(Name, other.Name);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Number * 397) ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }

        public override string ToString()
        {
            return Number.ToString("D2") + "-" + Name;
        }
    }
}