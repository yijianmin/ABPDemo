﻿using Abp.Runtime.Validation;
using MPACore.PhoneBook.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MPACore.PhoneBook.PhoneBooks.Dtos
{
    public class GetPersonInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string FilterText { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }
    }

    //ViewModel => dto => model   dto（Data Transfer Object）数据传输对象
}
