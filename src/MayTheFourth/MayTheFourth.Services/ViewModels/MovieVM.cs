using MayTheFourth.Entities;
using MayTheFourth.Services.Dto;
using MayTheFourth.Utils.Validation;

namespace MayTheFourth.Services.ViewModels
{
    public class MovieVM : BaseViewModel
    {
        public MovieVM()
        {
            Characters = [];
            Planets = [];
            Vehicles = [];
            Starships = [];
        }

        public string Title { get; set; } = string.Empty;
        public int? Episode { get; set; }
        public string OpeningCrawl { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public string Producer { get; set; } = string.Empty;
        public DateTime? ReleaseDate { get; set; }

        public ICollection<Character> Characters { get; set; }
        public ICollection<Planet> Planets { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<Starship> Starships { get; set; }

       public override Movie GetEntity() =>
            new()
            {
                Id = Id,
                Title = Title,
                Episode = Episode ?? 0,
                OpeningCrawl = OpeningCrawl,
                Director = Director,
                Producer = Producer,
                ReleaseDate = ReleaseDate ?? DateTime.Now,
                Characters = Characters,
                Planets = Planets,
                Vehicles = Vehicles,
                Starships = Starships,
                CreatedAt = CreatedAt,
                UpdatedAt = UpdatedAt
            };

        public override ValidationViewModel IsValid()
        {
            var resultMessages = new List<string>();
            if (string.IsNullOrEmpty(Title))
                resultMessages.Add(Utils.Properties.Resources.TitleIsRequired);

            if (Episode == null || Episode <= 0)
                resultMessages.Add(Utils.Properties.Resources.EpisodeIsRequired);

            if (string.IsNullOrEmpty(OpeningCrawl))
                resultMessages.Add(Utils.Properties.Resources.OpeningCrawlIsRequired);

            if (string.IsNullOrEmpty(Director))
                resultMessages.Add(Utils.Properties.Resources.DirectorIsRequired);

            if (string.IsNullOrEmpty(Producer))
                resultMessages.Add(Utils.Properties.Resources.ProducerIsRequired);

            if (ReleaseDate == null)
                resultMessages.Add(Utils.Properties.Resources.ReleaseDateIsRequired);

            return resultMessages.Any() ?
                ValidationViewModel.Create(ValidationModelResult.Warning, resultMessages.ToArray()) :
                ValidationViewModel.Create(ValidationModelResult.Success);
        }
    }
}
