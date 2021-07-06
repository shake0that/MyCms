using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageGroupRepository:IDisposable
    {
        /// <summary>
        /// خواندن تمام گروه های خبری از دیتابیس
        /// </summary>
        /// <returns></returns>
        IEnumerable<PageGroup> GetAllGroups();
        /// <summary>
        /// خواندن یک گروه خبری با استفاده از کلید آن 
        /// </summary>
        /// <param name="groupId"> کلید گروه خبری </param>
        /// <returns></returns>
        PageGroup GetGroupById(int groupId);
        /// <summary>
        /// اضافه کردن گروه خبری
        /// </summary>
        /// <param name="pageGroup"> اطلاعات گروه خبری جدید </param>
        /// <returns></returns>
        bool InsertGroup(PageGroup pageGroup);
        /// <summary>
        /// ویرایش گروه خبری
        /// </summary>
        /// <param name="pageGroup"> اطلاعات گروه خبری بعد از ویرایش </param>
        /// <returns></returns>
        bool UpdateGroup(PageGroup pageGroup);
        /// <summary>
        /// خواندن گروه خبری برای حذف
        /// </summary>
        /// <param name="pageGroup"> گروه خبری مورد نظر </param>
        /// <returns></returns>
        bool DeleteGroup(PageGroup pageGroup);
        /// <summary>
        /// حذف گروه خبری با استفاده از کلید آن
        /// </summary>
        /// <param name="groupId"> کلید گروه خبری </param>
        /// <returns></returns>
        bool DeleteGroup(int groupId);
        /// <summary>
        /// اعمال تغییرات
        /// </summary>
        void save();
        /// <summary>
        /// برای نمایش گروه های خبری در صفحه
        /// </summary>
        /// <returns></returns>
        IEnumerable<ShowGroupViewModel> GetGroupsForView();
    }
}
