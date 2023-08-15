using System;

namespace Sample.RemoveFromList
{
    public class Customer : System.IComparable
    {
        private static SortOrder _order;

        public enum SortOrder
        {
            Ascending = 0,
            Descending = 1
        }

        public Customer(int id, string name)
            : this(id, name, "Other")
        { }

        public Customer(int id, string name, string rating)
        {
            this.Id = id;
            this.Name = name;
            this.Rating = rating;
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }

        public static SortOrder Order
        {
            get { return _order; }
            set { _order = value; }
        }

        public override bool Equals(Object obj)
        {
            bool retVal = false;
            if (obj != null)
            {
                Customer custObj = (Customer)obj;
                if ((custObj.Id == this.Id) &&
                    (custObj.Name.Equals(this.Name) &&
                    (custObj.Rating.Equals(this.Rating))))
                    retVal = true;
            }
            return retVal;
        }

        public override string ToString()
        {
            return this.Id + ": " + this.Name;
        }

        public int CompareTo(Object obj)
        {
            switch (_order)
            {
                case SortOrder.Ascending:
                    return this.Name.CompareTo(((Customer)obj).Name);
                case SortOrder.Descending:
                    return (((Customer)obj).Name).CompareTo(this.Name);
                default:
                    return this.Name.CompareTo(((Customer)obj).Name);
            }
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Customer left, Customer right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(Customer left, Customer right)
        {
            return !(left == right);
        }

        public static bool operator <(Customer left, Customer right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Customer left, Customer right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(Customer left, Customer right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(Customer left, Customer right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }
    }
}