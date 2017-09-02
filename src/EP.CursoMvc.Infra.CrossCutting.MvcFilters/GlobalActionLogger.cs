using System.Web.Mvc;

namespace EP.CursoMvc.Infra.CrossCutting.MvcFilters
{
    public class GlobalActionLogger : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // Log de Auditoria
            // Usuario, Acao, IP, Maquina

            if (filterContext.Exception != null)
            {
                // Manipular a EX
                // Injetar alguma LIB de tratamento de erro
                //  -> Gravar log do erro no BD
                //  -> Email para o admin
                //  -> Retornar cod de erro amigavel

                // Log4net
                // Elmah.IO
                // Custom Logger

                filterContext.ExceptionHandled = true;
                filterContext.Result = new HttpStatusCodeResult(500);
            }

            base.OnActionExecuted(filterContext);
        }
    }
}