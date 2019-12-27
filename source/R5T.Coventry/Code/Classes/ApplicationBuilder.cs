using System;

using RichmondApplicationBuilder = R5T.Richmond.ApplicationBuilder;


namespace R5T.Coventry
{
    /// <summary>
    /// A type in the <see cref="R5T.Coventry"/> namespace that forwards the <see cref="R5T.Richmond.ApplicationBuilder"/> type.
    /// This avoids an extra using statement for the <see cref="R5T.Richmond"/> namespace.
    /// </summary>
    public static class ApplicationBuilder
    {
        public static RichmondApplicationBuilder New()
        {
            var applicationBuilder = RichmondApplicationBuilder.New();
            return applicationBuilder;
        }
    }
}
