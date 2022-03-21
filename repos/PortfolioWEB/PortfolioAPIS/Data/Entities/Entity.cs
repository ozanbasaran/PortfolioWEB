using System;

namespace PortfolioWeb.Data
{
    public abstract class Entity: IDifferenceableEntity, IValidableEntity
    {
        public DateTime CreatedDate { get;  set; }

        

        public TimeSpan Difference()
        {
            return DateTime.Now - CreatedDate;
        }
        public bool IsValid => Validate();
        public abstract bool Validate();

    }
}
