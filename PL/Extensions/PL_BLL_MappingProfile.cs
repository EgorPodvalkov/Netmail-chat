﻿using AutoMapper;
using BLL.DTOs;
using PL.Models;

namespace PL.Extensions
{
    public class PL_BLL_MappingProfile : Profile
    {
        public PL_BLL_MappingProfile()
        {
            #region ChatMessage
            CreateMap<ChatMessageDTO, MessageModel>()
                .ForMember(mod => mod.Text, opt =>
                    opt.MapFrom(dto => dto.Content))
                .ForMember(mod => mod.NickName, opt =>
                    opt.MapFrom(dto => dto.NickName))
                .ForMember(mod => mod.SendTime, opt =>
                    opt.MapFrom(dto => dto.SendTime));
            #endregion

            #region ChatRoom
            CreateMap<ChatRoomDTO, ChatWithMessagesModel>()
                .ForMember(mod => mod.Name, opt =>
                    opt.MapFrom(dto => dto.Name))
                .ForMember(mod => mod.Messages, opt =>
                    opt.MapFrom(dto => dto.Messages));
            #endregion
        }
    }
}
