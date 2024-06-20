using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_laba
{
    public class OrderPropositions
    {
        private Client client;
        private RealEstates realEstates;
        public int CountOfPropositions => realEstates.Size;
        public OrderPropositions(Client client, RealEstates realEstates)
        {
            if (realEstates.Size > 4)
            {
                throw new ArgumentException("count of realEstate must be smaller than 5");
            }
            this.client = client;
            this.realEstates = realEstates;
        }
        public OrderPropositions(Client client)
        {
            this.client = client;
            realEstates = new RealEstates();
        }
        public void AddProposition(RealEstate realEstate)
        {
            if (realEstates.Size > 4)
            {
                Console.WriteLine("you can't add new realEstate");
            }
            else
            {
                realEstates.AddRealEstate(realEstate);
            }
        }
        public void CancelProposition(RealEstate realEstate)
        {
            realEstates.RemoveRealEstate(realEstate);
        }
        public bool FindNeededProposition(decimal price, RealEstateType realEstateType)
        {
           return realEstates.IsConsistNeededProposition(price, realEstateType);
        }
    }
}
