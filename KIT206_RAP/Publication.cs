using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP
{
    internal class Publication
    {
        // Properties
        public bool Q1Ranked { get; set; }
        public DateTime PublicationYear { get; set; }
        public string Title { get; set; }
        public string DOI { get; set; }
        public List<Researcher> Authors { get; set; }
        public string CiteAs { get; set; }
        public DateTime AvailabilityDate { get; set; }
        public int PageCount { get; set; }
        public PublicationType Type { get; set; }
        public RankingType Ranking { get; set; }

        // Constructor
        public Publication(bool q1Ranked, DateTime publicationYear, string title, string doi, List<Researcher> authors, string citeAs, DateTime availabilityDate, int pageCount, PublicationType type, RankingType ranking)
        {
            Q1Ranked = q1Ranked;
            PublicationYear = publicationYear;
            Title = title;
            DOI = doi;
            Authors = authors;
            CiteAs = citeAs;
            AvailabilityDate = availabilityDate;
            PageCount = pageCount;
            Type = type;
            Ranking = ranking;
        }

        // Method to count cumulative publications
        public int cumulativePubs()
        {
            return Authors.Sum(author => author.Publications.Count);
        }
    }

    public enum PublicationType
    {
        Conference,
        Journal
    }

    public enum RankingType
    {
        Q1,
        Q2,
        Q3,
        Q4
    }
 
}
