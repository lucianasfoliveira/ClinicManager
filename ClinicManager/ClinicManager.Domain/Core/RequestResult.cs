namespace ClinicManager.Domain.Core
{
    public class RequestResult
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public static RequestResult Ok() => new RequestResult { Sucesso = true };
        public static RequestResult Erro(string msg) => new RequestResult { Sucesso = false, Mensagem = msg };
    }
}
