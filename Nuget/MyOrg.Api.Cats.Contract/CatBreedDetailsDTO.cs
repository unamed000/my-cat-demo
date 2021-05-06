namespace MyOrg.Api.Cats.Contract
{
    public class CatBreedDetailsDTO
    {
        public string url { get; set; }
        
        public CatBreedDetailsInfoDTO[] breeds { get; set; }
    }

    public class CatBreedDetailsInfoDTO
    {
        public string id { get; set; }
        
        public string name { get; set; }
        
        public string description { get; set; }
    }
}