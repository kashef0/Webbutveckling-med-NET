
using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace myApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    [ViewData]
    public List<Animal> Animals { get; set; } = [];

    public void OnGet()
    {
        
        Animals =
        [
        new() {
            Name = "Antelope",
            Type = "Mammal",
            Description = "A fast and agile herbivore, known for its graceful leaps.",
            Habitat = "Savannas, grasslands, and open woodlands of Africa."
        },
        new() {
            Name = "Badger",
            Type = "Mammal",
            Description = "A burrowing animal with short legs and a broad body.",
            Habitat = "Woodlands, grasslands, and farmland, primarily in Europe and North America."
        },
        new() {
            Name = "Cat",
            Type = "Mammal",
            Description = "A small carnivorous animal, often kept as a pet.",
            Habitat = "Domestic environments, but wild cats can be found in various regions worldwide."
        },
        new() {
            Name = "Dog",
            Type = "Mammal",
            Description = "A loyal and friendly domesticated carnivore.",
            Habitat = "Homes, but wild dogs can be found in forests, savannas, and grasslands worldwide."
        },
        new() {
            Name = "Eagle",
            Type = "Bird",
            Description = "A large bird of prey with excellent vision and powerful talons.",
            Habitat = "Mountains, cliffs, and large open areas in North America, Europe, and Asia."
        },
        new() {
            Name = "Crocodile",
            Type = "Reptile",
            Description = "A large, predatory reptile with a long body and powerful jaws.",
            Habitat = "Rivers, lakes, and wetlands in Africa, Asia, and the Americas."
        }]
        ;

    }
    

}
