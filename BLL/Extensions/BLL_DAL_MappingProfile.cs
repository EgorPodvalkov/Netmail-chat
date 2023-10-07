using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL.Extensions
{
    public class BLL_DAL_MappingProfile : Profile
    {
        public BLL_DAL_MappingProfile()
        {
            #region ChatMessage
            CreateMap<ChatMessageDTO, ChatMessage>()
                .ForMember(ent => ent.ID, opt =>
                    opt.MapFrom(dto => dto.ID))
                .ForMember(ent => ent.Content, opt =>
                    opt.MapFrom(dto => dto.Content))
                .ForMember(ent => ent.NickName, opt =>
                    opt.MapFrom(dto => dto.NickName))
                .ForMember(ent => ent.SendTime, opt =>
                    opt.MapFrom(dto => dto.SendTime))
                .ForMember(ent => ent.ChatRoomID, opt =>
                    opt.MapFrom(dto => dto.ChatRoomID))
                .ForMember(ent => ent.ChatRoom, opt =>
                    opt.MapFrom(dto => dto.ChatRoom));

            CreateMap<ChatMessage, ChatMessageDTO>()
                .ForMember(dto => dto.ID, opt =>
                    opt.Ignore())
                .ForMember(dto => dto.Content, opt =>
                    opt.MapFrom(ent => ent.Content))
                .ForMember(dto => dto.NickName, opt =>
                    opt.MapFrom(ent => ent.NickName))
                .ForMember(dto => dto.SendTime, opt =>
                    opt.MapFrom(ent => ent.SendTime))
                .ForMember(dto => dto.ChatRoomID, opt =>
                    opt.MapFrom(ent => ent.ChatRoomID));
            #endregion

            #region ChatRoom
            CreateMap<ChatRoomDTO, ChatRoom>()
                .ForMember(ent => ent.ID, opt =>
                    opt.MapFrom(dto => dto.ID))
                .ForMember(ent => ent.Name, opt =>
                    opt.MapFrom(dto => dto.Name))
                .ForMember(ent => ent.Messages, opt =>
                    opt.MapFrom(dto => dto.Messages));

            CreateMap<ChatRoom, ChatRoomDTO>()
                .ForMember(dto => dto.ID, opt =>
                    opt.Ignore())
                .ForMember(dto => dto.Name, opt =>
                    opt.MapFrom(ent => ent.Name))
                .ForMember(dto => dto.Messages, opt =>
                    opt.MapFrom(ent => ent.Messages));
            #endregion

            #region Editor
            CreateMap<EditorDTO, Editor>()
                .ForMember(ent => ent.ID, opt =>
                    opt.MapFrom(dto => dto.ID))
                .ForMember(ent => ent.Name, opt =>
                    opt.MapFrom(dto => dto.Name));

            CreateMap<Editor, EditorDTO>()
                .ForMember(dto => dto.ID, opt =>
                    opt.Ignore())
                .ForMember(dto => dto.Name, opt =>
                    opt.MapFrom(ent => ent.Name));
            #endregion

            #region Article
            CreateMap<ArticleDTO, Article>()
                .ForMember(ent => ent.ID, opt =>
                    opt.MapFrom(dto => dto.ID))
                .ForMember(ent => ent.Title, opt =>
                    opt.MapFrom(dto => dto.Title))
                .ForMember(ent => ent.Description, opt =>
                    opt.MapFrom(dto => dto.Description))
                .ForMember(ent => ent.SendTime, opt =>
                    opt.MapFrom(dto => dto.SendTime ?? DateTime.Now))
                .ForMember(ent => ent.EditorID, opt =>
                    opt.MapFrom(dto => dto.EditorID))
                .ForMember(ent => ent.Editor, opt =>
                    opt.MapFrom(dto => dto.Editor));

            CreateMap<Article, ArticleDTO>()
                .ForMember(dto => dto.ID, opt =>
                    opt.Ignore())
                .ForMember(dto => dto.Title, opt =>
                    opt.MapFrom(ent => ent.Title))
                .ForMember(dto => dto.Description, opt =>
                    opt.MapFrom(ent => ent.Description))
                .ForMember(dto => dto.SendTime, opt =>
                    opt.MapFrom(ent => ent.SendTime))
                .ForMember(dto => dto.EditorID, opt =>
                    opt.MapFrom(ent => ent.EditorID))
                .ForMember(dto => dto.Editor, opt =>
                    opt.MapFrom(ent => ent.Editor));
            #endregion
        }
    }
}
