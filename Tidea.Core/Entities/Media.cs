namespace Tidea.Core.Entities
{
    public class Media
    {
        public string Id { get; set; }
        public string CampaingId { get; set; }
        public byte[] Image { get; set; }
        public string VideoUrl { get; set; }
    }
}