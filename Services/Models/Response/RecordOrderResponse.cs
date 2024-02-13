using Applications.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Models.Response {
    public class RecordOrderResponse {
        public int UserId { get; set; }
        public DateOnly Date { get; set; }
        public List<RecordDishResponse> Dishes { get; set; } = null!;
    }
}
