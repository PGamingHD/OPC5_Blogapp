using Blazored.SessionStorage;
using Microsoft.EntityFrameworkCore;
using OPC5_Blogapp.Components;
using OPC5_Blogapp.Data;
using Services.Posts;
using Services.Tags;
using Services.Users;

namespace OPC5_Blogapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var connectionString = builder.Configuration.GetConnectionString("ConnectionString") ?? throw new InvalidOperationException("Connection string 'ConnectionString' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>((DbContextOptionsBuilder options) =>
                options.UseMySQL(connectionString));

            builder.Services.AddBlazoredSessionStorage();

            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IPostService, PostService>();
            builder.Services.AddTransient<ICommentService, CommentService>();
            builder.Services.AddTransient<ITagService, TagService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
