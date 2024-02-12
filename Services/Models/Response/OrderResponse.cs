using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Models.Response {
    public class OrderResponse {
        public float total {get;set;}
        public int idOrder {get;set;}
        public ResponseState State { get; set; }
    }
}
