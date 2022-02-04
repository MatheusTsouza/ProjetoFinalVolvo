using System;

namespace ProjetoFinalVolvo
{

    class ConcessionariaException : ApplicationException {

        private string motivo;
        public override string Message { get { return motivo; } }

        public ConcessionariaException(string motivo) {
            this.motivo = motivo;
        }
    }
}