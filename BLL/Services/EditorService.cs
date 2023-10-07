using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.UoW;

namespace BLL.Services
{
    public class EditorService : IEditorService
    {
        private readonly IMapper _mapper;
        private readonly IUoW _uow;
        private readonly IEditorRepository _repo;

        public EditorService(IUoW uow, IMapper mapper)
        {
            _mapper = mapper;
            _uow = uow;
            _repo = uow.GetEditorRepository();
        }

        public async Task<EditorDTO?> GetEditorIDByPassAsync(string pass)
        {
            var entity = await _repo.GetEditorIDByPassAsync(pass);

            return _mapper.Map<EditorDTO>(entity);
        }
    }
}
