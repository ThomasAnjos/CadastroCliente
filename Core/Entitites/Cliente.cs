namespace Core.Entitites
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public string ClienteEmail { get; set; }
        public byte[] ClienteLogotipo { get; set; }
        public string ClienteLogradouro { get; set; }
    }
}
