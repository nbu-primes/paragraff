using Paragraff.ViewModels.ReviewDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.DataServices.Contracts
{
    public interface IReviewService
    {
        PostReviewDto GetPostReview(Guid postId, string userId);
        byte[] GetBookImage(Guid bookId);
        double RatePost(Guid postId, int ratedFromViewer, string userId);
    }
}
