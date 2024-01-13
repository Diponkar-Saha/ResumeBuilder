﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Persistence.Features.Membership
{
    public class ApplicationClaim
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }


    }
}
