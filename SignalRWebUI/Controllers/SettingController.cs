﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDto;

namespace SignalRWebUI.Controllers
{
    public class SettingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public SettingController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity?.Name);
            UserEditDto userEditDto = new UserEditDto();
            userEditDto.SurName = values.SurName;
            userEditDto.Name = values.Name;
            userEditDto.UserName = values.UserName;
            userEditDto.Mail = values.Email;
            return View(userEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditDto userEditDto)
        {
            if(userEditDto.Password == userEditDto.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity?.Name);
                user.Name = userEditDto.Name;
                user.SurName = userEditDto.SurName;
                user.Email = userEditDto.Mail;
                user.UserName = userEditDto.UserName;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user,userEditDto.Password);
                await _userManager.UpdateAsync(user);
                return  RedirectToAction("Index","Login");
            }
            return View();
        }
    }
}
