using Paragraff.ViewModels.DataTransferObjects;
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
        IEnumerable<SummaryPostDto> GetUserPosts(string userId);
        IEnumerable<SummaryPostDto> GetAllPosts();
        byte[] GetBookCover(Guid bookId);
    }
}
