namespace Advanced.Events
{
    public class MailService
    {
        public void OnVideoEncoded(object source, VideoEncoderEventArgs args)
        {
            var x = args.Video?.Title;
        }
    }
}
