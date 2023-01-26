using MediatR;


namespace DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public DateTime Birthdate { get; private set; }
    }
}
