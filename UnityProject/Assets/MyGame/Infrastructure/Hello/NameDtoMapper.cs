using MyGame.Domain.Hello;

namespace MyGame.Infrastructure.Hello
{
    public static class NameDtoMapper
    {
        public static NameDto ToDto(this Name name) => new() { Text = name.Text };
    }
}