namespace MyGame.Domain.Hello
{
    public class Name
    {
        public readonly string Text;
        public readonly bool IsValid;

        public Name(string text)
        {
            if (string.IsNullOrWhiteSpace(text) || text.Length > 10)
            {
                IsValid = false;
                return;
            }
            
            IsValid = true;
            Text = text;
        }
    }
}
