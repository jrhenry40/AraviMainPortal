using AraviPortal.Backend.UnitsOfWork.Interfaces;
using AraviPortal.Shared.Entities;
using AraviPortal.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace AraviPortal.Backend.Data;

public class SeedDb
{
    private readonly DataContext _context;
    private readonly IUsersUnitOfWork _usersUnitOfWork;

    public SeedDb(DataContext context, IUsersUnitOfWork usersUnitOfWork)
    {
        _context = context;
        _usersUnitOfWork = usersUnitOfWork;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckCitiesAsync();
        await CheckHangarsAsync();
        await CheckRolesAsync();
        await CheckUsersAsync();
    }

    private async Task CheckUsersAsync()
    {
        await CheckUserAsync("Guardian", "IT", "aravi-itsoftware@amentum.com", "3108608778", UserType.Superadmin);
        await CheckUserAsync("Henry", "Rios", "henry.rios@amentum.com", "3213470465", UserType.Superadmin);
        await CheckUserAsync("Adriana", "Reyes", "adriana.reyes@amentum.com", "3108595190", UserType.Superadmin);
    }

    private async Task<User> CheckUserAsync(string firstName, string lastName, string email, string phone, UserType userType)
    {
        var user = await _usersUnitOfWork.GetUserAsync(email);
        if (user == null)
        {
            var city = await _context.Cities.FirstOrDefaultAsync(x => x.Name == "Bogotá");
            user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserName = email,
                PhoneNumber = phone,
                City = city!,
                UserType = userType
            };

            await _usersUnitOfWork.AddUserAsync(user, "123456");
            await _usersUnitOfWork.AddUserToRoleAsync(user, userType.ToString());

            var token = await _usersUnitOfWork.GenerateEmailConfirmationTokenAsync(user);
            await _usersUnitOfWork.ConfirmEmailAsync(user, token);
        }

        return user;
    }

    private async Task CheckRolesAsync()
    {
        await _usersUnitOfWork.CheckRoleAsync(UserType.Superadmin.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.Admin.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.User.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.Course_Admin.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.Course_Student.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.Course_Consultant.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.SIS_Admin.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.SIS_Report.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.SIS_CustomerServices.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.SIS_Repairables.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.SRAA_Admin.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.SRAA_ConsultantUser.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.SRAA_DataEntry.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.Inventory_Admin.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.Inventory_Custodians.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.Inventory_InventoryClerks.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.Inventory_ITMaintenanceTeam.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.Course_Student_SIS_Admin.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.Course_Student_SIS_Report.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.Course_Student_SIS_CustomerServices.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.Course_Student_SIS_Repairables.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.Course_Student_SRAA_Admin.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.Course_Student_SRAA_ConsultantUser.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.Course_Student_SRAA_DataEntry.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.Course_Student_Inventory_Admin.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.Course_Student_Inventory_Custodians.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.Course_Student_Inventory_InventoryClerks.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.Course_Student_Inventory_ITMaintenanceTeam.ToString());
    }

    private async Task CheckCitiesAsync()
    {
        if (!_context.Cities.Any())
        {
            var citiesSQLScript = File.ReadAllText("Data\\Cities.sql");
            await _context.Database.ExecuteSqlRawAsync(citiesSQLScript);
        }
    }

    private async Task CheckHangarsAsync()
    {
        if (!_context.Hangars.Any())
        {
            foreach (var city in _context.Cities)
            {
                if (city.Name == "Bogotá")
                {
                    _context.Hangars.Add(new Hangar { Name = "GYM H1", City = city! });
                    _context.Hangars.Add(new Hangar { Name = "GYM H2", City = city! });
                    _context.Hangars.Add(new Hangar { Name = "GYM H3", City = city! });
                }
                else if (city.Name == "Tuluá")
                {
                    _context.Hangars.Add(new Hangar { Name = "TUL H1", City = city! });
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}