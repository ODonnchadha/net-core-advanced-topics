using Advanced.Events;
using NUnit.Framework;

namespace NUnitTest.Delegates
{
    public class EventsShould
    {
        VideoEncoder publisher;
        MailService subscriber1;
        TextService subscriber2;

        [SetUp()]
        public void Setup()
        {
            this.publisher = new VideoEncoder { };
            this.subscriber1 = new MailService { };
            this.subscriber2 = new TextService { };
        }

        [Test()]
        public void PublishSubscribe()
        {
            publisher.VideoEncoded += subscriber1.OnVideoEncoded;
            publisher.VideoEncoded += subscriber2.OnVideoEncoded;

            publisher.Encode(new Video { Title = "Jaws 3D" });
        }
    }
}
