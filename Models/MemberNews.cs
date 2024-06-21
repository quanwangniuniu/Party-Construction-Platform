using System;

/*
 *  党员风采数据模型
 */

namespace Niuniumama.Models
{
    public class MemberNews
    {
        // 党员风采标题
        public string Title { get; set; }    
        // 发布日期
        public DateTime PublishDate { get; set; } 
        // 发布来源
        public string Source { get; set; }
        // 风采展示内容
        public string Content { get; set; }
        // 编辑人
        public string Editor { get; set; }
        // 核审人
        public string Reviewer { get; set; }
    }
}