using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.Models;

namespace PL.Controllers
{
    public class StatController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IChatMessageService _chatMessageBS;
        private readonly IChatRoomService _chatRoomBS;

        public StatController(
            IMapper mapper,
            IChatRoomService chatRoomBS,
            IChatMessageService chatMessageBS)
        {
            _mapper = mapper;
            _chatMessageBS = chatMessageBS;
            _chatRoomBS = chatRoomBS;
        }

        [HttpGet]
        public async Task<IActionResult> Chat()
        {
            var stat = new ChatStatModel
            {
                ChatMessagesAmount = await _chatMessageBS.GetAmountAsync(),
                ChatRoomsAmount = await _chatRoomBS.GetAmountAsync()
            };

            return View(stat);
        }

        [HttpGet("/GetStat")]
        public async Task<IActionResult> GetStat()
        {
            var stat = new ChatStatModel
            {
                ChatMessagesAmount = await _chatMessageBS.GetAmountAsync(),
                ChatRoomsAmount = await _chatRoomBS.GetAmountAsync()
            };

            return Ok(stat);
        }
    }
}
