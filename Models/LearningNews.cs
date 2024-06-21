using System;

/*
 *  学习园地数据模型
 */

namespace Niuniumama.Models
{
    public class LearningNews
    {
        // 学习标题
        public string Title { get; set; }    
        // 发布日期
        public DateTime PublishDate { get; set; } 
        // 发布来源
        public string Source { get; set; }
        // 学习内容
        public string Content { get; set; }
        // 编辑人
        public string Editor { get; set; }
        // 核审人
        public string Reviewer { get; set; }
    }
}