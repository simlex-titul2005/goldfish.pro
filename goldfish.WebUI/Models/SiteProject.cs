﻿using SX.WebCore.DbModels.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace goldfish.WebUI.Models
{
    [Table("D_SITE_PROJECT")]
    public class SiteProject : SxMaterial
    {
        [Url(ErrorMessageResourceType = typeof(SX.WebCore.Resources.Messages), ErrorMessageResourceName = "ValidUrlField")]
        [MaxLength(255, ErrorMessageResourceType = typeof(SX.WebCore.Resources.Messages), ErrorMessageResourceName = "MaxLengthField")]
        [Display(Name ="Ссылка")]
        public string Url { get; set; }

        public virtual ICollection<SiteProjectSecurityItem> SecurityItems { get; set; }
    }
}