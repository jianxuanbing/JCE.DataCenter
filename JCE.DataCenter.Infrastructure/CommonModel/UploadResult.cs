/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.CommonModel
 * 文件名：UploadResult
 * 版本号：v1.0.0.0
 * 唯一标识：fad3f1f8-5cc8-4b5f-a5ff-1688541398a2
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/11 18:59:08
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/11 18:59:08
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCE.DataCenter.Infrastructure.CommonModel
{
    /// <summary>
    /// 上传结果
    /// </summary>
    public class UploadResult
    {
        /// <summary>
        /// 文件ID
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// 文件名，例如：xxx.jpg
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 文件路径，例如：~/Upload/Image/xxx.jpg
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 文件类型，image/jpeg
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 文件长度（字节数）
        /// </summary>
        public long Length { get; set; }
    }
}
