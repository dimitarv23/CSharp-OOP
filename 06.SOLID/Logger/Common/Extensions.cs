﻿using Logger.Appenders.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Common
{
    public static class Extensions
    {
        public static void AddRange(this ICollection<IAppender> appenders, IEnumerable<IAppender> appendersToAdd)
        {
            foreach (var appender in appendersToAdd)
            {
                appenders.Add(appender);
            }
        }

        public static IReadOnlyCollection<IAppender> AsReadOnly(this ICollection<IAppender> appenders)
            => (IReadOnlyCollection<IAppender>)appenders;
    }
}
