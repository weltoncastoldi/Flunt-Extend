namespace Flunt.Validations
{
    public interface IValidatable
    {
        void Validate();
        bool Validate(string value);
    }
}