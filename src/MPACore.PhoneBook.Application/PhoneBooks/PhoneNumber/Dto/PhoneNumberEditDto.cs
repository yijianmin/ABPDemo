using MPACore.PhoneBook.PhoneBooks.Dtos;
using MPACore.PhoneBook.PhoneBooks.Persons;
using MPACore.PhoneBook.PhoneBooks.PhoneNumbers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MPACore.PhoneBook.PhoneBooks.PhoneNumber.Dto
{
    public class PhoneNumberEditDto
    {
        /// <summary>
        /// 电话号码
        /// </summary>
        [Required]
        [MaxLength(PhoneBookConsts.MaxPhoneNumberLength)]
        public string Number { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public PhoneNumberType PhoneNumberType { get; set; }









        //public int PersonId { get; set; }

        //public PersonEditDto Person { get; set; }

        //public DateTime CreationTime { get; set; }
    }
}
