﻿using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.Models;

namespace PL.Controllers
{
    public class ChatController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IChatMessageService _chatMessageBS;
        private readonly IChatRoomService _chatRoomBS;

        public ChatController(
            IMapper mapper,
            IChatRoomService chatRoomBS,
            IChatMessageService chatMessageBS
            )
        {
            _mapper = mapper;
            _chatMessageBS = chatMessageBS;
            _chatRoomBS = chatRoomBS;
        }


        [HttpPost("/Send")]
        public async Task<IActionResult> SendMessage()
        {
            const string badJSON = "You need use json (string ChatName, string? NickName, string Content).";
            try
            {
                if (!Request.HasJsonContentType())
                    throw new Exception(badJSON);

                var request = await Request.ReadFromJsonAsync<ChatSendRequestModel>();
                if (request is null
                    || string.IsNullOrEmpty(request.ChatName)
                    || string.IsNullOrEmpty(request.Content))
                    throw new Exception(badJSON);

                var chatID = await _chatRoomBS.GetChatIDByName(request.ChatName);
                await _chatMessageBS.AddMessageAsync(chatID, request.Content, request.NickName);

                var responce = new ChatSendResponceModel
                {
                    Message = $"Your message successfully added to chat '{request.ChatName}' :) ([Hint]: Use /GetHTML or /GetJSON for reading chat)"
                };
                return Ok(responce);
            }
            catch (Exception ex)
            {
                var responce = new ChatSendResponceModel
                {
                    Error = ex.Message
                };
                return Ok(responce);
            }
        }
    }
}