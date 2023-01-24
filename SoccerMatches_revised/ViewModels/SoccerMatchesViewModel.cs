using System.Collections.Generic;

namespace SoccerMatches_revised.ViewModels
{
    public class SoccerMatchesViewModel
    {
        public IEnumerable<SoccerMatchViewModel> SoccerMatches { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
