namespace _5363922APICHATgpt
{
    public partial class MainPage : ContentPage
    {
        private readonly ServicioOpenI _openAIService;
        public MainPage()
        {
            InitializeComponent();


            // Obtener la clave API de OpenAI desde una variable de entorno o configuración
            string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new InvalidOperationException("API Key de OpenAI no configurada.");
            }

            _openAIService = new ServicioOpenI(apiKey);
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
             
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                string userInput = userInputEntry.Text;
                string response = await _openAIService.GetChatCompletionAsync(userInput);
                responseLabel.Text = response;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }

}
