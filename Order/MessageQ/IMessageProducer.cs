namespace OrderCase.MessageQ
{
    public interface IMessageProducer
    {
        void SendMessage<T> (T message);
    }
}