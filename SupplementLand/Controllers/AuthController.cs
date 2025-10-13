using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SupplementLand.Application.Dtos;
using SupplementLand.Application.Interfaces;
using SupplementLand.Domain.Entities;
using SupplementLand.Infrastructure.Services;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SupplementLand.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;
    private readonly IPasswordHasher<User> _passwordHasher;

    public AuthController(IUserService userService, IConfiguration configuration,IPasswordHasher<User> passwordHasher)
    {
        _userService = userService;
        _configuration = configuration;
        _passwordHasher = passwordHasher;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(UserDto userDto)
    {
        var result = await _userService.AddUser(userDto);
        if (!result.Success) return BadRequest(result.Message);

        return Ok(result.Message);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginDto login)
    {
        var user = await _userService.GetUserByMobile(login.Mobile);
        if (user == null) return BadRequest("Invalid credentials");

        var passwordHasher = new PasswordHasher<User>();
        var result = passwordHasher.VerifyHashedPassword(user, user.Password, login.Password);
        if (result == PasswordVerificationResult.Failed)
            return BadRequest("Password is incorrect");

        var accessToken = GenerateToken(user);
        var refreshToken = GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        await _userService.UpdateUser(new UpdateDto
        {
            Id = user.Id,
            FullName = user.FullName,
            Mobile = user.Mobile,
            Email = user.Email,
            Password = user.Password,
            ConfirmPassword = user.Password,
        });

        // ذخیره توکن‌ها در کوکی HttpOnly
        Response.Cookies.Append("access_token", accessToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true, // فقط روی HTTPS
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddHours(1)
        });

        Response.Cookies.Append("refresh_token", refreshToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddDays(7)
        });

        return Ok(new { message = "Login successful" });
    }

    [HttpPost("RefreshToken")]
    public async Task<IActionResult> RefreshToken()
    {
        var refreshToken = Request.Cookies["refresh_token"];
        if (string.IsNullOrEmpty(refreshToken))
            return Unauthorized("Refresh token missing");

        var user = await _userService.GetUserByRefreshToken(refreshToken);
        if (user == null || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            return Unauthorized("Invalid refresh token");

        var newAccessToken = GenerateToken(user);
        var newRefreshToken = GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        await _userService.UpdateUser(new UpdateDto
        {
            Id = user.Id,
            FullName = user.FullName,
            Mobile = user.Mobile,
            Email = user.Email,
            Password = user.Password,
            ConfirmPassword = user.Password,
        });

        // به‌روزرسانی کوکی‌ها
        Response.Cookies.Append("access_token", newAccessToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddHours(1)
        });

        Response.Cookies.Append("refresh_token", newRefreshToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddDays(7)
        });

        return Ok(new { message = "Token refreshed successfully" });
    }


    [HttpPost("Logout")]
    [Authorize]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("access_token");
        Response.Cookies.Delete("refresh_token");

        return Ok(new { message = "Logged out successfully" });
    }

    [HttpPost("ForgetPassword")]
    public async Task<IActionResult> ForgetPassword(ForgetPasswordDto dto)
    {
        var user = await _userService.GetUserByMobile(dto.Mobile);
        if (user == null) return NotFound("User doesn't exist");

        await _userService.UpdateUser(new UpdateDto
        {
            Id = user.Id,
            FullName = user.FullName,
            Mobile = user.Mobile,
            Email = user.Email,
            Password =_passwordHasher.HashPassword(user,dto.Password),
            ConfirmPassword = dto.ConfirmPassword
        });

        return Ok("Password reset successfully");
    }
    [HttpGet("GetUserProfile/{userId}")]
    [Authorize]
    public async Task<IActionResult> GetUserProfile(int userId)
    {
        var user=await _userService.GetUserProfile(userId);
        return Ok(user);
    }

    private string GenerateToken(User user)
    {
        var claims = new[]
        {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.FullName),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.Role, user.Role)
    };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}
