using System.Collections.Generic;

namespace Logger.Appenders.Contracts
{
    public interface IAppenderCollection
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void AddAppender(IAppender appender);
        bool RemoveAppender(IAppender appender);
        void Clear();
    }
}
