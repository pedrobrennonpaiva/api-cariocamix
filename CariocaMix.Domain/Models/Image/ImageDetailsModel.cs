using System;

namespace CariocaMix.Domain.Models.Image
{
    public class ImageDetailsModel
    {
        public long Id { get; set; }

        public DateTime RegisterDate { get; set; }

        public string Name { get; set; }

        public string ContentType { get; set; }

        public byte[] Data { get; set; }
    }
}
