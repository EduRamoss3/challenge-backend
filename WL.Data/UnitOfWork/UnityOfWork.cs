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

        public IUser UserRepository { get { return _userRepository = _userRepository ?? new UserRepository(); } }
        public ITransfer TransferRepository { get { return _clientRepository = _clientRepository ?? new ClientRepository(_context); } }
        public IWallet SchedulesRepository { get { return _schedulesRepository = _schedulesRepository ?? new SchedulesRepository(_context); } }

        public IWallet WalletRepository => throw new NotImplementedException();

        public ITransfer TransferRepository => throw new NotImplementedException();

        public IUser UserRepository => throw new NotImplementedException();
    }
}
