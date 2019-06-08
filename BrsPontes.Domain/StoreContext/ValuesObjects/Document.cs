using System;
using System.Collections.Generic;
using System.Text;

namespace BrsPontes.Domain.StoreContext.ValuesObjects
{
    public class Document
    {
        public Document(string number)
        {
            Number = number;
        }

        public string Number { get; private set; }

        public override string ToString()
        {
            return Number;
        }
    }
}
