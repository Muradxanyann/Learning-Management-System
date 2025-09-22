using Application.DTOs.AuthenticationDto;
using Domain.Entities;

namespace Application.Interfaces;

public interface ITokenService
{
    Task<AuthResponseDto> CreateTokenAsync(ApplicationUser user);
}