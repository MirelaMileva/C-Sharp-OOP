using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Exceptions;
using Telephony.Models;

namespace Telephony.Core
{
    public class Engine : IEngine
    {
        private StationaryPhone stationaryPhone;
        private Smartphone smartphone;

        public Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartphone = new Smartphone();
        }
        public void Run()
        {
            string[] phoneNumbers = Console.ReadLine()
                .Split()
                .ToArray();

            string[] sites = Console.ReadLine()
                .Split()
                .ToArray();

            CallNumbers(phoneNumbers);
            BrowseSites(sites);
        }

        private void BrowseSites(string[] sites)
        {
            foreach (var url in sites)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(url));
                }
                catch (InvalidUrlException iue)
                {
                    Console.WriteLine(iue.Message);
                }
            }
        }

        private void CallNumbers(string[] phoneNumbers)
        {
            foreach (var number in phoneNumbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(number));
                    }
                    else if (number.Length == 10)
                    {
                        Console.WriteLine(smartphone.Call(number));
                    }
                    else
                    {
                        throw new InvalidNumberException();
                    }
                }
                catch (InvalidNumberException ine)
                {
                    Console.WriteLine(ine.Message);
                }

            }
        }
    }
}
