using Limxc.Arch.Core.Shared.Interfaces;

namespace Limxc.Arch.UI.MAUIBlazor.Service
{
    public class TTSService : ITTSService
    {
        private SpeechOptions _speechOptions;
        public TTSService()
        {
            //_speechOptions = new SpeechOptions();

            //TextToSpeech.Default.GetLocalesAsync()
            //    .ContinueWith(async t =>
            //    {
            //        var locals = await t;
            //        var local = locals.FirstOrDefault(l => l.Language.StartsWith("zh"));
            //        _speechOptions = new SpeechOptions
            //        {
            //            Volume = 1.0f,
            //            Pitch = 1.0f,
            //            Locale = local
            //        };
            //    });

        }

        public async Task Speak(string text)
        {
            try
            {
                var locals = await TextToSpeech.Default.GetLocalesAsync();

                var local = locals.FirstOrDefault(l => l.Language.StartsWith("zh"));
                var speechOptions = new SpeechOptions
                {
                    Volume = 1.0f,
                    Pitch = 1.0f,
                    Locale = local
                };
                await TextToSpeech.Default.SpeakAsync(text, speechOptions);
            }
            catch (Exception e)
            {

            }
        }
    }
}
