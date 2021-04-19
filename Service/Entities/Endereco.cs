using System;

namespace Service.Entities
{
    class Endereco
    {
        private string _cep;
        public string Estado { get; private set; }
        public string Cidade { get; private set; }
        public string Bairro { get; private set; }
        public string Rua { get; private set; }

        public string Cep 
        {
            get { return _cep; }
            set { _cep = value; }
        }

        public Endereco()
        {
        }

        public Endereco(string cep, string estado, string cidade, string bairro, string rua)
        {
            Cep = cep;
            Estado = estado;
            Cidade = cidade;
            Bairro = bairro;
            Rua = rua;
        }

        public void PesquisarCep()
        {
            if (!string.IsNullOrWhiteSpace(this.Cep))
            {
                using (var ws = new WSCorreios.AtendeClienteClient())
                {
                    try
                    {
                        var endereco = ws.consultaCEP(this.Cep.Trim());

                        this.Estado = endereco.uf;
                        this.Bairro = endereco.bairro;
                        this.Cidade = endereco.cidade;
                        this.Rua = endereco.end;
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message + " Insira um cep valido");
                    }
                }
            }
            else
            {
                throw new Exception("Insira um cep valido");
            }
        }
    }
}