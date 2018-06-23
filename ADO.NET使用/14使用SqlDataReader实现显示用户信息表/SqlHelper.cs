#region
// ===============================================================================
// Project Name        :    _14使用SqlDataReader实现显示用户信息表
// Project Description :   
// ===============================================================================
// Class Name          :    SqlHelper
// Class Version       :    v1.0.0.0
// Class Description   :   
// Author              :    shanzm
// Create Time         :    2018-6-21 00:22:08
// Update Time         :    2018-6-21 00:22:08
// ===============================================================================
// Copyright © SHANZM-PC 2018 . All rights reserved.
// ===============================================================================
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace _14使用SqlDataReader实现显示用户信息表
{
    public class SqlHelper
    {
        public static string GetConnStr()
        {
            return ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        }
    }
}
