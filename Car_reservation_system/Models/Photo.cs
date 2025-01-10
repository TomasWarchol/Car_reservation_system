namespace Car_reservation_system.Models
{
    public class Photo
    {
        public int ID { get; set; }

        public string ImagePath { get; set; }

        public bool IsMainPhoto { get; set; }

        
        public int AdvertisementId { get; set; }
    }
}
