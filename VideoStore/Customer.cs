﻿using System;
using System.Collections.Generic;

namespace VideoStore
{
    public class Customer
    {
        public Customer(string name)
        {
            this.name = name;
        }

        public void AddRental(Rental rental)
        {
            rentals.Add(rental);
        }

        public string GetName()
        {
            return name;
        }

        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            String result = "Rental Record for " + GetName() + "\n";

            foreach (var rental in rentals)
            {
                double thisAmount = 0;

                // determines the amount for each line
                switch (rental.GetMovie().GetPriceCode())
                {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (rental.GetDaysRented() > 2)
                            thisAmount += (rental.GetDaysRented() - 2) * 1.5;
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += rental.GetDaysRented() * 3;
                        break;
                    case Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (rental.GetDaysRented() > 3)
                            thisAmount += (rental.GetDaysRented() - 3) * 1.5;
                        break;
                }

                frequentRenterPoints++;

                if (rental.GetMovie().GetPriceCode() == Movie.NEW_RELEASE
                        && rental.GetDaysRented() > 1)
                    frequentRenterPoints++;

                result += "\t" + rental.GetMovie().GetTitle() + "\t"
                                    + thisAmount + "\n";
                totalAmount += thisAmount;

            }

            result += "You owed " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points\n";


            return result;
        }


        private String name;
        private List<Rental> rentals = new List<Rental>();
    }
}
