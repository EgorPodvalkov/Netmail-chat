﻿using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IArticleService
    {
        Task<IEnumerable<ArticleDTO>> GetArticlesWithEditorsAsync(int skip = 0, int? take = null);
        Task<int> GetArticlesAmountAsync();
        Task AddArticleAsync(ArticleDTO dto);
    }
}
