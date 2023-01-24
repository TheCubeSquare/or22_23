using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerMatches_revised.ViewModels
{
    public class PagingInfo
    {
        public int CurrentPage { get; set; }
        public bool Ascending { get; set; }
        public int Sort { get; set; }
    }
}
