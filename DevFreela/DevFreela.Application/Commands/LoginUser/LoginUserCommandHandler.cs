using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository userRepository;

        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            this.userRepository = userRepository;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var hashPassword = _authService.ComputeSha256Hash(request.Password);
            var user = await userRepository.GetByEmailAndPasswordAsync(request.Email, hashPassword);

            if (user == null) return null;

            var loginUserViewModel = new LoginUserViewModel(request.Email, _authService.GenerateJwtToken(request.Email, user.Role));

            return loginUserViewModel;
        }
    }
}
