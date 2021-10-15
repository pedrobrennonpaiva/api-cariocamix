namespace CariocaMix.Domain.Models.Image
{
    public class ImageUpdateModel
    {
        public string Name { get; set; }

        public string ContentType { get; set; }

        public byte[] Data { get; set; }
    }
}
