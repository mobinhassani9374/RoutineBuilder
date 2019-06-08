using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RoutineBuilder.Entities
{
    public class Setting : BaseEntity<int>
    {
        public SettingKey Key { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }

    public enum SettingKey
    {
        [Display(Name = "نام کاربری برای لاگین کاربر")]
        LoginUserName = 1,

        [Display(Name = "رمزعبور برای لاگین کاربر")]
        LoginPassword = 2
    }
}
