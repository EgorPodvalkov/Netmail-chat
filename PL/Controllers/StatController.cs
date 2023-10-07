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
        private readonly IArticleService _articleBS;

        public StatController(
            IMapper mapper,
            IChatRoomService chatRoomBS,
            IChatMessageService chatMessageBS,
            IArticleService articleBS
            )
        {
            _mapper = mapper;
            _chatMessageBS = chatMessageBS;
            _chatRoomBS = chatRoomBS;
            _articleBS = articleBS;
        }

        private async Task<StatModel> GetStat()
        {
            var stat = new StatModel
            {
                ChatMessagesAmount = await _chatMessageBS.GetAmountAsync(),
                ChatRoomsAmount = await _chatRoomBS.GetAmountAsync(),
                ArticlesAmount = await _articleBS.GetArticlesAmountAsync(),
            };

            return stat;
        }

        [HttpGet]
        public async Task<IActionResult> GetStatHTML()
        {
            var stat = await GetStat();

            return View(stat);
        }

        [HttpGet("/GetStatJSON")]
        public async Task<IActionResult> GetStatJSON()
        {
            var stat = await GetStat();

            return Ok(stat);
        }
    }
}
