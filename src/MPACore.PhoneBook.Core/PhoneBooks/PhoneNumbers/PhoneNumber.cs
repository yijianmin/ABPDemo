using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MPACore.PhoneBook.PhoneBooks.Persons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MPACore.PhoneBook.PhoneBooks.PhoneNumbers
{
    public class PhoneNumber :Entity<long>, IHasCreationTime
    {
        /// <summary>
        /// 电话号码
        /// </summary>
        [Required]
        [MaxLength(11)]
        public string Number { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public PhoneNumberType PhoneNumberType { get; set; }

        //EF2.0没有贪婪加载，2.1有贪婪加载

        public int PersonId { get; set; }

        public Person Person { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
