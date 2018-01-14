using Paragraff.ViewModels.ReviewDTOs;
using Paragraff.ViewModels.ReviewViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.DataServices.Contracts
{
    public interface ICommentService
    {
        void CreateComment(CommentReviewViewModel comment);
        IEnumerable<CommentReviewDto> GetCommentsForPost(Guid postId);
    }
}
