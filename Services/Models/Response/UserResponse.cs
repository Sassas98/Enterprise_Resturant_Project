using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Models.Response {
    public class UserResponse {
        public string State { get; set; } = string.Empty;
        public List<Claim> Claims { get; set; } = null!;

    }
}
