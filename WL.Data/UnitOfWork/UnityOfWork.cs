using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WL.Data.Context;
using WL.Data.Repository;
using WL.Data.Repository.Interfaces;
using WL.Data.UnitOfWork.Interfaces;

namespace WL.Data.UnitOfWork
{
    public class UnityOfWork : IUnityOfWork
    {
        private IUser _userRepository;
        private ITransfer _transferRepository;
        private IWallet _walletRepository;

        public AppDbContext _context;

        public UnityOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IUser UserRepository { get { return _userRepository = _userRepository ?? new UserRepository(_context); } }
        public ITransfer TransferRepository { get { return _transferRepository = _transferRepository ?? new TransferRepository(_context); } }
        public IWallet WalletRepository { get { return _walletRepository = _walletRepository ?? new WalletRepository(_context); } }

    }
}
