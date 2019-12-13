using System;

namespace Guesthouse.Services.Conveniences.Dto
{
    public class ConvenienceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal? Cost { get; set; }
        public bool IsBlock { get; set; }
    }
}