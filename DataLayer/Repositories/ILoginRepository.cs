using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public interface ILoginRepository
   {
        /// <summary>
        /// چک کردن صحت اطلاعات برای وارد شدن به حساب کاربری
        /// </summary>
        /// <param name="username"> نام کاربری </param>
        /// <param name="password"> رمزعبور </param>
        /// <returns></returns>
       bool IsExistUser(string username, string password);
   }
}
