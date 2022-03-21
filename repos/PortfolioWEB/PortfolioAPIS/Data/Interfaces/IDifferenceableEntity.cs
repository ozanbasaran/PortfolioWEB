using System;

namespace PortfolioWeb.Data
{
    public interface IDifferenceableEntity
    {
        public TimeSpan Difference();
    }
}
