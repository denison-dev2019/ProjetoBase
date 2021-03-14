using System;

namespace Dominio.Interfaces.Contextos
{
    public interface IContexto : IDisposable
    {

        #region Transação
        /// <summary>
        /// Inicializa a transação.
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Commita uma transação
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// Confirmar transação corrente.
        /// </summary>
        int SaveChanges();

        /// <summary>
        /// Desfazer transação corrente.
        /// </summary>
        void Rollback();


        #endregion

    }
}
