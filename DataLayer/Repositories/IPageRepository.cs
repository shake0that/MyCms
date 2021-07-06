using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageRepository:IDisposable
    {
        /// <summary>
        /// خواندن تمام خبر ها
        /// </summary>
        /// <returns></returns>
        IEnumerable<Page> GetAllPage();
        /// <summary>
        /// خواندن خبر مورد نظر با استفاده از کلید
        /// </summary>
        /// <param name="pageId"> کلید خبر </param>
        /// <returns></returns>
        Page GetPageById(int pageId);
        /// <summary>
        /// اضافه کردن خبر
        /// </summary>
        /// <param name="page"> خبر </param>
        /// <returns></returns>
        bool InsertPage(Page page);
        /// <summary>
        /// ویرایش خبر
        /// </summary>
        /// <param name="page"> خبر ویرایش شده </param>
        /// <returns></returns>
        bool UpdatePage(Page page);
        /// <summary>
        /// حذف خبر
        /// </summary>
        /// <param name="page"> خبر </param>
        /// <returns></returns>
        bool DeletePage(Page page);
        /// <summary>
        /// حذف خبر با استفاده از کلید 
        /// </summary>
        /// <param name="pageId"> کلید خبر </param>
        /// <returns></returns>
        bool DeletePage(int pageId);
        /// <summary>
        /// اعمال تغییرات
        /// </summary>
        void Save();

        /// <summary>
        /// خواندن 4 تا از پربازدیدترین اخبار
        /// </summary>
        /// <param name="take"></param>
        /// <returns></returns>
        IEnumerable<Page> TopNews(int take = 4);
        /// <summary>
        /// خواندن صفحاتی ک برای نمایش در اسلایدر است
        /// </summary>
        /// <returns></returns>
        IEnumerable<Page> PagesInSlider();
        /// <summary>
        /// خواندن 4 خبر اخیرا اضافه شده
        /// </summary>
        /// <param name="take"></param>
        /// <returns></returns>
        IEnumerable<Page> LastNews(int take = 4);
        /// <summary>
        /// نمایش اخبار بر اساس گروه خبری
        /// </summary>
        /// <param name="groupId"> کلید گروه خبری </param>
        /// <returns></returns>
        IEnumerable<Page> ShowPageByGroupId(int groupId);
        /// <summary>
        /// جستجوی خبر
        /// </summary>
        /// <param name="search"> کلمه ی جست و جو شده </param>
        /// <returns></returns>
        IEnumerable<Page> SearchPage(string search);

    }
}
