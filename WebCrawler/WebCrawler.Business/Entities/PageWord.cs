using System;
using System.Collections;
using System.Collections.Generic;

namespace WebCrawler.Business.Entities
{
    public class PageWord : BaseEntity
    {
        public PageWord()
        {
            Id = Guid.NewGuid();
        }

        public PageWord(string word) : this()
        {
            Word = word;
        }

        public string Word { get; set; }

        public ICollection<PageUrlPageWord> Urls { get; set; }
    }
}
