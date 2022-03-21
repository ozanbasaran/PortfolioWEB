namespace PortfolioWeb.Data
{
    public interface IValidableEntity
    {
        public bool IsValid=> Validate();
        public abstract bool Validate(); 
    }
}
