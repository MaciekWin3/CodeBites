namespace API.Repo
{
    public abstract class BaseRepository
    {
        protected readonly DataContext context;
        public BaseRepository(DataContext context)
        {
            this.context = context;
        }
    }
}
