// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using HygieiaApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HygieiaApp.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AdminService _adminService;
        private readonly SignInManager<IdentityUser> _signInManager;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            AdminService adminService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _adminService = adminService;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
      

        
        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            public string FirstName { get; set; }
            public string Username { get; set; }
            public string LastName { get; set; }
            [Display(Name = "Date of birth")]
            public DateTime DateOfBirth { get; set; }
            [EmailAddress]
            public string Email { get; set; }
        }

        private async Task LoadAsync(IdentityUser user)
        {
            if (_userManager != null)
            {
                var userName = await _userManager.GetUserNameAsync(user);
                var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
                var appUser = _adminService.GetUserById(user.Id);

                

                Input = new InputModel
                {
                    PhoneNumber = phoneNumber,
                    Username = appUser.UserName,
                    FirstName = appUser.FirstName,
                    LastName = appUser.LastName,
                    DateOfBirth = appUser.DateOfBirth,
                    Email = appUser.Email
                };
            }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            var appUser = _adminService.GetUserById(user.Id);
            appUser.FirstName = Input.FirstName;
            appUser.LastName = Input.LastName;
            appUser.DateOfBirth = Input.DateOfBirth;
            appUser.Email = Input.Email;
            appUser.UserName = Input.Username;
            appUser.NormalizedUserName = appUser.UserName.ToUpper();
            _adminService.UpdateUser(appUser);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
