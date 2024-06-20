using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_laba
{
   public enum RealEstateType
   {
        oneRoomFlat,
        twoRoomFlat,
        threeRoomFlat,
        privateHouse
   }
    public class RealEstate
    {
        private decimal price;
        public decimal Price
        {
            get { return price; }
        }
        private bool isRepaired;
        public bool IsRepaired { get { return isRepaired;} }
        RealEstateType realEstateType;
        public RealEstateType RealEstateType
        {
            get { return realEstateType; }
        }
        private string location;
        public string Location { get { return location; } }
        public RealEstate(decimal price, bool isRepaired, RealEstateType realEstateType, string location) 
        { 
            this.price = price;
            this.isRepaired = isRepaired;
            this.realEstateType = realEstateType;
            this.location = location;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Info about flat: \n Type: {realEstateType} \n Location: {location} \n Is it repaired: {isRepaired} \n Price: {price}");
        }
        public void ChangePrice(decimal price)
        {
            this.price = price;
        }
        public void ChangeIsRepaired(bool isRepaired)
        {
            this.isRepaired = isRepaired;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            RealEstate? realEstate = obj as RealEstate;
            if (this.Price == realEstate.Price && this.isRepaired == realEstate.IsRepaired && this.RealEstateType == realEstate.RealEstateType && this.Location == realEstate.Location)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
