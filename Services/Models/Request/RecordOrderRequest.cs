using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Models.Request {
    public class RecordOrderRequest {
        public DateOnly From {get;set;}
        public DateOnly To {get;set;}
        public int PageSize {get;set;}
        public int PageNumber {get;set;}
        public int? UserId {get;set;}
    }
}
