namespace APICatalogo.Services
{
    public class MeuServico : IMeuServico
    {
        public string Saudacao(string nome)
        {
            string dt = DateTime.Now.ToString("HH:mm");

            return $"Bem-vindo, {nome} \n{dt}";
        }
    }
}
