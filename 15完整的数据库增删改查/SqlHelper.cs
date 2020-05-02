#region
// ===============================================================================
// Project Name        :    _15完整的数据库增删改查
// Project Description :   
// ===============================================================================
// Class Name          :    SqlHelper
// Class Version       :    v1.0.0.0
// Class Description   :   
// Author              :    shanzm
// Create Time         :    2018-6-21 21:40:28
// Update Time         :    2018-6-21 21:40:28
// ===============================================================================
// Copyright © SHANZM-PC 2018 . All rights reserved.
// ===============================================================================
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace _15完整的数据库增删改查
{
    public class SqlHelper
    {
        public static string GetConnStr()
        {
            return ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        }
    }
}
