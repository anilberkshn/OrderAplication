namespace Customer.MessageQ
{
    public interface IMessageProducer
    {
        void SendMessage<T> (T message);
    }
}