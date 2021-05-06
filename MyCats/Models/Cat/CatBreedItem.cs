using ImageSource = Xamarin.Forms.ImageSource;

namespace MyCats.Models.Cat
{
    public class CatBreedItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ImageSource ImageUrl { get; set; }
    }
}