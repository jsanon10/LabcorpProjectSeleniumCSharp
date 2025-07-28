using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabcorpAutomation.Context
{
    public class PositionDetailsContext
    {
        public string positionName { get; set; }
        public string positionID { get; set; }
        public string positionLocation { get; set; }
        public string firstSentence { get; set; }
        public IDictionary<string, string> positionDetails { get;set; } = new Dictionary<string, string>();
    }


}
