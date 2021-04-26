using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace NewTaxiProject.AbstractFactory
{
    public class Choose_Type
    {
        public static AbstractFactory ChooseType()
        {
            var factoryType = ConfigurationManager.AppSettings["factoryType"];
            // AbstractFactory factory;

            switch (factoryType)
            {
                case "file":
                    return new FactoryTxt();




                default:
                    return new FactoryList();

            }


        }

    }
}
