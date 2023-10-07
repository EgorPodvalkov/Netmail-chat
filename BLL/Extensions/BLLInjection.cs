using BLL.Interfaces;
using BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Extensions
{
    public static class BLLInjecting
    {
        public static void InjectBLL(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BLL_DAL_MappingProfile));

            services.AddScoped<IChatMessageService, ChatMessageService>();
            services.AddScoped<IChatRoomService, ChatRoomService>();
            services.AddScoped<IEditorService, EditorService>();
            services.AddScoped<IArticleService, ArticleService>();
        }

    }
}
