﻿namespace HousekeeperApp.Services.Contracts
{
    using System.Threading.Tasks;
    using HousekeeperApp.ViewModels.Users;

    public interface IUsersService
    {
        Task CreateHousekeeperAsync(CreateHousekeeperViewModel model);

        Task<UserViewModel> GetUserByIdAsync(string id);

        Task<UsersViewModel> GetUsersAsync(int page = 1, int count = 10);

        Task DeleteUserByIdAsync(string id);

        Task<EditUserViewModel> GetUserToEditByIdAsync(string id);

        Task UpdateUserAsync(EditUserViewModel model);
    }
}