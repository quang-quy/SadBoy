﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnVM : BenhAn
    {
        
    }

    public class BenhAnCreateVM : BenhAnVM
    {
        [Required(ErrorMessage = "ID bệnh án là bắt buộc.")]
        public new decimal Idba { get; set; }
    }
}