using jCoreDemoApp.Application.Common.Interfaces;
using System;

namespace jCoreDemoApp.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
