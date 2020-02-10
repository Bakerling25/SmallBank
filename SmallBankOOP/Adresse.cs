using System;
using System.Collections.Generic;
using System.Text;

namespace SmallBankOOP
{
    class Adresse
    {
        private string streetName;
        private string cityName;
        private int zipCode;
        private int houseNumber;
        private int etageNumber;

        public string StreetName { get { return streetName; } set { streetName = value; } }
        public string CityName { get { return cityName; } set { cityName = value; } }
        public int ZipCode { get { return zipCode; } set { zipCode = value; } }
        public int HouseNumber { get { return houseNumber; } set { houseNumber = value; } }
        public int EtageNumber { get { return etageNumber; } set { etageNumber = value; } }

        public Adresse(string streetN, string cityN, int zipC, int houseN)
        {
            StreetName = streetN;
            CityName = cityN;
            ZipCode = zipC;
            HouseNumber = houseN;
        }
        public Adresse(string streetN, string cityN, int zipC, int houseN, int etageN)
        {
            StreetName = streetN;
            CityName = cityN;
            ZipCode = zipC;
            HouseNumber = houseN;
            EtageNumber = etageN;
        }
    }
}
