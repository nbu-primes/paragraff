using Paragraff.ViewModels.PostViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.DataServices.Contracts
{
    public interface IPostService
    {
        void CreatePost(NewPostViewModel postVm, string userId);
    }
}
