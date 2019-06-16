using log4net;
using System;
using System.Data.Entity.Validation;

namespace Arch.Infra.Common.Logging
{
    public static class Log
    {
        private static readonly ILog log = LogManager.GetLogger("LogInFile");

        public static void LogException(this Exception exception)
        {
            log.Error(exception.Message, exception);
        }

        public static void LogException(this DbEntityValidationException exception)
        {
            string errorFormat = "EntityValidationErrors: Entity: {0} - PropertyName: {1} - ErrorMessage: {2}";

            foreach (var e in exception.EntityValidationErrors)
            {
                foreach (var ve in e.ValidationErrors)
                    log.ErrorFormat(errorFormat, e.Entry.Entity.GetType().FullName, ve.PropertyName, ve.ErrorMessage);
            }
        }

        public static void LogMessage(string message)
        {
            log.Info(message);
        }
    }
}