using Logger.Layouts.Contracts;
using Logger.Messages.Contracts;

namespace Logger.Appenders.Contracts
{
    public interface IAppender
    {
        int Count { get; }
        ILayout Layout { get; }

        void Append(IMessage message);
    }
}
