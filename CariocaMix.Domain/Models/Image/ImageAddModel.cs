namespace CariocaMix.Domain.Models.Image
{
    public class ImageAddModel
    {
        public ImageAddModel(string name, string contentType, byte[] data)
        {
            Name = name;
            ContentType = contentType;
            Data = data;
        }

        public string Name { get; set; }

        public string ContentType { get; set; }

        public byte[] Data { get; set; }
    }
}
