#region
// ===============================================================================
// Project Name        :    _07实现下拉列表选取省市
// Project Description :   
// ===============================================================================
// Class Name          :    AreaInfo
// Class Version       :    v1.0.0.0
// Class Description   :   
// Author              :    shanzm
// Create Time         :    2018-6-17 23:49:58
// Update Time         :    2018-6-17 23:49:58
// ===============================================================================
// Copyright © SHANZM-PC 2018 . All rights reserved.
// ===============================================================================
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07实现下拉列表选取省市
{
   public   class AreaInfo
    {
        public string  AreaName { get; set; }

        public int  AreaPid { get; set; }

        public int AreaId { get; set; }

       //重写ToString方法
        public override string ToString()
        {
            return AreaName;
        }
    }
}
