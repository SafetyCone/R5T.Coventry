using System;

using Microsoft.Extensions.Logging;

using CoventryApplicationStartupBase = R5T.Coventry.ApplicationStartupBase;


namespace R5T.Coventry.Construction
{
    public class Startup : CoventryApplicationStartupBase
    {
        public Startup(ILogger<Startup> logger)
            : base(logger)
        {
        }
    }
}
