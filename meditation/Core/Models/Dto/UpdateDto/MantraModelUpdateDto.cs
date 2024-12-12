namespace meditation.Core.Models.Dto.UpdateDto
{
    public class MantraModelUpdateDto:BaseModel
    {
        public string MantraName { get; set; }
        public string MantraImage { get; set; }
        public string MantraAudio { get; set; }
        public string MantraDescription { get; set; }
        public string LordImage { get; set; }
        public string LordThreed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
