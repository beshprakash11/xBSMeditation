using System.ComponentModel.DataAnnotations.Schema;

namespace meditation.Core.Models.Domain
{
    public class MantraModel:BaseModel
    {
        public string MantraName { get; set; }
        public string MantraImagePath { get; set; }
        public string MantraAudioPath { get; set; }
        public string MantraDescription { get; set; }
        public string LordImagePath { get; set; }
        public string LordThreedPath { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [NotMapped] // Prevents this property from being mapped to the database
        public IFormFile MantraImage { get; set; }

        [NotMapped]
        public IFormFile MantraAudio { get; set; }

        [NotMapped]
        public IFormFile LordImage { get; set; }

        [NotMapped]
        public IFormFile LordThreed { get; set; }
    }
}
