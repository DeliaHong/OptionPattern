using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionsPattern
{
    public class ApiGatewayOption
    {
        public OrderApi order { get; set; }
        public ProductApi product { get; set; }
    }

    public class OrderApi
    { 
        public string Get { get; set; }
        public string Create { get; set; }
    }

    public class ProductApi
    { 
        public string Get { get; set; }
        public string ExcelImport { get; set; }
    }
}
