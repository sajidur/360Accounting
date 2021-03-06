﻿using _360Accounting.Core.Entities;
using _360Accounting.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Accounting.Core
{
    public interface IFeatureSetAccessService : IService<FeatureSetAccess>
    {
        FeatureSetAccess GetByFeatureSetId(long companyId, long featureSetId);

        FeatureSetAccess GetSingle(long companyId, string userId);
    }
}
