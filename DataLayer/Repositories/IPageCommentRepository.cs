using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageCommentRepository
    {
        /// <summary>
        /// گرفتن یا خواندن تمام کامنت های یک خبر
        /// </summary>
        /// <param name="pageId"> خبر مورد نظر </param>
        /// <returns></returns>
        IEnumerable<PageComment> GetCommentByNewsId(int pageId);
        /// <summary>
        /// اظافه کردن یک کامنت به خبر
        /// </summary>
        /// <param name="comment"> کامنت مورد نظر برای اضافه کردن </param>
        /// <returns></returns>
        bool AddComment(PageComment comment);
    }
}
