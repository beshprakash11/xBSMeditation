using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xBSMeditation.MVVM.Models
{
    public class MantraModel:BaseModel
    {
        public string MantraName { get; set; }
        public string  MantraImage { get; set; }
        public string MantraAudio { get; set; }
        public string MantraDescription { get; set; }
        public string LordImage { get; set; }
        public string LordThreed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
