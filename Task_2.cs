using System;
using System.Collections.Generic;
using System.IO;

namespace Practice_DZ_10_Dedok
{
    public class Article
    {
        public string Title { get; set; }
        public int CharacterCount { get; set; }
        public string Preview { get; set; }

        public Article() { }

        public Article(string title, int characterCount, string preview)
        {
            Title = title;
            CharacterCount = characterCount;
            Preview = preview;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Characters: {CharacterCount}, Preview: {Preview}";
        }
    }

    public class Journal
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public DateTime PublicationDate { get; set; }
        public int PageCount { get; set; }
        public List<Article> Articles { get; set; } = new List<Article>();

        public Journal() { }

        public Journal(string title, string publisher, DateTime publicationDate, int pageCount)
        {
            Title = title;
            Publisher = publisher;
            PublicationDate = publicationDate;
            PageCount = pageCount;
        }

        public override string ToString()
        {
            return $"Journal: {Title}, Publisher: {Publisher}, Date: {PublicationDate.ToShortDateString()}, Pages: {PageCount}, Articles: {string.Join("; ", Articles)}";
        }
    }
}
