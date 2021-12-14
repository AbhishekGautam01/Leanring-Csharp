namespace EventsAndDelegates
{
    public class MailService
    {
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine($"MailService: Sending E-Mail for Video: {e.Video.Title}");
        }
    }
}
