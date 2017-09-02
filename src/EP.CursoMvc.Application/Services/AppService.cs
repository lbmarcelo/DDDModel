using EP.CursoMvc.Infra.Data.UoW;

namespace EP.CursoMvc.Application.Services
{
    public abstract class AppService
    {
        private readonly IUnitOfWork _uow;

        protected AppService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected void Commit()
        {
            _uow.Commit();
        }
    }
}