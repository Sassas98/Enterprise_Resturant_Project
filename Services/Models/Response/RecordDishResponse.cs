using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Models.Response {
    public class RecordDishResponse {
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}
