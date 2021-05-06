namespace MyOrg.Api.Cats.Contract
{
    public class CatBreedDTO
    {
        public string name { get; set; }
        
        public string id { get; set; }
        
        public CatBreedImageDTO Image { get; set; }
    }

    public class CatBreedImageDTO
    {
        public string url { get; set; }
    }
}