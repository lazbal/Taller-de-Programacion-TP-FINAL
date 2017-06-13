using System;
using System.Linq;
using System.Data.Entity;

namespace CapaDatos
{
    /// <summary>
    /// Clase de Repositorio Genéricos para los elementos del contexto.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class RepositorioGenerico<TEntity> where TEntity : class
    {
		#region Datos
        internal CapaDatosContexto context;
        internal DbSet<TEntity> dbSet;
		#endregion
		#region Constructores
		/// <summary>
		/// Inicializa una instancia de la clase <see cref="CapaDatos.RepositorioGenerico`1"/>.
		/// </summary>
		/// <param name="pContexto">Contexto.</param>
		public RepositorioGenerico(CapaDatosContexto pContexto)
		{
			this.context = pContexto;
			this.dbSet = context.Set<TEntity>();
		}
		#endregion
		#region Propiedades
        /// <summary>
        /// Devuelve el repositorio como <typeparamref name="IQueryable"/>.
        /// </summary>
		public IQueryable<TEntity> Queryable
        {
            get
            {
				return dbSet;
            }
        }
		#endregion
		#region Métodos
        /// <summary>
        /// Obtener un elemento de la base de datos por su Id.
        /// </summary>
        /// <param name="id">Id del objeto a devolver.</param>
        /// <returns></returns>
		public virtual TEntity GetByID(object id)
		{
			return this.dbSet.Find(id);
        }

        /// <summary>
        /// Insertar un elemento a la base de datos.
        /// </summary>
        /// <param name="entity">Elemento a insertar</param>
        public void Insert(TEntity entity)
		{
            this.dbSet.Add(entity);
		}

		/// <summary>
		/// Eliminar un elemento de la base de datos.
		/// </summary>
		/// <param name="entityToDelete">elemento a eliminar.</param>
		public void Delete(TEntity entityToDelete)
		{
			//Adjunta la entrada y luego la elimina. 
			if (context.Entry (entityToDelete).State != EntityState.Detached) {
				context.Entry (entityToDelete).State = EntityState.Deleted;
			} 
			else {
				dbSet.Attach (entityToDelete);
				dbSet.Remove (entityToDelete);
			}
		}

        /// <summary>
        /// Método para eliminar un elemento de la base de datos.
        /// </summary>
        /// <param name="id">ID del elemento a eliminar.</param>
        public void Delete(object id)
        {
            //Obtiene el elemento e invoca al otro delete.
            TEntity entityToDelete = dbSet.Find(id);
			if (entityToDelete != null) {
				this.Delete(entityToDelete);
			}
        }

        /// <summary>
        /// Método para actualizar un elemento de la base de datos.
        /// </summary>
        /// <param name="entityToUpdate">Elemento actualizado.</param>
        public void Update(TEntity entityToUpdate)
        {
            //Adjunta la entrada y luego la establece como modificada para que se modifique posteriormente.
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
		#endregion
    }
}
