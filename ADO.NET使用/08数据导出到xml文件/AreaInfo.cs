#region
// ===============================================================================
// Project Name        :    _08数据导出到xml文件
// Project Description :   
// ===============================================================================
// Class Name          :    AreaInfo
// Class Version       :    v1.0.0.0
// Class Description   :   
// Author              :    shanzm
// Create Time         :    2018-6-18 02:38:59
// Update Time         :    2018-6-18 02:38:59
// ===============================================================================
// Copyright © SHANZM-PC 2018 . All rights reserved.
// ===============================================================================
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08数据导出到xml文件
{
    public class AreaInfo
    {
        public int AreaId { get; set; }

        public string AreaName { get; set; }

        public int AreaPid { get; set; }

        public AreaInfo(int areaId, string areaName, int areaPid)
        {
            this.AreaId = areaId;
            this.AreaName = areaName;
            this.AreaPid = areaPid;
        }
    }
}
