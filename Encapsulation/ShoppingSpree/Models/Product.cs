using ShoppingSpree.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ShoppingSpree.Models
{
    public class Product
    {
        private const decimal COST_MIN_VALUE = 0;
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name 
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.InvalidNameExceptionMessage);
                }

                this.name = value;
            }
        }
        public decimal Cost 
        {
            get => this.cost;
            set
            {
                if (value < COST_MIN_VALUE)
                {
                    throw new ArgumentException(GlobalConstants.InvalidMoneyExecptionMessage);
                }

                this.cost = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
