namespace Advanced.Events
{
    public class VideoEncoder
    {
        public delegate void VideoEncodedEventHandler(object source, VideoEncoderEventArgs args);
        public event VideoEncodedEventHandler VideoEncoded;
        public void Encode(Video video) => OnVideoEncoded(video);
        protected virtual void OnVideoEncoded(Video video) => VideoEncoded?.Invoke(this, new VideoEncoderEventArgs { Video = video });
    }
}
