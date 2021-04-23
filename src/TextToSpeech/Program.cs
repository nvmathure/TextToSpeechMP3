
//#define EXPORT

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;


namespace TextToSpeech
{
    class Program
    {
        static async Task Main()
        {
            await SynthesizeAudioAsync();
        }

        static async Task SynthesizeAudioAsync()
        {
            var config = SpeechConfig.FromEndpoint(
                new Uri("https://eastus.api.cognitive.microsoft.com/sts/v1.0/issuetoken"),
                "ee7e8304193c464f82dc7e5af674eabb");

            config.SetProperty("SpeechServiceResponse_Synthesis_WordBoundaryEnabled", "false");

            //using var audioConfig = AudioConfig.FromWavFileOutput("file.wav");
            //using var synthesizer = new SpeechSynthesizer(config, audioConfig);
            var fileName = "Message.xml";
            var outputFileName = "01-AzureServerless-Intro.mp3";

#if EXPORT
            config.SetSpeechSynthesisOutputFormat(SpeechSynthesisOutputFormat.Audio24Khz160KBitRateMonoMp3);
            using var synthesizer = new SpeechSynthesizer(config, null);
            var ssml = File.ReadAllText(fileName);
            var result = await synthesizer.SpeakSsmlAsync(ssml);
            using var stream = AudioDataStream.FromResult(result);
            await stream.SaveToWaveFileAsync(outputFileName);

#else
            using var synthesizer = new SpeechSynthesizer(config);
            var ssml = File.ReadAllText(fileName);
            await synthesizer.SpeakSsmlAsync(ssml);
       
#endif

        }
    }
}
