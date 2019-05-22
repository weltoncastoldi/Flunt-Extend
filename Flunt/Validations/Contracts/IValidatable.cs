namespace FluntExtendBr.Validations
{
    public interface IValidatable
    {
        void Validate();
        bool Validate(string value);
    }
}