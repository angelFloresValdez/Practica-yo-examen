using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConexionEF.Models
{
    public class UserListViewModel
    {
        public UserListViewModel()
        {
            UserList = new List<UserViewModel>();
            MessageConfirmed = string.Empty;
            MessageRemoved = string.Empty;

        }
        
        public List<UserViewModel> UserList { get; set; }

        public string MessageConfirmed { get; set; }
        public string MessageRemoved { get; set; }
    }
}