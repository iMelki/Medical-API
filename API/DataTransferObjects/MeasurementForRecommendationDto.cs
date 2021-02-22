using System.ComponentModel.DataAnnotations;

namespace API.DataTransferObjects
{
    public class MeasurementForRecommendationDto
    {
        [Required]
        public string Operator { get; set; }
        public int Platelets { get; set; }
        public float Albumin { get; set; }
    }
}