#region
// ===============================================================================
// Project Name        :    _15完整的数据库增删改查
// Project Description :   
// ===============================================================================
// Class Name          :    UserInfo
// Class Version       :    v1.0.0.0
// Class Description   :   
// Author              :    shanzm
// Create Time         :    2018-6-22 03:50:52
// Update Time         :    2018-6-22 03:50:52
// ===============================================================================
// Copyright © SHANZM-PC 2018 . All rights reserved.
// ===============================================================================
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _15完整的数据库增删改查
{
   public  class UserInfo
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string UserPwd { get; set; }

        public DateTime LastErrorDateTime { get; set; }

        public int ErrorTimes { get; set; }

        public int DelFlag { get; set; }

        public DateTime CreateDate { get; set; }

    }
}
