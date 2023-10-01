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
        }
    }
}
