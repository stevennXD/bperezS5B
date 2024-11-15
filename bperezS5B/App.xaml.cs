using bperezS5B.Models;

namespace bperezS5B
{
    public partial class App : Application
    {
        public static PersonaRepository personaRepo { get; set; }
        public App(PersonaRepository personaRepository)
        {
            InitializeComponent();

            MainPage = new Views.vPersona();
            personaRepo = personaRepository;
        }
    }
}
