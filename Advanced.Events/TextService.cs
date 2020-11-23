namespace Advanced.Events
{
    public class TextService
    {
        public void OnVideoEncoded(object source, VideoEncoderEventArgs args) 
        { 
            var x = args.Video?.Title; 
        }
    }
}
