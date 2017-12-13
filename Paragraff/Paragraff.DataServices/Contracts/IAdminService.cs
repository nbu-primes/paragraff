using Paragraff.Data.Models;
using Paragraff.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.DataServices.Contracts
{
    public interface IAdminService
    {
        List<AllUsersViewModel> DisplayAllUsers();
    }
}
