using DAL.Context;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL.UoW
{
    public class UoW : IUoW
    {
        private readonly NetmailChatDatabaseContext _db;

        private IChatMessageRepository? _messageRepository;
        private IChatRoomRepository? _roomRepository;
        private IEditorRepository? _editorRepository;
        private IArticleRepository? _articleRepository;

        public UoW(NetmailChatDatabaseContext db)
        {
            _db = db;
        }

        public IChatMessageRepository GetChatMessageRepository()
        {
            _messageRepository ??= new ChatMessageRepository(_db);

            return _messageRepository;
        }

        public IChatRoomRepository GetChatRoomRepository()
        {
            _roomRepository ??= new ChatRoomRepository(_db);

            return _roomRepository;
        }

        public IEditorRepository GetEditorRepository()
        {
            _editorRepository ??= new EditorRepository(_db);

            return _editorRepository;
        }

        public IArticleRepository GetArtileRepository()
        {
            _articleRepository ??= new ArticleRepository(_db);

            return _articleRepository;
        }

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
