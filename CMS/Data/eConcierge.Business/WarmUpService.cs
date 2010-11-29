using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eConcierge.Business
{
    public class WarmUpService
    {
        public bool CanConnectToDatabase()
        {
            return Facade.Facade.CanConnectToDatabase();
        }
    }
}
