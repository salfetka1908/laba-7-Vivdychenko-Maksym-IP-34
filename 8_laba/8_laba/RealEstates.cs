using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_laba
{
    public class RealEstates
    {
        private List<RealEstate> realEstates;
        public int Size => realEstates.Count;
        public RealEstates()
        {
            realEstates = new List<RealEstate>();
        }
        public RealEstate this[int index]
        {
            get
            {
                if (index < 0 || index >= realEstates.Count)
                {
                    throw new IndexOutOfRangeException("Індекс поза межами допустимого діапазону.");
                }
                return realEstates[index];
            }
        }
        public void AddRealEstate(RealEstate realEstate)
        {
            if (!realEstates.Contains(realEstate))
            {
                realEstates.Add(realEstate);
            }
        }
        public void RemoveRealEstate(RealEstate realEstate)
        {
            realEstates.Remove(realEstate);
        }
        public void SortByTypes()
        {
            realEstates.Sort(new RealEstateComparer(SortFieldRealEstate.Type));
        }
        public void SortByPrice()
        {
            realEstates.Sort(new RealEstateComparer(SortFieldRealEstate.Price));
        }
        public RealEstates FindByType(RealEstateType realEstateType)
        {
            RealEstates returnValue = new RealEstates();
            foreach (RealEstate realEstate in realEstates)
            {
                if(realEstate.RealEstateType == realEstateType)
                {
                    returnValue.AddRealEstate(realEstate);
                }
            }
            return returnValue;
        }
        public RealEstates FindBySmallerPrice(decimal price)
        {
            RealEstates returnValue = new RealEstates();
            foreach(RealEstate realEstate in realEstates)
            {
                if(realEstate.Price <= price)
                {
                    returnValue.AddRealEstate(realEstate);
                }
            }
            return returnValue;
        }
        public bool IsConsistNeededProposition(decimal price, RealEstateType realEstateType)
        {
            RealEstates neededByPrice = FindBySmallerPrice(price);
            RealEstates neededRealEstate = neededByPrice.FindByType(realEstateType);
            if(neededRealEstate.Size == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    internal enum SortFieldRealEstate
    {
        Type,
        Price
    }
    internal class RealEstateComparer : IComparer<RealEstate>
    {
        SortFieldRealEstate sortFieldRealEstate;
        public RealEstateComparer(SortFieldRealEstate sortFieldRealEstate)
        {
            this.sortFieldRealEstate = sortFieldRealEstate;
        }
        public int Compare(RealEstate x, RealEstate y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException();
            }
            if (sortFieldRealEstate == SortFieldRealEstate.Price)
            {
                return x.Price.CompareTo(y.Price);
            }
            else
            {
                return x.RealEstateType.CompareTo(y.RealEstateType);
            }
        }
    }
}
