using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.UoW;

namespace BLL.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IMapper _mapper;
        private readonly IUoW _uow;
        private readonly IArticleRepository _repo;

        public ArticleService(IUoW uow, IMapper mapper)
        {
            _mapper = mapper;
            _uow = uow;
            _repo = uow.GetArtileRepository();
        }

        public async Task<IEnumerable<ArticleDTO>> GetArticlesWithEditorsAsync(int skip = 0, int? take = null)
        {
            var entities = await _repo.GetArticlesWithEditorsAsync(skip, take);

            return _mapper.Map<IEnumerable<ArticleDTO>>(entities);
        }
        public async Task<int> GetArticlesAmountAsync()
        {
            return await _repo.GetArticlesAmountAsync();
        }

        public async Task AddArticleAsync(ArticleDTO dto)
        {
            var entity = _mapper.Map<Article>(dto);

            await _repo.AddAsync(entity);
            await _uow.SaveAsync();
        }
    }
}
