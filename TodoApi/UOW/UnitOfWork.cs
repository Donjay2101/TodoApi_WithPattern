using System;
using System.Collections.Generic;
using System.Diagnostics;
using TodoApi.Entities;
using TodoApi.Repositories;
using TodoApi.Repositories.Interfaces;

namespace TodoApi.UOW
{
    public class UnitOfWork :IUnitOfWork
    {
        #region Private member variables...

        private AppDBcontext _context = null;
        private IRepository<Todo> _todoRepository;
        private IRepository<User> _userRepository;
        private IRepository<Role> _roleRepository;
        private IRepository<UserInRole> _userInRoleRepository;
        //private GenericRepository<User> _userRepository;
        //private GenericRepository<Product> _productRepository;
        //private GenericRepository<Token> _tokenRepository;
        #endregion

        public UnitOfWork(AppDBcontext context)
        {
            _context = context;
        }

        #region Public Repository Creation properties...

        public IRepository<Todo>  TodoRepository
        {
            get
            {
                if (this._todoRepository== null)
                    this._todoRepository = new TodoRepository<Todo>(_context);
                return _todoRepository;
            }
        }

        public IRepository<User> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                    this._userRepository = new UserRepository<User>(_context);
                return _userRepository;
            }
        }

        public IRepository<Role> RoleRepository
        {
            get
            {
                if (this._roleRepository == null)
                    this._roleRepository = new TodoRepository<Role>(_context);
                return _roleRepository;
            }
        }

        public IRepository<UserInRole> UserInRoleRepository
        {
            get
            {
                if (this._userInRoleRepository == null)
                    this._userInRoleRepository = new TodoRepository<UserInRole>(_context);
                return _userInRoleRepository;
            }
        }

        ///// <summary>
        ///// Get/Set Property for product repository.
        ///// </summary>
        //public GenericRepository<Product> ProductRepository
        //{
        //    get
        //    {
        //        if (this._productRepository == null)
        //            this._productRepository = new GenericRepository<Product>(_context);
        //        return _productRepository;
        //    }
        //}

        ///// <summary>
        ///// Get/Set Property for user repository.
        ///// </summary>
        //public GenericRepository<User> UserRepository
        //{
        //    get
        //    {
        //        if (this._userRepository == null)
        //            this._userRepository = new GenericRepository<User>(_context);
        //        return _userRepository;
        //    }
        //}

        ///// <summary>
        ///// Get/Set Property for token repository.
        ///// </summary>
        //public GenericRepository<Token> TokenRepository
        //{
        //    get
        //    {
        //        if (this._tokenRepository == null)
        //            this._tokenRepository = new GenericRepository<Token>(_context);
        //        return _tokenRepository;
        //    }
        //}
        #endregion

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                var outputLines = new List<string>();
                outputLines.Add(e.Message);
                outputLines.Add(e.InnerException.Message);
                //foreach(var ex in e.InnerException)
                //{

                //}
                //foreach (var eve in e.EntityValidationErrors)
                //{
                //    outputLines.Add(string.Format(
                //        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                //        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                //    foreach (var ve in eve.ValidationErrors)
                //    {
                //        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                //    }
                //}
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}


